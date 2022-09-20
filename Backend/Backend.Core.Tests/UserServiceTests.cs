using Backend.Core.Models;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Xunit;

namespace Backend.Core.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void UserGet_NonExistingUser_ReturnNull()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserService(applicationContextFactory.CreateDbContext(new string[] { }));
            var userLogin = new LoginUser() { Login = "TestLogin" + (char)new Random().Next(1,100), Password = "TestPassword" + (char)new Random().Next(1, 100) };

            // Act
            var user = service.Get(userLogin);

            // Assert
            Assert.Null(user);
        }

        [Fact]
        public void UserGet_ExistingUser_ReturnId()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserService(applicationContextFactory.CreateDbContext(new string[] { }));
            var userLogin = new LoginUser() { Login = "amonullo@gmail.com", Password = "12345678" };

            // Act
            var user = service.Get(userLogin);

            // Assert
            Assert.Equal(1, user.UserId);
        }

        [Fact]
        public void UserCreate_UserWithExistingLogin_NotCreatedUser()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserService(applicationContextFactory.CreateDbContext(new string[] { }));
            var userRegister = new RegisterUser() { Login = "amonullo@gmail.com", Password = "TestPassword", FirstName = "TestFirstName", LastName = " TestLastName" };

            // Act
            var statusCode = service.Create(userRegister);

            // Assert
            Assert.Equal(409, (int)statusCode);
        }

        [Fact]
        public void UserCreate_UserWithNonExistingLogin_CreatedUser()
        {
            // Arrange
            ApplicationContextFactory applicationContextFactory = new ApplicationContextFactory();
            var service = new UserService(applicationContextFactory.CreateDbContext(new string[] { }));
            var userRegister = new RegisterUser() { Login = "TestLogin", Password = "TestPassword", FirstName = "TestFirstName", LastName = "TestLastName" };

            // Act
            var statusCode = service.Create(userRegister);

            // Assert
            Assert.Equal(201, (int)statusCode);
        }
    }
}