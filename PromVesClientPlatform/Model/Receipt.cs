using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Model
{
    public class Receipt
    {
        public Guid Id { get; set; }
        //время создания квитанции
        public DateTime DateTime { get; set; }
        //оператор взвегивния
        public string Operator { get; set; }
        // Навигационное свойство
        public ICollection<Weighing> Weighings { get; set; } = new List<Weighing>();
    }
}
