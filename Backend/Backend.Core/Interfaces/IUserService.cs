using Backend.Core.Models;
using Backend.Infrastructure.Models;
 using System.Net;

namespace Backend.Core.Interfaces
{
    public interface IUserService
    {
        User? Get(LoginUser loginUser);
        HttpStatusCode Create(RegisterUser registerUser);
    }
}
