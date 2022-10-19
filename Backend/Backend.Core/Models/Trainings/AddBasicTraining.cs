using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Trainings
{
    public class AddBasicTraining
    {
        public int UserId { get; set; }
        public int BasicalSetId { get; set; }
        public int Time { get; set; }
        public DateTime Date { get; set; }
    }
}
