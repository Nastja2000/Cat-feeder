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
            Feeder feeder = _feederRepository.read(id);
            if (feeder == null)
            {
                //TODO обработать
            }
            else
            {
                if (feeder.tankCapacity >= feeder.tankFood + quan)
                {
                    feeder.tankFood += quan;
                }
                else
                {
                    //TODO обработать переполнение
                    feeder.tankFood = feeder.tankCapacity;
                }
            }


            //TODO перевести на войд если понадобиться
            return 0;
        }

        public IEnumerable<Feeder> GetAllFeeders()
        {
           return _feederRepository.readAll();
        }

        public void StartImmitation()
        {
            throw new NotImplementedException();
            /*
            _initiative = GetInitiative().ToArray();  // copy initiative to avoid state changes during combat
            if (!_initiative.Any())
                throw new Exception("Unable to start combat without participants!");

            _turn_durations = new TimeSpan[_initiative.Length];
            _round_durations.Clear();
            Round = 0;
            Turn = 0;

            _combat_start = _round_start = _turn_start = DateTime.Now;
            _timer.Start();
            */
        }

        public void StopImmitation()
        {
            throw new NotImplementedException();
            /*
            SwitchToNextTurn();
            if (Turn != 0)  // add not completed round in statistics
                _round_durations.Add(_turn_start - _round_start);
            _timer.Stop();*/
        }
    }
}
