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
        string TurnFoodAmount { get; set; }

        event Action<string, string> GoBack;
        event Action<IEnumerable<string>> Save;

        string ownerName { get; set; }
        string feederName { get; set; }
        string scheduleName { get; set; }

        //TODO ???? Mark это строка, идёт отдельным набором полей в сэйве
        // event Action<string> AddMark;

        void ShowError(string message);
    }
}
