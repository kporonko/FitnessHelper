using Backend.Core.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IProfileService
    {
        UserProfile? GetUserProfileByUserId(int userId);
        List<TrainingDesc>? GetUserTrainingsByUserId(int userId);
        List<TrainingDesc>? GetBasicTrainingsByUserId(int userId);
    }
}
