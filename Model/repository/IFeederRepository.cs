using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.repository
{
    interface IFeederRepository : IRepository<Feeder>
    {
        public IEnumerable<Feeder> readByOwner(Owner owner);
        public IEnumerable<Schedule> GetSchedules(int id);


        /* возможно добавим позднее
        +readByType???*/

    }
}
