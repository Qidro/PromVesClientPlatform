namespace PromVesClientPlatform
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            usersDataGridView = new DataGridView();
            dataGridView1 = new DataGridView();
            loginColumn = new DataGridViewTextBoxColumn();
            roleColimn = new DataGridViewComboBoxColumn();
            activeColumn = new DataGridViewCheckBoxColumn();
            passwordColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // usersDataGridView
            // 
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Location = new Point(12, 86);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.ReadOnly = true;
            usersDataGridView.Size = new Size(642, 150);
            usersDataGridView.TabIndex = 0;
            usersDataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { loginColumn, roleColimn, activeColumn, passwordColumn });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(642, 57);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // loginColumn
            // 
            loginColumn.HeaderText = "Логин";
            loginColumn.Name = "loginColumn";
            // 
            // roleColimn
            // 
            roleColimn.HeaderText = "Роль";
            roleColimn.Items.AddRange(new object[] { "admin", "operator" });
            roleColimn.Name = "roleColimn";
            // 
            // activeColumn
            // 
            activeColumn.HeaderText = "Активность";
            activeColumn.Name = "activeColumn";
            // 
            // passwordColumn
            // 
            passwordColumn.HeaderText = "Пароль";
            passwordColumn.Name = "passwordColumn";
            passwordColumn.Resizable = DataGridViewTriState.True;
            passwordColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 273);
            Controls.Add(dataGridView1);
            Controls.Add(usersDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usersDataGridView;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn loginColumn;
        private DataGridViewComboBoxColumn roleColimn;
        private DataGridViewCheckBoxColumn activeColumn;
        private DataGridViewTextBoxColumn passwordColumn;
    }
}