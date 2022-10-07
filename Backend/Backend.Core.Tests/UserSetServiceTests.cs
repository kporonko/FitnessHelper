using Backend.Core.Models.UserSets;
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
    public class UserSetServiceTests
    {
        [Fact]
        public void GetListOfUserSetsSmallDesc_ExistingUserId_ListOfExercises()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserSetService(new ApplicationContext(options));

            var user = new User { UserId = 4, FirstName = "Name", LastName = "Last", Login = "UserSetServiceTests1Login", Password = "UserSetServiceTests1Password" };

            var muscle = new Muscle { MuscleId = 4, UrlImage = "", Name = "4 Muscle", Description = "", PartOfBody = "Neck" };
            var exerciseFull = new Exercise { ExerciseId = 3, Description = "Desc", Name = "Name", UrlImage = "img", UrlVideo = "Video" };
            var exMuscles = new ExerciseMuscles { MuscleId = muscle.MuscleId, Exercise = exerciseFull, ExerciseId = exerciseFull.ExerciseId, Id = 4, IsTarget = true, Muscle = muscle };

            var muscle2 = new Muscle { MuscleId = 5, UrlImage = "", Name = "5 muscle", Description = "", PartOfBody = "Chest" };
            var exerciseFull2 = new Exercise { ExerciseId = 4, Description = "Desc", Name = "Bench Diff", UrlImage = "img", UrlVideo = "Video" };
            var exMuscles2 = new ExerciseMuscles { MuscleId = muscle2.MuscleId, Exercise = exerciseFull2, ExerciseId = exerciseFull2.ExerciseId, Id = 5, IsTarget = true, Muscle = muscle2 };

            var muscle3 = new Muscle { MuscleId = 6, UrlImage = "", Name = "6 Muscle", Description = "", PartOfBody = "Back" };
            var exMuscles3 = new ExerciseMuscles { MuscleId = muscle3.MuscleId, Exercise = exerciseFull2, ExerciseId = exerciseFull2.ExerciseId, Id = 6, IsTarget = false, Muscle = muscle3 };

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

            var setEx1 = new UserSetExercise { ExerciseId = exerciseFull.ExerciseId, Id = 2, UserSetId = 2 };
            var setEx2 = new UserSetExercise { ExerciseId = exerciseFull2.ExerciseId, Id = 3, UserSetId = 3 };
            var setEx3 = new UserSetExercise { ExerciseId = exerciseFull2.ExerciseId, Id = 4, UserSetId = 3 };
            var set1 = new UserSetOfExercises { UserSetId = 2, UserId = user.UserId, Name = "FirstSet", UserSetsExercises = new List<UserSetExercise>() { setEx1 } };
            var set2 = new UserSetOfExercises { UserSetId = 3, UserId = user.UserId, Name = "SecondSet", UserSetsExercises = new List<UserSetExercise>() { setEx2, setEx3 } };

            using (var context = new ApplicationContext(options))
            {
                context.Users.Add(user);

                context.UserSetExercises.Add(setEx1);
                context.UserSetExercises.Add(setEx2);
                context.UserSetExercises.Add(setEx3);
                context.SaveChanges();

                context.UserSetOfExercises.Add(set1);
                context.UserSetOfExercises.Add(set2);
                context.SaveChanges();
            }

            // Act
            var result = service.GetListOfUserSetsSmallDesc(4);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(2, result[0].Exercises.Count);
        }

        [Fact]
        public void GetListOfUserSetsSmallDesc_NonExistingUserId_Null()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserSetService(new ApplicationContext(options));

            // Act
            var result = service.GetListOfUserSetsSmallDesc(1111111111);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddNewUserSet_ExistingUserId_201StatusCode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new UserSetService(new ApplicationContext(options));

            var user = new User { UserId = 6, FirstName = "Name", LastName = "Last", Login = "UserSetServiceTests1Login", Password = "UserSetServiceTests1Password" };
            
            using (var context = new ApplicationContext(options))
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            AddUserSet addUserSet = new AddUserSet() {SetName = "TrySetName", UserId = 6};

            // Act
            var result = service.AddNewUserSet(addUserSet);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, result);
        }

        [Fact]
        public void AddNewUserSet_NonExistingUserId_400StatusCode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new UserSetService(new ApplicationContext(options));

            AddUserSet addUserSet = new AddUserSet() { SetName = "TrySetName", UserId = 77777 };

            // Act
            var result = service.AddNewUserSet(addUserSet);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result);
        }

        [Fact]
        public void AddExerciseToUserList_ValidData_201StatusCode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new UserSetService(new ApplicationContext(options));
            AddExerciseToUserSet addExerciseToUserSet = new AddExerciseToUserSet() { ExerciseId = 2, UserSetId = 1};

            // Act
            var result = service.AddExerciseToUserSet(addExerciseToUserSet);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, result);
        }

        [Fact]
        public void AddExerciseToUserList_NonExistingData_400StatusCode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new UserSetService(new ApplicationContext(options));
            AddExerciseToUserSet addExerciseToUserSet = new AddExerciseToUserSet() { ExerciseId = 111, UserSetId = 1 };
            AddExerciseToUserSet addExerciseToUserSet2 = new AddExerciseToUserSet() { ExerciseId = 1, UserSetId = 111 };
            AddExerciseToUserSet addExerciseToUserSet3 = new AddExerciseToUserSet() { ExerciseId = 111, UserSetId = 111 };

            // Act
            var result = service.AddExerciseToUserSet(addExerciseToUserSet);
            var result2 = service.AddExerciseToUserSet(addExerciseToUserSet2);
            var result3 = service.AddExerciseToUserSet(addExerciseToUserSet3);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result2);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result3);

        }
    }
}
