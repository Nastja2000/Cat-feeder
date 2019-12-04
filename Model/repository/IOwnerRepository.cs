using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.repository
{
    interface IOwnerRepository
    {
        IEnumerable<Schedule> GetSchedules(int id);
        IEnumerable<Feeder> GetFeeders(int id);
    }
}
