using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.UserMuscles
{
    public class MusclesForUpdate
    {
        public int UserId { get; set; }
        public List<int> Synergists { get; set; }
        public List<int> Target { get; set; }
    }
}
