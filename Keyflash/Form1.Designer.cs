namespace Keyflash
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ComPortBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rw1990Radio = new System.Windows.Forms.RadioButton();
            this.rw2004Radio = new System.Windows.Forms.RadioButton();
            this.CurrentCodeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NewCodeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ConnectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FirmwareVerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReadButton = new System.Windows.Forms.Button();
            this.WriteButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.LogCleanButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComPortBox
            // 
            this.ComPortBox.FormattingEnabled = true;
            this.ComPortBox.Location = new System.Drawing.Point(44, 19);
            this.ComPortBox.Name = "ComPortBox";
            this.ComPortBox.Size = new System.Drawing.Size(60, 21);
            this.ComPortBox.TabIndex = 1;
            this.ComPortBox.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Порт";
            // 
            // rw1990Radio
            // 
            this.rw1990Radio.AutoSize = true;
            this.rw1990Radio.Checked = true;
            this.rw1990Radio.Enabled = false;
            this.rw1990Radio.Location = new System.Drawing.Point(118, 20);
            this.rw1990Radio.Name = "rw1990Radio";
            this.rw1990Radio.Size = new System.Drawing.Size(68, 17);
            this.rw1990Radio.TabIndex = 3;
            this.rw1990Radio.TabStop = true;
            this.rw1990Radio.Text = "RW1990";
            this.rw1990Radio.UseVisualStyleBackColor = true;
            // 
            // rw2004Radio
            // 
            this.rw2004Radio.AutoSize = true;
            this.rw2004Radio.Enabled = false;
            this.rw2004Radio.Location = new System.Drawing.Point(192, 20);
            this.rw2004Radio.Name = "rw2004Radio";
            this.rw2004Radio.Size = new System.Drawing.Size(68, 17);
            this.rw2004Radio.TabIndex = 4;
            this.rw2004Radio.TabStop = true;
            this.rw2004Radio.Text = "RW2004";
            this.rw2004Radio.UseVisualStyleBackColor = true;
            // 
            // CurrentCodeBox
            // 
            this.CurrentCodeBox.Location = new System.Drawing.Point(106, 19);
            this.CurrentCodeBox.Name = "CurrentCodeBox";
            this.CurrentCodeBox.ReadOnly = true;
            this.CurrentCodeBox.Size = new System.Drawing.Size(153, 20);
            this.CurrentCodeBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Прочитанный код";
            // 
            // NewCodeBox
            // 
            this.NewCodeBox.Location = new System.Drawing.Point(106, 45);
            this.NewCodeBox.Name = "NewCodeBox";
            this.NewCodeBox.Size = new System.Drawing.Size(153, 20);
            this.NewCodeBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Код для записи";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectedLabel,
            this.FirmwareVerLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 230);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(468, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ConnectedLabel
            // 
            this.ConnectedLabel.Name = "ConnectedLabel";
            this.ConnectedLabel.Size = new System.Drawing.Size(162, 17);
            this.ConnectedLabel.Text = "Устройство: не подключено";
            // 
            // FirmwareVerLabel
            // 
            this.FirmwareVerLabel.Name = "FirmwareVerLabel";
            this.FirmwareVerLabel.Size = new System.Drawing.Size(135, 17);
            this.FirmwareVerLabel.Text = "Версия прошивки: N/A";
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(6, 71);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(115, 23);
            this.ReadButton.TabIndex = 10;
            this.ReadButton.Text = "Чтение";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(144, 71);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(115, 23);
            this.WriteButton.TabIndex = 11;
            this.WriteButton.Text = "Запись";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(6, 100);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(253, 23);
            this.CopyButton.TabIndex = 12;
            this.CopyButton.Text = "Копия";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // LogCleanButton
            // 
            this.LogCleanButton.Location = new System.Drawing.Point(283, 195);
            this.LogCleanButton.Name = "LogCleanButton";
            this.LogCleanButton.Size = new System.Drawing.Size(173, 23);
            this.LogCleanButton.TabIndex = 14;
            this.LogCleanButton.Text = "Очистить";
            this.LogCleanButton.UseVisualStyleBackColor = true;
            this.LogCleanButton.Click += new System.EventHandler(this.LogCleanButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.rw1990Radio);
            this.groupBox1.Controls.Add(this.ComPortBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rw2004Radio);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 77);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(10, 48);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(253, 23);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Подключиться к устройству";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NewCodeBox);
            this.groupBox2.Controls.Add(this.CurrentCodeBox);
            this.groupBox2.Controls.Add(this.CopyButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.WriteButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ReadButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(11, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 130);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Операции с ключами";
            // 
            // LogBox
            // 
            this.LogBox.FormattingEnabled = true;
            this.LogBox.Location = new System.Drawing.Point(284, 22);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(173, 160);
            this.LogBox.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(468, 252);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.LogCleanButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "KeyFlash v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComPortBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rw1990Radio;
        private System.Windows.Forms.RadioButton rw2004Radio;
        private System.Windows.Forms.TextBox CurrentCodeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewCodeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ConnectedLabel;
        private System.Windows.Forms.ToolStripStatusLabel FirmwareVerLabel;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button LogCleanButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.Button ConnectButton;
    }
}

