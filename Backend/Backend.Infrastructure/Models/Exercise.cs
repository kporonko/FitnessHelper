using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string UrlVideo { get; set; }
        public virtual List<UserSetExercise> UserSetsExercises { get; set; } = new List<UserSetExercise>();
        public virtual List<BasicalSetExercise> BasicalSetExercises { get; set; } = new List<BasicalSetExercise>();
        public virtual List<ExerciseMuscles> ExerciseMuscles { get; set; } = new List<ExerciseMuscles>();

    }
}
