using System;
using System.Collections.Generic;
using Model.entities;
using Model.repository;
using Model.repository.realization;

namespace Model.services.realization
{
    public class ImitationService : IImitationService
    {
        private IFeederRepository _feederRepository = new FeederRepository();

        public TimeSpan ImitationDuration { get ; set ; }
        public int StepSize { get ; set ; }
        public int EatingFreq { get ; set ; }
        public int EatingQuan { get ; set ; }

        public int addFood(int id, int quan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feeder> GetAllFeeders()
        {
           return _feederRepository.readAll();
        }

        public void StartImmitation()
        {
            throw new NotImplementedException();
        }

        public void StopImmitation()
        {
            throw new NotImplementedException();
        }
    }
}
