using System.Diagnostics;

namespace DVDL_dataLayer
{
    static public class clsDataAccessSetting
    {
        public static string stringConnection = "Server=.;Database=P2-Library;Trusted_Connection=True;";

        public static void LogEx(string ex, EventLogEntryType type)
        {
            string sourceName = "Library";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }


            // Log an information event
            EventLog.WriteEntry(sourceName, ex, type);
        }
    }
}
