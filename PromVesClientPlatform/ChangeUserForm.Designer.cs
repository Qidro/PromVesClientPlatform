namespace PromVesClientPlatform
{
    partial class ChangeUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserForm));
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            activeComboBox = new ComboBox();
            roleComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            changeUserButton = new Button();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginTextBox.Location = new Point(36, 36);
            loginTextBox.Multiline = true;
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(163, 31);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passwordTextBox.Location = new Point(257, 33);
            passwordTextBox.Multiline = true;
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(163, 32);
            passwordTextBox.TabIndex = 1;
            // 
            // activeComboBox
            // 
            activeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            activeComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            activeComboBox.FormattingEnabled = true;
            activeComboBox.Items.AddRange(new object[] { "Активный", "Неактивный" });
            activeComboBox.Location = new Point(257, 105);
            activeComboBox.Name = "activeComboBox";
            activeComboBox.Size = new Size(163, 29);
            activeComboBox.TabIndex = 2;
            // 
            // roleComboBox
            // 
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "admin", "operator" });
            roleComboBox.Location = new Point(36, 105);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(163, 29);
            roleComboBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(36, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(257, 71);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 5;
            label2.Text = "Активность";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(257, 9);
            label3.Name = "label3";
            label3.Size = new Size(63, 21);
            label3.TabIndex = 6;
            label3.Text = "Пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(36, 71);
            label4.Name = "label4";
            label4.Size = new Size(44, 21);
            label4.TabIndex = 7;
            label4.Text = "Роль";
            // 
            // changeUserButton
            // 
            changeUserButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            changeUserButton.Location = new Point(97, 153);
            changeUserButton.Name = "changeUserButton";
            changeUserButton.Size = new Size(252, 45);
            changeUserButton.TabIndex = 8;
            changeUserButton.Text = "Изменить пользователя";
            changeUserButton.UseVisualStyleBackColor = true;
            changeUserButton.Click += changeUserButton_Click;
            // 
            // ChangeUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 239);
            Controls.Add(changeUserButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(roleComboBox);
            Controls.Add(activeComboBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChangeUserForm";
            Text = "Редактироваине пользовтаеля";
            Load += ChangeUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private ComboBox activeComboBox;
        private ComboBox roleComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button changeUserButton;
    }
}