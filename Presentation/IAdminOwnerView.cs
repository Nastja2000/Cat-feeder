using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation
{
    public interface IAdminOwnerView : IView
    {
        event Action<string, string> ShowFeeder;
        event Action GoBack;
        event Action<string,string> addFeeder;
        event Action<string, string> deleteFeeder;

        string ownerName { get; set; }

        void ShowFeeders(IEnumerable<string> feeders);
        //void ChooseFeeder();
        //void Log();
    }
}
