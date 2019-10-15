using CSTest.Models;
using System.Collections.Generic;

namespace CSTest.Interfaces {
    public interface IHouseNames {
        IEnumerable<HouseName> getHouseNames { get; }
    }
}
