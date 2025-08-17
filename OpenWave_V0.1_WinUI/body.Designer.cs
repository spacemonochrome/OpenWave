namespace OpenWave_V0._1_WinUI
{
    partial class body
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(body));
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.rbManage = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.COMListBox = new System.Windows.Forms.ComboBox();
            this.ListComPort = new System.Windows.Forms.Button();
            this.PortConnect = new System.Windows.Forms.Button();
            this.PortDisconnect = new System.Windows.Forms.Button();
            this.TerminalEkran = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ADCRun = new System.Windows.Forms.Button();
            this.ADCStop = new System.Windows.Forms.Button();
            this.formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 0F;
            this.formsPlot1.Location = new System.Drawing.Point(12, 80);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(561, 288);
            this.formsPlot1.TabIndex = 0;
            // 
            // rbManage
            // 
            this.rbManage.AutoSize = true;
            this.rbManage.Location = new System.Drawing.Point(270, 14);
            this.rbManage.Name = "rbManage";
            this.rbManage.Size = new System.Drawing.Size(68, 17);
            this.rbManage.TabIndex = 2;
            this.rbManage.Text = "Axis Limit";
            this.rbManage.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(344, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Auto Scale";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // COMListBox
            // 
            this.COMListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMListBox.FormattingEnabled = true;
            this.COMListBox.Location = new System.Drawing.Point(13, 10);
            this.COMListBox.Name = "COMListBox";
            this.COMListBox.Size = new System.Drawing.Size(75, 21);
            this.COMListBox.TabIndex = 3;
            // 
            // ListComPort
            // 
            this.ListComPort.Location = new System.Drawing.Point(13, 37);
            this.ListComPort.Name = "ListComPort";
            this.ListComPort.Size = new System.Drawing.Size(75, 37);
            this.ListComPort.TabIndex = 1;
            this.ListComPort.Text = "Portları Listele";
            this.ListComPort.UseVisualStyleBackColor = true;
            this.ListComPort.Click += new System.EventHandler(this.ListComPort_Click);
            // 
            // PortConnect
            // 
            this.PortConnect.Enabled = false;
            this.PortConnect.Location = new System.Drawing.Point(94, 10);
            this.PortConnect.Name = "PortConnect";
            this.PortConnect.Size = new System.Drawing.Size(75, 21);
            this.PortConnect.TabIndex = 1;
            this.PortConnect.Text = "Bağlan";
            this.PortConnect.UseVisualStyleBackColor = true;
            this.PortConnect.Click += new System.EventHandler(this.PortConnect_Click);
            // 
            // PortDisconnect
            // 
            this.PortDisconnect.Enabled = false;
            this.PortDisconnect.Location = new System.Drawing.Point(94, 37);
            this.PortDisconnect.Name = "PortDisconnect";
            this.PortDisconnect.Size = new System.Drawing.Size(75, 37);
            this.PortDisconnect.TabIndex = 1;
            this.PortDisconnect.Text = "Bağlantıyı Kes";
            this.PortDisconnect.UseVisualStyleBackColor = true;
            this.PortDisconnect.Click += new System.EventHandler(this.PortDisconnect_Click);
            // 
            // TerminalEkran
            // 
            this.TerminalEkran.Location = new System.Drawing.Point(579, 37);
            this.TerminalEkran.Multiline = true;
            this.TerminalEkran.Name = "TerminalEkran";
            this.TerminalEkran.Size = new System.Drawing.Size(207, 544);
            this.TerminalEkran.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(576, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Terminal:";
            // 
            // ADCRun
            // 
            this.ADCRun.Enabled = false;
            this.ADCRun.Location = new System.Drawing.Point(175, 10);
            this.ADCRun.Name = "ADCRun";
            this.ADCRun.Size = new System.Drawing.Size(75, 27);
            this.ADCRun.TabIndex = 1;
            this.ADCRun.Text = "Çalıştır";
            this.ADCRun.UseVisualStyleBackColor = true;
            this.ADCRun.Click += new System.EventHandler(this.ADCRun_Click);
            // 
            // ADCStop
            // 
            this.ADCStop.Enabled = false;
            this.ADCStop.Location = new System.Drawing.Point(175, 43);
            this.ADCStop.Name = "ADCStop";
            this.ADCStop.Size = new System.Drawing.Size(75, 31);
            this.ADCStop.TabIndex = 1;
            this.ADCStop.Text = "Durdur";
            this.ADCStop.UseVisualStyleBackColor = true;
            this.ADCStop.Click += new System.EventHandler(this.ADCStop_Click);
            // 
            // formsPlot2
            // 
            this.formsPlot2.DisplayScale = 0F;
            this.formsPlot2.Location = new System.Drawing.Point(13, 375);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(560, 206);
            this.formsPlot2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(261, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baskın Frekans (Hz)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(388, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "0 Hz";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(480, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Trigger";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // body
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 596);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.formsPlot2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TerminalEkran);
            this.Controls.Add(this.COMListBox);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.rbManage);
            this.Controls.Add(this.ADCStop);
            this.Controls.Add(this.ADCRun);
            this.Controls.Add(this.PortDisconnect);
            this.Controls.Add(this.PortConnect);
            this.Controls.Add(this.ListComPort);
            this.Controls.Add(this.formsPlot1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "body";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenWave v0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.RadioButton rbManage;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox COMListBox;
        private System.Windows.Forms.Button ListComPort;
        private System.Windows.Forms.Button PortConnect;
        private System.Windows.Forms.Button PortDisconnect;
        private System.Windows.Forms.TextBox TerminalEkran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ADCRun;
        private System.Windows.Forms.Button ADCStop;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

