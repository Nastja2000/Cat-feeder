using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IAdminMainService
    {
        event Action OwnersUpdated;

        //TODO разобраться с тем, передавать ли id
        IEnumerable<string> GetAllOwners();
        void addOwner(string name);
        void deleteOwner(string name);
//+log()
    }
}
