using System;
using System.Collections.Generic;


namespace Presentation
{
    public interface IAdminFeederView : IView
    {
        event Action<string> ShowSch;
        event Action<string, string> ImportSchedule;
        event Action<string, string> ExportSchedule;
        //event Action<string> AddSch;
        //event Action<string> DeleteSch;
        event Action<string> GoBack;

        event Action<string, IEnumerable<string>> Save;
        string ownerName { get; set; }
        string feederName { get; set; }

        void ShowSchs(IEnumerable<string> characters);

    //    void ShowError(string message);
    }
}
