using Backend.Core.Interfaces;
using Backend.Core.Models.Achievments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AchievmentController : ControllerBase
    {
        private readonly IAchievmentService _achievmentService;
        public AchievmentController(IAchievmentService achievmentService)
        {
            _achievmentService = achievmentService;
        }

        [HttpGet]
        [Route("/TrainingExercises/{userId}")]
        public ActionResult<AchievmentSmallDesc> TrainingExercises(int userId)
        {
            var achievment = _achievmentService.TrainingExercises(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/Is5BasicalTrainings/{userId}")]
        public ActionResult<AchievmentSmallDesc> Is5BasicalTrainings(int userId)
        {
            var achievment = _achievmentService.Is5BasicalTrainings(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/Is5OwnTrainings/{userId}")]
        public ActionResult<AchievmentSmallDesc> Is5OwnTrainings(int userId)
        {
            var achievment = _achievmentService.Is5OwnTrainings(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpPut]
        [Route("/PutAchievment/{userId}")]
        public IActionResult PutAchievment(UserAchievmentDto userAchievmentDto)
        {
            var code = _achievmentService.PutAchievment(userAchievmentDto.AchievmentId, userAchievmentDto.UserId);
            if ((int)code == 200)
                return Ok();
            return NotFound();
        }

        [HttpGet]
        [Route("/GetAllAchievments/{userId}")]
        public IActionResult GetAllAchievments(int userId)
        {
            var list = _achievmentService.GetAllAchievments(userId);
            if (list.Count > 0)
                return Ok(list);
            return NotFound();
        }
    }
}
