namespace PromVesClientPlatform
{
    partial class DirectoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryForm));
            EmplyeedataGridView = new DataGridView();
            GroupAnimaldataGridView = new DataGridView();
            AddEmployeebutton = new Button();
            EditEmployeebutton = new Button();
            DeleteEmployee = new Button();
            AddAnimalGroup = new Button();
            EditAnimalGroup = new Button();
            DeleteAnimalGroupbutton = new Button();
            EmplyeetextBox = new TextBox();
            GroupAnimaltextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)EmplyeedataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GroupAnimaldataGridView).BeginInit();
            SuspendLayout();
            // 
            // EmplyeedataGridView
            // 
            EmplyeedataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EmplyeedataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmplyeedataGridView.Location = new Point(12, 163);
            EmplyeedataGridView.Name = "EmplyeedataGridView";
            EmplyeedataGridView.ReadOnly = true;
            EmplyeedataGridView.RowHeadersVisible = false;
            EmplyeedataGridView.Size = new Size(282, 305);
            EmplyeedataGridView.TabIndex = 0;
            EmplyeedataGridView.CellContentClick += EmplyeedataGridView_CellClick;
            // 
            // GroupAnimaldataGridView
            // 
            GroupAnimaldataGridView.AllowUserToResizeColumns = false;
            GroupAnimaldataGridView.AllowUserToResizeRows = false;
            GroupAnimaldataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GroupAnimaldataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GroupAnimaldataGridView.Location = new Point(358, 163);
            GroupAnimaldataGridView.MultiSelect = false;
            GroupAnimaldataGridView.Name = "GroupAnimaldataGridView";
            GroupAnimaldataGridView.ReadOnly = true;
            GroupAnimaldataGridView.RowHeadersVisible = false;
            GroupAnimaldataGridView.Size = new Size(282, 305);
            GroupAnimaldataGridView.TabIndex = 1;
            GroupAnimaldataGridView.CellContentClick += GroupAnimaldataGridView_CellClick;
            // 
            // AddEmployeebutton
            // 
            AddEmployeebutton.Location = new Point(12, 26);
            AddEmployeebutton.Name = "AddEmployeebutton";
            AddEmployeebutton.Size = new Size(138, 42);
            AddEmployeebutton.TabIndex = 2;
            AddEmployeebutton.Text = "Добавить сотрудника";
            AddEmployeebutton.UseVisualStyleBackColor = true;
            AddEmployeebutton.Click += AddEmployeebutton_Click;
            // 
            // EditEmployeebutton
            // 
            EditEmployeebutton.Location = new Point(156, 26);
            EditEmployeebutton.Name = "EditEmployeebutton";
            EditEmployeebutton.Size = new Size(138, 42);
            EditEmployeebutton.TabIndex = 3;
            EditEmployeebutton.Text = "Изменить сотрудника";
            EditEmployeebutton.UseVisualStyleBackColor = true;
            EditEmployeebutton.Click += EditEmployeebutton_Click;
            // 
            // DeleteEmployee
            // 
            DeleteEmployee.Location = new Point(12, 74);
            DeleteEmployee.Name = "DeleteEmployee";
            DeleteEmployee.Size = new Size(138, 42);
            DeleteEmployee.TabIndex = 4;
            DeleteEmployee.Text = "Удалить сотрудника";
            DeleteEmployee.UseVisualStyleBackColor = true;
            DeleteEmployee.Click += DeleteEmployee_Click;
            // 
            // AddAnimalGroup
            // 
            AddAnimalGroup.Location = new Point(358, 26);
            AddAnimalGroup.Name = "AddAnimalGroup";
            AddAnimalGroup.Size = new Size(138, 42);
            AddAnimalGroup.TabIndex = 5;
            AddAnimalGroup.Text = "Добавить группу";
            AddAnimalGroup.UseVisualStyleBackColor = true;
            AddAnimalGroup.Click += AddAnimalGroup_Click;
            // 
            // EditAnimalGroup
            // 
            EditAnimalGroup.Location = new Point(502, 26);
            EditAnimalGroup.Name = "EditAnimalGroup";
            EditAnimalGroup.Size = new Size(138, 42);
            EditAnimalGroup.TabIndex = 6;
            EditAnimalGroup.Text = "Изменить группу ";
            EditAnimalGroup.UseVisualStyleBackColor = true;
            EditAnimalGroup.Click += EditAnimalGroup_Click;
            // 
            // DeleteAnimalGroupbutton
            // 
            DeleteAnimalGroupbutton.Location = new Point(358, 74);
            DeleteAnimalGroupbutton.Name = "DeleteAnimalGroupbutton";
            DeleteAnimalGroupbutton.Size = new Size(138, 42);
            DeleteAnimalGroupbutton.TabIndex = 7;
            DeleteAnimalGroupbutton.Text = "Удалить группу";
            DeleteAnimalGroupbutton.UseVisualStyleBackColor = true;
            DeleteAnimalGroupbutton.Click += DeleteAnimalGroupbutton_Click;
            // 
            // EmplyeetextBox
            // 
            EmplyeetextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            EmplyeetextBox.Location = new Point(12, 122);
            EmplyeetextBox.Name = "EmplyeetextBox";
            EmplyeetextBox.Size = new Size(282, 35);
            EmplyeetextBox.TabIndex = 8;
            // 
            // GroupAnimaltextBox
            // 
            GroupAnimaltextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            GroupAnimaltextBox.Location = new Point(358, 122);
            GroupAnimaltextBox.Name = "GroupAnimaltextBox";
            GroupAnimaltextBox.Size = new Size(282, 35);
            GroupAnimaltextBox.TabIndex = 9;
            // 
            // DirectoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 486);
            Controls.Add(GroupAnimaltextBox);
            Controls.Add(EmplyeetextBox);
            Controls.Add(DeleteAnimalGroupbutton);
            Controls.Add(EditAnimalGroup);
            Controls.Add(AddAnimalGroup);
            Controls.Add(DeleteEmployee);
            Controls.Add(EditEmployeebutton);
            Controls.Add(AddEmployeebutton);
            Controls.Add(GroupAnimaldataGridView);
            Controls.Add(EmplyeedataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DirectoryForm";
            Text = "Справочник";
            Load += DirectoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)EmplyeedataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)GroupAnimaldataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView EmplyeedataGridView;
        private DataGridView GroupAnimaldataGridView;
        private Button AddEmployeebutton;
        private Button EditEmployeebutton;
        private Button DeleteEmployee;
        private Button AddAnimalGroup;
        private Button EditAnimalGroup;
        private Button DeleteAnimalGroupbutton;
        private TextBox EmplyeetextBox;
        private TextBox GroupAnimaltextBox;
    }
}