using System;
using System.Collections.Generic;
using System.Linq;
using CSTest.Models;

namespace CSTest.Data {
    public class DBObjects {
        private static Dictionary<string, HouseName> houseNames;
        private static Dictionary<string, PlantName> plantNames;

        public static void initial(AppDbContent content) {

            if (!content.houseNames.Any()) content.houseNames.AddRange(getHouseNames.Select(h => h.Value));
            if (!content.plantNames.Any()) content.plantNames.AddRange(getPlantNames.Select(p => p.Value));
            
            DateTemp dateTemp = new DateTemp {
                daysNumber = 16435,
                dateTime = DateTime.ParseExact("2014-12-31T00:00:00", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                temperature = -9
            };
            if (!content.dateTemps.Any()) content.dateTemps.AddRange(dateTemp);
            
            if (!content.houseDetails.Any()) content.houseDetails.AddRange(
                new HouseDetail {
                    daysNumber = 16435,
                    houseName = getHouseNames["Жилой дом 1"],
                    //localDateTemp = dateTemp,
                    consumptionHouse = 16144
                });
            if (!content.plantDetails.Any()) content.plantDetails.AddRange(
                new PlantDetail {
                    daysNumber = 16435,
                    plantName = getPlantNames["Кирпичный завод 1"],
                    //localDateTemp = dateTemp,
                    price = 1983.3,
                    consumptionPlant = 1990545.2
                });

            content.SaveChanges();
        }

        private static Dictionary<string, HouseName> getHouseNames {
            get {
                if (houseNames == null) {
                    var list = new HouseName[] {
                        new HouseName { name = "Жилой дом 1" }
                    };
                    houseNames = new Dictionary<string, HouseName>();
                    foreach (HouseName h in list) houseNames.Add(h.name, h);
                }
                return houseNames;
            }
        }
        private static Dictionary<string, PlantName> getPlantNames {
            get {
                if (plantNames == null) {
                    var list = new PlantName[] {
                        new PlantName { name = "Кирпичный завод 1" }
                    };
                    plantNames = new Dictionary<string, PlantName>();
                    foreach (PlantName p in list) plantNames.Add(p.name, p);
                }
                return plantNames;
            }
        }
    }
}
