using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model
{
    interface IScheduleService
    {
        event Action ScheduleByOwnerUpdate;

        Schedule GetSchedule();

        void Save(IEnumerable<string> info);
        //+log(Schedule)
    }
}
