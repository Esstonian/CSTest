using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSTest.Models {
    public class PlantName {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<PlantDetail> listPlantDetails { get; set; }

        public PlantName() {
            listPlantDetails = new List<PlantDetail>();
        }
    }
}
