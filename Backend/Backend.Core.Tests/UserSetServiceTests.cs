using Backend.Core.Models.UserSets;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
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
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var resList = service.GetListOfUserSetsSmallDesc(1);
            // Assert
            Assert.NotEmpty(resList);
        }

        [Fact]
        public void GetListOfUserSetsSmallDesc_NonExistingUserId_Null()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var resList = service.GetListOfUserSetsSmallDesc(1000);
            // Assert
            Assert.Null(resList);
        }

        [Fact]
        public void AddNewUserSet_ExistingUserId_201StatusCode()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));
            var model = new AddUserSet { SetName = "TestName", UserId = 1 };
            // Act
            var result = service.AddNewUserSet(model);
            // Assert
            Assert.Equal(201, (int)result);
        }

        [Fact]
        public void AddNewUserSet_NonExistingUserId_400StatusCode()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));
            var model = new AddUserSet { SetName = "TestName", UserId = 1000 };
            // Act
            var result = service.AddNewUserSet(model);
            // Assert
            Assert.Equal(400, (int)result);
        }

        [Fact]
        public void AddExerciseToUserList_ValidData_201StatusCode()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));
            var model = new AddExerciseToUserSet { ExerciseId = 11, UserSetId = 1 };
            // Act
            var result = service.AddExerciseToUserSet(model);
            // Assert
            Assert.Equal(201, (int)result);
        }

        [Fact]
        public void AddExerciseToUserList_NonExistingData_400StatusCode()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserSetService(applicationContextFactory.CreateDbContext(new string[] { }));
            var model = new AddExerciseToUserSet { ExerciseId = 101010, UserSetId = 101010 };
            // Act
            var result = service.AddExerciseToUserSet(model);
            // Assert
            Assert.Equal(400, (int)result);
        }
    }
}
