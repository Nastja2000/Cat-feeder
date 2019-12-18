using Model.entities;
using Model.repository;
using Model.repository.realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.services.realization
{
    public class AdminMainService : IAdminMainService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action OwnerUpdated;

        public void addOwner(string name)
        {
            Owner owner = _ownerRepository.readByName(name);
            if (owner == null)
            {
                owner = new Owner();
                owner.name = name;
                owner.id = _ownerRepository.create(owner);
            }
        }

        public void deleteOwner(int id)
        {
            Owner owner = _ownerRepository.read(id);
            if (owner != null)
            {
                _ownerRepository.delete(owner.id);
            }
        }

        public IEnumerable<string> GetAllOwners()
        {
            //TODO разобраться с тем, передавать ли id
            List <Owner> owners = _ownerRepository.readAll().ToList();
            List<string> names = new List<string>();
            foreach (Owner owner in owners)
            {
                names.Add(owner.name);
            }
           return names;
        }
    }
}
