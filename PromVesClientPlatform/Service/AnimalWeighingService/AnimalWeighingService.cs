using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Service.AnimalWeighingService
{
    public class AnimalWeighingService
    {
        private readonly ILogger<AnimalWeighingService> _logger;
        private readonly ApplicationDbContext _dbContext;

        public AnimalWeighingService(
            ILogger<AnimalWeighingService> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<ServiceResult> saveWeighingAsync(WeighingDto dtoWeighing)
        {
            try
            {
                //поиск последней записи по номеру животного или станка, чтобы получить дату предыдущего взвешивания
                var lastWeighing = await _dbContext.Weighings
            .Include(w => w.Receipt)
            .Where(w => w.AnimalNumber == dtoWeighing.AnimalNumber)
            .OrderByDescending(w => w.Receipt.DateTime)
            .FirstOrDefaultAsync();
                //записываем в модель данные взвешивания
                var weighingResult = new Weighing
                {
                    Id = Guid.NewGuid(),
                    GroupAnimals = dtoWeighing.GroupAnimals,
                    Department = dtoWeighing.Department,
                    Brigade = dtoWeighing.Brigade,
                    ResponsibleEmployee = dtoWeighing.ResponsibleEmployee,
                    AnimalNumber = dtoWeighing.AnimalNumber,
                    Quantity = dtoWeighing.Quantity,
                    QuantityOld = lastWeighing?.QuantityOld,
                    CurrentWeighing = dtoWeighing.CurrentWeighing,
                    CurrentWeighingOld = lastWeighing?.CurrentWeighing,
                    WeightGain = dtoWeighing.CurrentWeighing - (lastWeighing?.CurrentWeighing ?? 0),
                    WeightGainOld = lastWeighing?.WeightGain,
                    WeighingDate = DateTime.UtcNow,
                    DatePreviousWeighing = lastWeighing?.WeighingDate,
                    ReceiptId = dtoWeighing.IdReceipt
                };
                _dbContext.Weighings.Add(weighingResult);
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка обновления БД. InnerException: {InnerException}",
                    ex.InnerException?.Message);

                return ServiceResult.Fail(
                    "Ошибка обновления БД: " +
                    ex.InnerException?.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Ошибка выполнения запроса: " + ex.Message);
                return ServiceResult.Fail("Ошибка выполнения запроса: " + ex.Message);
                //  return ServiceResult.Fail("Ошибка выполнения запроса.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка получения данных: " + ex.Message);
                return ServiceResult.Fail("Ошибка получения данных: " + ex.Message);
            }
        }

            //метод создания квитанции
        public async Task<ServiceResult> saveReceiptAsync(Guid Id, string Operator)
        {
            var receipt = new Receipt
            {
                Id = Id,
                DateTime = DateTime.UtcNow,
                Operator = Operator
            };

            try
            {
                bool exists = await _dbContext.Receipts.AnyAsync(r => r.Id == receipt.Id);
                if (!exists)
                {
                    _dbContext.Receipts.Add(receipt);
                    await _dbContext.SaveChangesAsync();
                    
                }
                else
                {
                    // Квитанция уже существует
                }
                return ServiceResult.Ok();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Ошибка обновления БД:" + ex.Message);
                return ServiceResult.Fail("Ошибка обновления БД: " + ex.Message);
            }

            catch (Exception ex)
            {
                return ServiceResult.Fail("Ошибка в записи в БД: " + ex.Message);
            }

        }
        //метод предназначен для получения коллекции изображений для табла общего веса
        public async Task<List<Image>> GetImageWeighingAsync(decimal weightSum)
        {
            List<Image> images = new List<Image>();
            //преобразуем массив в string формат
            string weightSumString = weightSum.ToString("F2");
            Console.WriteLine(weightSumString);
            //начиаем проход массива с конца
            for (int i = weightSumString.Length - 1; i >= 0; i--)
            {
                //вычисляем проход по цикла
                int iteration = weightSumString.Length - 1 - i;

                if (weightSumString.Length - 1 < i)
                {
                    images.Add(Properties.Resources._00);
                }
                //проверяем на третьем проходе массива ли мы 
                if (iteration == 3)
                {
                    //сохраняем значения согласну элементу (значение с запятой)
                    switch (weightSumString[i])
                    {
                        case '0':
                            images.Add(Properties.Resources._0t);
                            break;
                        case '1':
                            images.Add(Properties.Resources._1t);
                            break;
                        case '2':
                            images.Add(Properties.Resources._2t);
                            break;
                        case '3':
                            images.Add(Properties.Resources._3t);
                            break;
                        case '4':
                            images.Add(Properties.Resources._4t);
                            break;
                        case '5':
                            images.Add(Properties.Resources._5t);
                            break;
                        case '6':
                            images.Add(Properties.Resources._6t);
                            break;
                        case '7':
                            images.Add(Properties.Resources._7t);
                            break;
                        case '8':
                            images.Add(Properties.Resources._8t);
                            break;
                        case '9':
                            images.Add(Properties.Resources._9t);
                            break;

                    }
                }
                else
                {
                    //сохраняем значения согласну элементу (значение без запятой)
                    switch (weightSumString[i])
                    {
                        case '0':
                            images.Add(Properties.Resources._0);
                            break;
                        case '1':
                            images.Add(Properties.Resources._1);
                            break;
                        case '2':
                            images.Add(Properties.Resources._2);
                            break;
                        case '3':
                            images.Add(Properties.Resources._3);
                            break;
                        case '4':
                            images.Add(Properties.Resources._4);
                            break;
                        case '5':
                            images.Add(Properties.Resources._5);
                            break;
                        case '6':
                            images.Add(Properties.Resources._6);
                            break;
                        case '7':
                            images.Add(Properties.Resources._7);
                            break;
                        case '8':
                            images.Add(Properties.Resources._8);
                            break;
                        case '9':
                            images.Add(Properties.Resources._9);
                            break;

                    }
                }
                //char u = weightSumString[i];
                if (i == 0 && iteration != 6)
                {
                    for (int j = 0; j < 6 - iteration; j++)
                    {
                        images.Add(Properties.Resources._00);
                    }
                }
            }

            return images;
        }
        //получение локального ip адреса компьютера
        public async Task<IPAddress> GetLocalIPAddressAsync()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            }

            throw new Exception("Локальный IPv4 адрес не найден.");
        }
    }
    
}