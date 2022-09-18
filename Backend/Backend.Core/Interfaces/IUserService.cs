using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Core.Interfaces
{
    public interface IUserService
    {
        ActionResult<User> Get(LoginUser loginUser);
        HttpStatusCode Create(RegisterUser registerUser);
    }
}
