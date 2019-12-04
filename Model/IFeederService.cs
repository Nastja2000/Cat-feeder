using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IFeederService
    {
        //TODO: Всё тут
        event Action ScheduleByOwnerUpdated;
        event Action FeederByOwnerUpdated;


        IEnumerable<Schedule> GetAllSchedules();
        //+findSchedules(???)
        void chooseSchedule(int id);
        void ImportSchedule(StreamReader reader);
        void ExportSchedule(StreamWriter writer);
        void deleteSchedule( int id);
		//+log(Feeder)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        void changeName(int id, string name);
		void CreateSchedule(/*что прийдёт из форм*/);
    }
}
