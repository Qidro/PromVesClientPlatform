using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.ComPortSettingService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PromVesClientPlatform
{
    public partial class ComPortSettingPort : Form
    {
        private readonly ComPortSettingService _comPortSettingService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILogger<ComPortSettingPort> _logger;
        public ComPortSettingPort(ComPortSettingService comPortSettingService, CurrentUserService currentUserService)
        {
            InitializeComponent();
            _comPortSettingService = comPortSettingService;
            _currentUserService = currentUserService;
        }

        private async void ComPortSettingPort_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Ты");
            await GetSettingComPortList();
            await GetSettingComPort();

        }
        //получение настроек из файла
        private async Task GetSettingComPort()
        {
            var result = await _comPortSettingService.GetSavedSettingComPort();
            if (result.Success == false)
            {
                MessageBox.Show($"Произошла ошибка получения данных с файла конфигурации с com порта, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                standartSetting();
                return;
            }
            var port = result.Data.SerialPorts[0];

            namePortComboBox.Text = port.PortName;
            baudRatecomboBox.Text = port.BaudRate.ToString();
            dataBitsComboBox.Text = port.DataBits.ToString();
            parityComboBox.Text = port.Parity.ToString();
            stopBitsComboBox.Text = port.StopBits.ToString();
            handshakeComboBox.Text = port.Handshake.ToString();
        }
        //сохранение вариантов настроек в ComBox
        private async Task GetSettingComPortList()
        {
            var result = await _comPortSettingService.GetNameComPort();
            //comboBox1.Items.Add("COM3");
            //перебираем результат списка com портов
            foreach (var comPortName in result)
            {
                namePortComboBox.Items.Add(comPortName);
            }
        }
        //метод выводит настройки по умолчанию
        private void button2_Click(object sender, EventArgs e)
        {
            //вызов метода со стандартными настройками
            standartSetting();
        }
        //запись стандартных настроек com порта
        private void standartSetting()
        {
            baudRatecomboBox.Text = "1200";
            dataBitsComboBox.Text = "8";
            parityComboBox.Text = "None";
            stopBitsComboBox.Text = "One";
            handshakeComboBox.Text = "None";
        }
        //созранение настроек
        private async void button1_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля комбокса
            if (groupBox1.Controls.OfType<System.Windows.Forms.ComboBox>().Any(x => x.SelectedIndex == -1))
            {
                MessageBox.Show("Не все параметры выбраны");
                return;
            }
            //сохроняем параметры в модель
            var settings = new SerialPortSettings
            {
                Id = 1,
                PortName = namePortComboBox.Text,
                BaudRate = Convert.ToInt32(baudRatecomboBox.SelectedItem),
                DataBits = Convert.ToInt32(dataBitsComboBox.SelectedItem),
                Parity = Enum.Parse<Parity>(parityComboBox.SelectedItem.ToString()),
                StopBits = Enum.Parse<StopBits>(stopBitsComboBox.SelectedItem.ToString()),
                Handshake = Enum.Parse<Handshake>(handshakeComboBox.SelectedItem.ToString())
            };
            //вызываем метод сохранения
            var result = await _comPortSettingService.SaveAsync(settings);
            //проверка выполнения
            if (result.Success == true)
            {
                MessageBox.Show("Файл с настройкми был успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Файл с настройками не был сохранен, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void handshakeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
