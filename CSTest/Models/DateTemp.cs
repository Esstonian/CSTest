using System;
using System.ComponentModel.DataAnnotations;

namespace CSTest {
    public class DateTemp {
        [Key]
        public int id { get; set; }
        public int daysNumber { get; set; }
        public DateTime dateTime { get; set; }
        public double temperature { get; set; }

        public static DateTime zeroCountDateTime = new DateTime(1970, 1, 1); //unix time
    }
}
