using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IFeederService
    {
        //TODO: Всё тут
        // +findSchedules(???)
        IEnumerable<Schedule> GetAllSchedule();
        void ImportSchedule(StreamReader reader);
        void ExportSchedule(StreamWriter writer);
        void chooseSchedule(int id);
        void deleteSchedule(int id);
        void CreateSchedule(/*что прийдёт из форм*/);
        //+log(Feeder)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //void changeName(???)
    }
}
