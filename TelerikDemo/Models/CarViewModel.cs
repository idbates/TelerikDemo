using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TelerikDemo.Models.Car;

namespace TelerikDemo.Models
{
    public class CarViewModel
    {
        public int? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarTypeEnum CarType { get; set; }
        public bool AirConditioner { get; set; }
        public DateTime DateModified { get; set; }
    }
}
