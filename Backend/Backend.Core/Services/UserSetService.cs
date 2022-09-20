 using Backend.Core.Interfaces;
using Backend.Core.Models.UserSets;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class UserSetService : IUserSetService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public UserSetService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary> 
        /// Gets list of small description of User Sets by Userid. 
        /// </summary>
        /// <param name="userId">Id of User whose sets we are searching for.</param>
        /// <returns>List of small userset description model.</returns>
        public List<UserSetOfExercisesSmallDesc>? GetListOfUserSetsSmallDesc(int userId)
        {
            if (!_context.Users.Any(x => x.UserId == userId))
                return null;
            
            var userSets = _context.UserSetOfExercises.Include(x => x.UserSetsExercises).ThenInclude(x => x.Exercise).Include(x => x.User).Where(x => x.UserId == userId).ToList();
            if (userSets.Count == 0)
                return null;
            
            List<UserSetOfExercisesSmallDesc> resList = new List<UserSetOfExercisesSmallDesc>();
            foreach (var set in userSets)
            {
                FillUserSetDesc(set, resList);
            }

            return resList;
        }


        /// <summary>
        /// Adds new userset without exercises to user sets.
        /// </summary>
        /// <param name="addUserSet">Name of set and id of user who created this set.</param>
        /// <returns>StatusCode 201 if all is ok. 400 if somethng went wrong.</returns>
        public HttpStatusCode AddNewUserSet(AddUserSet addUserSet)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == addUserSet.UserId);
            if (user == null)
                return HttpStatusCode.BadRequest;
            
            var set = new UserSetOfExercises() { Name = addUserSet.SetName, UserId = addUserSet.UserId, User = user, UserSetsExercises = new List<UserSetExercise>(), UserSetTrainings = new List<UserSetTraining>() };
            _context.UserSetOfExercises.Add(set);
            _context.SaveChanges();
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Adds the Exercise to UserSet.
        /// </summary>
        /// <param name="addExercise"></param>
        /// <returns></returns>
        public HttpStatusCode AddExerciseToUserSet(AddExerciseToUserSet addExercise)
        {
            var exercise = _context.Exercises.FirstOrDefault(x => x.ExerciseId == addExercise.ExerciseId);
            var set = _context.UserSetOfExercises.FirstOrDefault(x => x.UserSetId == addExercise.UserSetId);

            if (!IsCorrectAddExerciseData(exercise, set))
                return HttpStatusCode.BadRequest;

            var userSetExercises = new UserSetExercise { ExerciseId = addExercise.ExerciseId, UserSetId = addExercise.UserSetId, Exercise = exercise, UserSetOfExercises = set };
            AddUserSetExercseToContext(userSetExercises);
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Converts userset into small desc model.
        /// </summary>
        /// <param name="set">Full description of user set.</param>
        /// <param name="resList">Resultive list of small descriptions of user sets.</param>
        private void FillUserSetDesc(UserSetOfExercises set, List<UserSetOfExercisesSmallDesc> resList)
        {
            UserSetOfExercisesSmallDesc newSetDesc = new UserSetOfExercisesSmallDesc() { Id = set.UserSetId, Name = set.Name };
            var exList = new List<string>();
            FillExercises(set, exList);
            AddExercisesToUserSetDesc(exList, newSetDesc, resList);
        }

        /// <summary>
        /// Converts data from intermediate table userset_exercises into list of exercises` names.
        /// </summary>
        /// <param name="set"></param>
        /// <param name="exList"></param>
        private void FillExercises(UserSetOfExercises set, List<string> exList)
        {
            foreach (var setExercise in set.UserSetsExercises)
            {
                var exercise = _context.Exercises.FirstOrDefault(x => x.ExerciseId == setExercise.ExerciseId);
                if (exercise == null)
                    continue;

                exList.Add(exercise.Name);
            }
        }

        /// <summary>
        /// Adds the list of exercises` names to our dto and adds received dto into resultive list.
        /// </summary>
        /// <param name="exList"></param>
        /// <param name="newSetDesc"></param>
        /// <param name="resList"></param>
        private void AddExercisesToUserSetDesc(List<string> exList, UserSetOfExercisesSmallDesc newSetDesc, List<UserSetOfExercisesSmallDesc> resList)
        {
            newSetDesc.Exercises = exList;
            resList.Add(newSetDesc);
        }

        /// <summary>
        /// Checks if the received data exists in db and correct.
        /// </summary>
        /// <param name="exercise">Exercise or null.</param>
        /// <param name="set">UserSet or null.</param>
        /// <returns></returns>
        private bool IsCorrectAddExerciseData(Exercise? exercise, UserSetOfExercises? set)
        {
            if (exercise == null || set == null)
                return false;

            return true;
        }

        /// <summary>
        /// Adds the object of intermediate table UserSetExercise to db.
        /// </summary>
        /// <param name="userSetExercises">Created and filled object of UserSetExercise.</param>
        private void AddUserSetExercseToContext(UserSetExercise userSetExercises)
        {
            _context.UserSetExercises.Add(userSetExercises);
            _context.SaveChanges();
        }
    }
}
