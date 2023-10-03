using TimeTrackerUI.Data;
using TimeTrackerUI.Models;

namespace TimeTrackerUI.Pages
{
    public partial class TimeEntryComponent
    {
        public TimeEntry Model { get; set; } = new TimeEntry();

        public List<TimeTracker> ExistingTimeEntries = new List<TimeTracker>();

        void SaveEntry()
        {
            Console.WriteLine($"Saving Entry {Model}");
            TimeTracker newRow = new TimeTracker();
            newRow.EntryTime = Model.Entry;
            newRow.EntryDate = DateOnly.FromDateTime(Model.EntryDate);
            newRow.PersonName = Model.Name;
            newRow.ExitTime = Model.Exit;
            newRow.TotalHours = Model.Exit - Model.Entry;
            ExistingTimeEntries.Add(newRow);
        }
        void ClearUI(){
            
        }
        void PersistAllEntries()
        {
            using (TTContext ttContext = new TTContext())
            {
                foreach (var ttEntry in ExistingTimeEntries)
                {                    
                    ttContext.Add(ttEntry);
                }
                ttContext.SaveChanges();
            }
        }
    }
}