using System.Collections.Generic;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSTest.Data.Repository {
    public class PlantRepository : IPlantNames{
        private readonly AppDbContent appDbContent;

        public PlantRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<PlantName> getPlantNames => appDbContent.plantNames;
    }
}
