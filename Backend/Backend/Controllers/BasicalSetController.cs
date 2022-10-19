using Backend.Core.Interfaces;
using Backend.Core.Models.BasicSets;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicalSetController : ControllerBase
    {
        private readonly IBasicSetService _basicSetService;
        public BasicalSetController(IBasicSetService basicSetService)
        {
            _basicSetService = basicSetService;
        }

        [HttpGet]
        [Route("/BasicalSetBySection/{section}")]
        public ActionResult<List<BasicalSetInfo>> BasicalSetBySection(int section)
        {
            var sets = _basicSetService.GetBasicalSetsSmallInfoBySection(section);
            if (sets == null)
                return NotFound();

            return sets;
        }

        [HttpGet]
        [Route("/BasicalSetById/{id}")]
        public ActionResult<BasicalSetFullInfo> BasicalSetById(int id)
        {
            var set = _basicSetService.GetBasicalSetFullDescById(id);
            if (set == null)
                return NotFound();

            return set;
        }
    }
}
