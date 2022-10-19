using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class BasicalSetExercise
    {
        public int Id { get; set; }
        public int BasicalSetId { get; set; }
        public virtual BasicalSetOfExercises BasicalSetOfExercises { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
