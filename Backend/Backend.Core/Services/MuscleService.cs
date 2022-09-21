using Backend.Core.Interfaces;
using Backend.Core.Models.Muscles;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class MuscleService : IMuscleService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public MuscleService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets muscle description by id. 
        /// </summary>
        /// <param name="id">Id of muscle.</param>
        /// <returns>Muscle description dto.</returns>
        public MuscleFullDesc? GetMuscleById(int id)
        {
            Muscle? muscle = _context.Muscles.FirstOrDefault(x => x.MuscleId == id);
            if (muscle is null)
                return null;
            
            return new MuscleFullDesc { MuscleId = muscle.MuscleId, Description = muscle.Description, Name = muscle.Name, PartOfBody = muscle.PartOfBody, UrlImage = muscle.UrlImage};
        }
    }
}
