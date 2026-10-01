using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class WeighingDto
    {
        public Guid Id { get; set; }
        //Вешивание
        public decimal CurrentWeighing { get; set; }
        //группа животных
        public string? GroupAnimals { get; set; }
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
        public Guid IdReceipt { get; set; }
    }
}
