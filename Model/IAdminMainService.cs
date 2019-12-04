using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IAdminMainService
    {
        event Action OwnerUpdated;

        IEnumerable<string> GetAllOwners();
        void addOwner(string name);
        void deleteOwner(int id);
//+log()
    }
}
