using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation
{
    public interface IOwnerView : IView
    {
        event Action<string, string> ShowFeeder;
        event Action GoBack;
        event Action<string> AddFeeder;
        event Action<string> DeleteFeeder;

        string ownerName { get; set; }

        void ShowFeeders(IEnumerable<string> feeders);
        //void ChooseFeeder();
        //void Log();
    }
}
