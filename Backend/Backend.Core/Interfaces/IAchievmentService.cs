using Backend.Core.Models.Achievments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IAchievmentService
    {
        AchievmentSmallDesc? TrainingExercises(int userId);
        AchievmentSmallDesc? Is5BasicalTrainings(int userId);
        AchievmentSmallDesc? Is5OwnTrainings(int userId);
        List<AchievmentFull> GetAllAchievments(int userId);
        HttpStatusCode PutAchievment(int achievmentId, int userId);
    }
}
