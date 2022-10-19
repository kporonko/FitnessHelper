using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Exercises
{
    public class ExercisesUserSet
    {
        public string Name { get; set; }
        public List<ExerciseSmallDescription> exerciseSmallDescription { get; set; } = new List<ExerciseSmallDescription>();
    }
}
