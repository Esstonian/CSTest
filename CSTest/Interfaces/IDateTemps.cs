using CSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSTest.Interfaces {
    public interface IDateTemps {
        IEnumerable<DateTemp> getDateTemps { get; }
        DateTemp getObjectDateTemp(int id);
    }
}
