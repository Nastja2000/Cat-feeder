using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.services
{
    public interface IScheduleService
    {
        event Action<string> ScheduleUpdated;

        Schedule GetSchedule(string name);
     
        //testS
        void Save(IEnumerable<string> info);
       // void AddMark(string mark);
        //+log(Schedule)
    }
}
