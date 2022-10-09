using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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

                var user = new User { Login = registerUser.Login, Password = ConvertPasswordToHash(registerUser.Password), FirstName = registerUser.FirstName, LastName = registerUser.LastName };
                FillAchievments(user);
                FillMuscles(user);
                _context.Users.Add(user);
                _context.SaveChanges();

                return HttpStatusCode.Created;
            }
            catch (Exception)
            {
                throw;
            }
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
        /// Checks if the entered password matches the real password
        /// </summary>
        /// <param name="user">Actual user with entered log in data.</param>
        /// <param name="loginUser">User`s entered log in data.</param>
        /// <returns>If entered password mathes actual password.</returns>
        private bool UserPasswordValidation(User? user, LoginUser loginUser)
        {
            if (user == null)
                return false;
            if (user?.Password == ConvertPasswordToHash(loginUser?.Password))
                return true;

            return false;
        }

        /// <summary>
        /// Fills all achievments to user with ISDone = false.
        /// </summary>
        /// <param name="user"></param>
        private void FillAchievments(User user)
        {
            var achievments = _context.Achievments.ToList();
            for (int i = 0; i < achievments.Count; i++)
            {
                user.UsersAchievments.Add(new UserAchievment { Achievment = achievments[i], IsDone = false });
            }
        }

        /// <summary>
        /// Fills all muscles with 0 points to user.
        /// </summary>
        /// <param name="user"></param>
        private void FillMuscles(User user)
        {
            var muscles = _context.Muscles.ToList();
            for (int i = 0; i < muscles.Count; i++)
            {
                user.UserMuscles.Add(new UserMuscles { UserId = user.UserId, MuscleId = muscles[i].MuscleId, MusclePoints = 0});
            }
        }

        /// <summary>
        /// Converts password to hash.
        /// </summary>
        /// <param name="password">Password string to convert.</param>
        /// <returns>Hash of password.</returns>
        private string ConvertPasswordToHash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    } 
}
