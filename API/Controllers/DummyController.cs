using API.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController : ControllerBase
    {
        private readonly WeekInfoContext _ctx;

        public DummyController(WeekInfoContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
