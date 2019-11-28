using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public class Schedule
    {
        public int amountOfFood { get; set; }
        public IList<string> marks = new List<string>();

        /*TODO: как реализовать get set для этого листа */
    }
}
