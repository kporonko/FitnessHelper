using Backend.Core.Models.BasicSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IBasicSetService
    {
        List<BasicalSetInfo>? GetBasicalSetsSmallInfoBySection(int section);
        BasicalSetFullInfo? GetBasicalSetFullDescById(int id);
    }
}
