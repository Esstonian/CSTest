using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CSTest.Data.Repository {
    public class DateTempRepository : IDateTemps {
        private readonly AppDbContent appDbContent;

        public DateTempRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<DateTemp> getDateTemps
            => appDbContent.dateTemps.OrderBy(d => d.daysNumber);

        public DateTemp getObjectDateTemp(int id)
            => appDbContent.dateTemps.FirstOrDefault(d => d.id == id);
    }
}
