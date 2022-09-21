using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Muscles
{
    public class MuscleFullDesc
    {
        public int MuscleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string PartOfBody { get; set; }
    }
}
