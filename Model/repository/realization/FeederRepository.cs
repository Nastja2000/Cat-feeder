using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

//TODO фундаментально: список доступных расписаний по сути маленький репозиторий для каждой кормушки
//ИЛИ хранить id и доставать из общего списка по id
//Соотвественно 1 репозиторий = 1 сущьность, или можно обращаться к соседним?
//Так же вопрос : существует ли тут аналог "сессии" или нам свой создать?
//обращаться из одного сервиса в другой?

namespace Model.repository.realization
{
    class FeederRepository : IFeederRepository
    {
        private static List<Feeder> _data = new List<Feeder>();
        private static int _end_index = 0;
        public int create(Feeder obj)
        {
            obj.id = _end_index;
            _end_index += 1;
            _data.Add(obj);
            return obj.id;
        }

        //TODO
        public void delete(int id)
        {
            _data.RemoveAll(c => c.id == id);
        }

        public Feeder read(int id)
        {
            return _data.Find(c => c.id == id);
        }

        public IEnumerable<Feeder> readAll()
        {
            List<Feeder> copy = new List<Feeder>();
            //TODO глубокое копирование??;
            copy.AddRange(_data);
            return copy;
        }

        public IEnumerable<Feeder> readByOwner(Owner owner)
        {
            throw new NotImplementedException();
            /* TODO это метод Owner, но мало ли переползём сюда
            return _data.Find(c => c.owner == owner);
            */
        }

        public void update(Feeder obj)
        {
            var feeder = _data.Find(o => o.id == obj.id);
            if (feeder != null)
            {
                feeder.name = obj.name;
                feeder.activeSchedule = obj.activeSchedule;
                feeder.speed = obj.speed;
                feeder.tankCapacity = obj.tankCapacity;
                feeder.tankFood = obj.tankFood;
            }
        }

        public IEnumerable<Schedule> GetSchedules(int id)
        {

            return read(id).schedules;
        }

    }
}
