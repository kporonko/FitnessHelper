using Backend.Infrastructure.Configuration;
using Backend.Infrastructure.Models;

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
            modelBuilder.ApplyConfiguration(new BasicalSetEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new BasicalSetExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new BasicalSetOfExercisesConfiguration());
            modelBuilder.ApplyConfiguration(new BasicalSetTrainingConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseMusclesConfiguration());
            modelBuilder.ApplyConfiguration(new MuscleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSetExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new UserSetOfExercisesConfiguration());
            modelBuilder.ApplyConfiguration(new UserSetTrainingConfiguration());


            modelBuilder
                .Entity<UserSetOfExercises>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSetsOfExercises)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
            modelBuilder
                .Entity<UserSetTraining>()
                .HasOne(x => x.UserSetOfExercises)
                .WithMany(x => x.UserSetTrainings)
                .HasForeignKey(x => x.UserSetId)
                .IsRequired();

            modelBuilder
                .Entity<UserSetExercise>()
                .HasOne(x => x.UserSetOfExercises)
                .WithMany(x => x.UserSetsExercises)
                .HasForeignKey(x => x.UserSetId)
                .IsRequired();
            modelBuilder
                .Entity<UserSetExercise>()
                .HasOne(x => x.Exercise)
                .WithMany(x => x.UserSetsExercises)
                .HasForeignKey(x => x.ExerciseId)
                .IsRequired();

            modelBuilder
                .Entity<ExerciseMuscles>()
                .HasOne(x => x.Exercise)
                .WithMany(x => x.ExerciseMuscles)
                .HasForeignKey(x => x.ExerciseId)
                .IsRequired();
            modelBuilder
                .Entity<ExerciseMuscles>()
                .HasOne(x => x.Muscle)
                .WithMany(x => x.ExerciseMuscles)
                .HasForeignKey(x => x.MuscleId)
                .IsRequired();

            modelBuilder
                .Entity<BasicalSetExercise>()
                .HasOne(x => x.BasicalSetOfExercises)
                .WithMany(x => x.BasicalSetExercises)
                .HasForeignKey(x => x.BasicalSetId)
                .IsRequired();
            modelBuilder
                .Entity<BasicalSetExercise>()
                .HasOne(x => x.Exercise)
                .WithMany(x => x.BasicalSetExercises)
                .HasForeignKey(x => x.ExerciseId)
                .IsRequired();

            modelBuilder
                .Entity<BasicalSetTraining>()
                .HasOne(x => x.BasicalSetOfExercises)
                .WithMany(x => x.BasicalSetTrainings)
                .HasForeignKey(x => x.BasicalSetId)
                .IsRequired();
            modelBuilder
                .Entity<BasicalSetTraining>()
                .HasOne(x => x.User)
                .WithMany(x => x.BasicalSetTrainings)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            modelBuilder
                .Entity<BasicalSetOfExercises>()
                .HasOne(x => x.BasicalSetEfficiency)
                .WithOne(b => b.BasicalSetOfExercises)
                .HasForeignKey<BasicalSetOfExercises>(x => x.BasicalSetId)
                .IsRequired();
        }
    }
}
