using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSTest.Data.Repository {
    public class HouseDetailRepository : IHouseDetailes {
        private readonly AppDbContent appDbContent;

        public HouseDetailRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<HouseDetail> getHouseDetails
            //=> appDbContent.houseDetails.Include(h => h.houseName);
            => appDbContent.houseDetails.OrderBy(h => h.daysNumber);

        public HouseDetail getObjectHouseDetail(int id)
            => appDbContent.houseDetails.FirstOrDefault(h => h.id == id);
    }
}
