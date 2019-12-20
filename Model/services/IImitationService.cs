using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IImitationService
    { 
        
        TimeSpan ImitationDuration { get; set;}
        int StepSize { get;  set;}
        int EatingFreq { get;  set;}
        int EatingQuan { get; set;}
        IEnumerable<Feeder> GetAllFeeders();

        
        int addFood(int id, int quan);
        void StartImmitation();
        void StopImmitation();


    }
}
