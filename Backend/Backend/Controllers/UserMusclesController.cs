using Backend.Core.Interfaces;
using Backend.Core.Models.UserMuscles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMusclesController : ControllerBase
    {
        private readonly IUserMusclesService _userMuscleService;
        public UserMusclesController(IUserMusclesService userMuscleService)
        {
            _userMuscleService = userMuscleService;
        }

        [HttpGet]
        [Route("/UserMuscles/{userId}")]
        public ActionResult<List<UserMuscleSmallDesc>> UserMuscles(int userId)
        {
            var muscles = _userMuscleService.GetUserMuscles(userId);
            if (muscles.Count == 0)
                return NotFound();
            return Ok(muscles);
        }

        [HttpPut]
        [Route("/UserMuscles")]
        public IActionResult UserMuscles(MusclesForUpdate musclesForUpdate)
        {
            var code = _userMuscleService.UpdateUserMuscles(musclesForUpdate);
            return Ok();
        }
    }
}
