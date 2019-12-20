using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation
{
    public interface IOwnerView : IView
    {
        event Action<string> addFeeder;
        event Action GoBack;
        event Action<string> deleteFeeder;
        event Action ShowFeeder;

        void ShowFeeders(IEnumerable<string> feeders);
        //void ChooseFeeder();
        //void Log();
    }
}
