using Backend.Core.Models.UserSets;
using System.Net;

namespace Backend.Core.Interfaces
{
    public interface IUserSetService
    {
        List<UserSetOfExercisesSmallDesc>? GetListOfUserSetsSmallDesc(int userId);
        HttpStatusCode AddNewUserSet(AddUserSet addUserSet);
        HttpStatusCode AddExerciseToUserSet(AddExerciseToUserSet addExercise);
    }
}
