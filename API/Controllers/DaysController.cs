using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/weeks/{weekId}/days")]
    public class DaysController : ControllerBase
    {
        private readonly ILogger<DaysController> _logger;
        public DaysController(ILogger<DaysController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult GetDays(int weekId)
        {
            try
            {
                var week = WeeksDataStore.Current.Weeks
                    .FirstOrDefault(d => d.Id == weekId);
                    
                if (week == null)
                {
                    _logger.LogInformation($"week with id {weekId} wasn't found when acessing days.");
                    return NotFound();
                }
                return Ok(week.Days);
            }
            catch 
            {
                _logger.LogCritical($"Exception while getting days for week with id {weekId}.");
                return StatusCode(500,"A problem happened while handling your request");
            }
        }

        [HttpGet("{id}", Name = "GetDay")]
        public IActionResult GetDay(int weekId, int id)
        {
            var week = WeeksDataStore.Current.Weeks
                .FirstOrDefault(w => w.Id == weekId);

            if (week == null)
            {
                return NotFound();
            }

            var dayToReturn = week.Days
                .FirstOrDefault(d => d.Id == id);

            if (dayToReturn == null)
            {
                return NotFound();
            }

            return Ok(dayToReturn);
        }

        [HttpPost]
        public IActionResult CreateDay(int weekId, DayForCreationDto day)
        {
            var week = WeeksDataStore.Current.Weeks
                .FirstOrDefault(w => w.Id == weekId);

            if (week == null)
            {
                return NotFound();
            }

            var maxDayId = WeeksDataStore.Current.Weeks
                .SelectMany(w => w.Days).Max(d => d.Id);
            // find highest id 

            var finalDay = new DayDto()
            {
                Id = ++maxDayId,
                Date = day.Date,
                WeekDay = day.WeekDay

            };
            // add 1 to create id

            week.Days.Add(finalDay);

            return CreatedAtRoute(
                "GetDay",
                new { weekId, id = finalDay.Id },
                finalDay);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDay(int weekId, int id, [FromBody] DayForUpdateDto day)
        {
            var week = WeeksDataStore.Current.Weeks
                .FirstOrDefault(w => w.Id == weekId);

            if (week == null)
            {
                return NotFound();
            }

            var dayFromStore = week.Days
                .FirstOrDefault(d => d.Id == id);

            if (day == null)
            {
                return NotFound();
            }

            dayFromStore.Date = day.Date;
            dayFromStore.WeekDay = day.WeekDay;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateDay(int weekId, int id, [FromBody] JsonPatchDocument<DayForUpdateDto> patchDoc)
        {
            var week = WeeksDataStore.Current.Weeks
                .FirstOrDefault(w => w.Id == weekId);

            if (week == null)
            {
                return NotFound();
            }

            var dayFromStore = week.Days
                .FirstOrDefault(d => d.Id == id);

            if (dayFromStore == null)
            {
                return NotFound();
            }

            var dayToPatch =
                new DayForUpdateDto()
                {
                    Date = dayFromStore.Date,
                    WeekDay = dayFromStore.WeekDay
                };

            patchDoc.ApplyTo(dayToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(dayToPatch))
            {
                return BadRequest(ModelState);
            }

            dayFromStore.Date = dayToPatch.Date;
            dayFromStore.WeekDay = dayToPatch.WeekDay;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDay(int weekId, int id)
        {
            var week = WeeksDataStore.Current.Weeks
                .FirstOrDefault(w => w.Id == weekId);

            if (week == null)
            {
                return NotFound();
            }

            var dayFromStore = week.Days
                .FirstOrDefault(d => d.Id == id);

            if (dayFromStore == null)
            {
                return NotFound();
            }

            week.Days.Remove(dayFromStore);

            return NoContent();
        }
    }
}