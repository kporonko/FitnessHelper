using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/Login")]
        public ActionResult<User> Login(string login,[DataType(DataType.Password)] string password)
        {
            var user = _userService.Get(new LoginUser { Login = login, Password = password });
            if (user == null)
                return NoContent();
            return Ok(user);
            
        }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser)
        {
            if((int)_userService.Create(registerUser) == 201)
                return CreatedAtAction(nameof(Register), registerUser);
            return Conflict();
        }
    }
}
