using System;
using System.Collections.Generic;

namespace Presentation
{
    public interface IAdminView : IView
    {
        event Action ShowUser;
        event Action GoBack;
        event Action<string> AddUser;
        event Action<string> DeleteUser;

        void ShowUsers(IEnumerable<string> users);
        void ShowError(string message);
        //void ChooseUser();
        //void Log();
    }
}
