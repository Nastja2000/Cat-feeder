﻿using Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services
{
    public interface IImitationService
    {
        //TODO разобраться с модификатором доступа

        public event Action FeedersUpdated;

        public event Action ImitationDurationUpdated;

        public TimeSpan ImitationDuration { get; set;}
        public int StepSize { get;  set;}
        public int EatingFreq { get;  set;}
        public int EatingQuan { get; set;}
        IEnumerable<Feeder> GetAllFeeders();
        public void OneStep();
        int addFood(string name, int quan);
        void StartImmitation();
        void StopImmitation();

       
    }
}
