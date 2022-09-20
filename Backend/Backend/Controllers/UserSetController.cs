using Backend.Core.Interfaces;
using Backend.Core.Models.UserSets;
using Backend.Core.Services;
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
        [Route("/UserSetsByUserId/{userId}")]
        public ActionResult<List<UserSetOfExercisesSmallDesc>> GetListOfUserSetsSmallDescByUserId(int userId)
        {
            var sets = _userSetService.GetListOfUserSetsSmallDesc(userId);
            if (sets == null)
                return NotFound();

            return sets;
        }

        [HttpPost]
        [Route("/CreateNewUserSetOfExercises")]
        public IActionResult CreateNewUserSetOfExercises(AddUserSet addUserSet)
        {
            if (_userSetService.AddNewUserSet(addUserSet) == System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return CreatedAtAction(nameof(CreateNewUserSetOfExercises), addUserSet);
        }

        [HttpPost]
        [Route("/AddExerciseToUserSet")]
        public IActionResult AddExerciseToUserSet(AddExerciseToUserSet data)
        {
            if (_userSetService.AddExerciseToUserSet(data) == System.Net.HttpStatusCode.BadRequest)
                return BadRequest();
            else
                return CreatedAtAction(nameof(AddExerciseToUserSet), data);
        }
    }
}
