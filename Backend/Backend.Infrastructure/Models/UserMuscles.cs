using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class UserMuscles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MuscleId { get; set; }
        public virtual User User { get; set; }
        public virtual Muscle Muscle { get; set; }

        public double MusclePoints { get; set; }
    }
}
