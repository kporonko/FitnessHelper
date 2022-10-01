using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Core.Models.User;
using Backend.Infrastructure.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

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
        [Route("/GetToken")]
        public Data GetToken(string login, [DataType(DataType.Password)] string password)
        {
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
            nvc.Add(new KeyValuePair<string, string>("client_id", "ropc_client"));
            nvc.Add(new KeyValuePair<string, string>("client_secret", "secret_1"));
            nvc.Add(new KeyValuePair<string, string>("scope", "openid"));
            nvc.Add(new KeyValuePair<string, string>("username", $"{login}"));
            nvc.Add(new KeyValuePair<string, string>("password", $"{password}"));
            var client = new HttpClient();
            HttpResponseMessage response = client.PostAsync("http://localhost:7199/connect/token", new FormUrlEncodedContent(nvc)).Result;
            var token = response.Content.ReadAsStringAsync().Result;
            Model tokenStr = JsonConvert.DeserializeObject<Model>(token);

            var user = _userService.Get(new LoginUser { Login = login, Password = password });
            if (user is null)
            {
                return new Data();
            }
            Data data = new Data { Token = tokenStr.access_token, UserId = user.UserId };
            return data;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/Login")]
        public IActionResult Login()
        {
            return Ok();
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
