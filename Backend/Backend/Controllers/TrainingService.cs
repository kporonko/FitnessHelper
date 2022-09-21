using Backend.Core.Interfaces;
using Backend.Core.Models.Trainings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainingService : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public TrainingService(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        [Route("/CreateAndAddBasicTraining")]
        public IActionResult CreateAndAddBasicTraining(AddBasicTraining addBasicTraining)
        {
            if ((int)_trainingService.CreateAndAddBasicTraining(addBasicTraining) == 201)
                return CreatedAtAction(nameof(CreateAndAddBasicTraining), addBasicTraining);
            return BadRequest();
        }

        [HttpPost]
        [Route("/CreateAndAddUserTraining")]
        public IActionResult CreateAndAddUserTraining(AddUserTraining addUserTraining)
        {
            if ((int)_trainingService.CreateAndAddUserTraining(addUserTraining) == 201)
                return CreatedAtAction(nameof(CreateAndAddUserTraining), addUserTraining);
            return BadRequest();
        }
    }
}
