using CSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSTest.Interfaces {
    public interface IPlantDetailes {
        IEnumerable<PlantDetail> getPlantDetails { get; }
        PlantDetail getObjectPlantDetail(int id);
    }
}
