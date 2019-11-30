using System;
using System.Collections.Generic;


namespace Presentation
{
   public interface IFeederView : IView
    {
        event Action ShowSch;
        event Action<string> ImportSch;
        event Action<string> ExportSch;
        event Action<string> AddSch;
        event Action GoBack;

        void ShowSchs(IEnumerable<string> characters);
        void ShowError(string message);
    }
}
