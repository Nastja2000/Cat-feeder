using System;
using System.Collections.Generic;

namespace Presentation
{
    public interface IAdminView : IView
    {
        event Action ShowOwner;
        event Action GoBack;
        event Action<string> addOwner;
        event Action<string> deleteOwner;

        void ShowOwners(IEnumerable<string> users);
        void ShowError(string message);
        //void ChooseUser();
        //void Log();
    }
}
