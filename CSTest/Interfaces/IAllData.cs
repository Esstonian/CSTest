using CSTest.Models;
using System.Collections.Generic;

namespace CSTest.Interfaces {
    public interface IAllData {
        IEnumerable<AllData> allDatas { get; }
    }
}
