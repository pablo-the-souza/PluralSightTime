using System.Collections.Generic;
using API.Models;

namespace API
{
    public class WeeksDataStore
    {
        public static WeeksDataStore Current {get; } = new WeeksDataStore();
        // ensures we keep working on the same instance 
        public List<WeekDto> Weeks {get; set; }
        public WeeksDataStore()
        {
            Weeks = new List<WeekDto>()
                {
                    new  WeekDto()
                    {
                        Id = 1,
                        Name = "Week 40",
                        Days = new List<DayDto>()
                        {
                            new  DayDto() {Id = 1, Date = "2020-09-30", WeekDay = "Wednesday"},
                            new  DayDto() {Id = 2, Date = "2020-10-01", WeekDay = "Thursday"},
                            new  DayDto() {Id = 3, Date = "2020-10-02", WeekDay = "Friday"}
                        }
                    },

                    new  WeekDto() 
                    {
                        Id = 2, 
                        Name = "Week 41",
                        Days = new List<DayDto>()
                        {
                            new  DayDto() {Id = 4, Date = "2020-09-09", WeekDay = "Friday"},
                            new  DayDto() {Id = 5, Date = "2020-10-10", WeekDay = "Saturday"},
                            new  DayDto() {Id = 6, Date = "2020-10-11", WeekDay = "Sunday"}
                        }
                    },

                    new  WeekDto() 
                    {
                        Id = 3, 
                        Name = "Week 42",
                        Days = new List<DayDto>()
                        {
                            new  DayDto() {Id = 7, Date = "2020-09-18", WeekDay = "Saturday"},
                            new  DayDto() {Id = 8, Date = "2020-10-19", WeekDay = "Sunday"},
                            new  DayDto() {Id = 9, Date = "2020-10-20", WeekDay = "Monday"}
                        }
                    }
                };
        }
    }
}