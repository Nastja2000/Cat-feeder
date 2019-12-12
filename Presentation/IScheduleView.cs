using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IScheduleView : IView
    {
        string TurnDurationLimit { get; set; }

        event Action GoBack;
        event Action<string> Save;
        //event Action<bool> AddMark;

        void ShowError(string message);
    }
}
