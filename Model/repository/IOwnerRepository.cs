using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.repository
{
    public interface IOwnerRepository
    {
        IEnumerable<Schedule> GetSchedules(int id);
        IEnumerable<Feeder> GetFeeders(int id);
    }
}
