using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.repository.realization
{
    class ScheduleRepository : IScheduleRepository
    {
        private static List<Schedule> _data = new List<Schedule>();
        private static int _end_index = 0;
        public int create(Schedule obj)
        {
            obj.id = _end_index;
            _end_index += 1;
            _data.Add(obj);
            return obj.id;
        }

        public void delete(int id)
        {
            _data.RemoveAll(c => c.id == id);
        }

        public Schedule read(int id)
        {
            return _data.Find(c => c.id == id);
        }

        public IEnumerable<Schedule> readAll()
        {
            List<Schedule> copy = new List<Schedule>();
            //TODO глубокое копирование????;
            copy.AddRange(_data);
            return copy;
        }

        public IEnumerable<Schedule> readByMarks(IEnumerable<string> marks)
        {
            List<Schedule> rezult = new List<Schedule>();
            foreach (Schedule s in _data){
                if (s.marks.Intersect(marks).Any())
                {
                    rezult.Add(s);     
                }
            }
            rezult.Sort((s1, s2) => s1.marks.Intersect(marks).Count().CompareTo(s2.marks.Intersect(marks).Count()));
            return rezult;
        }


        public IEnumerable<Schedule> readByOwner(Owner owner)
        {
            throw new NotImplementedException();
            /* TODO это метод Owner, но мало ли переползём сюда
            return _data.Find(c => c.owner == owner);
            а может вообще в расписание перекинем
            */
        }

        public void update(Schedule obj)
        {
            var schedule = _data.Find(c => c.id == obj.id);
            if (schedule != null)
            {
                schedule.amountOfFood = obj.amountOfFood;
                schedule.marks = obj.marks;
                schedule.interval = obj.interval;
            }
        }
    }
}
