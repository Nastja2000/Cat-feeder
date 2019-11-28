using System;
using System.Collections.Generic;

namespace Presentation
{
    public interface IAdminView : IView
    {
        event Action ShowUser;
      //event Action ShowUsers;
        event Action GoBack;
        event Action<string> AddUser;
        event Action<string> DeleteUser;

        void ChooseUser();
        void Log();
    }
}
