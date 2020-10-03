using System.Collections.Generic;

namespace API.Models
{
    public class WeekDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DayDto> Days {get; set;} = 
            new List<DayDto>();
    }
}