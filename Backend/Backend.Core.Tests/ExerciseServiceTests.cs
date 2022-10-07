using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Core.Tests
{
    public class ExerciseServiceTests
    {
        [Fact]
        public void GetAllValidExercisesBySearch_ExistingInput_ReturnListOfExercisesBySearch()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            var muscle = new Muscle { MuscleId = 1, UrlImage = "", Name = "First Muscle", Description = "", PartOfBody = "Neck" };
            var exerciseFull = new Exercise { ExerciseId = 1, Description = "Desc", Name = "Name", UrlImage = "img", UrlVideo = "Video" };
            var exMuscles = new ExerciseMuscles { MuscleId = muscle.MuscleId, Exercise = exerciseFull, ExerciseId = exerciseFull.ExerciseId, Id = 1, IsTarget = true, Muscle = muscle };

            var muscle2 = new Muscle { MuscleId = 2, UrlImage = "", Name = "Second muscle", Description = "", PartOfBody = "Chest" };
            var exerciseFull2 = new Exercise { ExerciseId = 2, Description = "Desc", Name = "Bench Press", UrlImage = "img", UrlVideo = "Video" };
            var exMuscles2 = new ExerciseMuscles { MuscleId = muscle2.MuscleId, Exercise = exerciseFull2, ExerciseId = exerciseFull2.ExerciseId, Id = 2, IsTarget = true, Muscle = muscle2 };

            var muscle3 = new Muscle { MuscleId = 3, UrlImage = "", Name = "Third Muscle", Description = "", PartOfBody = "Back" };
            var exMuscles3 = new ExerciseMuscles { MuscleId = muscle3.MuscleId, Exercise = exerciseFull2, ExerciseId = exerciseFull2.ExerciseId, Id = 3, IsTarget = false, Muscle = muscle3 };

            muscle.ExerciseMuscles.Add(exMuscles);
            muscle2.ExerciseMuscles.Add(exMuscles2);
            muscle3.ExerciseMuscles.Add(exMuscles3);
            exerciseFull.ExerciseMuscles.Add(exMuscles);
            exerciseFull2.ExerciseMuscles.Add(exMuscles2);
            exerciseFull2.ExerciseMuscles.Add(exMuscles3);

            using (var context = new ApplicationContext(options))
            {
                context.ExerciseMuscles.AddRange(exMuscles, exMuscles2, exMuscles3);
                context.Exercises.AddRange(exerciseFull, exerciseFull2);
                context.Muscles.AddRange(muscle, muscle2, muscle3);
                context.SaveChanges();
            }

            // Act
            var result = service.ExercisesSearch("Bench");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.True(result.Any(x => x.Name.Contains("Bench")));
        }

        [Fact]
        public void GetAllValidExercisesBySearch_NonExistingInput_ReturnEmptyList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            // Act
            var result = service.ExercisesSearch("Aaaa");

            // Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void GetValidExercisesByPartOfBody_ExistingPart_ReturnListOfExercisesOfPartOfBody ()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            // Act
            var result = service.ExercisesByPartOfBody("Neck");

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetValidExercisesByPartOfBody_NonExistingPart_ReturnEmptyList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            // Act
            var result = service.ExercisesByPartOfBody("Nonex");

            // Assert
            Assert.Empty(result);
        }


        [Fact]
        public void GetValidExercisesByUserSet_NonExistingSet_ReturnEmptyModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            // Act
            var result = service.ExercisesByUserSet(111);

            // Assert
            Assert.Empty(result.exerciseSmallDescription);
            Assert.Null(result.Name);
        }


        [Fact]
        public void GetAllValidExercises_AllStates_ReturnListOfExercises()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ExerciseService(new ApplicationContext(options));

            // Act
            var result = service.AllExercises();

            // Assert
            Assert.Equal(4, result.Count);
        }
    }
}
