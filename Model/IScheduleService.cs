using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model
{
    public interface IScheduleService
    {
        event Action ScheduleByOwnerUpdate;

        Schedule GetSchedule();
     
        //testS
        void Save(IEnumerable<string> info);
        //+log(Schedule)
    }
}
