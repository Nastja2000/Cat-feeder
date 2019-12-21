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
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action OwnerUpdated;

        public void changeName(int id, string name)
        {
            Owner old = _ownerRepository.read(id);
            if (old != null)
            {
                string oldname = old.name;
                old.name = name;
                old.log.Add("Owner №" + id + "change name from " + oldname + "to" + name);
                OwnerUpdated?.Invoke();
            }
        }

        public IEnumerable<Feeder> GetAllFeeders(string name)
        {
            Owner owner = _ownerRepository.readByName(name);
            return _ownerRepository.GetFeeders(owner.id);
        }
    }
}
