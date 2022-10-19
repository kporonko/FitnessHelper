using Backend.Core.Models.UserMuscles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IUserMusclesService
    {
        List<UserMuscleSmallDesc> GetUserMuscles(int userId);

        HttpStatusCode UpdateUserMuscles(MusclesForUpdate userMuscles);
    }
}
