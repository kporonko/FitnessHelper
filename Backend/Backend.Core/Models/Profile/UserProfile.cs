using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Profile
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int TotalTrainings { get; set; }
        public int TotalTrainingsTimeInMinutes { get; set; }
    }
}
