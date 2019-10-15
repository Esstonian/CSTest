using CSTest.Models;
using System.Collections.Generic;

namespace CSTest.Interfaces {
    public interface IPlantNames {
        IEnumerable<PlantName> getPlantNames { get; }
    }
}
