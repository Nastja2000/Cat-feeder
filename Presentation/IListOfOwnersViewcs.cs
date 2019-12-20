using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public interface IListOfOwnersViewcs : IView
    {
        event Action GoBack;
        event Action<int> ShowOwner;

        void ShowOwners(IEnumerable<string> users);
    }

}
