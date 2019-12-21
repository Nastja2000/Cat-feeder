using Model.entities;
using Model.repository;
using Model.repository.realization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.services.realization
{
    public class AdminMainService : IAdminMainService
    {
        private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action OwnersUpdated;

        public void addOwner(string name)
        {
            Owner owner = _ownerRepository.readByName(name);
            if (owner == null)
            {
                owner = new Owner();
                owner.name = name;
                owner.id = _ownerRepository.create(owner);
                owner.log.Add("Owner №" + owner.id + "created by Admin");
                OwnersUpdated?.Invoke();
            }
        }

        public void deleteOwner(string name)
        {
            Owner owner = _ownerRepository.readByName(name);
            if (owner != null)
            {
                _ownerRepository.delete(owner.id);
                //TODO решить что-то с логом имитации, мб хранить только изменения нижнего уровня, соотв логи овнера и самой имитации в имитации
              //  owner.log.Add("Owner №" + id + "deleted by Admin");
                OwnersUpdated?.Invoke();
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
