using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class ReceiptDtoExcel
    {
        //группа животных
        public string GroupAnimals { get; set; }
        //отделение
        public string Department { get; set; }
        //бригада
        public string Brigade { get; set; }
        //За кем прикреплены животные
        public string ResponsibleEmployee { get; set; }
        //номер животного или станка
        public decimal AnimalNumber { get; set; }
        //Количество
        public decimal Quantity { get; set; }
        //Количество старое
        public decimal QuantityOld { get; set; }
        //Привес
        public decimal WeightGain { get; set; }
        //Привес прошлый
        public decimal WeightGainOld { get; set; }
        //Дата взвешивания (текущее)
        public DateTime WeighingDate { get; set; }
        //Дата предыдущего взвешивания
        public DateTime DateWeighingOld { get; set; }
        //текущее взвешивание
        public decimal CurrentWeighing { get; set; }
        //предыдущее взвешивание
        public decimal CurrentWeighingOld { get; set; }

    }
}
