using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;

namespace API.Entities
{
    public class Week
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "No name.")]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Day> Days {get; set;} = 
            new List<Day>();
    }
}