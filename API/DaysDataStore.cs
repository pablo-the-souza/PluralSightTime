using System.Collections.Generic;
using API.Models;

namespace API
{
    public class DaysDataStore
    {
        public static DaysDataStore Current {get; } = new DaysDataStore();
        // ensures we keep working on the same instance 
        public List<DayDto> Days {get; set; }
        public DaysDataStore()
        {
            Days = new List<DayDto>()
                {
                    new  DayDto() {Id = 1, Date = "2020-09-30", WeekDay = "Wednesday"},
                    new  DayDto() {Id = 2, Date = "2020-10-01", WeekDay = "Thursday"},
                    new  DayDto() {Id = 3, Date = "2020-10-02", WeekDay = "Friday"}
                };
        }
    }
}