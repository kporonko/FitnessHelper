using Backend.Core.Interfaces;
using Backend.Core.Models.UserMuscles;
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
    public class UserMusclesService : IUserMusclesService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public UserMusclesService(ApplicationContext context)
        {
            _context = context;
        }

        public List<UserMuscleSmallDesc> GetUserMuscles(int userId)
        {
            var userMuscles = _context.UserMuscles.Include(x => x.Muscle).Include(x => x.User).Where(x => x.UserId == userId).ToList();
            var resList = new List<UserMuscleSmallDesc>();
            double countPoints = CountOverallMusclesPoints(userMuscles);

            foreach (var userMuscle in userMuscles)
            {
                var muscle = _context.Muscles.FirstOrDefault(x => x.MuscleId == userMuscle.MuscleId);
                var resMuscle = new UserMuscleSmallDesc { Id = muscle.MuscleId, Name = muscle.Name, UrlImage = muscle.UrlImage };
                if(countPoints <= 0)
                    resMuscle.Percentage = 0;
                else
                    resMuscle.Percentage = userMuscle.MusclePoints / countPoints;
                resList.Add(resMuscle);
                _context.SaveChanges();
            }
            resList = resList.OrderBy(x => x.Percentage).ThenBy(x => x.Name).ToList();
            return resList;
        }

        public HttpStatusCode UpdateUserMuscles(MusclesForUpdate userMuscles)
        {
            foreach (var target in userMuscles.Target)
            {
                var targetMuscle = _context.UserMuscles.FirstOrDefault(x => x.MuscleId == target.Id);
                targetMuscle.MusclePoints += 10;
            }

            foreach (var synergistList in userMuscles.Synergists)
            {
                foreach (var synergist in synergistList)
                {
                    var muscle = _context.UserMuscles.FirstOrDefault(x => x.MuscleId == synergist.Id);
                    muscle.MusclePoints += 5;
                }
            }
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Counts overall points of all users muscles in order to count percentage.
        /// </summary>
        /// <param name="userMuscles"></param>
        /// <returns></returns>
        private double CountOverallMusclesPoints(List<UserMuscles> userMuscles)
        {
            double countPoints = 0;
            foreach (var userMuscle in userMuscles)
            {
                countPoints += userMuscle.MusclePoints;
            }
            return countPoints;
        }
    }
}
