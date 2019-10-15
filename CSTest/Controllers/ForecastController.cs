using System.Collections.Generic;
using System.Linq;
using CSTest.Data;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSTest.Controllers {
    public class ForecastController : Controller {
        private IHouseDetailes houseDetailes;
        private IPlantDetailes plantDetailes;
        private Dictionary<int, double> consH;
        private Dictionary<int, double> consP;
        private List<double> consuptions { get; set; }
        private List<double> consuptionsLimit { get; set; }
        public ForecastModel forecastModel { get; set; }


        public ForecastController(IHouseDetailes houseDetailes, IPlantDetailes plantDetailes) {
            this.houseDetailes = houseDetailes;
            this.plantDetailes = plantDetailes;
            consH = new Dictionary<int, double>();
            consP = new Dictionary<int, double>();

            consuptions = new List<double>();
            consuptionsLimit = new List<double>();

            foreach (HouseDetail h in houseDetailes.getHouseDetails) {
                if (!consH.ContainsKey(h.daysNumber)) consH.Add(h.daysNumber, h.consumptionHouse);
                else consH[h.daysNumber] = consH[h.daysNumber] + h.consumptionHouse;
            }
            foreach (PlantDetail p in plantDetailes.getPlantDetails) {
                if (!consP.ContainsKey(p.daysNumber)) consP.Add(p.daysNumber, p.consumptionPlant);
                else consP[p.daysNumber] = consP[p.daysNumber] + p.consumptionPlant;
            }
            foreach (KeyValuePair<int, double> pair in consH) {
                consuptions.Add(pair.Value + consP[pair.Key]);
            }
            forecastModel = new ForecastModel();
            if (consuptions.Count >= 7) {
                for (int i = consuptions.Count - 7; i < consuptions.Count; i++) { //last 7 days
                    consuptionsLimit.Add(consuptions[i]);
                }
                forecastModel.consuption = consuptionsLimit.ToArray();
                forecastModel.forecast = new MNK().calc(consuptionsLimit.ToArray(), 3);
                forecastModel.date = DateTemp.zeroCountDateTime.AddDays(plantDetailes.getPlantDetails.Last().daysNumber + 1);
            }
        }

        public IActionResult Index() {
            return View(forecastModel);
        }
    }
}
