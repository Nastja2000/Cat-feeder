using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.repository
{
    interface IFeederRepository : IRepository<Feeder>
    {
        IEnumerable<Feeder> readByOwner(Owner owner);
        /* возможно добавим позднее
        +readByType???*/

    }
}
