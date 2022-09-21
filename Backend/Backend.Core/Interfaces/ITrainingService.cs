using Backend.Core.Models.Trainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface ITrainingService
    {
        HttpStatusCode CreateAndAddUserTraining(AddUserTraining addUserTraining);
        HttpStatusCode CreateAndAddBasicTraining(AddBasicTraining addBasicTraining);
    }
}
