using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{

    public interface IFeederService
    {
        event Action ScheduleUpdated;

        IEnumerable<Schedule> GetAllSchedules(int id);
        //findSchedules(???)
        void ImportSchedule(StreamReader reader);
        void ExportSchedule(StreamWriter writer);

    }
}
