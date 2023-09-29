using TimeTrackerUI.Data;
using TimeTrackerUI.Models;

namespace TimeTrackerUI.Pages
{
    public partial class TimeEntryComponent
    {
        public TimeEntry Model { get; set; } = new TimeEntry();

        public List<TimeEntryTable> ExistingTimeEntries = new List<TimeEntryTable>();

        void SaveEntry()
        {
           Console.WriteLine($"Saving Entry {Model}");
            TimeEntryTable newRow = new TimeEntryTable();
            newRow.EntryTime = Model.Entry;
            newRow.EntryDate = DateOnly.FromDateTime(Model.EntryDate);
            newRow.PersonName = Model.Name;
            newRow.ExitTime = Model.Exit;
            newRow.TotalHours = Model.Exit - Model.Entry;
        }
    }
}