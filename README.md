# OpenWave

<img width="819" height="622" alt="image" src="https://github.com/user-attachments/assets/6e130990-a102-4f3a-badb-cc378f61b3b2" />



## English Description

OpenWave is a dual-part project consisting of:
- **STM32F103C8T6-based firmware** for high-speed ADC data acquisition and USB communication.
- **C# Windows UI application** for real-time data visualization, serial communication, and signal analysis (including FFT).

### Features
- High-speed ADC sampling on STM32, with DMA and USB CDC for efficient data transfer.
- Start/Stop control and data streaming via USB commands.
- Windows UI (WinForms) for:
	- Serial port connection and management
	- Real-time plotting of incoming data (ScottPlot)
	- Trigger-based waveform alignment
	- Real-time FFT spectrum analysis
	- Terminal output for status and debug
- Modular and extensible codebase.

### How It Works
1. **Firmware** samples analog signals using the ADC, buffers data, and sends it to the PC via USB when commanded.
2. **PC Application** receives the data, displays it live, and performs FFT for frequency analysis.

### Requirements
- STM32F103C8T6 microcontroller
- Windows PC
- .NET Framework (WinForms)
- Required NuGet packages: ScottPlot, MathNet.Numerics, OpenTK, etc.

### Quick Start
1. Flash the STM32 with the firmware in `OpenWave_V0.1`.
2. Build and run the Windows UI in `OpenWave_V0.1_WinUI`.
3. Connect the STM32 via USB, select the COM port, and start streaming data.

---

## Türkçe Açıklama

OpenWave, iki ana bölümden oluşan bir projedir:
- **STM32F103C8T6 tabanlı firmware** ile yüksek hızlı ADC veri toplama ve USB iletişimi.
- **C# Windows arayüz uygulaması** ile gerçek zamanlı veri görselleştirme, seri iletişim ve sinyal analizi (FFT dahil).

### Özellikler
- STM32 üzerinde yüksek hızlı ADC örnekleme, DMA ve USB CDC ile verimli veri aktarımı.
- USB komutları ile başlat/durdur kontrolü ve veri akışı.
- Windows arayüzü (WinForms):
	- Seri port bağlantısı ve yönetimi
	- Gelen verinin gerçek zamanlı grafiği (ScottPlot)
	- Tetikleme tabanlı dalga hizalama
	- Gerçek zamanlı FFT spektrum analizi
	- Durum ve hata için terminal çıktısı
- Modüler ve genişletilebilir kod yapısı.

### Nasıl Çalışır?
1. **Firmware**, analog sinyalleri ADC ile örnekler, veriyi tamponlar ve komut geldiğinde PC'ye USB ile gönderir.
2. **PC Uygulaması**, veriyi alır, canlı olarak gösterir ve frekans analizi için FFT uygular.

### Gereksinimler
- STM32F103C8T6 mikrodenetleyici
- Windows PC
- .NET Framework (WinForms)
- Gerekli NuGet paketleri: ScottPlot, MathNet.Numerics, OpenTK, vb.

### Hızlı Başlangıç
1. STM32'ye `OpenWave_V0.1` içindeki firmware'i yükleyin.
2. `OpenWave_V0.1_WinUI` içindeki Windows arayüzünü derleyip çalıştırın.
3. STM32'yi USB ile bağlayın, COM portunu seçin ve veri akışını başlatın.
