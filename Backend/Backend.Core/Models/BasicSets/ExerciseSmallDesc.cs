using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.BasicSets
{
    public class ExerciseSmallDesc
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string TargetMuscle { get; set; }
        public int TargetId { get; set; }
        public List<int> SynergistsId { get; set; }
    }
}
