using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public class PressFeeder : Feeder
    {
        public Random rand = new Random();

        public int NowSpeed { get; set; }
    }
}
