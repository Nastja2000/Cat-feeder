using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IImitationView : IView
    {
        int id { get; }
        string CountOfFood { get; }
        string EatingQuantVal { get; }
        string StepSizeVal { get; }
        string EatingFreqVal { get; }

       // string TurnDurationLimit { get; set; }

        event Action ShowUser;
        event Action ShowAdmin;

        event Action StartImmitation;
        event Action StopImmitation;
        event Action addFood;
        event Action setEatingQuan;
        event Action setEatingFreq;
        event Action setStepSize;

        void ShowFood(IEnumerable<string> food);
        void ShowFeederStatus(int countOfFood);
        void ShowTime(TimeSpan imit_duration);
        void ImitationStarted();
        void ImitationStopped();
        void ShowError(string message);
    }
}
