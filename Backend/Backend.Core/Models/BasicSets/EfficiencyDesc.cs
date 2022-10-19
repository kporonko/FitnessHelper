using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.BasicSets
{
    public class EfficiencyDesc
    {
        [Required]
        public int Cardio { get; set; }

        [Required]
        public int Legs { get; set; }

        [Required]
        public int Arms { get; set; }

        [Required]
        public int Back { get; set; }

        [Required]
        public int Chest { get; set; }

        [Required]
        public int Abs { get; set; }
    }
}
