using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
<<<<<<< HEAD
  public  interface IAdminFeederService
=======
    public interface IAdminFeederService
>>>>>>> common_branch
    {
        event Action ScheduleUpdated;

        IEnumerable<Schedule> GetAllSchedules();
        //findSchedules(???)
        void ImportSchedule(StreamReader reader);
        void ExportSchedule(StreamWriter writer);

    }
}
