using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.UserMuscles
{
    public class MusclesForUpdate
    {
        public List<List<MuscleId>> Synergists { get; set; }
        public List<MuscleId> Target { get; set; }
    }
}
