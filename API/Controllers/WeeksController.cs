using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/weeks")]
    public class WeeksController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetWeeks()
        {
            return Ok(WeeksDataStore.Current.Weeks);
        }

        [HttpGet("{id}")]
        public IActionResult GetWeek(int id)
        {

            var dayToReturn = WeeksDataStore.Current.Weeks.FirstOrDefault(d => d.Id == id);

            if (dayToReturn == null)
            {
                return NotFound();
            }
            return Ok (dayToReturn);
        }
    }
}
