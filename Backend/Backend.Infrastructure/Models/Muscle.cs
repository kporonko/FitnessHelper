using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Muscle
    {
        public int MuscleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string PartOfBody { get; set; }
        public virtual List<ExerciseMuscles> ExerciseMuscles { get; set; } = new List<ExerciseMuscles>();
    }
}
