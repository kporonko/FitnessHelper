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
    public class ProfileServiceTests
    {
        [Fact]
        public void GetUserProfileByUserId_ValidUserId_ReturnsUserDesc()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var newUser = new User { UserId = 20, FirstName = "Profile", LastName = "Profile", Login = "ddd", Password = "ddddddddd" };
            using (var context = new ApplicationContext(options))
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }

            var service = new ProfileService(new ApplicationContext(options));

            // Act
            var result = service.GetUserProfileByUserId(20);
            using (var context = new ApplicationContext(options))
            {
                context.Users.Remove(newUser);
                context.SaveChanges();
            }
            // Assert
            Assert.Equal("Profile Profile", result.Name);
        }


        [Fact]
        public void GetUserProfileByUserId_InvalidUserId_ReturnsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;

            var service = new ProfileService(new ApplicationContext(options));

            // Act
            var result = service.GetUserProfileByUserId(4333);

            // Assert
            Assert.Null(result);
        }
    }
}
