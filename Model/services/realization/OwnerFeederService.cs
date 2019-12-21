using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model.entities;
using Model.repository;
using Model.repository.realization;
using Newtonsoft.Json;

namespace Model.services.realization
{
    public class OwnerFeederService : IOwnerFeederService
    {

        private readonly JsonSerializer _serializer = new JsonSerializer();

        private IFeederRepository _feederRepository = new FeederRepository();
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();
        public event Action FeederByOwnerUpdated;
        public event Action FeederUpdated;

        public void changeName(int id, string name)
        {
            Feeder old = _feederRepository.read(id);
            if (old != null)
            {
                old.name = name;
            }
        }

        public void chooseSchedule(string feederName, string scheduleName)
        {
            Feeder feeder = _feederRepository.readByName(feederName);
            IEnumerable<Schedule> schedules = _feederRepository.GetSchedules(feeder.id);
            Schedule newActive = schedules.ToList().Find(s => s.name == scheduleName);
            if (newActive != null)
            {
                feeder.activeSchedule = newActive;
                FeederUpdated?.Invoke();
            }
        }

        public void CreateSchedule(string feederName, string name)
        {
            List<string> marksList = new List<string>();
            marksList.Add(name);
            Schedule schedule = new Schedule(marksList);
            schedule.name = name;
            _scheduleRepository.create(schedule);
            Feeder feeder = _feederRepository.readByName(feederName);
            List<Schedule> l = feeder.schedules.ToList();
            l.Add(schedule);
            feeder.schedules = l;
            _feederRepository.update(feeder);
            FeederUpdated?.Invoke();
        }



        public void deleteSchedule(string feederName, string scheduleName)
        {
            try
            {
                //TODO поменять void na int и не бросать ошибки а на презенторе проверять получилось ли
                Feeder feeder = _feederRepository.readByName(feederName);
                //TODO спросить можно ли так
                if (feeder.activeSchedule?.name == scheduleName)
                {
                    //TODO проверить
                    throw new InvalidOperationException();
                }
                else
                {
                    feeder.schedules = feeder.schedules.Where(s => s.name != scheduleName);
                    _feederRepository.update(feeder);
                    Schedule schedule = _scheduleRepository.readByName(scheduleName);
                    _scheduleRepository.delete(schedule.id);
                    FeederUpdated?.Invoke();
                }
            }
            catch (InvalidOperationException e)
            {
                //TODO: обработать или/и кинуть дальше
                e.ToString();
            }

        }

        public void ExportSchedule(StreamWriter writer, string name)
        {
            _serializer.Serialize(writer, GetAllSchedules(name));
        }

        public IEnumerable<Schedule> GetAllSchedules(string name)
        {
            Feeder feeder = _feederRepository.readByName(name);
            return _feederRepository.GetSchedules(feeder.id);
        }

        public void ImportSchedule(StreamReader reader, string name)
        {
            Feeder feeder = _feederRepository.readByName(name);
            //TODO какого, простите, хрена? тут просто не работает to list
            List<Schedule> schedules = new List<Schedule>();//_feederRepository.GetSchedules(id).ToList();
            if (feeder != null)
            {
                List<Schedule> schedule = (List<Schedule>)_serializer.Deserialize(reader, typeof(List<Schedule>));
                foreach (var c in schedule)
                {
                    c.id = _scheduleRepository.create(c);
                    schedules.Add(c);
                }
                feeder.schedules = schedules;
                _feederRepository.update(feeder);
                FeederUpdated?.Invoke();
            }
        }
    }
}

