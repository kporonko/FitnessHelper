using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.BasicSets
{
    public class BasicalSetFullInfo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public EfficiencyDesc Efficiency { get; set; }

        [Required]
        public List<ExerciseSmallDesc> ExerciseSmallDescs { get; set; }
    }
}
