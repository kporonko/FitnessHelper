using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Exercises
{
    public class ExerciseFull
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string UrlVideo { get; set; }
        public MuscleSmallDesc TargetMuscle { get; set; }
        public List<MuscleSmallDesc> SynergistMuscles { get; set; }
    }
}
