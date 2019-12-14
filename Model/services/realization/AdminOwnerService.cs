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
    class AdminOwnerService : IAdminOwnerService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        private IFeederRepository _feederRepository = new FeederRepository();

        public event Action FeederUpdated;

        public void addFeeder(int id, string name)
        {
            Feeder feeder = new Feeder();
            _feederRepository.create(feeder);
            Owner owner = _ownerRepository.read(id);
            List<Feeder> l = owner.feeders.ToList();
            l.Add(feeder);
            owner.feeders = l;
            _ownerRepository.update(owner);
        }

        //TODO: обращаться из одного сервиса в другой
        public void deleteFeeder(int ownerId, int feederId)
        {
            Owner owner = _ownerRepository.read(ownerId);
            owner.feeders = owner.feeders.Where(s => s.id != feederId);
            _ownerRepository.update(owner);
            _feederRepository.delete(feederId);
        }

        public IEnumerable<Feeder> GetAllFeeders(int id)
        {
            return _ownerRepository.GetFeeders(id);
        }
    }
}
