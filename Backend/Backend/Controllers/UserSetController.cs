using Backend.Core.Interfaces;
using Backend.Core.Models.UserSets;
using Backend.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSetController : ControllerBase
    {
        private readonly IUserSetService _userSetService;
        public UserSetController(IUserSetService userSetService)
        {
            _userSetService = userSetService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/UserSets/{userId}")]
        public ActionResult<List<UserSetOfExercisesSmallDesc>> UserSets(int userId)
        {
            var sets = _userSetService.GetListOfUserSetsSmallDesc(userId);
            if (sets == null)
                return NotFound();

            return sets;
        }

        [HttpPost]
        [Route("/UserSet")]
        public IActionResult UserSet(AddUserSet addUserSet)
        {
            if (_userSetService.AddNewUserSet(addUserSet) == System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return CreatedAtAction(nameof(UserSet), addUserSet);
        }

        [HttpPost]
        [Route("/ExerciseToUserSet")]
        public IActionResult ExerciseToUserSet(AddExerciseToUserSet data)
        {
            if (_userSetService.AddExerciseToUserSet(data) == System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return CreatedAtAction(nameof(ExerciseToUserSet), data);
        }

        [HttpDelete]
        [Route("/UserSet")]
        public IActionResult UserSet(DeleteUserSet deleteUserSet)
        {
            if (_userSetService.DeleteUserSet(deleteUserSet) is System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return Ok();
        }

        [HttpDelete]
        [Route("/ExerciseFromUserSet")]
        public IActionResult DeleteExerciseFromUserSet(DeleteExercise deleteExercise)
        {
            if (_userSetService.DeleteExerciseFromUserSet(deleteExercise) is System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return Ok();
        }
    }
}
