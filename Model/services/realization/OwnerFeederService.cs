using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model.entities;
using Model.repository;
using Model.repository.realization;

namespace Model.services.realization
{
    public class OwnerFeederService : IOwnerFeederService
    {
        private IFeederRepository _feederRepository = new FeederRepository();
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();
        public event Action FeederByOwnerUpdated;
        public event Action ScheduleUpdated;

        public void changeName(int id, string name)
        {
            Feeder old = _feederRepository.read(id);
            if (old != null)
            {
                old.name = name;
            }
        }

        public void chooseSchedule(int feederId, int scheduleId)
        {
            Feeder feeder = _feederRepository.read(feederId);
            IEnumerable<Schedule> schedules = _feederRepository.GetSchedules(feederId);
            Schedule newActive = schedules.ToList().Find(s => s.id == scheduleId);
            if (newActive != null)
            {
                feeder.activeSchedule = newActive;
            }
        }

        public void CreateSchedule(int id, string name)
        {
            List<string> marksList = new List<string>();
            marksList.Add(name);
            Schedule schedule = new Schedule(marksList);
            _scheduleRepository.create(schedule);
            Feeder feeder = _feederRepository.read(id);
            List<Schedule> l = feeder.schedules.ToList();
            l.Add(schedule);
            feeder.schedules = l;
            _feederRepository.update(feeder);
        }



        public void deleteSchedule(int feederId, int scheduleId)
        {
            try
            {
                //TODO поменять void na int и не бросать ошибки а на презенторе проверять получилось ли
                Feeder feeder = _feederRepository.read(feederId);
                //TODO спросить можно ли так
                if (feeder.activeSchedule?.id == scheduleId)
                {
                    //TODO проверить
                    throw new InvalidOperationException();
                }
                else
                {
                    feeder.schedules = feeder.schedules.Where(s => s.id != scheduleId);
                    _feederRepository.update(feeder);
                    _scheduleRepository.delete(scheduleId);
                }
            }
            catch (InvalidOperationException e)
            {
                //TODO: обработать или/и кинуть дальше
                e.ToString();
            }

        }

        public void ExportSchedule(StreamWriter writer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetAllSchedules(int id)
        {
            return _feederRepository.GetSchedules(id);
        }

        public void ImportSchedule(StreamReader reader)
        {
            throw new NotImplementedException();
        }
    }
}

