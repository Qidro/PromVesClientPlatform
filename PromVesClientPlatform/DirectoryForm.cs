using PromVesClientPlatform.Model;
using PromVesClientPlatform.Model;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.DirectoryService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromVesClientPlatform
{
    public partial class DirectoryForm : Form
    {
        private readonly DirectoryService _directoryService;
        public DirectoryForm(DirectoryService directoryService)
        {
            InitializeComponent();
            _directoryService = directoryService;
        }
        //метод для загрузки данных в таблицу
        private async Task LoadEmployeesAsync()
        {
            var employees = await _directoryService.GetEmployeesAsync();

            EmplyeedataGridView.DataSource = null;

            EmplyeedataGridView.AutoGenerateColumns = false;
            EmplyeedataGridView.Columns.Clear();

            var fullNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "ФИО",
                DataPropertyName = nameof(Employee.FullName),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            EmplyeedataGridView.Columns.Add(fullNameColumn);

            EmplyeedataGridView.DataSource = employees;
        }

        private async Task LoadAnimalGroupsAsync()
        {
            var groups = await _directoryService.GetAnimalGroupsAsync();

            GroupAnimaldataGridView.DataSource = null;

            GroupAnimaldataGridView.AutoGenerateColumns = false;

            GroupAnimaldataGridView.Columns.Clear();

            GroupAnimaldataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Группа животных",
                DataPropertyName = nameof(AnimalGroup.Name),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            GroupAnimaldataGridView.DataSource = groups;
        }

        private async void DirectoryForm_Load(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
            await LoadAnimalGroupsAsync();
        }

        private async void AddEmployeebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmplyeetextBox.Text))
            {
                MessageBox.Show(
                    "Введите ФИО сотрудника.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            await _directoryService.AddEmployeeAsync(
                EmplyeetextBox.Text);

            EmplyeetextBox.Clear();

            await LoadEmployeesAsync();
        }

        private async void EditEmployeebutton_Click(object sender, EventArgs e)
        {
            if (EmplyeedataGridView.CurrentRow?.DataBoundItem
       is not Employee employee)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(EditEmployeebutton.Text))
            {
                MessageBox.Show(
                    "Введите новое ФИО.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            await _directoryService.UpdateEmployeeAsync(
                employee.Id,
                EmplyeetextBox.Text);

            EmplyeetextBox.Clear();

            await LoadEmployeesAsync();
        }

        private async void DeleteEmployee_Click(object sender, EventArgs e)
        {
            if (EmplyeedataGridView.CurrentRow?.DataBoundItem
        is not Employee employee)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result = MessageBox.Show(
                $"Удалить сотрудника «{employee.FullName}»?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            await _directoryService.DeleteEmployeeAsync(
                employee.Id);

            await LoadEmployeesAsync();
        }

        private async void AddAnimalGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GroupAnimaltextBox.Text))
            {
                MessageBox.Show(
                    "Введите название группы.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            await _directoryService.AddAnimalGroupAsync(
                GroupAnimaltextBox.Text);

            GroupAnimaltextBox.Clear();

            await LoadAnimalGroupsAsync();
        }

        private async void EditAnimalGroup_Click(object sender, EventArgs e)
        {
            if (GroupAnimaldataGridView.CurrentRow?.DataBoundItem
       is not AnimalGroup group)
            {
                MessageBox.Show(
                    "Выберите группу животных.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(GroupAnimaltextBox.Text))
            {
                MessageBox.Show(
                    "Введите новое название группы.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            await _directoryService.UpdateAnimalGroupAsync(
                group.Id,
                GroupAnimaltextBox.Text);

            GroupAnimaltextBox.Clear();

            await LoadAnimalGroupsAsync();
        }

        private async void DeleteAnimalGroupbutton_Click(object sender, EventArgs e)
        {
            if (GroupAnimaldataGridView.CurrentRow?.DataBoundItem
      is not AnimalGroup group)
            {
                MessageBox.Show(
                    "Выберите группу животных.",
                    "Справочник",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result = MessageBox.Show(
                $"Удалить группу «{group.Name}»?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            await _directoryService.DeleteAnimalGroupAsync(
                group.Id);

            await LoadAnimalGroupsAsync();
        }

        private void EmplyeedataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var fullName = EmplyeedataGridView.Rows[e.RowIndex]
                .Cells["FullName"]
                .Value?.ToString();

            if (!string.IsNullOrWhiteSpace(fullName))
            {
                EmplyeetextBox.Text = fullName;
            }
        }

        private void GroupAnimaldataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var groupName = GroupAnimaldataGridView.Rows[e.RowIndex]
                .Cells["Name"]
                .Value?.ToString();

            if (!string.IsNullOrWhiteSpace(groupName))
            {
                GroupAnimaltextBox.Text = groupName;
            }
        }
    }
}
