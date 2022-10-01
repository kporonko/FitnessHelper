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
                        User user = new User { UserName = reader[i].ToString(), Password = reader[i+1].ToString() };
                        users.Add(user);
                        i += 1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var username = context.UserName;
            var password = context.Password;

            //byte[] hash = SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes(password)); // for the future.
            if (users.Any(x => x.UserName == username && x.Password == password))
            {
                context.Result = new GrantValidationResult(username, "pwd");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid Credentials");
            return Task.CompletedTask;
        }
    }
}
