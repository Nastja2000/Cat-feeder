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
    public class AdminOwnerService : IAdminOwnerService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        private IFeederRepository _feederRepository = new FeederRepository();

        public event Action<string> OwnerUpdated;

        public void addFeeder(string ownerName, string name)
        {
            Feeder feeder = new Feeder();
            feeder.name = name;
            _feederRepository.create(feeder);
            Owner owner = _ownerRepository.readByName(ownerName);
            List<Feeder> l = owner.feeders.ToList();
            l.Add(feeder);
            owner.feeders = l;
            _ownerRepository.update(owner);
            OwnerUpdated?.Invoke(ownerName);
        }

        //TODO: обращаться из одного сервиса в другой
        public void deleteFeeder(string ownerName, string feederName)
        {
            Owner owner = _ownerRepository.readByName(ownerName);
            owner.feeders = owner.feeders.Where(s => s.name != feederName);
            _ownerRepository.update(owner);
            Feeder feeder = _feederRepository.readByName(feederName);
            _feederRepository.delete(feeder.id);
            OwnerUpdated?.Invoke(ownerName);
        }


        //todo разобраться с id
        public IEnumerable<string> GetAllFeeders(string name)
        {
            Owner owner = _ownerRepository.readByName(name);
            List<Feeder> feeders = _ownerRepository.GetFeeders(owner.id).ToList();
            List<string> names = new List<string>();
            foreach (Feeder feeder in feeders)
            {
                names.Add(feeder.name);
            }
            return names;
        }
    }
}
