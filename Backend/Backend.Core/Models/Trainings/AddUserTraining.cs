using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models.Trainings
{
    public class AddUserTraining
    {
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public int UserSetId { get; set; }
    }
}
