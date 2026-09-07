using Microsoft.Extensions.Logging;
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

    }
}
