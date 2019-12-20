using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    //TODO plate
    public class Feeder : EntityBase
    {
        public int tankCapacity { get; set; }
        public int tankFood { get; set; }
        /*TODO: plateFood*/
        public Schedule activeSchedule { get; set; }

        public IEnumerable<Schedule> schedules = new List<Schedule>();
        public int cats { get; set; }
        public int speed { get; set; }


    }
}
