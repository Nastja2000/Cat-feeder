using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;
using Model.repository;
using Model.repository.realization;

namespace Model.services.realization
{
    class AdminFeederService : IFeederService
    {
        private IFeederRepository _feederRepository = new FeederRepository();
      //  private IOwnerRepository _ownerRepository = new OwnerRepository();
        public event Action ScheduleUpdated;

        public void ExportSchedule(StreamWriter writer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetAllSchedules(int id)
        {
            return _feederRepository.GetSchedules(id);
        }

        public void ImportSchedule(StreamReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
