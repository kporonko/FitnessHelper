using Backend.Core.Interfaces;
using Backend.Core.Models.Achievments;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class AchievmentService : IAchievmentService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public AchievmentService(ApplicationContext context)
        {
            _context = context;
        }

        public AchievmentSmallDesc? TrainingExercises(int userId)
        {
            var user = _context.Users.Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            int count = 0;
            foreach (var userSet in user.UserSetsOfExercises)
            {
                count += userSet.UserSetTrainings.Count;
            }

            count += user.BasicalSetTrainings.Count;

            if (count == 1)
                return new AchievmentSmallDesc { Id = 1, Desc = "Finish Your First Training Session", Name = "First Steps" };
            else if(count == 10)
                return new AchievmentSmallDesc { Id = 2, Desc = "Finish 10 Training Sessions", Name = "On The Right Way" };
            else if (count == 50)
                return new AchievmentSmallDesc { Id = 3, Desc = "Finish 50 Training Sessions", Name = "You got better" };
            else
                return null;
        }

        public AchievmentSmallDesc? Is5BasicalTrainings(int userId)
        {
            var user = _context.Users.Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            int count = 0;
            count += user.BasicalSetTrainings.Count;
            if (count == 5)
                return new AchievmentSmallDesc { Id = 4, Desc = "Finish 5 Basical Training Sessions", Name = "Learn From The Best" };
            else
                return null;
        }

        public AchievmentSmallDesc? Is5OwnTrainings(int userId)
        {
            var user = _context.Users.Include(x => x.UserSetsOfExercises).ThenInclude(x => x.UserSetTrainings).FirstOrDefault(x => x.UserId == userId);
            int count = 0;
            foreach (var userSet in user.UserSetsOfExercises)
            {
                count += userSet.UserSetTrainings.Count;
            }
            if (count == 5)
                return new AchievmentSmallDesc { Id = 5, Desc = "Finish 5 Your Own Trainings", Name = "Train On Your Own" };
            else
                return null;
        }

        public HttpStatusCode PutAchievment(int achievmentId, int userId)
        {
            var userAchievment = _context.UserAchievments.First(x => x.UserId == userId && x.AchievmentId == achievmentId);
            userAchievment.IsDone = true;
            return HttpStatusCode.OK;
        }

        public List<AchievmentFull> GetAllAchievments(int userId)
        {
            var resList = new List<AchievmentFull>();
            var user = _context.Users.Include(x => x.UsersAchievments).ThenInclude(x => x.Achievment).FirstOrDefault(x => x.UserId == userId);

            foreach (var userAchievment in user.UsersAchievments)
            {
                var achievment = new AchievmentFull { AchievmentId = userAchievment.AchievmentId, Description = userAchievment.Achievment.Description, Name = userAchievment.Achievment.Name, IsDone = userAchievment.IsDone, Image = userAchievment.Achievment.UrlImage };
                resList.Add(achievment);
            }

            return resList;
        }
    }
}
