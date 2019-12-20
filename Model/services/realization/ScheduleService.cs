using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.services.realization
{
    public class ScheduleService : IScheduleService
    {
        public event Action ScheduleByOwnerUpdate;

        public Schedule GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<string> info)
        {
            throw new NotImplementedException();
        }
    }
}
