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
            createUserDataGridView = new DataGridView();
            loginColumn = new DataGridViewTextBoxColumn();
            roleColimn = new DataGridViewComboBoxColumn();
            activeColumn = new DataGridViewCheckBoxColumn();
            passwordColumn = new DataGridViewTextBoxColumn();
            createUserButton = new Button();
            changeUserButton = new Button();
            deleateUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)createUserDataGridView).BeginInit();
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
            // createUserDataGridView
            // 
            createUserDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            createUserDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            createUserDataGridView.Columns.AddRange(new DataGridViewColumn[] { loginColumn, roleColimn, activeColumn, passwordColumn });
            createUserDataGridView.Location = new Point(12, 12);
            createUserDataGridView.Name = "createUserDataGridView";
            createUserDataGridView.Size = new Size(642, 57);
            createUserDataGridView.TabIndex = 1;
            createUserDataGridView.CellContentClick += dataGridView1_CellContentClick_1;
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
            // createUserButton
            // 
            createUserButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            createUserButton.Location = new Point(689, 12);
            createUserButton.Name = "createUserButton";
            createUserButton.Size = new Size(186, 39);
            createUserButton.TabIndex = 2;
            createUserButton.Text = "Добавить пользователя";
            createUserButton.UseVisualStyleBackColor = true;
            createUserButton.Click += createUserButton_Click;
            // 
            // changeUserButton
            // 
            changeUserButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            changeUserButton.Location = new Point(689, 57);
            changeUserButton.Name = "changeUserButton";
            changeUserButton.Size = new Size(186, 40);
            changeUserButton.TabIndex = 3;
            changeUserButton.Text = "Изменить пользователя";
            changeUserButton.UseVisualStyleBackColor = true;
            changeUserButton.Click += changeUserButton_Click;
            // 
            // deleateUserButton
            // 
            deleateUserButton.BackColor = Color.Red;
            deleateUserButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deleateUserButton.ForeColor = Color.White;
            deleateUserButton.Location = new Point(689, 103);
            deleateUserButton.Name = "deleateUserButton";
            deleateUserButton.Size = new Size(186, 40);
            deleateUserButton.TabIndex = 4;
            deleateUserButton.Text = "Удалить пользователя";
            deleateUserButton.UseVisualStyleBackColor = false;
            deleateUserButton.Click += deleateUserButton_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 273);
            Controls.Add(deleateUserButton);
            Controls.Add(changeUserButton);
            Controls.Add(createUserButton);
            Controls.Add(createUserDataGridView);
            Controls.Add(usersDataGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)createUserDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usersDataGridView;
        private DataGridView createUserDataGridView;
        private DataGridViewTextBoxColumn loginColumn;
        private DataGridViewComboBoxColumn roleColimn;
        private DataGridViewCheckBoxColumn activeColumn;
        private DataGridViewTextBoxColumn passwordColumn;
        private Button createUserButton;
        private Button changeUserButton;
        private Button deleateUserButton;
    }
}