using CSTest.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSTest {
    public class HouseDetail {
        [Key]
        public int id { get; set; }
        public int daysNumber { get; set; }
        public HouseName houseName { get; set; }
        public double consumptionHouse { get; set; }
        public DateTime localDateTemp { get; set; }
        public string userName { get; set; }
    }
}
