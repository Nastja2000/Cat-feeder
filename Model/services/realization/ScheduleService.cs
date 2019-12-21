using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;
using Model.repository;
using Model.repository.realization;

namespace Model.services.realization
{
    public class ScheduleService : IScheduleService
    {

        private IScheduleRepository _scheduleRepository = new ScheduleRepository();
        public event Action<string> ScheduleUpdated;

        public Schedule GetSchedule(string name)
        {
            return _scheduleRepository.readByName(name);
        }

        public void Save(IEnumerable<string> info)
        {
            IEnumerator<string> fields = info.GetEnumerator();
            fields.MoveNext();
            Schedule schedule = _scheduleRepository.readByName(fields.Current);
            fields.MoveNext();
            string[] time  = fields.Current.Split(':');
            //TODO обработка
            int.TryParse(time[0], out int hours);
            int.TryParse(time[0], out int minutes);
            minutes /= 20;
            schedule.interval = new TimeSpan (hours,minutes,0);
            fields.MoveNext();
            int.TryParse(fields.Current, out int amount);
            schedule.amountOfFood = amount;
        }
    }
}
