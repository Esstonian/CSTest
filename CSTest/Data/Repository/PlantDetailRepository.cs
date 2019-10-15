using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSTest.Data.Repository {
    public class PlantDetailRepository : IPlantDetailes {
        private readonly AppDbContent appDbContent;

        public PlantDetailRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<PlantDetail> getPlantDetails
            //=> appDbContent.plantDetails.Include(p => p.plantName);
            => appDbContent.plantDetails.OrderBy(p => p.daysNumber);
        public PlantDetail getObjectPlantDetail(int id)
            => appDbContent.plantDetails.FirstOrDefault(p => p.id == id);
    }
}
