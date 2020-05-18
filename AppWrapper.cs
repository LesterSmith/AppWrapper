using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace AppWrapper
{
    public class AppWrapper
    {
        public enum ReporterBreak
        {
            None = 0,
            Day = 1,
            Week = 2,
            Month = 3
        }

        public enum WindowEventType
        {
            EventHook = 0, // SetWinEventHook to use events
            Polling =1 // poll on timer thru GetWindowTitle
        }
        public static string DevTrkrConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[DBName].ConnectionString; }
        }
        //public static string devenv = "devenv";
        //public const string VSCode = "Code";
        //public const string VSCodeUnknown = "vscodeUnknown";
        //public const string VSUnknown = "VSUnknown";
        //public const string appUnknown = "appUnknown";
        public const string AppName = "DevTracker";
        public const string Settings = "Settings";
        public const string MainOnTop = "MainOnTop";
        //public const string RunFileWatcher = "RunFileWatcher";
        public const string ProgramError = "Program Error";
        public const string DBName = "DevTrkr";
        // NOTE: Config Option Names
        public const string PollingTimeInterval = "POLLINGTIMEINTERVAL";
        public const string WindowTypeEvents = "WINDOWTYPEEVENTS";
        public const string DevProjFileExtension = "IDEPROJECTFILEEXTENSION";
        public const string RecordApps = "RECORDAPPS";
        public const string RecordFiles = "RECORDFILES";
        public const string CacheExpirationTime = "CACHEEXPIRATIONTIME";
        public const string FileWatcherDirecory = "FILEWATCHERDIRECTORY";
        public const string CalendarQueriedTime = "CALENDARQUERIEDTIME";
        // NOTE: End of Config Option Names
    }
}
