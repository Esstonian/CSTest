using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTest.Models;

namespace CSTest.Interfaces {
    public interface IHouseDetailes {
        IEnumerable<HouseDetail> getHouseDetails { get; }
        HouseDetail getObjectHouseDetail(int id);
    }
}
