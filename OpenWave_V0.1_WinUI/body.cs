using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;

namespace OpenWave_V0._1_WinUI
{
    public partial class body : Form
    {

        public string Title => "Data Streamer";
        public string Description => "Plots live streaming data as a fixed-width line plot, " +
            "shifting old data out as new data comes in.";

        readonly System.Windows.Forms.Timer AddNewDataTimer = new System.Windows.Forms.Timer() { Interval = 10, Enabled = true };
        readonly System.Windows.Forms.Timer UpdatePlotTimer = new System.Windows.Forms.Timer() { Interval = 50, Enabled = true };

        readonly ScottPlot.Plottables.DataStreamer Streamer1;

        readonly ScottPlot.DataGenerators.RandomWalker Walker1 = new ScottPlot.DataGenerators.RandomWalker(0);

        public body()
        {
            InitializeComponent();

            Streamer1 = formsPlot1.Plot.Add.DataStreamer(1024*TotalBlock);

            Streamer1.LineColor = Colors.DarkRed;

            formsPlot1.UserInputProcessor.Enable();
            
            UpdatePlotTimer.Tick += (s, e) =>
            {
                if (Streamer1.HasNewData)
                {
                    formsPlot1.Plot.Title($"Processed {Streamer1.Data.CountTotal:N0} points");
                    formsPlot1.Refresh();
                }
            };
            
            Streamer1.ViewScrollLeft();

            rbManage.CheckedChanged += (sender, e) =>
            {
                RadioButton rb = sender as RadioButton;
                if (rb != null && rb.Checked)
                {
                    formsPlot1.Plot.Axes.ContinuouslyAutoscale = false;
                    Streamer1.ManageAxisLimits = true;
                }
                else
                {
                    formsPlot1.Plot.Axes.ContinuouslyAutoscale = true;
                    Streamer1.ManageAxisLimits = false;
                }
                formsPlot1.Refresh();
            };           
        }

        public int TotalBlock = 5;
        private SerialPort SeriPort = new SerialPort();
        private byte[] buffer;
        private List<byte> tempBuffer = new List<byte>();
        private System.Timers.Timer timeoutTimer;
        private const int TIMEOUT_MS = 40; 

        private void ADCRun_Click(object sender, EventArgs e)
        {
            ADCRun.Enabled = false;
            ADCStop.Enabled = true;
            PortDisconnect.Enabled = false;            
            SeriPort.Write("Start");
            SeriPort.BaseStream.ReadAsync(buffer, 0, buffer.Length);

        }

        private void ADCStop_Click(object sender, EventArgs e)
        {
            ADCRun.Enabled = true;
            ADCStop.Enabled = false;
            PortDisconnect.Enabled = true;
            SeriPort.Write("Stop!");
        }

        private void PortDisconnect_Click(object sender, EventArgs e)
        {
            SeriPort.Close();
            PortDisconnect.Enabled = false;
            PortConnect.Enabled = true;
            ADCRun.Enabled = false;
            ADCStop.Enabled = false;
        }

        private void PortConnect_Click(object sender, EventArgs e)
        {
            if (COMListBox.SelectedItem != null)
            {
                SeriPort.PortName = COMListBox.SelectedItem.ToString();
                SeriPort.BaudRate = 115200;
                buffer = new byte[(TotalBlock * 1024 * 2)];
                SeriPort.ReadBufferSize = buffer.Length;
                SeriPort.DataReceived += SeriPort_DataReceived;

                timeoutTimer = new System.Timers.Timer(TIMEOUT_MS);
                timeoutTimer.AutoReset = false;
                timeoutTimer.Elapsed += TimeoutTimer_Elapsed;

                try
                {
                    SeriPort.Open();
                    TerminalEkran.AppendText("Port açıldı! \n");
                    PortDisconnect.Enabled = true;
                    PortConnect.Enabled = false;
                    ADCRun.Enabled = true;
                }
                catch (Exception ex)
                {
                    TerminalEkran.AppendText("Port açılamadı:\n" + ex.Message + "\n");
                }
            }
        }

        private void SeriPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesAvailable = SeriPort.BytesToRead;
            if (bytesAvailable > 0)
            {
                byte[] readBuffer = new byte[bytesAvailable];
                SeriPort.Read(readBuffer, 0, bytesAvailable);

                tempBuffer.AddRange(readBuffer);

                // Tampon dolduysa
                if (tempBuffer.Count >= buffer.Length)
                {
                    OnBufferFull(tempBuffer.ToArray(), tempBuffer.Count);
                    tempBuffer.Clear();
                }

                timeoutTimer.Stop();
                timeoutTimer.Start();
            }
        }
       

        public bool triggerselected = false;

        private void OnBufferFull(byte[] data, int length)
        {
            this.BeginInvoke((Action)(() =>
            {
                if (triggerselected == true)
                {
                    int sampleCount = length / 2;
                    ushort[] samples16 = new ushort[sampleCount];

                    for (int i = 0, j = 0; i + 1 < length; i += 2, j++)
                    {
                        samples16[j] = BitConverter.ToUInt16(data, i); // little endian
                    }

                    // ushort -> double
                    double[] samples = samples16.Select(s => (double)s).ToArray();

                    // --------- Trigger tabanlı hizalama ---------
                    double triggerLevel = 2048;  // 12-bit ADC için ortalama seviye
                    double hysteresis = 10;    // tetik kararı için küçük tampon
                    bool risingEdge = true;  // yükselen kenar tetik

                    int idx = FindTriggerIndex(samples, triggerLevel, hysteresis, risingEdge);
                    if (idx > 0 && idx < samples.Length)
                    {
                        double[] aligned = new double[samples.Length];
                        Array.Copy(samples, idx, aligned, 0, samples.Length - idx);
                        Array.Copy(samples, 0, aligned, samples.Length - idx, idx);
                        samples = aligned;
                    }

                    // ScottPlot için ekle
                    foreach (var v in samples)
                        Streamer1.Add(v);

                    // FFT ve terminal
                    ComputeFFT(samples);
                }

                else if (triggerselected == false)
                {
                    var sb = new StringBuilder();
                    int sampleCount = length / 2;
                    ushort[] samples16 = new ushort[sampleCount];

                    for (int i = 0, j = 0; i + 1 < length; i += 2, j++)
                    {
                        ushort value = BitConverter.ToUInt16(data, i); // little endian
                        sb.AppendLine(value.ToString());
                        samples16[j] = value;

                        // Grafik için ekle
                        Streamer1.Add(value);
                    }

                    // ushort -> double
                    double[] samples = samples16.Select(s => (double)s).ToArray();

                    // FFT hesapla ve ScottPlot ile çiz
                    ComputeFFT(samples);
                }               

            }));
        }

        // Trigger index bulma fonksiyonu
        private int FindTriggerIndex(double[] x, double level, double hyst, bool rising)
        {
            for (int i = 1; i < x.Length; i++)
            {
                if (rising)
                {
                    bool below = x[i - 1] <= level - hyst;
                    bool above = x[i] >= level + hyst;
                    if (below && above) return i;
                }
                else
                {
                    bool above = x[i - 1] >= level + hyst;
                    bool below = x[i] <= level - hyst;
                    if (above && below) return i;
                }
            }
            return -1; // tetik yok
        }

        private void AppendToTerminalSafe(string text, int maxLines = 1000)
        {
            this.BeginInvoke((Action)(() =>
            {
                // Mevcut satırlar + yeni satırlar
                var allLines = TerminalEkran.Lines.ToList();
                allLines.AddRange(text.Split('\n'));

                // Son maxLines satırı al
                if (allLines.Count > maxLines)
                {
                    allLines = allLines.Skip(allLines.Count - maxLines).ToList();
                }

                TerminalEkran.Text = string.Join("\n", allLines);

                // Scroll otomatik
                TerminalEkran.SelectionStart = TerminalEkran.Text.Length;
                TerminalEkran.ScrollToCaret();
            }));
        }


        private void TimeoutTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempBuffer.Count > 0)
            {
                this.BeginInvoke((Action)(() =>
                {
                    TerminalEkran.AppendText($"Timeout! Tampon temizlendi, {tempBuffer.Count} byte atıldı.\n");
                }));
                tempBuffer.Clear();
            }
        }

        private void ListComPort_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            COMListBox.Items.Clear();

            foreach (string port in ports)
            {
                COMListBox.Items.Add(port);
            }

            if (COMListBox.Items.Count > 0)
            {
                COMListBox.SelectedIndex = 0;
                PortConnect.Enabled = true;
            }
                
            else
            {
                PortConnect.Enabled = false;
            }                
        }
        
        private void ComputeFFT(double[] samples)
        {
            int N = samples.Length; // Örnek sayısı
            double sampleRate = 1.0 / (1.1666e-6); // ~857 kHz

            // DC offset'i kaldır
            double mean = samples.Average();
            for (int i = 0; i < samples.Length; i++)
                samples[i] -= mean;

            // Pencere uygulama (opsiyonel ama önerilir)
            var window = MathNet.Numerics.Window.Hann(samples.Length);
            for (int i = 0; i < samples.Length; i++)
                samples[i] *= window[i];

            // double[] -> Complex[] dönüştür
            Complex[] spectrum = samples.Select(s => new Complex(s, 0)).ToArray();

            // FFT hesapla
            Fourier.Forward(spectrum, FourierOptions.Matlab);

            // Genlik spektrumu
            double[] magnitude = spectrum
                .Take(N / 2)
                .Select(c => c.Magnitude)
                .ToArray();

            // Frekans ekseni
            double[] frequencies = Enumerable.Range(0, N / 2)
                .Select(i => i * sampleRate / N)
                .ToArray();

            // DC bileşenini atlayarak baskın frekansı bul
            int peakIndex = magnitude
                .Skip(1)
                .Select((val, idx) => new { val, idx })
                .OrderByDescending(x => x.val)
                .First().idx + 1; // +1 çünkü Skip(1)

            double peakFrequency = frequencies[peakIndex];

            // Konsola veya terminale yazdır
            label3.Text = $"{peakFrequency:N2} Hz";

            // ScottPlot ile çiz
            formsPlot2.Plot.Clear();
            formsPlot2.Plot.Add.SignalXY(frequencies, magnitude);
            formsPlot2.Plot.Title("FFT Spektrumu");
            formsPlot2.Plot.XLabel("Frekans (Hz)");
            formsPlot2.Plot.YLabel("Genlik");
            formsPlot2.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                triggerselected = true;
            }
            else
            {
                triggerselected = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/spacemonochrome/OpenWave",
                UseShellExecute = true
            });
        }
    }
}
