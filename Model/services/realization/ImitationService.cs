using System;
using System.Collections.Generic;
using Model.entities;
using Model.repository;
using Model.repository.realization;

namespace Model.services.realization
{
    public class ImitationService : IImitationService
    {
        

        private IFeederRepository _feederRepository;

        public event Action FeedersUpdated;
        public event Action ImitationDurationUpdated;

        private readonly ITimer _timer;
        public TimeSpan ImitationDuration { get; set; }
        public int StepSize { get; set; }
        public int EatingFreq { get; set; }
        public int EatingQuan { get; set; }

        public ImitationService(ITimer timer, IFeederRepository repository)
        {
            _feederRepository = repository;
            _timer = timer;
            _timer.Interval = 5000;
            _timer.Tick += TimerTick;
            StepSize = 1;
            

         //   _round_durations = new List<TimeSpan>();
        }

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

        private void TimerTick(object sender, EventArgs e)
        {
            bool f = false;
            int minutes = StepSize * 20 % 60;
            int hours = StepSize * 20 / 60;
            TimeSpan ts = new TimeSpan(hours, minutes, 0);
            ImitationDuration = ImitationDuration.Add(ts);
            foreach (Feeder feeder in _feederRepository.readAll())
            {
                if (CheckStatus(feeder)) f = true;
            }
            if (f) FeedersUpdated?.Invoke();

            ImitationDurationUpdated?.Invoke();
        }

        private bool CheckStatus(Feeder feeder)
        {
            bool f = false;
            if (feeder != null)
            {
                Schedule schedule = feeder.activeSchedule;
                if (schedule != null)
                {
                    //TODO разобраться с таймером приложения и синхронизировать расписания с ним
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
                            feeder.tankFood = 0;
                            feeder.leftToAdd = 0;
                            //TODO воткнуть алярму???
                        }
                        else
                        {
                            feeder.tankFood -= speed;
                            feeder.leftToAdd -= speed;
                            
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
                            }
                            else
                            {
                                feeder.tankFood = 0;
                                feeder.leftToAdd = 0; //TODO воткнуть алярму???
                            }
                        } else
                        {
                           /* if (feeder.leftToAdd > feeder.tankFood)
                            {
                                //TODO воткнуть алярму???
                            }*/
                            feeder.tankFood = 0;
                            feeder.leftToAdd = 0;
                        }
                        f = true;
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
