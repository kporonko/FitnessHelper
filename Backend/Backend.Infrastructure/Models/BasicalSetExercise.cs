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
        public int SetId { get; set; }
        public virtual BasicalSetOfExercises UserSetOfExercises { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
