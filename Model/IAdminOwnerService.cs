using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IAdminOwnerService
    {

        event Action FeederUpdated;

        IEnumerable<Feeder> GetAllFeeders();

        void addFeeder(string name);
        void deleteFeeder(int Id);
        //+log(owner: Owner)
    }
}
