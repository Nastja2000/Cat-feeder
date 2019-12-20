using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IAdminOwnerService
    {

        event Action<int> OwnerUpdated;

        IEnumerable<string> GetAllFeeders(int id);

        void addFeeder(int id, string name);
        void deleteFeeder(int ownerId, int Id);
        //+log(owner: Owner)

    }
}
