using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public class Owner : EntityBase
    {
        IEnumerable<Schedule> schedules = new List<Schedule>();
        IEnumerable<Feeder> feeders = new List<Feeder>();
    }
}
