using System;
using System.ComponentModel.DataAnnotations;

namespace CSTest.Models {
    public class PlantDetail {
        [Key]
        public int id { get; set; }
        public int daysNumber { get; set; }
        public PlantName plantName { get; set; }
        public double price { get; set; }
        public double consumptionPlant { get; set; }
        public DateTime localDateTemp { get; set; }
        public string userName { get; set; }
    }
}
