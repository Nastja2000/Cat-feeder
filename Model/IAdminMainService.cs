using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAdminMainService
    {
        IEnumerable<Owner> GetAllOwners();
        void addOwner(/*что прийдёт из форм*/);
        void deleteOwner(int id);
//+log()
    }
}
