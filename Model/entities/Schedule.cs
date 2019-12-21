using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public class Schedule : EntityBase
    {
        public Schedule(IEnumerable<string> _marks, int amount, TimeSpan _interval)
        {
            id = -1;
            amountOfFood = amount;
            interval = _interval;
            marks = _marks;
        }
        public Schedule(IEnumerable<string>_marks, int amount) : this(_marks, amount, new TimeSpan(1,0,0))
        {

        }
        public Schedule(IEnumerable<string>_marks) : this(_marks, 1000, new TimeSpan(1, 0, 0))
        {

        }

        //TODO решить с этим что-то
        private Schedule() : this (new List<string>(), 1000, new TimeSpan(1, 0, 0)) { }
        public int amountOfFood { get; set; }
        public TimeSpan interval { get; set; }

        //TODO разобраться с "по рассписанию"
        // public int IEnumarable<DateTimeOffset> timeList = new List<DateTimeOffset>();
        public IEnumerable<string> marks = new List<string>();

        public int round { get; set; } = 0;
        /*TODO: как реализовать get set для этого листа */
    }
}
