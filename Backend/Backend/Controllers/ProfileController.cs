using Backend.Core.Interfaces;
using Backend.Core.Models.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("/GetUserProfileByUserId/{userId}")]
        public ActionResult<UserProfile> GetUserProfileByUserId(int userId)
        {
            var profile = _profileService.GetUserProfileByUserId(userId);
            if (profile == null)
                return NoContent();
            return Ok(profile);
        }

        [HttpGet]
        [Route("/GetUserTrainingsByUserId/{userId}")]
        public ActionResult<List<TrainingDesc>> GetUserTrainingsByUserId(int userId)
        {
            var trainings = _profileService.GetUserTrainingsByUserId(userId);
            if (trainings == null)
                return BadRequest();
            return Ok(trainings);
        }

        [HttpGet]
        [Route("/GetBasicTrainingsByUserId/{userId}")]
        public ActionResult<List<TrainingDesc>> GetBasicTrainingsByUserId(int userId)
        {
            var trainings = _profileService.GetBasicTrainingsByUserId(userId);
            if (trainings == null)
                return BadRequest();
            return Ok(trainings);
        }
    }
}
