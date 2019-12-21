using System;
using System.Collections.Generic;


namespace Presentation
{
   public interface IFeederView : IView
    {
        event Action<string, string, string> ShowSch;
        event Action<string, string> SetActive;
        event Action<string, string> ImportSchedule;
        event Action<string, string> ExportSchedule;
        event Action<string, string> CreateSchedule;
        event Action<string> GoBack;

        string feederName { get; set; }
        string ownerName { get; set; }

        void ShowSchs(IEnumerable<string> characters);
        void ShowError(string message);
    }
}
