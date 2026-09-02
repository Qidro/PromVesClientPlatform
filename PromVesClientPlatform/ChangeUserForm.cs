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

        private void changeUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}
