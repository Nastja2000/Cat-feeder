using Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.entities;

namespace Model.repository
{
    interface IScheduleRepository: IRepository<Schedule>
    {
        IEnumerable<Schedule> readByOwner(Owner owner);
        IEnumerable<Schedule> readByMarks(IEnumerable<string> marks);
    }
}
