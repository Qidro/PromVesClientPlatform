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
            brigadeСheckBox = new CheckBox();
            brigadeTextBox = new TextBox();
            quantityCheckBox = new CheckBox();
            quantityTextBox = new TextBox();
            animalNumberCheckBox = new CheckBox();
            animalNumberTextBox = new TextBox();
            responsibleEmployeeCheckBox = new CheckBox();
            responsibleEmployeeTextBox = new TextBox();
            departmentCheckBox = new CheckBox();
            departmentTextBox = new TextBox();
            animalsGroupCheckBox = new CheckBox();
            animalsGroupTextBox = new TextBox();
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
            groupBox1.Controls.Add(brigadeСheckBox);
            groupBox1.Controls.Add(brigadeTextBox);
            groupBox1.Controls.Add(quantityCheckBox);
            groupBox1.Controls.Add(quantityTextBox);
            groupBox1.Controls.Add(animalNumberCheckBox);
            groupBox1.Controls.Add(animalNumberTextBox);
            groupBox1.Controls.Add(responsibleEmployeeCheckBox);
            groupBox1.Controls.Add(responsibleEmployeeTextBox);
            groupBox1.Controls.Add(departmentCheckBox);
            groupBox1.Controls.Add(departmentTextBox);
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
            groupBox1.Enter += groupBox1_Enter;
            // 
            // brigadeСheckBox
            // 
            brigadeСheckBox.AutoSize = true;
            brigadeСheckBox.Location = new Point(22, 201);
            brigadeСheckBox.Name = "brigadeСheckBox";
            brigadeСheckBox.Size = new Size(70, 19);
            brigadeСheckBox.TabIndex = 18;
            brigadeСheckBox.Text = "Бригада";
            brigadeСheckBox.UseVisualStyleBackColor = true;
            // 
            // brigadeTextBox
            // 
            brigadeTextBox.Location = new Point(202, 201);
            brigadeTextBox.Name = "brigadeTextBox";
            brigadeTextBox.Size = new Size(166, 23);
            brigadeTextBox.TabIndex = 17;
            // 
            // quantityCheckBox
            // 
            quantityCheckBox.AutoSize = true;
            quantityCheckBox.Location = new Point(22, 285);
            quantityCheckBox.Name = "quantityCheckBox";
            quantityCheckBox.Size = new Size(150, 19);
            quantityCheckBox.TabIndex = 16;
            quantityCheckBox.Text = "Количество животных";
            quantityCheckBox.UseVisualStyleBackColor = true;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(202, 287);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(166, 23);
            quantityTextBox.TabIndex = 15;
            // 
            // animalNumberCheckBox
            // 
            animalNumberCheckBox.AutoSize = true;
            animalNumberCheckBox.Location = new Point(22, 256);
            animalNumberCheckBox.Name = "animalNumberCheckBox";
            animalNumberCheckBox.Size = new Size(168, 19);
            animalNumberCheckBox.TabIndex = 14;
            animalNumberCheckBox.Text = "Номер станка/животного";
            animalNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // animalNumberTextBox
            // 
            animalNumberTextBox.Location = new Point(202, 258);
            animalNumberTextBox.Name = "animalNumberTextBox";
            animalNumberTextBox.Size = new Size(166, 23);
            animalNumberTextBox.TabIndex = 13;
            // 
            // responsibleEmployeeCheckBox
            // 
            responsibleEmployeeCheckBox.AutoSize = true;
            responsibleEmployeeCheckBox.Location = new Point(22, 227);
            responsibleEmployeeCheckBox.Name = "responsibleEmployeeCheckBox";
            responsibleEmployeeCheckBox.Size = new Size(149, 19);
            responsibleEmployeeCheckBox.TabIndex = 12;
            responsibleEmployeeCheckBox.Text = "За кем прикрепленны";
            responsibleEmployeeCheckBox.UseVisualStyleBackColor = true;
            // 
            // responsibleEmployeeTextBox
            // 
            responsibleEmployeeTextBox.Location = new Point(202, 229);
            responsibleEmployeeTextBox.Name = "responsibleEmployeeTextBox";
            responsibleEmployeeTextBox.Size = new Size(166, 23);
            responsibleEmployeeTextBox.TabIndex = 11;
            // 
            // departmentCheckBox
            // 
            departmentCheckBox.AutoSize = true;
            departmentCheckBox.Location = new Point(22, 170);
            departmentCheckBox.Name = "departmentCheckBox";
            departmentCheckBox.Size = new Size(85, 19);
            departmentCheckBox.TabIndex = 10;
            departmentCheckBox.Text = "Отделение";
            departmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // departmentTextBox
            // 
            departmentTextBox.Location = new Point(202, 172);
            departmentTextBox.Name = "departmentTextBox";
            departmentTextBox.Size = new Size(166, 23);
            departmentTextBox.TabIndex = 9;
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
            btnSaveReceipt.Click += btnSaveReceipt_Click;
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
        private CheckBox quantityCheckBox;
        private TextBox quantityTextBox;
        private CheckBox animalNumberCheckBox;
        private TextBox animalNumberTextBox;
        private CheckBox responsibleEmployeeCheckBox;
        private TextBox responsibleEmployeeTextBox;
        private CheckBox departmentCheckBox;
        private TextBox departmentTextBox;
        private CheckBox animalsGroupCheckBox;
        private TextBox animalsGroupTextBox;
        private CheckBox brigadeСheckBox;
        private TextBox brigadeTextBox;
    }
}