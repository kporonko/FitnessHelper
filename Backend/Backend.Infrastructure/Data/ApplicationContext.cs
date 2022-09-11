using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<BasicalSetEfficiency> BasicalSetEfficiencies { get; set; }
        public DbSet<BasicalSetExercise> BasicalSetExercises { get; set; }
        public DbSet<BasicalSetOfExercises> BasicalSetOfExercises { get; set; }
        public DbSet<BasicalSetTraining> BasicalSetTrainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseMuscles> ExerciseMuscles { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetExercise> UserSetExercises { get; set; }
        public DbSet<UserSetOfExercises> UserSetOfExercises { get; set; }
        public DbSet<UserSetTraining> UserSetTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
