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
        void chooseSchedule(string feederName, string scheduleName);
        void deleteSchedule(string feederName, string scheduleName);
		//+log(Feeder)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        void changeName(int id, string name);
		void CreateSchedule(string feederName, string name);

  
    }
}
