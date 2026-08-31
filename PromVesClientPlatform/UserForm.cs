using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
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
        private List<UserDto> _userList;
        public UserForm(UserService userService, ILogger<UserForm> logger, IServiceProvider serviceProvider)
        {
            _userService = userService;
            _logger = logger;
            _serviceProvider = serviceProvider;
            InitializeComponent();
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
    }
}
