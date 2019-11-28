using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public class Owner : EntityBase
    {
        IList<Schedule> schedules = new List<Schedule>();
        IList<Feeder> feeders = new List<Feeder>();
    }
}
