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

        [HttpGet]
        [Route("/IsResearcher/{userId}")]
        public ActionResult<AchievmentSmallDesc> IsResearcher(int userId)
        {
            var achievment = _achievmentService.IsResearcher(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }

        [HttpGet]
        [Route("/IsCreator/{userId}")]
        public ActionResult<AchievmentSmallDesc> IsCreator(int userId)
        {
            var achievment = _achievmentService.IsCreator(userId);
            if (achievment == null)
                return NotFound();
            return Ok(achievment);
        }


        [HttpPut]
        [Route("/PutAchievment")]
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
