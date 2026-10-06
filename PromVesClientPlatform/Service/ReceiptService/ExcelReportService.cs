using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using System.Diagnostics;

namespace PromVesClientPlatform.Service.ReceiptsService
{
    public class ExcelReportService
    {
        private readonly ILogger<ExcelReportService> _logger;

        public ExcelReportService(ILogger<ExcelReportService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Создание отчета и отправка его на печать.
        /// </summary>
        public async Task<ServiceResult> CreateReport(
            List<ReceiptDtoExcel> cards,
            string operatorName)
        {
            try
            {
                if (cards == null || cards.Count == 0)
                {
                    return ServiceResult.Fail(
                        "Нет данных для формирования отчета.");
                }

                string templatePath = Path.Combine(
                    AppContext.BaseDirectory,
                    "Templates",
                    "PlatformCardTemplate.xlsx");

                string reportPath = Path.Combine(
                    AppContext.BaseDirectory,
                    "Report.xlsx");

                using (var workbook = new XLWorkbook(templatePath))
                {
                    var ws = workbook.Worksheet(1);

                    FillReport(ws, cards, operatorName);

                    workbook.SaveAs(reportPath);
                }

                // Печать на принтер по умолчанию
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = reportPath,
                    Verb = "print",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                };

                Process.Start(psi);

                return ServiceResult.Ok();
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(
                    ex,
                    "Шаблон отчета отсутствует.");

                return ServiceResult.Fail(
                    $"Шаблон отчета отсутствует: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(
                    ex,
                    "Папка Templates отсутствует.");

                return ServiceResult.Fail(
                    $"Папка Templates отсутствует: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(
                    ex,
                    "Нет прав на изменение файла.");

                return ServiceResult.Fail(
                    $"Нет прав на изменение файла: {ex.Message}");
            }
            catch (IOException ex)
            {
                _logger.LogError(
                    ex,
                    "Файл занят другим процессом.");

                return ServiceResult.Fail(
                    $"Файл занят другим процессом: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка при создании отчета.");

                return ServiceResult.Fail(
                    $"Ошибка при создании отчета: {ex.Message}");
            }
        }

        /// <summary>
        /// Заполнение Excel-шаблона данными.
        /// </summary>
        private void FillReport(
            IXLWorksheet ws,
            List<ReceiptDtoExcel> cards,
            string operatorName)
        {
            // ==========================================
            // ШАПКА ОТЧЕТА
            // ==========================================

            ws.Cell("J1").Value = cards[0].Department;

            ws.Cell("G2").Value = cards[0].Brigade;

            ws.Cell("J3").Value = cards[0].GroupAnimals;

            ws.Cell("K4").Value = cards[0].ResponsibleEmployee;
            // Даты взвешиваний
            ws.Cell("L7").Value = cards[0].DateWeighingOld;
            ws.Cell("U7").Value = cards[0].WeighingDate;

            ws.Cell("L7").Style.DateFormat.Format = "dd.MM.yyyy";
            ws.Cell("U7").Style.DateFormat.Format = "dd.MM.yyyy";


            // ==========================================
            // ДАННЫЕ ПО ЖИВОТНЫМ
            // ==========================================

            int row = 9;

            foreach (var card in cards)
            {
                // Номер животного / станка
                ws.Cell(row, 1).Value = card.AnimalNumber ?? 0m;

                // Количество голов предыдущее
                ws.Cell(row, 6).Value = card.QuantityOld;

                // Предыдущее взвешивание
                ws.Cell(row, 10).Value = card.CurrentWeighingOld;

                // Предыдущий привес
                ws.Cell(row, 17).Value = card.WeightGainOld;

                // Количество голов текущее
                ws.Cell(row, 18).Value = card.Quantity;

                // Текущее взвешивание
                ws.Cell(row, 19).Value = card.CurrentWeighing;

                // Привес
                ws.Cell(row, 22).Value = card.WeightGain;

                row++;

                // В исходном шаблоне предусмотрено 7 строк.
                if (row > 15)
                    break;
            }


            // ==========================================
            // ИТОГИ
            // ==========================================

            decimal totalQuantity = cards
                .Where(x => x.Quantity.HasValue)
                .Sum(x => x.Quantity.Value);

            decimal totalWeight = cards
                .Sum(x => x.CurrentWeighing);

            decimal totalWeightGain = cards
                .Where(x => x.WeightGain.HasValue)
                .Sum(x => x.WeightGain.Value);


            // Количество голов
            ws.Cell("S16").Value = totalQuantity;

            // Масса
            ws.Cell("U16").Value = totalWeight;

            // Привес
            ws.Cell("V16").Value = totalWeightGain;


            // ==========================================
            // ФОРМАТИРОВАНИЕ ЧИСЕЛ
            // ==========================================

            ws.Range("A9:A15")
                .Style.NumberFormat.Format = "0";

            ws.Range("F9:F15")
                .Style.NumberFormat.Format = "0";

            ws.Range("J9:J15")
                .Style.NumberFormat.Format = "0.00";

            ws.Range("Q9:Q15")
                .Style.NumberFormat.Format = "0.00";

            ws.Range("R9:R15")
                .Style.NumberFormat.Format = "0";

            ws.Range("S9:U15")
                .Style.NumberFormat.Format = "0.00";

            ws.Range("V9:V15")
                .Style.NumberFormat.Format = "0.00";


            // ==========================================
            // ИТОГОВЫЕ ФОРМАТЫ
            // ==========================================

            ws.Cell("S16")
                .Style.NumberFormat.Format = "0";

            ws.Cell("U16")
                .Style.NumberFormat.Format = "0.00";

            ws.Cell("V16")
                .Style.NumberFormat.Format = "0.00";


            // ==========================================
            // ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
            // ==========================================

            // Если понадобится вывести дату/оператора
            // в дальнейшем, можно использовать область
            // ниже таблицы.

            _logger.LogInformation(
                "Отчет платформенных весов сформирован. " +
                "Количество записей: {Count}, оператор: {Operator}",
                cards.Count,
                operatorName);
        }


        /// <summary>
        /// Сохранение отчета в выбранный пользователем файл.
        /// </summary>
        public async Task<ServiceResult> SaveReport(
            List<ReceiptDtoExcel> cards,
            string savePath)
        {
            try
            {
                if (cards == null || cards.Count == 0)
                {
                    return ServiceResult.Fail(
                        "Нет данных для формирования отчета.");
                }

                if (string.IsNullOrWhiteSpace(savePath))
                {
                    return ServiceResult.Fail(
                        "Не указан путь для сохранения отчета.");
                }

                string templatePath = Path.Combine(
                    AppContext.BaseDirectory,
                    "Templates",
                    "PlatformCardTemplate.xlsx");

                using var workbook = new XLWorkbook(templatePath);

                var ws = workbook.Worksheet(1);

                FillReport(
                    ws,
                    cards,
                    string.Empty);

                workbook.SaveAs(savePath);

                return ServiceResult.Ok();
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(
                    ex,
                    "Шаблон отчета отсутствует.");

                return ServiceResult.Fail(
                    $"Шаблон отчета отсутствует: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(
                    ex,
                    "Папка Templates отсутствует.");

                return ServiceResult.Fail(
                    $"Папка Templates отсутствует: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(
                    ex,
                    "Нет прав на сохранение отчета.");

                return ServiceResult.Fail(
                    $"Нет прав на сохранение отчета: {ex.Message}");
            }
            catch (IOException ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка доступа к файлу отчета.");

                return ServiceResult.Fail(
                    $"Ошибка доступа к файлу: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Не удалось сохранить отчет.");

                return ServiceResult.Fail(
                    $"Не удалось сохранить отчет: {ex.Message}");
            }
        }
    }
}