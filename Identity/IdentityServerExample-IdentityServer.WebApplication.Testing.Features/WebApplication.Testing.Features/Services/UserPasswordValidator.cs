using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace WebApplication1.Testing.Features.Services
{
    public sealed class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UserPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string connString = "Data Source=localhost\\SQLSERVER;Initial Catalog=TrainingHelperAlevel;Integrated Security=True;MultipleActiveResultSets=true";
            string query = "SELECT Login, Password FROM [dbo].[User]";
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    int i = 0;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserName = reader.GetString(0);
                        user.Password = reader.GetString(1);
                        users.Add(user);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var username = context.UserName;
            var password = context.Password;

            string hash = ConvertPasswordToHash(password);
            if (users.Any(x => x.UserName == username && x.Password == hash))
            {
                context.Result = new GrantValidationResult(username, "pwd");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid Credentials");
            return Task.CompletedTask;
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
