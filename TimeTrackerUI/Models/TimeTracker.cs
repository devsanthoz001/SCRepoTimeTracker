using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerUI.Models
{
    [Table("TimeTracker",Schema ="tt")]
    public class TimeTracker
    {
        [Required]
        public int Id { get; set; }
        [Column("Name")]
        public string PersonName { get; set; } = string.Empty;
        [Column("EntryForDate")]
        public DateOnly EntryDate { get; set; }
        [Column("EntryTime")]
        public DateTime EntryTime { get; set; }
        [Column("ExitTime")]
        public DateTime ExitTime { get; set; }
        [Column("TotalHours")]
        public TimeSpan TotalHours { get; set; }
    }
}
