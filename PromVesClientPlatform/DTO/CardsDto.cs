using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class CardsDto
    {
        public Guid Id { get; set; }
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
        //Предыдущее взвешивание
        public decimal? PreviousWeigh { get; set; }
        //Дата предыдущего взвешивания
        public DateTime? DatePreviousWeighing { get; set; }
        //текущее взвешивание
        public decimal CurrentWeighing { get; set; }
        //Привес
        public decimal? WeightGain { get; set; }
        //Дата взвешивания (текущее)
        public DateTime WeighingDate { get; set; }

    }
}
