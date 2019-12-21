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
        event Action FeederUpdated;

        IEnumerable<Schedule> GetAllSchedules(string name);
        //findSchedules(???)
        void ImportSchedule(StreamReader reader, string name);
        void ExportSchedule(StreamWriter writer, string name);

    }
}
