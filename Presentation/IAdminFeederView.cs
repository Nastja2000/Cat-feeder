using System;
using System.Collections.Generic;


namespace Presentation
{
    public interface IAdminFeederView : IView
    {
        event Action ShowSch;
        event Action<string> ImportSchedule;
        event Action<string> ExportSchedule;
        //event Action<string> AddSch;
        //event Action<string> DeleteSch;
        event Action GoBack;

        void ShowSchs(IEnumerable<string> characters);

    //    void ShowError(string message);
    }
}
