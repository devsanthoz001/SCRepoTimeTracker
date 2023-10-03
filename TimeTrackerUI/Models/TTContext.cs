using Microsoft.EntityFrameworkCore;

namespace TimeTrackerUI.Models
{
    public class TTContext : DbContext
    {

       public DbSet<TimeTracker> TimeEntries {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + "./TimeTracker.db");
        }

    }

}