using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Day
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "No week day")]
        [MaxLength(20)]
        public string WeekDay { get; set; }

        [ForeignKey("WeekId")]
        public Week Week {get; set; }
        public int WeekId {get; set; }
    }
}