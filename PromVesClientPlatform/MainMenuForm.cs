using Microsoft.Extensions.DependencyInjection;
using PromVesClientPlatform.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromVesClientPlatform
{
    public partial class MainMenuForm : Form
    {
        private readonly CurrentUserService _currentUserService;
        private readonly IServiceProvider _serviceProvider;
        public MainMenuForm(CurrentUserService currentUserService, IServiceProvider serviceProvider)
        {
            _currentUserService = currentUserService;
            _serviceProvider = serviceProvider; 
            InitializeComponent();
            //label1.Text = _currentUserService.CurrentUser?.Name;
            if (_currentUserService.CurrentUser?.Role != "admin")
            {
                menuStrip1.Enabled = true;
            }
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //открытие формы пользователей
            var form = _serviceProvider.GetRequiredService<ComPortSettingPort>();
            form.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //открытие формы пользователей
            var form = _serviceProvider.GetRequiredService<UserForm>();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ReceiptForm>();
            form.ShowDialog();
        }
    }
}
