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
                old.name = name;
            }
        }

        public IEnumerable<string> GetAllFeeders(int id)
        {
            List<Feeder> feeders = _ownerRepository.GetFeeders(id).ToList();
            List<string> names = new List<string>();
            foreach (Feeder feeder in feeders)
            {
                names.Add(feeder.name);
            }
            return names;
        }
    }
}
