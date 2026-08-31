using Microsoft.Extensions.DependencyInjection;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.AuthorizationService;

namespace PromVesClientPlatform
{
    public partial class Form1 : Form
    {
        private readonly UserService _userService;
        private readonly IServiceProvider _serviceProvider;
        private readonly CurrentUserService _currentUserService;
        public Form1(UserService userService, IServiceProvider serviceProvider, CurrentUserService currentUserService)
        {
            _userService = userService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;
            InitializeComponent();
        }
        private string Login;
        private string Password;
        //кнопка по авторизации пользователя
        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле логина", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле пароля", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Login = textBoxLogin.Text;
            Password = textBoxPassword.Text;
            //AuthorizationUserAsync
            //var result = await _userService.CreateUserAsync(Login, Password, "admin");
            var result = await _userService.AuthorizationUserAsync(Login, Password);
            if (result.Success != true)
            {
                MessageBox.Show($"{result.Message}", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _currentUserService.Login(result.Data!);
                //открытие формы
                var form = _serviceProvider.GetRequiredService<MainMenuForm>();
                form.ShowDialog();
            }
        }
    }
}
