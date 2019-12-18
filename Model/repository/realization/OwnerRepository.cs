using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.repository.realization
{
    class OwnerRepository : IOwnerRepository
    {

        private IFeederRepository _feederRepository = new FeederRepository();
        private static List<Owner> _data = new List<Owner>();
        private static int _end_index = 0;
        public int create(Owner obj)
        {
            obj.id = _end_index;
            _end_index += 1;
            _data.Add(obj);
            return obj.id;
        }

        //TODO
        public void delete(int id)
        {
            List<Feeder> feeders = GetFeeders(id).ToList();
            foreach (Feeder feeder in feeders)
            {
                _feederRepository.delete(feeder.id);
            }
            _data.RemoveAll(c => c.id == id);
        }

        public IEnumerable<Feeder> GetFeeders(int id)
        {

            return _data.Find(o => o.id == id).feeders;
        }

        /*    public IEnumerable<Schedule> GetSchedules(int id)
            {

                return _data.Find(c => c.id == id).schedules;
            }*/

        public Owner read(int id)
        {

            return _data.Find(c => c.id == id);
        }

        public Owner readByName(string name)
        {

            return _data.Find(c => c.name == name);
        }

        public IEnumerable<Owner> readAll()
        {
            List<Owner> copy = new List<Owner>();
            //TODO глубокое копирование??;
            copy.AddRange(_data);
            return copy;
        }

        public void update(Owner obj)
        {
            var Owner = _data.Find(o => o.id == obj.id);
            if (Owner != null)
            {
                Owner.feeders = obj.feeders;
                Owner.name = obj.name;
              //  Owner.schedules = obj.schedules;
            }
        }
    }
}
