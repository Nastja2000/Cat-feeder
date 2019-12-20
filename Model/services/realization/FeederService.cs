using System;
using System.Collections.Generic;
using System.IO;
using Model.entities;
using Model.repository;
using Model.repository.realization;
using Newtonsoft.Json;

namespace Model.services.realization
{
    public class FeederService : IFeederService
    {
        private IFeederRepository _feederRepository = new FeederRepository();
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();

        private readonly JsonSerializer _serializer;
        //private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action FeederUpdated;

        //todo зато тут работает
        public void ExportSchedule(StreamWriter writer, int id)
        {
            _serializer.Serialize(writer, GetAllSchedules(id));
        }

        public IEnumerable<Schedule> GetAllSchedules(int id)
        {
            return _feederRepository.GetSchedules(id);
        }

        //TODO пока не работает
        public void ImportSchedule(StreamReader reader, int id)
        {
            Feeder feeder = _feederRepository.read(id);
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
            } else
            {
                //TODO обработать
            }
        }
    }
}
