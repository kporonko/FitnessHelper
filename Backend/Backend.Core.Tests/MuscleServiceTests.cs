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
    public class MuscleServiceTests
    {
        [Fact]
        public void GetMuscleById_ValidMuscleId_MuscleDesc()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new MuscleService(new ApplicationContext(options));

            using (var context = new ApplicationContext(options))
            {
                var muscle = new Muscle { MuscleId = 10, Description = "", Name = "TryMuscle", UrlImage = "", PartOfBody = "Neck" };
                context.Muscles.Add(muscle);
                context.SaveChanges();
            }

            // Act
            var result = service.GetMuscleById(10);

            // Assert
            Assert.Equal("TryMuscle", result.Name);
            Assert.Equal(10, result.MuscleId);
        }

        [Fact]
        public void GetMuscleById_NonExistingIdMuscle_ReturnsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new MuscleService(new ApplicationContext(options));

            // Act
            var result = service.GetMuscleById(1111);

            // Assert
            Assert.Null(result);
        }
    }
}
