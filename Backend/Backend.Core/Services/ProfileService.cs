using Backend.Core.Interfaces;
using Backend.Core.Models.Profile;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class ProfileService : IProfileService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public ProfileService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets user profile by user id.
        /// </summary>
        /// <param name="userId">Id of user whose profile data we want to get.</param>
        /// <returns>User profile description.</returns>
        public UserProfile? GetUserProfileByUserId(int userId)
        {
            var user = _context.Users.Include(x => x.BasicalSetTrainings).Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            if (user == null)
                return null;

            UserProfile profile = new UserProfile { UserId = userId, Name = $"{user.FirstName} {user.LastName}" };
            
            (int countTrainings, int minutesTrainings) = GetCountAndMinutesOfUserBasicalTrainings(user);
            AddCountAndMinutesOfUserOwnTrainings(user, ref countTrainings, ref minutesTrainings);

            profile.TotalTrainings = countTrainings;
            profile.TotalTrainingsTimeInMinutes = minutesTrainings;
            return profile;
        }


        /// <summary>
        /// Gets user trainings dtos by id of user.
        /// </summary>
        /// <param name="userId">User`s id whose user set trainings we getting.</param>
        /// <returns>List of user trainings.</returns>
        public List<TrainingDesc>? GetUserTrainingsByUserId(int userId)
        {
            var user = _context.Users.Include(x => x.BasicalSetTrainings).Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            if (user == null)
                return null;

            var resList = new List<TrainingDesc>();
            GetUserTrainingsByUser(user, resList);

            return resList;
        }

        /// <summary>
        /// Gets basical trainings done by user with userid.
        /// </summary>
        /// <param name="userId">Id of user whose basical trainings we getting.</param>
        /// <returns>List of basical trainings done by userid.</returns>
        public List<TrainingDesc>? GetBasicTrainingsByUserId(int userId)
        {
            var user = _context.Users.Include(x => x.BasicalSetTrainings).Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            if (user == null)
                return null;

            var resList = new List<TrainingDesc>();
            foreach (var basicalTraining in user.BasicalSetTrainings)
            {
                var set = _context.BasicalSetOfExercises.FirstOrDefault(x => x.BasicalSetId == basicalTraining.BasicalSetId);
                var trainingDesc = new TrainingDesc { Date = basicalTraining.Date.ToString(), SetName = set.Name, Time = basicalTraining.Time.ToString() };
                resList.Add(trainingDesc);
            }

            return resList;
        }

        /// <summary>
        /// Gets count of trainings and minutes of trainings by user.
        /// </summary>
        /// <param name="user">User whose trainings info we want to get.</param>
        /// <returns>Count of basical trainings, minutes of basical trainings</returns>
        private (int, int) GetCountAndMinutesOfUserBasicalTrainings(User user)
        {
            int countTrainings = 0, minutesTrainings = 0;
            foreach (var basicalTraining in user.BasicalSetTrainings)
            {
                countTrainings++;
                minutesTrainings += basicalTraining.Time;
            }
            return (countTrainings, minutesTrainings);
        }

        /// <summary>
        /// Adds to count of trainings and minutes of trainings data from user set trainings.
        /// </summary>
        /// <param name="user">User whose trainings info we want to get.</param>
        /// <param name="countTrainings">Current count of trainings (only from basical sets).</param>
        /// <param name="minutesTrainings">Current minutes of trainings (only from basical sets).</param>
        private void AddCountAndMinutesOfUserOwnTrainings(User user, ref int countTrainings, ref int minutesTrainings)
        {
            foreach (var userSet in user.UserSetsOfExercises)
            {
                countTrainings += userSet.UserSetTrainings.Count;
                foreach (var userTraining in userSet.UserSetTrainings)
                {
                    minutesTrainings += userTraining.Time;
                }
            }
        }

        /// <summary>
        /// Gets usertraining list by user model.
        /// </summary>
        /// <param name="user">User whose trainings info we want to get.</param>
        /// <param name="resList">Resultive list of trainings.</param>
        private void GetUserTrainingsByUser(User user, List<TrainingDesc> resList)
        {
            foreach (var userset in user.UserSetsOfExercises)
            {
                foreach (var userTraining in userset.UserSetTrainings)
                {
                    TrainingDesc trainingDesc = new TrainingDesc { SetName = userset.Name };
                    trainingDesc.Date = userTraining.Date.ToString();
                    trainingDesc.Time = userTraining.Time.ToString();
                    resList.Add(trainingDesc);
                }
            }
        }
    }
}
