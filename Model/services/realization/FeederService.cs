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
    public class FeederService : IFeederService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        private IFeederRepository _feederRepository = new FeederRepository();
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();

        private readonly JsonSerializer _serializer = new JsonSerializer();
        //private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action<string> FeederUpdated;

        //todo зато тут работает
        public void ExportSchedule(StreamWriter writer, string id)
        {
            _serializer.Serialize(writer, GetAllSchedules(id));
        }

        public IEnumerable<Schedule> GetAllSchedules(string id)
        {
            Feeder feeder = _feederRepository.readByName(id);
            return _feederRepository.GetSchedules(feeder.id);
        }

        public void SaveFeeder(string ownerName, IEnumerable<string> info)
        {
            IEnumerator<string> enumerator = info.GetEnumerator();
            enumerator.MoveNext();
            Feeder feeder = _feederRepository.readByName(enumerator.Current);
            Owner owner = _ownerRepository.readByName(ownerName);
            if (feeder == null)
            {
                feeder = FeederFactory.factoryMethod(info);
                _feederRepository.create(feeder);
                List<Feeder> l = owner.feeders.ToList();
                l.Add(feeder);
                owner.feeders = l;
                _ownerRepository.update(owner);
            }
            else
            {
                feeder = FeederFactory.factoryMethod(info);
            }
        }



        //TODO пока не работает
        public void ImportSchedule(StreamReader reader, string id)
        {
            Feeder feeder = _feederRepository.readByName(id);
            //TODO какого, простите, хрена? тут просто не работает to list
            List<Schedule> schedules = new List<Schedule>();//_feederRepository.GetSchedules(id).ToList();
            if (feeder != null)
            {
                List<Schedule> schedule = (List<Schedule>)_serializer.Deserialize(reader, typeof(List<Schedule>));
                foreach (var c in schedule)
                {
                    c.id = _scheduleRepository.create(c);
                    schedules.Add(c);
                    //TODO можно время сделать статик и сюда впихнуть
                    c.log.Add("Sch imported in feeder №" + id + "by Admin");
                }
                feeder.schedules = schedules;
                _feederRepository.update(feeder);
                feeder.log.Add("Sch imported in feeder №" + id + "by Admin");
                FeederUpdated?.Invoke(id);
            }
            else
            {
                //TODO обработать
            }
        }
    }
}
