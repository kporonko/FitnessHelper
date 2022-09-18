using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Core.Interfaces
{
    public interface IUserService
    {
        User? Get(LoginUser loginUser);
        HttpStatusCode Create(RegisterUser registerUser);
    }
}
