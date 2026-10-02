using Microsoft.Extensions.Logging;
using PromVesClient.Service.TcpService;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.AnimalWeighingService;
using PromVesClientPlatform.Service.DirectoryService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromVesClientPlatform
{
    public partial class StaticForm : Form
    {
        //DI
        private readonly CurrentUserService _currentUserService;
        //логи
        private readonly ILogger<StaticForm> _logger;

        private readonly AnimalWeighingService _animalweighingservice;
        //обьект, который отвечает за подключение/отключение/получение данных сервера
        private readonly TcpService _tcpService;
        private Guid IdReceipt;
        //коллекциями с ссылка на картинки 
        private List<PictureBox> pictureBoxesList;
        private ScottPlot.Plottables.Signal signal;
        //сохранение ссылок на обьекты графиков
        private List<ScottPlot.WinForms.FormsPlot> plots;
        private readonly Queue<decimal> values = new();
        private readonly System.Windows.Forms.Timer graphTimer = new();
        private readonly DirectoryService _directoryService;

        private decimal currentWeight;

        public StaticForm(
            CurrentUserService currentUserService,
            ILogger<StaticForm> logger,
            AnimalWeighingService animalweighingservice,
            TcpService tcpService,
            DirectoryService directoryService)
        {
            _logger = logger;
            _animalweighingservice = animalweighingservice;
            _currentUserService = currentUserService;
            _tcpService = tcpService;
            _directoryService = directoryService;

            InitializeComponent();
            //регистрации метода на ожидание новых данных
            _tcpService.MessageReceived += ProcessMessage;
            //регистрация метода на ожидание ошибок
            _tcpService.ConnectionError += OnConnectionError;
            //добавляем при закрытии формы проверку на окончания взвешивания
            this.FormClosing += Form1_FormClosing;
            // таймер графика
            graphTimer.Interval = 1000;
            graphTimer.Tick += GraphTimer_Tick;
            formsPlot1.Refresh();
            //сохраняем ссылки
            pictureBoxesList = new List<PictureBox>
            {
                pictureBox6,
                pictureBox5,
                pictureBox4,
                pictureBox3,
                pictureBox2,
                pictureBox1
            };

            // начальное значение дисплея
            pictureBox1.Image = Properties.Resources._00;
            pictureBox2.Image = Properties.Resources._00;
            pictureBox3.Image = Properties.Resources._00;
            pictureBox4.Image = Properties.Resources._0t;
            pictureBox5.Image = Properties.Resources._0;
            pictureBox6.Image = Properties.Resources._0;
        }

        //событие ошибки
        private async void OnConnectionError(Exception ex)
        {
            BeginInvoke(() =>
            {
                graphTimer.Stop();
                MessageBox.Show(
                    ex.Message + ". Пытаемся переподключиться",
                    "Ошибка сервера",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            });
            //переподключение к серверу
            while (true)
            {
                try
                {
                    await _tcpService.DisconnectAsync();

                    await Task.Delay(5000);

                    await _tcpService.ConnectAsync();

                    BeginInvoke(() =>
                    {
                        graphTimer.Start();
                    });

                    break;
                }
                catch (Exception reconnectEx)
                {
                    _logger.LogWarning(reconnectEx,
                        "Не удалось подключиться. Повтор через 5 секунд.");
                }
            }
        }
        //метод для события(получения данных с сервака) по обработке полцченных данных
        private void ProcessMessage(string message)
        {
            try
            {
                ConnectionScalesCheck(message);
                string text = message.Trim()
            .Replace(',', '.');
                if (!decimal.TryParse(
                text,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal weight))
                {
                    _logger.LogWarning(
                        "Некорректное значение веса: {Message}",
                        message);

                    return;
                }
                // Полученное значение используем как есть
                currentWeight = weight;
                // Вывод на цифровое табло
                _ = DisplayingValue(currentWeight);
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(ex, "Некорректный формат данных");
            }
            catch (IndexOutOfRangeException ex)
            {
                _logger.LogWarning(ex, "Получено неполное сообщение");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обработки сообщения");
            }
        }
        //создание точек на графике
        private void AddPoint(decimal value)
        {
            if (values.Count == 300)
                values.Dequeue();

            values.Enqueue(value);

            formsPlot1.Plot.Clear();

            formsPlot1.Plot.Add.Signal(
                values.ToArray());

            formsPlot1.Plot.Axes.SetLimits(
                left: 0,
                right: Math.Max(1, values.Count - 1));

            formsPlot1.Plot.Axes.AutoScaleY();

            formsPlot1.Refresh();
        }
        //ивент на закрытие формы, если взвешивание активно - форма не будет закрыта и будет предупреждение
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Weighingbtn.Text.Equals("Начать взвешивание", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                "Сначала закончите взвешивание!",
                "Предупреждение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }
        //метод записи значений на табло
        private async Task DisplayingValue(decimal sumeWeight)
        {
            var ListValuesImage = await _animalweighingservice.GetImageWeighingAsync(sumeWeight);
            for (int i = 0; ListValuesImage.Count > i; i++)
            {
                if (pictureBoxesList.Count - 1 >= i)
                {
                    pictureBoxesList[i].Image = ListValuesImage[i];
                }

            }
        }
        //метод таймера
        private void GraphTimer_Tick(
           object? sender,
           EventArgs e)
        {
            AddPoint(currentWeight);
        }
        //проверка сообщения от сервера на связь с весами
        private bool ConnectionScalesCheck(string data)
        {
            string[] parts = data.Split(';');
            for (int i = 0; parts.Length > i; i++)
            {
                //проверка на то, что сервер прислал, что соединения с весами нет - обозначаем это
                if (parts[i] == "OFFLINE")
                {
                    //выводим, что соединение нет
                    lblConnectScale.BackColor = Color.Red;
                    return false;
                }
            }
            //выводим, что соединение есть
            lblConnectScale.BackColor = Color.Green;
            return true;
        }

        //нажатие на кнопку, которое отвечает за подключение к серверу и получению данных от него
        //либо его отключение от сервера
        private async void Weighingbtn_Click_1(object sender, EventArgs e)
        {
            if (Weighingbtn.Text == "Начать взвешивание")
            {
                try
                {
                    await _tcpService.ConnectAsync();
                    //начали взвешивание - данные можно сохранить
                    Weighingbtn.Enabled = true;
                    graphTimer.Start();
                    IdReceipt = Guid.NewGuid();
                    Weighingbtn.Text = "Закончить взвешивание";
                }
                catch (Exception ex)
                {
                    _logger.LogError("Ошибка: " + ex.Message.ToString());
                    await _tcpService.DisconnectAsync();
                    graphTimer.Stop();
                    MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

            }
            else
            {
                await _tcpService.DisconnectAsync();
                graphTimer.Stop();
                Weighingbtn.Text = "Начать взвешивание";
            }
        }

        //метод для сохранения данных взвешивания в БД
        private async void Savebtn_Click_1(object sender, EventArgs e)
        {
            // животное / станок
            if (string.IsNullOrWhiteSpace(
                AnimalNumbertextBox.Text))
            {
                MessageBox.Show(
                    "Введите номер животного или станка",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // количество
            if (string.IsNullOrWhiteSpace(
                QuantitytextBox.Text))
            {
                MessageBox.Show(
                    "Введите количество животных",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ============================================
            // ПАРСИНГ НОМЕРА ЖИВОТНОГО
            // ============================================

            string animalNumberText =
                AnimalNumbertextBox.Text.Trim()
                .Replace(',', '.');

            if (!decimal.TryParse(
                    animalNumberText,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal animalNumber))
            {
                MessageBox.Show(
                    "Введите корректный номер животного или станка",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ============================================
            // ПАРСИНГ КОЛИЧЕСТВА
            // ============================================

            string quantityText =
                QuantitytextBox.Text.Trim()
                .Replace(',', '.');

            if (!decimal.TryParse(
                    quantityText,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal quantity))
            {
                MessageBox.Show(
                    "Введите корректное количество",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ============================================
            // СОХРАНЕНИЕ КВИТАНЦИИ
            // ============================================

            var receiptResult =
                await _animalweighingservice.saveReceiptAsync(
                    IdReceipt,
                    _currentUserService.CurrentUser.Name);

            if (!receiptResult.Success)
            {
                MessageBox.Show(
                    "Квитанция не была сохранена. Причина: "
                    + receiptResult.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // ============================================
            // DTO
            // ============================================

            WeighingDto dtoWeighing = new WeighingDto
            {
                CurrentWeighing = currentWeight,

                GroupAnimals = GroupAnimalscomboBox.Text,

                Department = DepartmenttextBox.Text,

                Brigade = BrigadetextBox.Text,

                ResponsibleEmployee = ResponsibleEmployeecomboBox.Text,

                AnimalNumber = animalNumber,

                Quantity = quantity,

                IdReceipt = IdReceipt
            };


            // ============================================
            // СОХРАНЕНИЕ ВЗВЕШИВАНИЯ
            // ============================================

            var result =
                await _animalweighingservice
                    .saveWeighingAsync(dtoWeighing);


            if (!result.Success)
            {
                MessageBox.Show(
                    "Данные взвешивания не были сохранены в БД. Причина: "
                    + result.Message,
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            MessageBox.Show(
                "Данные успешно сохранены в БД",
                "Данные сохранены",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private async Task LoadDirectoriesAsync()
        {
            var employees = await _directoryService.GetEmployeesAsync();

            ResponsibleEmployeecomboBox.DataSource = employees;
            ResponsibleEmployeecomboBox.DisplayMember = nameof(Employee.FullName);
            ResponsibleEmployeecomboBox.ValueMember = nameof(Employee.Id);


            var groups = await _directoryService.GetAnimalGroupsAsync();

            GroupAnimalscomboBox.DataSource = groups;
            GroupAnimalscomboBox.DisplayMember = nameof(AnimalGroup.Name);
            GroupAnimalscomboBox.ValueMember = nameof(AnimalGroup.Id);
        }

        private async void StaticForm_Load(object sender, EventArgs e)
        {
            await LoadDirectoriesAsync();
        }
    }
}
