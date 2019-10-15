using System.Collections.Generic;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSTest.Data.Repository {
    public class HouseRepository : IHouseNames {
        private readonly AppDbContent appDbContent;

        public HouseRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        IEnumerable<HouseName> IHouseNames.getHouseNames => appDbContent.houseNames;
    }
}
