using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DayForCreationDto
    {
        [Required(ErrorMessage = "No date.")]
        [MaxLength(20)]
        public string Date { get; set; }
        [MaxLength(10)]
        public string WeekDay {get; set; }
    }
}