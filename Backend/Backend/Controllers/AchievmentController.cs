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
        [Route("/TrainingAchievements/{userId}")]
        public ActionResult<AchievmentSmallDesc> TrainingAchievements(int userId)
        {
            var achievment = _achievmentService.TrainingAchievements(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/FiveBasicalTrainings/{userId}")]
        public ActionResult<AchievmentSmallDesc> FiveBasicalTrainings(int userId)
        {
            var achievment = _achievmentService.Is5BasicalTrainings(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/FiveOwnTrainings/{userId}")]
        public ActionResult<AchievmentSmallDesc> FiveOwnTrainings(int userId)
        {
            var achievment = _achievmentService.Is5OwnTrainings(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/Researcher/{userId}")]
        public ActionResult<AchievmentSmallDesc> IsResearcher(int userId)
        {
            var achievment = _achievmentService.IsResearcher(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/Creator/{userId}")]
        public ActionResult<AchievmentSmallDesc> IsCreator(int userId)
        {
            var achievment = _achievmentService.IsCreator(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }


        [HttpPut]
        [Route("/Achievment")]
        public IActionResult Achievment(UserAchievmentDto userAchievmentDto)
        {
            var code = _achievmentService.PutAchievment(userAchievmentDto.AchievmentId, userAchievmentDto.UserId);
            if ((int)code == 200)
                return Ok();
            return NotFound();
        }

        [HttpGet]
        [Route("/Achievments/{userId}")]
        public IActionResult Achievments(int userId)
        {
            var list = _achievmentService.GetAllAchievments(userId);
            if (list.Count > 0)
                return Ok(list);
            return NotFound();
        }
    }
}
