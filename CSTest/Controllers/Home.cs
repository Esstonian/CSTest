using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSTest.Controllers {
    public class Home : Controller {
        private IDateTemps dateTemps;
        private IHouseDetailes houseDetailes;
        private IPlantDetailes plantDetailes;

        public Home(IDateTemps dates, IHouseDetailes houseDetailes, IPlantDetailes plantDetailes) {
            this.dateTemps = dates;
            this.houseDetailes = houseDetailes;
            this.plantDetailes = plantDetailes;
        }

        public Dictionary<int, AllData> allData { get; private set; }
        [HttpGet]
        public IActionResult Index() {
            allData = new Dictionary<int, AllData>();
            var currentDateTemps = dateTemps.getDateTemps;
            var currentHouseDetailes = houseDetailes.getHouseDetails;
            var currentPlantDetailes = plantDetailes.getPlantDetails;

            foreach (DateTemp d in currentDateTemps) {
                allData.Add(d.daysNumber, new AllData {
                    id = d.daysNumber,
                    temperature = d.temperature
                });
                foreach (HouseDetail h in currentHouseDetailes) {
                    if (h.daysNumber == d.daysNumber) {
                        allData[d.daysNumber].consumptionHouse = allData[d.daysNumber].consumptionHouse + h.consumptionHouse;
                    }
                }
                foreach (PlantDetail p in currentPlantDetailes) {
                    if (p.daysNumber == d.daysNumber) {
                        allData[d.daysNumber].consumptionPlant = allData[d.daysNumber].consumptionPlant + p.consumptionPlant;
                        allData[d.daysNumber].price = allData[d.daysNumber].price + p.price;
                    }
                }
            }
            List<AllData> list = new List<AllData>();
            foreach (KeyValuePair<int, AllData> pair in allData) list.Add(pair.Value);
            
            return View(list);
        }
    }
}
