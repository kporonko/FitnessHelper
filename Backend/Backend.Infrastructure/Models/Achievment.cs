using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Achievment
    {
        public int AchievmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public virtual List<UserAchievment> UsersAchievments { get; set; } = new List<UserAchievment>();
    }
}
