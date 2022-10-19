using Backend.Core.Models;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using DeepEqual.Syntax;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Backend.Core.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void UserGet_NonExistingUser_ReturnNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserService(new ApplicationContext(options));
            var user = new LoginUser { Password = "NonExistingPassword", Login = "NonExistingLogin" };

            // Act
            var result = service.Get(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UserGet_ExistingUser_ReturnUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserService(new ApplicationContext(options));
            var newUser = new User { UserId = 2, FirstName = "First", LastName = "Second", Login = "SecondTestLogin", Password = "SecondTestPassword" };
            using (var context = new ApplicationContext(options))
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            var user = new LoginUser { Password = "SecondTestPassword", Login = "SecondTestLogin" };

            // Act
            var result = service.Get(user);

            // Assert
            Assert.Equal(newUser.UserId, result.UserId);
        }

        [Fact]
        public void UserCreate_UserWithExistingLogin_NotCreatedUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserService(new ApplicationContext(options));
            var user = new RegisterUser { Password = "Second", FirstName = "Second", LastName = "Second", Login = "Login2" };
            var newUser = new User { UserId = 3, FirstName = "First", LastName = "Second", Login = "Login2", Password = "Password2" };
            using (var context = new ApplicationContext(options))
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            // Act
            var result = service.Create(user);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Conflict, result);
        }

        [Fact]
        public void UserCreate_UserWithNonExistingLogin_CreatedUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Gym")
                .Options;
            var service = new UserService(new ApplicationContext(options));
            var user = new RegisterUser { Password = "Password", FirstName = "First", LastName = "Last", Login = "Login" };

            // Act
            var result = service.Create(user);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, result);
        }
    }
}