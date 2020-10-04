using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class WeekInfoContext: DbContext
    {
        public WeekInfoContext( DbContextOptions<WeekInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Week> Weeks {get; set; }
        public DbSet<Day> Days {get; set; }
    }
}