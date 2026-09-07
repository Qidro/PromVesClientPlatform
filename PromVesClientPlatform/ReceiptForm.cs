using PromVesClientPlatform.DTO;
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
        public ReceiptForm(ReceiptService receiptService)
        {
            InitializeComponent();
            _receiptService = receiptService;
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
                MessageBox.Show($"Произошла ошибка получения данных, причина: {result.Message}","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
