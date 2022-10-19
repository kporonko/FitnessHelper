using Backend.Core.Models;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Backend.Core.Tests
{
    public class BasicSetServiceTests
    {
        [Fact]
        public void GetBasicalSetsSmallInfoBySection_ExistingSection_ReturnListOfExercises()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new BasicSetService(new ApplicationContext(options));
            var set = new BasicalSetOfExercises { BasicalSetId = 1, Description = "TestDesc", Name = "TestName", Section = 1, UrlImage = "TestImg", BasicalSetExercises = new List<BasicalSetExercise>() { new BasicalSetExercise { BasicalSetId = 1, ExerciseId = 1, Id = 1 } } };
            var set2 = new BasicalSetOfExercises { BasicalSetId = 2, Description = "TestDesc2", Name = "TestName2", Section = 1, UrlImage = "TestImg2", BasicalSetExercises = new List<BasicalSetExercise>() { new BasicalSetExercise { BasicalSetId = 2, ExerciseId = 1, Id = 2 } } };

            var eff = new BasicalSetEfficiency { EfficiencyId = 1, BasicalSetId = 1, Abs = 0, Arms = 2, Back = 3, Cardio = 0, Chest = 2, Legs = 5, BasicalSetOfExercises = set };
            var eff2 = new BasicalSetEfficiency { EfficiencyId = 2, BasicalSetId = 2, Abs = 0, Arms = 2, Back = 3, Cardio = 0, Chest = 2, Legs = 5, BasicalSetOfExercises = set2 };

            using (var context = new ApplicationContext(options))
            {
                context.BasicalSetOfExercises.Add(set);
                context.BasicalSetEfficiencies.Add(eff);
                context.BasicalSetEfficiencies.Add(eff2);
                context.BasicalSetOfExercises.Add(set2);
                context.SaveChanges();
            }

            // Act
            var result = service.GetBasicalSetsSmallInfoBySection(1);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetBasicalSetsSmallInfoBySection_NonExistingSection_ReturnNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new BasicSetService(new ApplicationContext(options));

            // Act
            var result = service.GetBasicalSetsSmallInfoBySection(111);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetBasicalSetFullDescById_ExistingId_ReturnBasicalSet()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var set = service.GetBasicalSetFullDescById(1);

            // Assert
            Assert.Equal(1, set.Id);
        }

        [Fact]
        public void GetBasicalSetFullDescById_NonExistingId_ReturnNull()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new BasicSetService(applicationContextFactory.CreateDbContext(new string[] { }));

            // Act
            var set = service.GetBasicalSetsSmallInfoBySection(10000);

            // Assert
            Assert.Null(set);
        }
    }
}
