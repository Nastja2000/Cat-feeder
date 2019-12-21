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

        event Action<string> OwnerUpdated;

        IEnumerable<string> GetAllFeeders(string name);

        void addFeeder(string nameOwn, string nameFeed);
        void deleteFeeder(string ownerName, string nameFeed);
        //+log(owner: Owner)

    }
}
