using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IImitationView : IView
    {
        string CountOfFood { get; }
        string EatingQuantVal { get; }
        string StepSizeVal { get; }
        string EatingFreqVal { get; }

       // string TurnDurationLimit { get; set; }

        event Action ShowUser;
        event Action ShowAdmin;

        event Action StartImitation;
        event Action StopImitation;
        event Action AddFood;
        event Action EatingQuant;
        event Action EatingFreq;
        event Action StepSize;

        void ShowFeederStatus(int countOfFood);
        void ShowTime(TimeSpan imit_duration);
        void ImitationStarted();
        void ImitationStopped();
        void ShowError(string message);
    }
}
