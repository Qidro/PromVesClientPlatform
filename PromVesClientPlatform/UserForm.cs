using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.ApplicationServices;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.AuthorizationService;
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
    public partial class UserForm : Form
    {
        private readonly UserService _userService;
        private readonly ILogger<UserForm> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly CurrentUserService _currentUserService;
        private List<UserDto> _userList;
        public UserForm(UserService userService, ILogger<UserForm> logger, IServiceProvider serviceProvider, CurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
            _logger = logger;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            createUserDataGridView.AllowUserToAddRows = false;

            // Создаём одну обычную строку
            createUserDataGridView.Rows.Add();
            //dataGridView1.AllowUserToAddRows = false;
            //Load += UserForm_Load;
        }
        //подгрузка данных для формы
        private async void UserForm_Load(object sender, EventArgs e)
        {
            await LoadDataTableAsync();
        }
        //загрузка полученных данных пользователей из БД
        private async Task LoadDataTableAsync()
        {
            var result = await _userService.GetUsersListAsync();
            //проверяем успешность операции
            if (result.Success == false)
            {
                MessageBox.Show($"Ошибка получения списка пользователей из БД, причина: {result.Data}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //сохраняем полученные данные в List и выводим их в таблицу
                _userList = result.Data;
                usersDataGridView.DataSource = _userList;
                //изменяем отображенние столбца
                usersDataGridView.Columns["Id"].Visible = false;
                //изменяем название у столбцов
                usersDataGridView.Columns["Name"].HeaderText = "Логин";
                usersDataGridView.Columns["Role"].HeaderText = "Роль пользователя";
                usersDataGridView.Columns["Active"].HeaderText = "Активность";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        //метод создания пользователя
        private async void createUserButton_Click(object sender, EventArgs e)
        {
            //записываем данные в перменные
            string login = createUserDataGridView.Rows[0].Cells[0].Value?.ToString();
            string role = createUserDataGridView.Rows[0].Cells[1].Value?.ToString();
            bool active = Convert.ToBoolean(createUserDataGridView.Rows[0].Cells[2].Value);
            string password = createUserDataGridView.Rows[0].Cells[3].Value?.ToString();
            //проверка данных на корректность
            //ячейки логина
            if (String.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите корректное имя пользователя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (String.IsNullOrEmpty(role)) //ячейки роли
            {
                MessageBox.Show("Выберите роль пользователя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (String.IsNullOrEmpty(password)) //ячейки паспорта
            {
                MessageBox.Show("Введите корректный пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //вызов метода создания нового пользователя
            var result = await _userService.CreateUserAsync(login, role, active, password);
            //проверка результата
            if (result.Success == true)
            {
                MessageBox.Show("Пользователь был успешно создан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //вызов метода обновления таблицы пользователей
                await LoadDataTableAsync();
                createUserDataGridView.Rows.Clear();
                // Создаём одну обычную строку
                createUserDataGridView.Rows.Add();
            }
            else
            {
                MessageBox.Show($"Пользователь не был создан, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MessageBox.Show(login);
            //MessageBox.Show(role);
            //MessageBox.Show(active);
            //MessageBox.Show(password);
        }
        //метод удаления пользователей
        private async void deleateUserButton_Click(object sender, EventArgs e)
        {

            if (usersDataGridView.CurrentCell != null)
            {
                //получаем номер строку
                int rowIndex = usersDataGridView.CurrentCell.RowIndex;
                //получаем Id пользователя
                Guid value = (Guid)usersDataGridView.Rows[rowIndex].Cells[0].Value;
                //проверка на удаление самого себя
                if (_currentUserService.CurrentUser?.Id == value)
                {
                    MessageBox.Show("Нельзя удалить самого себя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //вызываем метод по удалению пользолвателя
                var result = await _userService.DeleateUserAsync(value);
                if (result.Success == true)
                {
                    MessageBox.Show("Пользователь был удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //вызов метода обновления таблицы пользователей
                    await LoadDataTableAsync();
                }
                else
                {
                    MessageBox.Show($"Пользователь не удален причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //MessageBox.Show(value);
            }
        }
        //изменить данные пользователя
        private async void changeUserButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentCell != null)
            {
                //получаем номер строку
                int rowIndex = usersDataGridView.CurrentCell.RowIndex;
                //получаем Id пользователя
                Guid value = (Guid)usersDataGridView.Rows[rowIndex].Cells[0].Value;
                if (_currentUserService.CurrentUser?.Id == value)
                {
                    MessageBox.Show("Нельзя изменить самого себя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var form = ActivatorUtilities.CreateInstance<ChangeUserForm>(
                _serviceProvider,
                value);
                form.ShowDialog();
                //вызов метода обновления таблицы пользователей
                await LoadDataTableAsync();
                //MessageBox.Show(value);
            }
        }
    }
}
