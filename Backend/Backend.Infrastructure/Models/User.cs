using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<UserSetOfExercises> UserSetsOfExercises { get; set; } = new List<UserSetOfExercises>();
        public virtual List<BasicalSetTraining> BasicalSetTrainings { get; set; } = new List<BasicalSetTraining>();
        public virtual List<UserAchievment> UsersAchievments { get; set; } = new List<UserAchievment>();
        public virtual List<UserMuscles> UserMuscles { get; set; } = new List<UserMuscles>();

    }
}
