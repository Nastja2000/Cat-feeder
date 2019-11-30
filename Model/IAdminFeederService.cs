using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model
{
    interface IAdminFeederService
    {
        event Action ScheduleUpdated;

        IEnumerable<Schedule> GetAllSchedules();
        //findSchedules(???)
        ImportSchedule(StreamReader reader);
        ExportSchedule(StreamWriter writer);
    }
}
