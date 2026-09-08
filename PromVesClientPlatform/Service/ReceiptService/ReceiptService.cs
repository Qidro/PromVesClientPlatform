using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Service.ReceiptService
{
    public class ReceiptService
    {
        private readonly ILogger<ReceiptService> _logger;
        private readonly ApplicationDbContext _dbContext;
        public ReceiptService(ILogger<ReceiptService> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        //получение квитанция из Бд
        public async Task<ServiceResult<List<ReceiptDto>>> GetReceiptsListAsync()
        {
            try 
            {
                //получаем лист квитанций
                var ReceiptList = await _dbContext.Receipts
                  .Select(r => new ReceiptDto
                  {
                      Id = r.Id,
                      DateTime = DateTime.SpecifyKind(r.DateTime, DateTimeKind.Utc)
                                   .ToLocalTime(),
                      Operator = r.Operator
                  })
                  .ToListAsync();
                return ServiceResult<List<ReceiptDto>>.Ok(ReceiptList);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError("Привышенно время ожидания ответа: " + ex.Message);
                return ServiceResult<List<ReceiptDto>>.Fail("БД не отвечает, причина: " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError("Ошибка сервера БД: " + ex.Message);
                return ServiceResult<List<ReceiptDto>>.Fail("Ошибка сервера БД: " + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Неизвестная ошибка БД: " + ex.Message);
                return ServiceResult<List<ReceiptDto>>.Fail("Неизвестная ошибка БД: " + ex.Message);
            }
        }
        //метод получения карточек взвешивания
        public async Task<ServiceResult<List<CardsDto>>> GetCardsAsync(Guid Id)
        {
            try 
            {
                //заполняем лист данными
                var cardsList = await _dbContext.Weighings
                  .AsNoTracking()
                  .Where(x => x.ReceiptId == Id)
                  .Select(w => new CardsDto
                  {
                      Id = w.Id,
                      GroupAnimals = w.GroupAnimals,
                      Department = w.Department,
                      Brigade = w.Brigade,
                      ResponsibleEmployee = w.ResponsibleEmployee,
                      AnimalNumber = w.AnimalNumber,
                      Quantity = w.Quantity,
                      PreviousWeigh = w.PreviousWeigh,
                      DatePreviousWeighing = w.DatePreviousWeighing,
                      CurrentWeighing = w.CurrentWeighing,
                      WeightGain = w.WeightGain,
                      WeighingDate = w.WeighingDate
                  })
                  .ToListAsync();
                return ServiceResult<List<CardsDto>>.Ok(cardsList);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError("Привышенно время ожидания ответа: " + ex.Message);
                return ServiceResult<List<CardsDto>>.Fail("БД не отвечает, причина: " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError("Ошибка сервера БД: " + ex.Message);
                return ServiceResult<List<CardsDto>>.Fail("Ошибка сервера БД: " + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Неизвестная ошибка БД: " + ex.Message);
                return ServiceResult<List<CardsDto>>.Fail("Неизвестная ошибка БД: " + ex.Message);
            }
        }
        //метод удаления карточки взвешивания
        public async Task<ServiceResult> deletingCard(Guid Id)
        {
            try 
            {
                //поиск каточки по id
                var weighing = await _dbContext.Weighings.FindAsync(Id);
                //проверяем карточку, есть ли она или нет
                if (weighing == null)
                {
                    return ServiceResult.Fail("Карточки не была найдена");
                }
                //удаляем карточку взвешивания
                _dbContext.Weighings.Remove(weighing);
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления карточки");
                return ServiceResult.Fail("Ошибка удаления.");
            }
        }
        //метод удаления квитанции взвешивания
        public async Task<ServiceResult> deletingReceipt(Guid Id)
        {
            try
            {
                //поиск каточки по id
                var receipt = await _dbContext.Receipts.FindAsync(Id);
                //проверяем карточку, есть ли она или нет
                if (receipt == null)
                {
                    return ServiceResult.Fail("Квитанция не была найдена");
                }
                //удаляем карточку взвешивания
                _dbContext.Receipts.Remove(receipt);
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления квитанции");
                return ServiceResult.Fail("Ошибка удаления.");
            }
        }
    }
}
