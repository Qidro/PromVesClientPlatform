namespace PromVesClientPlatform
{
    partial class ComPortSettingPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComPortSettingPort));
            groupBox1 = new GroupBox();
            label6 = new Label();
            handshakeComboBox = new ComboBox();
            label5 = new Label();
            stopBitsComboBox = new ComboBox();
            label4 = new Label();
            parityComboBox = new ComboBox();
            label3 = new Label();
            dataBitsComboBox = new ComboBox();
            label2 = new Label();
            baudRatecomboBox = new ComboBox();
            label1 = new Label();
            namePortComboBox = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(handshakeComboBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(stopBitsComboBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(parityComboBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dataBitsComboBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(baudRatecomboBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(namePortComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 252);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "COM1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(48, 177);
            label6.Name = "label6";
            label6.Size = new Size(72, 17);
            label6.TabIndex = 11;
            label6.Text = "Handshake";
            // 
            // handshakeComboBox
            // 
            handshakeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            handshakeComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            handshakeComboBox.FormattingEnabled = true;
            handshakeComboBox.Items.AddRange(new object[] { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" });
            handshakeComboBox.Location = new Point(126, 174);
            handshakeComboBox.Name = "handshakeComboBox";
            handshakeComboBox.Size = new Size(150, 25);
            handshakeComboBox.TabIndex = 10;
            handshakeComboBox.SelectedIndexChanged += handshakeComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(48, 146);
            label5.Name = "label5";
            label5.Size = new Size(55, 17);
            label5.TabIndex = 9;
            label5.Text = "StopBits";
            // 
            // stopBitsComboBox
            // 
            stopBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stopBitsComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            stopBitsComboBox.FormattingEnabled = true;
            stopBitsComboBox.Items.AddRange(new object[] { "None", "One", "Two" });
            stopBitsComboBox.Location = new Point(126, 143);
            stopBitsComboBox.Name = "stopBitsComboBox";
            stopBitsComboBox.Size = new Size(150, 25);
            stopBitsComboBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(48, 115);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 7;
            label4.Text = "Parity";
            // 
            // parityComboBox
            // 
            parityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            parityComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            parityComboBox.FormattingEnabled = true;
            parityComboBox.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            parityComboBox.Location = new Point(126, 112);
            parityComboBox.Name = "parityComboBox";
            parityComboBox.Size = new Size(150, 25);
            parityComboBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(48, 84);
            label3.Name = "label3";
            label3.Size = new Size(55, 17);
            label3.TabIndex = 5;
            label3.Text = "DataBits";
            // 
            // dataBitsComboBox
            // 
            dataBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataBitsComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataBitsComboBox.FormattingEnabled = true;
            dataBitsComboBox.Items.AddRange(new object[] { "5", "6", "7", "8" });
            dataBitsComboBox.Location = new Point(126, 81);
            dataBitsComboBox.Name = "dataBitsComboBox";
            dataBitsComboBox.Size = new Size(150, 25);
            dataBitsComboBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(48, 53);
            label2.Name = "label2";
            label2.Size = new Size(63, 17);
            label2.TabIndex = 3;
            label2.Text = "BaudRate";
            // 
            // baudRatecomboBox
            // 
            baudRatecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baudRatecomboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            baudRatecomboBox.FormattingEnabled = true;
            baudRatecomboBox.Items.AddRange(new object[] { "1200", "2400", "4800", "9600" });
            baudRatecomboBox.Location = new Point(126, 50);
            baudRatecomboBox.Name = "baudRatecomboBox";
            baudRatecomboBox.Size = new Size(150, 25);
            baudRatecomboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(48, 22);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 1;
            label1.Text = "Port";
            // 
            // namePortComboBox
            // 
            namePortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            namePortComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            namePortComboBox.FormattingEnabled = true;
            namePortComboBox.Location = new Point(126, 19);
            namePortComboBox.Name = "namePortComboBox";
            namePortComboBox.Size = new Size(150, 25);
            namePortComboBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(319, 31);
            button1.Name = "button1";
            button1.Size = new Size(148, 35);
            button1.TabIndex = 1;
            button1.Text = "Сохранить настройки";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(319, 78);
            button2.Name = "button2";
            button2.Size = new Size(148, 35);
            button2.TabIndex = 2;
            button2.Text = "По умолчанию";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ComPortSettingPort
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 304);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ComPortSettingPort";
            Text = "Настройка com-порта";
            Load += ComPortSettingPort_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private ComboBox stopBitsComboBox;
        private Label label4;
        private ComboBox parityComboBox;
        private Label label3;
        private ComboBox dataBitsComboBox;
        private Label label2;
        private ComboBox baudRatecomboBox;
        private Label label1;
        private ComboBox namePortComboBox;
        private Label label6;
        private ComboBox handshakeComboBox;
        private Button button1;
        private Button button2;
    }
}