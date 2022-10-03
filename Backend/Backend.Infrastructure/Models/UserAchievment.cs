using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class UserAchievment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievmentId { get; set; }
        public virtual User User { get; set; }
        public virtual Achievment Achievment { get; set; }
        public bool IsDone { get; set; }
    }
}
