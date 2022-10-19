using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class UserSetOfExercises
    {
        public int UserSetId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<UserSetTraining> UserSetTrainings { get; set; } = new List<UserSetTraining>();
        public virtual List<UserSetExercise> UserSetsExercises { get; set; } = new List<UserSetExercise>();
    }
}
