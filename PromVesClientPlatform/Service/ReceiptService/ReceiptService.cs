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
    }
}
