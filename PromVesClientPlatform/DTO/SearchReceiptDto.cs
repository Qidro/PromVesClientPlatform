using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class SearchReceiptDto
    {
        //период с
        public DateTime periodStart { get; set; }
        //период по
        public DateTime periodEnd { get; set; }
        //оператор
        public string? Operator { get; set; }
        //группа животных
        public string? GroupAnimals { get; set; }
        //public DateTime DateTime { get; set; }
        //отделение
        public string? Department { get; set; }
        //бригада
        public string? Brigade { get; set; }
        //За кем прикреплены животные
        public string? ResponsibleEmployee { get; set; }
        //номер животного или станка
        public decimal? AnimalNumber { get; set; }
        //Количество
        public decimal? Quantity { get; set; }


    }
}
