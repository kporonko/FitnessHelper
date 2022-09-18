using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Core.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="registerUser">User`s registration data.</param>
        /// <returns>If new user is created.</returns>
        public HttpStatusCode Create(RegisterUser registerUser)
        {
            try
            {
                if (IfTheUserLoginExists(registerUser))
                    return HttpStatusCode.Conflict;
                
                _context.Users.Add(new User { Login = registerUser.Login, Password = registerUser.Password, FirstName = registerUser.FirstName, LastName = registerUser.LastName });
                _context.SaveChanges();
                return HttpStatusCode.Created;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if the user with entered login already exists.
        /// </summary>
        /// <param name="registerUser">User`s registration data.</param>
        /// <returns>Whether the user login exists.</returns>
        private bool IfTheUserLoginExists(RegisterUser registerUser)
        {
            User? user = _context.Users.FirstOrDefault(x => x.Login == registerUser.Login);
            if (user != null)
                return true;
            
            return false;
        }

        /// <summary>
        /// Gets the user with the entered login & password.
        /// </summary>
        /// <param name="loginUser">User`s entered login data.</param>
        /// <returns>User if entered data was correct. Null if data was incorrect.</returns>
        public User? Get(LoginUser loginUser)
        {
            try
            {
                User? user = _context.Users.FirstOrDefault(x => x.Login == loginUser.Login);
                if (UserPasswordValidation(user, loginUser))
                    return user;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if the entered password matches the real password
        /// </summary>
        /// <param name="user">Actual user with entered log in data.</param>
        /// <param name="loginUser">User`s entered log in data.</param>
        /// <returns>If entered password mathes actual password.</returns>
        private bool UserPasswordValidation(User? user, LoginUser loginUser)
        {
            if (user?.Password == loginUser?.Password)
                return true;

            return false;
        }
    } 
}
