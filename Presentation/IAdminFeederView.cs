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

        string ownerName { get; set; }

        void ShowSchs(IEnumerable<string> characters);

    //    void ShowError(string message);
    }
}
