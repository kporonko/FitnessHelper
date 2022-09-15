using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class BasicalSetEfficiency
    {
        public int EfficiencyId { get; set; }
        public int Cardio { get; set; }
        public int Legs { get; set; }
        public int Arms { get; set; }
        public int Back { get; set; }
        public int Chest { get; set; }
        public int Abs { get; set; }
        public int BasicalSetId { get; set; }
        public virtual BasicalSetOfExercises BasicalSetOfExercises { get; set; }
    }
}
