using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public abstract class Feeder : EntityBase
    {
        public int tankCapacity { get; set; }
        public int tankFood { get; set; }
        /*TODO: plateFood*/
        public Schedule schedule { get; set; }
        public int cats { get; set; }
        public int speed { get; set; }


    }
}
