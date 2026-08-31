using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.AuthorizationService;
using PromVesClientPlatform.Service.UserService;

namespace PromVesClientPlatform
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();
            services.AddDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(
                    "Host=localhost;Port=5432;Database=PromVesPlatformDb;Username=postgres;Password=6767669");
            });
            //регистрация форм
            services.AddTransient<Form1>();
            services.AddTransient<MainMenuForm>();
            services.AddTransient<UserForm>();
            //регистрация сервисов
            services.AddScoped<UserService>();
            services.AddScoped<HashPasswordService>();


            //регистрация одного экземпляра, чтобы все формы работали именно с ним
            services.AddSingleton<CurrentUserService>();

            services.AddLogging();
            var provider = services.BuildServiceProvider();
            ApplicationConfiguration.Initialize();
            Application.Run(
    provider.GetRequiredService<Form1>());
        }
    }
}