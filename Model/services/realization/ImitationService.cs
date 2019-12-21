using System;
using System.Collections.Generic;
using Model.entities;
using Model.repository;

namespace Model.services.realization
{
    public class ImitationService : IImitationService
    {


        private IFeederRepository _feederRepository;

        private static Random rand = new Random();

        public event Action FeedersUpdated;
        public event Action ImitationDurationUpdated;

        private readonly ITimer _timer;
        public TimeSpan ImitationDuration { get; set; }
        public int StepSize { get; set; }
        public int EatingFreq { get; set; } = 0;
        public int QuanDispersion { get; set; } = 0;
        public int EatingQuan { get; set; } = 0;

        public int foodStat { get; set; } = 0;
        public int UserStat { get; set; } = 0;
        public int FeedersStat { get; set; } = 0;

        public ImitationService(ITimer timer, IFeederRepository repository)
        {
            _feederRepository = repository;
            _timer = timer;
            _timer.Interval = 5000;
            _timer.Tick += TimerTick;
            StepSize = 1;
        }

        public int addFood(string id, int quan)
        {
            Feeder feeder = _feederRepository.readByName(id);
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

        public void OneStep()
        {
            bool f = false;
            int minutes = StepSize * 20 % 60;
            int hours = StepSize * 20 / 60;
            TimeSpan ts = new TimeSpan(hours, minutes, 0);
            ImitationDuration = ImitationDuration.Add(ts);
            foreach (Feeder feeder in _feederRepository.readAll())
            {
                if (CheckStatus(feeder)) f = true;
                if (EatingProtocol(feeder)) f = true;
            }
            if (f) FeedersUpdated?.Invoke();

            ImitationDurationUpdated?.Invoke();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            OneStep();
        }



        private bool CheckStatus(Feeder feeder)
        {
            bool f = false;
            if (feeder != null)
            {
                Schedule schedule = feeder.activeSchedule;
                
                if (((ImitationDuration.TotalSeconds / schedule.interval.TotalSeconds) - schedule.round> 1))
                {
                    schedule.round += 1;
                    feeder.leftToAdd += schedule.amountOfFood;
                }
                if (feeder.leftToAdd > 0)
                {

                    if (typeof(PressFeeder).IsInstanceOfType(feeder))
                    {
                        int speed;
                        PressFeeder realFeeder = (PressFeeder)feeder;
                        speed = realFeeder.speed * realFeeder.rand.Next(90, 110) / 100;
                        if (speed > feeder.tankFood)
                        {
                            feeder.plateFood += feeder.tankFood;
                            feeder.tankFood = 0;
                            feeder.leftToAdd = 0;
                            //TODO воткнуть алярму???
                        }
                        else
                        {
                            feeder.tankFood -= speed;
                            feeder.leftToAdd -= speed;
                            if (feeder.leftToAdd < 0) feeder.leftToAdd = 0;
                            feeder.plateFood += speed;
                        }
                        f = true;
                    }
                    if (typeof(MotoFeeder).IsInstanceOfType(feeder))
                    {
                        if (feeder.leftToAdd > feeder.speed)
                        {
                            if (feeder.tankFood > feeder.speed)
                            {
                                feeder.tankFood -= feeder.speed;
                                feeder.leftToAdd -= feeder.speed;
                                feeder.plateFood += feeder.speed;
                            }
                            else
                            {
                                feeder.plateFood += feeder.tankFood;
                                feeder.tankFood = 0;
                                feeder.leftToAdd = 0; //TODO воткнуть алярму???
                            }
                        }
                        else
                        {
                            /* if (feeder.leftToAdd > feeder.tankFood)
                             {
                                 //TODO воткнуть алярму???
                             }*/

                            feeder.plateFood += feeder.leftToAdd;
                            feeder.tankFood = 0;
                            feeder.leftToAdd = 0;
                        }
                        f = true;
                    }
                }

            }
            return f;
        }

        private bool EatingProtocol(Feeder feeder)
        {
            bool f = false;
            if (feeder != null)
            {
                if (feeder.plateFood <= 0)
                {
                    //todo alarm
                }
                else
                {
                    int poesc = 0;
                    for (int i = 0; i < feeder.cats; i++)
                    {
                        if (rand.Next(0, 100) >= EatingFreq)
                        {
                            poesc += EatingQuan + QuanDispersion * (rand.Next(0,200) - 100)/100;
                        }
                    }
                    if(feeder.plateFood < poesc)
                    {
                        feeder.plateFood = 0;
                    }
                    else
                    {
                        feeder.plateFood -= poesc;
                    }
                }
            }
            return f;
        }
        public void StartImmitation()
        {
            _timer.Start();
            //  throw new NotImplementedException();
            /*
            _initiative = GetInitiative().ToArray();  // copy initiative to avoid state changes during combat
            if (!_initiative.Any())
                throw new Exception("Unable to start combat without participants!");

            _turn_durations = new TimeSpan[_initiative.Length];
            _round_durations.Clear();
            Round = 0;
            Turn = 0;

            _combat_start = _round_start = _turn_start = DateTime.Now;

            */

        }

        public void StopImmitation()
        {
            _timer.Stop();
            //throw new NotImplementedException();
            /*
            SwitchToNextTurn();
            if (Turn != 0)  // add not completed round in statistics
                _round_durations.Add(_turn_start - _round_start);
            _timer.Stop();*/
        }
    }
}
