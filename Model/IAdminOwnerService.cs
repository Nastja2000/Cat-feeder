using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAdminOwnerService
    {
        IEnumerable<Feeder> GetAllFeeder();
        void addFeeder(/*что прийдёт из форм*/);
        void deleteFeeder(int Id);
//+log(owner: Owner)

    }
}
