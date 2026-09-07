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
            dataGridView2 = new DataGridView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 290);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(949, 246);
            dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(422, 250);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 2;
            label1.Text = "Квитанция от";
            label1.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new Point(994, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(321, 259);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтр квитанций";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(22, 112);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(80, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Оператор";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 23);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 72);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 3;
            label3.Text = "по";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 28);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Дата с";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(133, 66);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(166, 23);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(133, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(166, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // btnReportFilter
            // 
            btnReportFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnReportFilter.Location = new Point(994, 290);
            btnReportFilter.Name = "btnReportFilter";
            btnReportFilter.Size = new Size(321, 36);
            btnReportFilter.TabIndex = 4;
            btnReportFilter.Text = "Применить фильтр";
            btnReportFilter.UseVisualStyleBackColor = true;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnResetFilter.Location = new Point(994, 332);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(321, 36);
            btnResetFilter.TabIndex = 5;
            btnResetFilter.Text = "Сбросить фильтр";
            btnResetFilter.UseVisualStyleBackColor = true;
            // 
            // btnSaveReceipt
            // 
            btnSaveReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSaveReceipt.Location = new Point(994, 374);
            btnSaveReceipt.Name = "btnSaveReceipt";
            btnSaveReceipt.Size = new Size(321, 36);
            btnSaveReceipt.TabIndex = 6;
            btnSaveReceipt.Text = "Сохранить квитанцию";
            btnSaveReceipt.UseVisualStyleBackColor = true;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnPrintReceipt.Location = new Point(994, 416);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(321, 36);
            btnPrintReceipt.TabIndex = 7;
            btnPrintReceipt.Text = "Распечатать квитанцию";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCard
            // 
            btnDeleteCard.BackColor = Color.Red;
            btnDeleteCard.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteCard.ForeColor = Color.White;
            btnDeleteCard.Location = new Point(994, 458);
            btnDeleteCard.Name = "btnDeleteCard";
            btnDeleteCard.Size = new Size(321, 36);
            btnDeleteCard.TabIndex = 8;
            btnDeleteCard.Text = "Удалить карточку вагона";
            btnDeleteCard.UseVisualStyleBackColor = false;
            // 
            // btnDeleteReceipt
            // 
            btnDeleteReceipt.BackColor = Color.Red;
            btnDeleteReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteReceipt.ForeColor = Color.White;
            btnDeleteReceipt.Location = new Point(994, 500);
            btnDeleteReceipt.Name = "btnDeleteReceipt";
            btnDeleteReceipt.Size = new Size(321, 36);
            btnDeleteReceipt.TabIndex = 9;
            btnDeleteReceipt.Text = "Удалить квитанцию";
            btnDeleteReceipt.UseVisualStyleBackColor = false;
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
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridViewReceipts);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReceiptForm";
            Text = "Квитанции";
            Load += ReceiptForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceipts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewReceipts;
        private DataGridView dataGridView2;
        private Label label1;
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
        private CheckBox checkBox1;
        private TextBox textBox1;
    }
}