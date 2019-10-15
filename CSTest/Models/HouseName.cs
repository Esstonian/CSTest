using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSTest.Models {
    public class HouseName {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<HouseDetail> listHouseDetails { get; set; }

        public HouseName() {
            listHouseDetails = new List<HouseDetail>();
        }
    }
}
