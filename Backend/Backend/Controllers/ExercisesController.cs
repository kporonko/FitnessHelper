using Backend.Core.Interfaces;
using Backend.Core.Models.Exercises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        [Route("/Exercises")]
        public ActionResult<List<ExerciseSmallDescription>> Exercises()
        {
            var exercises = _exerciseService.AllExercises();
            if (exercises.Count == 0)
                return NotFound();
            return Ok(exercises);
        }

        [HttpGet]
        [Route("/ExercisesSearch/{search}")]
        public ActionResult<List<ExerciseSmallDescription>> ExercisesSearch(string search)
        {
            var exercises = _exerciseService.ExercisesSearch(search);
            if (exercises.Count == 0)
                return NotFound();
            return Ok(exercises);
        }

        [HttpGet]
        [Route("/ExercisesByPartOfBody/{partOfBody}")]
        public ActionResult<List<ExerciseSmallDescription>> ExercisesByPartOfBody(string partOfBody)
        {
            var exercises = _exerciseService.ExercisesByPartOfBody(partOfBody);
            if (exercises.Count == 0)
                return NotFound();
            return Ok(exercises);
        }

        [HttpGet]
        [Route("/ExercisesByUserSet/{setId}")]
        public ActionResult<ExercisesUserSet> ExercisesByUserSet(int setId)
        {
            var exercises = _exerciseService.ExercisesByUserSet(setId);
            return Ok(exercises);
        }

        [HttpGet]
        [Route("/ExerciseById/{id}")]
        public ActionResult<ExerciseFull> ExerciseById(int id)
        {
            var exercise = _exerciseService.ExerciseById(id);
            if (exercise is null)
                return NotFound();
            return exercise;
        }
    }
}
