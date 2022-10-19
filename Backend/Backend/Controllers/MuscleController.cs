using Backend.Core.Interfaces;
using Backend.Core.Models.Muscles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MuscleController : ControllerBase
    {
        private readonly IMuscleService _muscleService;
        public MuscleController(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        [HttpGet]
        [Route("/MuscleById/{id}")]
        public ActionResult<MuscleFullDesc> MuscleById(int id)
        {
            var muscle = _muscleService.GetMuscleById(id);
            if (muscle is null)
                return NotFound();
            return muscle;
        }
    }
}
