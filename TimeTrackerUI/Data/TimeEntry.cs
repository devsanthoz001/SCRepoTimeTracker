
namespace TimeTrackerUI.Data
{
    public partial class TimeEntry
    {
        public string Name { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Now.Date;
        public DateTime Entry { get; set; } = DateTime.MinValue;
        public DateTime Exit { get; set; } = DateTime.MinValue;
        public  DateTime TotalHours { get; set; } = DateTime.MaxValue;

        
        public override string ToString()
        {
            return $"Today {EntryDate}, Name: {Name} Started work at {Entry} and stopped at {Exit}. Total Work hours : {(Exit - Entry).TotalHours}";
        }
    }
}