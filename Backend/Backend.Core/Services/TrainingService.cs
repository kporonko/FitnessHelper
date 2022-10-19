using Backend.Core.Interfaces;
using Backend.Core.Models.Trainings;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class TrainingService : ITrainingService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public TrainingService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates and adds basical training to db.
        /// </summary>
        /// <param name="addBasicTraining">Dto data of basical training.</param>
        /// <returns>201 if training was created. 400 if something went wrong.</returns>
        public HttpStatusCode CreateAndAddBasicTraining(AddBasicTraining addBasicTraining)
        {
            var basicTraining = new BasicalSetTraining() { Date = addBasicTraining.Date, Time = addBasicTraining.Time, BasicalSetId = addBasicTraining.BasicalSetId, UserId = addBasicTraining.UserId };
            (var user, var basicalset) = GetUserAndBasicalSetByTraining(addBasicTraining);

            if (user is null || basicalset is null)
                return HttpStatusCode.BadRequest;

            basicTraining.User = user;
            basicTraining.BasicalSetOfExercises = basicalset;

            AddBasicalTrainingToContext(basicTraining);
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Creates and adds user training to db.
        /// </summary>
        /// <param name="addUserTraining">Dto data of user training.</param>
        /// <returns>201 if training was created. 400 if something went wrong.</returns>
        public HttpStatusCode CreateAndAddUserTraining(AddUserTraining addUserTraining)
        {
            var userTraining = new UserSetTraining() { Date = addUserTraining.Date, Time = addUserTraining.Time, UserSetId = addUserTraining.UserSetId };
            var userSet = _context.UserSetOfExercises.FirstOrDefault(x => x.UserSetId == addUserTraining.UserSetId);

            if (userSet is null)
                return HttpStatusCode.BadRequest;

            userTraining.UserSetOfExercises = userSet;

            AddUserTrainingToContext(userTraining);
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Adds basical training to context.
        /// </summary>
        /// <param name="basicTraining">Training we want to add to context.</param>
        private void AddBasicalTrainingToContext(BasicalSetTraining basicTraining)
        {
            _context.Add(basicTraining);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets user and basicaltraining by training dto info.
        /// </summary>
        /// <param name="addBasicTraining">Dto data of basical training.</param>
        /// <returns>User and BasicalSetOfExercises objects tuple.</returns>
        private (User, BasicalSetOfExercises) GetUserAndBasicalSetByTraining(AddBasicTraining addBasicTraining)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == addBasicTraining.UserId);
            var basicalset = _context.BasicalSetOfExercises.FirstOrDefault(x => x.BasicalSetId == addBasicTraining.BasicalSetId);

            return (user, basicalset);
        }

        /// <summary>
        /// Adds user training to context.
        /// </summary>
        /// <param name="userTraining">Training we want to add to context.</param>
        private void AddUserTrainingToContext(UserSetTraining userTraining)
        {
            _context.Add(userTraining);
            _context.SaveChanges();
        }
    }
}
