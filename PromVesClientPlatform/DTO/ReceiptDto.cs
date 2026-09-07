using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class ReceiptDto
    {
        public Guid Id { get; set; }
        //время создания квитанции
        public DateTime DateTime { get; set; }
        //оператор взвегивния
        public string Operator { get; set; }
    }
}
