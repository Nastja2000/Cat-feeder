using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation
{
    public interface IAdminOwnerView : IView
    {
        event Action ShowFeeder;
        event Action GoBack;
        event Action<string> AddFeeder;
        event Action<string> DeleteFeeder;

        void ShowFeeders(IEnumerable<string> feeders);
        //void ChooseFeeder();
        //void Log();
    }
}
