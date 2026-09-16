using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    WeighingDate = DateTime.Now,
                    DatePreviousWeighing = lastWeighing?.WeighingDate,
                    ReceiptId = dtoWeighing.IdReceipt
                };
                _dbContext.Weighings.Add(weighingResult);
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Ошибка обновления БД:" + ex.Message);
                return ServiceResult.Fail("Ошибка обновления БД: " + ex.Message);
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


    }
    
}