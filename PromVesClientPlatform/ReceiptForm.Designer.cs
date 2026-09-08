namespace PromVesClientPlatform
{
    partial class ReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            dataGridViewReceipts = new DataGridView();
            dataGridViewСards = new DataGridView();
            receiptInfoLabel = new Label();
            groupBox1 = new GroupBox();
            operatorCheckBox = new CheckBox();
            operatorTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            btnReportFilter = new Button();
            btnResetFilter = new Button();
            btnSaveReceipt = new Button();
            btnPrintReceipt = new Button();
            btnDeleteCard = new Button();
            btnDeleteReceipt = new Button();
            animalsGroupCheckBox = new CheckBox();
            animalsGroupTextBox = new TextBox();
            checkBox3 = new CheckBox();
            textBox3 = new TextBox();
            checkBox4 = new CheckBox();
            textBox4 = new TextBox();
            checkBox5 = new CheckBox();
            textBox5 = new TextBox();
            checkBox6 = new CheckBox();
            textBox6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceipts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewСards).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewReceipts
            // 
            dataGridViewReceipts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceipts.Location = new Point(12, 12);
            dataGridViewReceipts.Name = "dataGridViewReceipts";
            dataGridViewReceipts.ReadOnly = true;
            dataGridViewReceipts.Size = new Size(949, 221);
            dataGridViewReceipts.TabIndex = 0;
            dataGridViewReceipts.CellClick += dataGridViewReceipts_CellClick;
            // 
            // dataGridViewСards
            // 
            dataGridViewСards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewСards.Location = new Point(12, 290);
            dataGridViewСards.Name = "dataGridViewСards";
            dataGridViewСards.Size = new Size(949, 325);
            dataGridViewСards.TabIndex = 1;
            // 
            // receiptInfoLabel
            // 
            receiptInfoLabel.AutoSize = true;
            receiptInfoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            receiptInfoLabel.Location = new Point(422, 250);
            receiptInfoLabel.Name = "receiptInfoLabel";
            receiptInfoLabel.Size = new Size(107, 21);
            receiptInfoLabel.TabIndex = 2;
            receiptInfoLabel.Text = "Квитанция от";
            receiptInfoLabel.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox6);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(checkBox5);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(animalsGroupCheckBox);
            groupBox1.Controls.Add(animalsGroupTextBox);
            groupBox1.Controls.Add(operatorCheckBox);
            groupBox1.Controls.Add(operatorTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new Point(994, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 351);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтр квитанций";
            // 
            // operatorCheckBox
            // 
            operatorCheckBox.AutoSize = true;
            operatorCheckBox.Location = new Point(22, 112);
            operatorCheckBox.Name = "operatorCheckBox";
            operatorCheckBox.Size = new Size(80, 19);
            operatorCheckBox.TabIndex = 6;
            operatorCheckBox.Text = "Оператор";
            operatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // operatorTextBox
            // 
            operatorTextBox.Location = new Point(202, 114);
            operatorTextBox.Name = "operatorTextBox";
            operatorTextBox.Size = new Size(166, 23);
            operatorTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 72);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 3;
            label3.Text = "по";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 28);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Дата с";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(202, 72);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(166, 23);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(202, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(166, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // btnReportFilter
            // 
            btnReportFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnReportFilter.Location = new Point(994, 369);
            btnReportFilter.Name = "btnReportFilter";
            btnReportFilter.Size = new Size(393, 36);
            btnReportFilter.TabIndex = 4;
            btnReportFilter.Text = "Применить фильтр";
            btnReportFilter.UseVisualStyleBackColor = true;
            btnReportFilter.Click += btnReportFilter_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnResetFilter.Location = new Point(994, 411);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(393, 36);
            btnResetFilter.TabIndex = 5;
            btnResetFilter.Text = "Сбросить фильтр";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnSaveReceipt
            // 
            btnSaveReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSaveReceipt.Location = new Point(994, 453);
            btnSaveReceipt.Name = "btnSaveReceipt";
            btnSaveReceipt.Size = new Size(393, 36);
            btnSaveReceipt.TabIndex = 6;
            btnSaveReceipt.Text = "Сохранить квитанцию";
            btnSaveReceipt.UseVisualStyleBackColor = true;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnPrintReceipt.Location = new Point(994, 495);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(393, 36);
            btnPrintReceipt.TabIndex = 7;
            btnPrintReceipt.Text = "Распечатать квитанцию";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCard
            // 
            btnDeleteCard.BackColor = Color.Red;
            btnDeleteCard.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteCard.ForeColor = Color.White;
            btnDeleteCard.Location = new Point(994, 537);
            btnDeleteCard.Name = "btnDeleteCard";
            btnDeleteCard.Size = new Size(393, 36);
            btnDeleteCard.TabIndex = 8;
            btnDeleteCard.Text = "Удалить карточку вагона";
            btnDeleteCard.UseVisualStyleBackColor = false;
            btnDeleteCard.Click += btnDeleteCard_Click;
            // 
            // btnDeleteReceipt
            // 
            btnDeleteReceipt.BackColor = Color.Red;
            btnDeleteReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteReceipt.ForeColor = Color.White;
            btnDeleteReceipt.Location = new Point(994, 579);
            btnDeleteReceipt.Name = "btnDeleteReceipt";
            btnDeleteReceipt.Size = new Size(393, 36);
            btnDeleteReceipt.TabIndex = 9;
            btnDeleteReceipt.Text = "Удалить квитанцию";
            btnDeleteReceipt.UseVisualStyleBackColor = false;
            btnDeleteReceipt.Click += btnDeleteReceipt_Click;
            // 
            // animalsGroupCheckBox
            // 
            animalsGroupCheckBox.AutoSize = true;
            animalsGroupCheckBox.Location = new Point(22, 141);
            animalsGroupCheckBox.Name = "animalsGroupCheckBox";
            animalsGroupCheckBox.Size = new Size(124, 19);
            animalsGroupCheckBox.TabIndex = 8;
            animalsGroupCheckBox.Text = "Группа животных";
            animalsGroupCheckBox.UseVisualStyleBackColor = true;
            // 
            // animalsGroupTextBox
            // 
            animalsGroupTextBox.Location = new Point(202, 143);
            animalsGroupTextBox.Name = "animalsGroupTextBox";
            animalsGroupTextBox.Size = new Size(166, 23);
            animalsGroupTextBox.TabIndex = 7;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(22, 170);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(85, 19);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "Отделение";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(202, 172);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(166, 23);
            textBox3.TabIndex = 9;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(22, 199);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(149, 19);
            checkBox4.TabIndex = 12;
            checkBox4.Text = "За кем прикрепленны";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(202, 201);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(166, 23);
            textBox4.TabIndex = 11;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(22, 228);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(168, 19);
            checkBox5.TabIndex = 14;
            checkBox5.Text = "Номер станка/животного";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(202, 230);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(166, 23);
            textBox5.TabIndex = 13;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(22, 257);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(150, 19);
            checkBox6.TabIndex = 16;
            checkBox6.Text = "Количество животных";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(202, 259);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(166, 23);
            textBox6.TabIndex = 15;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 631);
            Controls.Add(btnDeleteReceipt);
            Controls.Add(btnDeleteCard);
            Controls.Add(btnPrintReceipt);
            Controls.Add(btnSaveReceipt);
            Controls.Add(btnResetFilter);
            Controls.Add(btnReportFilter);
            Controls.Add(groupBox1);
            Controls.Add(receiptInfoLabel);
            Controls.Add(dataGridViewСards);
            Controls.Add(dataGridViewReceipts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReceiptForm";
            Text = "Квитанции";
            Load += ReceiptForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceipts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewСards).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewReceipts;
        private DataGridView dataGridViewСards;
        private Label receiptInfoLabel;
        private GroupBox groupBox1;
        private Button btnReportFilter;
        private Button btnResetFilter;
        private Button btnSaveReceipt;
        private Button btnPrintReceipt;
        private Button btnDeleteCard;
        private Button btnDeleteReceipt;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private CheckBox operatorCheckBox;
        private TextBox operatorTextBox;
        private CheckBox checkBox6;
        private TextBox textBox6;
        private CheckBox checkBox5;
        private TextBox textBox5;
        private CheckBox checkBox4;
        private TextBox textBox4;
        private CheckBox checkBox3;
        private TextBox textBox3;
        private CheckBox animalsGroupCheckBox;
        private TextBox animalsGroupTextBox;
    }
}