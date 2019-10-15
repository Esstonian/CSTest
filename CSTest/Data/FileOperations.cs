using CSTest.Interfaces;
using CSTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CSTest.Data {
    public class FileOperations : IFileOperations {
        public string userName;
        private readonly AppDbContent _content;

        public FileOperations(AppDbContent content) {
            this._content = content;
        }

        public List<HouseName> houses { get; private set; }
        public List<PlantName> plants { get; private set; }
        public Dictionary<int, DateTemp> dates { get; private set; }

        private System.DateTime getDate(XElement element) {
            return DateTime.ParseExact(element.Attribute("Date").Value, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        private double getDouble(XElement element, string attribute) {
            return double.Parse(element.Attribute(attribute).Value, System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        private string getUserName() {
            var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            userName = userName.Substring(userName.LastIndexOf("\\") + 1);
            return userName;
        }

        public void saveToDb() {
            foreach (KeyValuePair<int, DateTemp> pair in dates) {
                if (!_content.dateTemps.Any(d => d.daysNumber == pair.Key)) _content.dateTemps.Add(pair.Value);
            }
            foreach (HouseName house in houses) {
                if (!_content.houseNames.Any(h => h.name == house.name)) _content.houseNames.Add(house);
            }
            foreach (PlantName plant in plants) {
                if (!_content.plantNames.Any(p => p.name == plant.name)) _content.plantNames.Add(plant);
            }
            _content.SaveChanges();

            var listDays = _content.dateTemps.Select(d => d.daysNumber).ToList();
            foreach (HouseName house in houses) {
                foreach (HouseDetail houseDetail in house.listHouseDetails) {
                    if (!listDays.Contains(houseDetail.daysNumber)) {
                        _content.houseDetails.Add(houseDetail);
                    }
                }
            }
            foreach (PlantName plant in plants) {
                foreach (PlantDetail plantDetail in plant.listPlantDetails) {
                    if (!listDays.Contains(plantDetail.daysNumber)) {
                        _content.plantDetails.Add(plantDetail);
                    }
                }
            }
            string userName = getUserName();
            _content.SaveChanges();

        }

        public void parseXml(Stream stream) {
            
            DateTime now = DateTime.Now;
            houses = new List<HouseName>();
            plants = new List<PlantName>();
            dates = new Dictionary<int, DateTemp>();

            stream.Position = 0;
            XDocument xml = XDocument.Load(stream);

            foreach (XElement el in xml.Root.Element("houses").Elements("house")) {
                var house = new HouseName {
                    name = el.Attribute("Name").Value
                };
                houses.Add(house);
                foreach (XElement element in el.Elements()) {
                    DateTemp dateTemp = new DateTemp {
                        dateTime = getDate(element),
                        temperature = getDouble(element, "Weather")
                    };
                    TimeSpan span = (dateTemp.dateTime - DateTemp.zeroCountDateTime);
                    dateTemp.daysNumber = span.Days;
                    HouseDetail houseDetail = new HouseDetail {
                        localDateTemp = now,
                        userName = getUserName(),
                        daysNumber = dateTemp.daysNumber,
                        consumptionHouse = getDouble(element, "Consumption")
                    };
                    if (!dates.ContainsKey(span.Days)) dates.Add(span.Days, dateTemp);
                    house.listHouseDetails.Add(houseDetail);
                }
            }

            foreach (XElement el in xml.Root.Elements("plants").Elements()) {
                PlantName plant = new PlantName {
                    name = el.Attribute("Name").Value
                };
                plants.Add(plant);
                foreach (XElement element in el.Elements()) {
                    TimeSpan span = getDate(element) - DateTemp.zeroCountDateTime;
                    PlantDetail plantDetail = new PlantDetail {
                        localDateTemp = now,
                        userName = getUserName(),
                        daysNumber = span.Days,
                        price = getDouble(element, "Price"),
                        consumptionPlant = getDouble(element, "Consumption")
                    };
                    plant.listPlantDetails.Add(plantDetail);
                }
            }
            saveToDb();
        }
    }
}

