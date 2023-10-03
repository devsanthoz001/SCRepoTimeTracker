using TimeTrackerUI.Data;
using TimeTrackerUI.Models;

namespace TimeTrackerUI.Pages
{
    public partial class TimeEntryComponent
    {
        const string FILETIMEENTRIES = "MyTimeEntries.txt";
        public TimeEntry Model { get; set; } = new TimeEntry();

        public List<TimeTracker> ExistingTimeEntries = new List<TimeTracker>();

        public TimeEntryComponent(){
            if(File.Exists(FILETIMEENTRIES)){
                using(StreamReader sr = new StreamReader(FILETIMEENTRIES)){
                    string lineRead = sr.ReadLine();
                    lineRead = sr.ReadLine();
                    while(!string.IsNullOrEmpty(lineRead)){
                        if(lineRead.Contains("|")){
                            TimeTracker timeTracker = new TimeTracker(lineRead);
                            ExistingTimeEntries.Add(timeTracker);
                        }
                        lineRead = sr.ReadLine();
                    }
                }
            }
        }

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
        void ClearUI()
        {

        }
        void PersistAllEntries()
        {
            // using (TTContext ttContext = new TTContext())
            // {
            //     foreach (var ttEntry in ExistingTimeEntries)
            //     {                    
            //         ttContext.Add(ttEntry);
            //     }
            //     ttContext.SaveChanges();
            // }

            using (StreamWriter sw = new StreamWriter(FILETIMEENTRIES))
            {
                sw.WriteLine(new TimeTracker().Columns());
                foreach (var ttEntry in ExistingTimeEntries)
                {
                    sw.WriteLine(ttEntry);
                }
            }
        }
    }
}