using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.UserMuscles
{
    public class UserMuscleSmallDesc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
        public string UrlImage { get; set; }
    }
}
