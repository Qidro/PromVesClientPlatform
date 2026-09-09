using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Service;
using PromVesClientPlatform.Service.ReceiptService;
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
    public partial class ReceiptForm : Form
    {
        private readonly ReceiptService _receiptService;
        private List<ReceiptDto> receiptList;
        private List<CardsDto> cardsList = new();
        //поле для печати квитанции
        private string OperatorReceipt;
        private readonly ILogger<ReceiptForm> _logger;
        private readonly CurrentUserService _currentUserService;
        public ReceiptForm(ReceiptService receiptService, ILogger<ReceiptForm> logger, CurrentUserService currentUserService)
        {
            InitializeComponent();
            _receiptService = receiptService;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        private async void ReceiptForm_Load(object sender, EventArgs e)
        {
            await ReceiptLoad();
        }
        //загрузка предварительных данных из БД
        private async Task ReceiptLoad()
        {
            //вызываем метод получения квитанций из БД
            var result = await _receiptService.GetReceiptsListAsync();
            if (result.Success == false)
            {
                MessageBox.Show($"Произошла ошибка получения данных, причина: {result.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //копируем результат запроса в поле
            receiptList = result.Data;
            dataGridViewReceipts.DataSource = result.Data;
            //dataGridView2.DataSource = resulet.Data;
            dataGridViewReceipts.Columns["Id"].Visible = false;
            //dataGridView1.Columns["Weighings"].Visible = false;
            dataGridViewReceipts.Columns["DateTime"].HeaderText = "Дата и время";
            //dataGridView1.Columns["TypeWeighng"].HeaderText = "Тип взвешивания";
            dataGridViewReceipts.Columns["Operator"].HeaderText = "Оператор";
        }

        private async void dataGridViewReceipts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < receiptList.Count)
            {
                //MessageBox.Show(
                //    //$"Столбец: {e.ColumnIndex}\n" +
                //   // $"Строка: {e.RowIndex}\n" +
                //    $"Id: {receiptList[e.RowIndex].Id}\n" +
                //    $"Дата: {receiptList[e.RowIndex].DateTime}"
                //);

                //выводим информацию о времени создания квитанции
                receiptInfoLabel.Text = "Квитанция от " + receiptList[e.RowIndex].DateTime.ToString();
                //сохраняем выбранную квитанцию в поле
                OperatorReceipt = receiptList[e.RowIndex].Operator;
                var result = await _receiptService.GetCardsAsync(receiptList[e.RowIndex].Id);
                if (result.Success == true)
                {
                    cardsList = result.Data;
                    dataGridViewСards.DataSource = result.Data;
                    settingViewTable();

                }
                else
                {
                    MessageBox.Show("Не удалось вывести квитанцию, причина: " + result.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void settingViewTable()
        {
            dataGridViewСards.Columns["Id"].Visible = false;
            //dataGridViewСards.Columns["ReceiptId"].Visible = false;
            //dataGridViewСards.Columns["VagonNumber"].HeaderText = "Номер вагона";
            dataGridViewСards.Columns["GroupAnimals"].HeaderText = "Группа животных";
            dataGridViewСards.Columns["Department"].HeaderText = "Отделение";
            dataGridViewСards.Columns["Brigade"].HeaderText = "Бригада";
            dataGridViewСards.Columns["ResponsibleEmployee"].HeaderText = "За кем прикреплены животные";
            dataGridViewСards.Columns["AnimalNumber"].HeaderText = "Номер животного или станка";
            dataGridViewСards.Columns["Quantity"].HeaderText = "Количество";
            dataGridViewСards.Columns["PreviousWeigh"].HeaderText = "Предыдущее взвешивание";
            dataGridViewСards.Columns["DatePreviousWeighing"].HeaderText = "Дата предыдущего взвешивания";
            dataGridViewСards.Columns["CurrentWeighing"].HeaderText = "Текущее взвешивание";
            dataGridViewСards.Columns["WeightGain"].HeaderText = "Привес";
            dataGridViewСards.Columns["WeighingDate"].HeaderText = "Дата взвешивания (текущее)";

            //Запрещаем редактировать только данные взвешивания и даты взешивания
            dataGridViewСards.Columns["WeighingDate"].ReadOnly = true;
            dataGridViewСards.Columns["CurrentWeighing"].ReadOnly = true;

            dataGridViewСards.Columns["WeighingDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridViewСards.Columns["DatePreviousWeighing"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private async void btnDeleteCard_Click(object sender, EventArgs e)
        {
            if (dataGridViewСards.CurrentRow != null)
            {

                //MessageBox.Show($"Номер строки: {dataGridViewСards.CurrentRow.Index}");
                DialogResult resultConfirmation = MessageBox.Show(
                "Вы действительно хотите удалить карточку вагона?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                //проверка на выбор пользователя
                if (resultConfirmation == DialogResult.Yes)
                {
                    _logger.LogInformation($"Пользователь {_currentUserService.CurrentUser?.Name} нажал кнопку удаления карточки вагона");
                    // Выполнить удаление
                    var result = await _receiptService.deletingCard(cardsList[dataGridViewСards.CurrentRow.Index].Id);
                    if (result.Success == true)
                    {
                        MessageBox.Show(
                        "Каточка успешно удалена",
                        "Удаление карточки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        cardsList.RemoveAt(dataGridViewСards.CurrentRow.Index);
                        dataGridViewСards.DataSource = null;
                        dataGridViewСards.DataSource = cardsList;
                        settingViewTable();
                        //await loadingTableData();
                        //dataGridViewСards.DataSource = null;
                        //receiptInfoLabel.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(
                        $"Карточка не удалина, причина: {result.Message}",
                        "Ошибка удаления квитанции",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }
                else
                {
                    // Пользователь нажал "Нет"
                    MessageBox.Show(
                        "В начале выберите карточку",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Перед удалением выберите карточку, которую хотели бы удалить", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //метод удаления квитанции
        private async void btnDeleteReceipt_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceipts.CurrentRow != null)
            {
                //MessageBox.Show($"Номер строки: {dataGridViewСards.CurrentRow.Index}");
                DialogResult resultConfirmation = MessageBox.Show(
                "Вы действительно хотите удалить карточку вагона?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                //проверка на выбор пользователя
                if (resultConfirmation == DialogResult.Yes)
                {
                    _logger.LogInformation($"Пользователь {_currentUserService.CurrentUser?.Name} нажал кнопку удаления квитанции");
                    // Выполнить удаление
                    var result = await _receiptService.deletingReceipt(receiptList[dataGridViewReceipts.CurrentRow.Index].Id);
                    if (result.Success == true)
                    {
                        MessageBox.Show(
                        "Квитанция успешно удалена",
                        "Удаление квитанции",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        await ReceiptLoad();
                        dataGridViewСards.DataSource = null;
                        receiptInfoLabel.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(
                        $"Квитанция не удалина, причина: {result.Message}",
                        "Ошибка удаления квитанции",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }
                else
                {
                    // Пользователь нажал "Нет"
                }
            }
            else
            {
                MessageBox.Show("Перед удалением выберите квитанцию, которую хотели бы удалить", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnReportFilter_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
