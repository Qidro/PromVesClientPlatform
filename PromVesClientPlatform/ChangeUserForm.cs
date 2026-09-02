using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PromVesClientPlatform
{
    public partial class ChangeUserForm : Form
    {
        private Guid _userId;
        private string userName;
        private string userPassword;
        private string userRole;
        private bool userActive;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ChangeUserForm> _logger;
        private readonly UserService _userService;
        //private readonly AppDbContext dbContext;
        public ChangeUserForm(IServiceProvider serviceProvider, ILogger<ChangeUserForm> logger, UserService userService, Guid userId)
        {
            InitializeComponent();
            _userId = userId;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _userService = userService;
            //_dbContext = dbContext;
        }

        private async void ChangeUserForm_Load(object sender, EventArgs e)
        {
            await FillingDataUser();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //подгрузка данных польззователя
        private async Task FillingDataUser()
        {
            //вызов метода получения данных пользователя
            var result = await _userService.GetUserAsync(_userId);
            //проверка на выполнение операции
            if (result.Success == true)
            {
                //записываем логин пользователя
                loginTextBox.Text = result.Data.Name;
                //выбираем элемент из списка ролей
                int index = roleComboBox.FindStringExact(result.Data.Role);
                if (index >= 0)
                {
                    roleComboBox.SelectedIndex = index;
                }
                //активность пользователя
                bool active = result.Data.Active;
                if (active == true)
                {
                    activeComboBox.SelectedItem = "Активный";
                }
                else
                {
                    activeComboBox.SelectedItem = "Неактивный";
                }
            }
            else
            {
                MessageBox.Show($"Ошибка получения данных пользователя, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //метод кнопки обнолвения данных пользователя
        private async void changeUserButton_Click(object sender, EventArgs e)
        {
            //проверка корректного вода пользователя
            if (String.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show("Введите корректный логин пользователя", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //проверка корректного ввода пароля
            //if (String.IsNullOrWhiteSpace(passwordTextBox.Text))
            //{
            //    MessageBox.Show("Введите корректный пароль пользователя", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //выбор активности
            if (activeComboBox.Text == "Активный")
            {
                userActive = true;
            }
            else
            {
                userActive = false;
            }
            //запись в поля результаов
            userName = loginTextBox.Text;
            userPassword = passwordTextBox.Text;
            userRole = roleComboBox.Text;
            //вызов метода по изменению данных пользователя
            var result = await _userService.ChangeUserAsync(_userId, userName, userRole, userActive, userPassword);
            //вывод результата
            if (result.Success == true)
            {
                MessageBox.Show("Пользователь был успешно обновлен", "Инфомарция", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FillingDataUser();
            }
            else
            {
                MessageBox.Show($"Пользователь не был обновлен, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
