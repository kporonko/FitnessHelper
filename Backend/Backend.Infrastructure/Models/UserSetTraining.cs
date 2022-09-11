using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class UserSetTraining
    {
        public int UserTrainingId { get; set; }
        public DateTime Date { get; set; }
        public int SetId { get; set; }
        public virtual UserSetOfExercises UserSetOfExercises { get; set; }
    }
}
