using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.UserSets
{
    public class AddExerciseToUserSet
    {
        public int ExerciseId { get; set; }
        public int UserSetId { get; set; }
    }
}
