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
                      QuantityOld = w.QuantityOld,
                      CurrentWeighing = w.CurrentWeighing,
                      CurrentWeighingOld = w.CurrentWeighingOld,
                      DatePreviousWeighing = w.DatePreviousWeighing,
                      WeightGain = w.WeightGain,
                      WeightGainOld = w.WeightGainOld,
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
        //метод поиска квитанций по фильтрам
        public async Task<ServiceResult<List<ReceiptDto>>> GetSearchReceiptAsync(SearchReceiptDto filter)
        {
            try
            {
                //AsQueryable подчеркивает, что далее запрос будет строиться динамически (добавляться)
                var query = _dbContext.Receipts.AsQueryable();
                //период
                query = query.Where( r =>
                r.DateTime >= filter.periodStart &&
                r.DateTime <= filter.periodEnd);
                //поиск оператора
                if (!string.IsNullOrWhiteSpace(filter.Operator))
                {
                    query = query.Where( r =>
                    r.Operator == filter.Operator);
                }
                //поиск Группы животных
                if (!string.IsNullOrWhiteSpace(filter.GroupAnimals))
                {
                    query = query.Where( r =>
                        r.Weighings.Any(w => w.GroupAnimals == filter.GroupAnimals));
                }
                //поиск департамента
                if (!string.IsNullOrWhiteSpace(filter.Department))
                {
                    query = query.Where( r=>
                        r.Weighings.Any(w => w.Department == filter.Department));
                }
                //поиск Бригады
                if (!string.IsNullOrWhiteSpace(filter.Brigade))
                {
                    query = query.Where(r =>
                    r.Weighings.Any(w => w.Brigade == filter.Brigade));
                }
                //поиск за кем прикреплены животные
                if (!string.IsNullOrWhiteSpace(filter.ResponsibleEmployee))
                {
                    query = query.Where(r=>
                    r.Weighings.Any(w => w.ResponsibleEmployee == filter.ResponsibleEmployee));
                }
                //поиск номера или станка
                if (filter.AnimalNumber.HasValue)
                {
                    query = query.Where(r =>
                    r.Weighings.Any(w => w.AnimalNumber == filter.AnimalNumber));
                }
                //количество животных
                if (filter.Quantity.HasValue)
                {
                    query = query.Where(r =>
                    r.Weighings.Any(w=> w.Quantity == filter.Quantity));
                }
                //делаем запрос
                var reseiptFilter = await query.Select(
                    r=> new ReceiptDto
                    { 
                        Id = r.Id,
                        DateTime = r.DateTime,
                        Operator = r.Operator,
                    })
                    .ToListAsync();
                return new ServiceResult<List<ReceiptDto>>
                {
                    Success = true,
                    Data = reseiptFilter
                };
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
            //return ServiceResult<List<ReceiptDto>>.Fail("");
        }
    }
}
