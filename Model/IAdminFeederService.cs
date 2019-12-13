using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  interface IAdminFeederService
    {
        event Action ScheduleUpdated;

        IEnumerable<Schedule> GetAllSchedules();
        //findSchedules(???)
        void ImportSchedule(StreamReader reader);
        void ExportSchedule(StreamWriter writer);

    }
}
