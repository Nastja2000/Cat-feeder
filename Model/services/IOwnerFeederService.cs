using Model.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IOwnerFeederService : IFeederService
    {
        //TODO: Всё тут
        event Action FeederByOwnerUpdated;


        //+findSchedules(???)
        void chooseSchedule(int feederId, int scheduleId);
        void deleteSchedule(int feederId, int scheduleId);
		//+log(Feeder)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        void changeName(int id, string name);
		void CreateSchedule(int feederId, string name);

  
    }
}
