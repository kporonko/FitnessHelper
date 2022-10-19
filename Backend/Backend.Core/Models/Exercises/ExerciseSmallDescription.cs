using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Exercises
{
    public class ExerciseSmallDescription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string TargetMuscle { get; set; }
        public List<int> SynergistsId { get; set; }
        public int TargetId { get; set; }
    }
}
