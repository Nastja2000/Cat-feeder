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
        TimeSpan ImitationDuration { get; }
        IEnumerable<Feeder> GetAllFeeders();

        int getEatingFreq();
        void setEatingFreq(int freq);
        int getEatingQuan();
        void setEatingQuan(int quan);
        int getStepSize();
        int setStepSize(int size);
        int addFood(int id, int quan);
        void StartImmitation();
        void StopImmitation();


    }
}
