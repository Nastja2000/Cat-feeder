using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public static class FeederFactory
    {
        public static Feeder factoryMethod(IEnumerable<string> fields)
        {
            IEnumerator<string> enumerator =  fields.GetEnumerator();
            enumerator.MoveNext();
            string name = enumerator.Current;
            enumerator.MoveNext();
            int.TryParse(enumerator.Current, out int tankCap);
            enumerator.MoveNext();
            int.TryParse(enumerator.Current, out int cats);
            enumerator.MoveNext();
            int.TryParse(enumerator.Current, out int speed);
            enumerator.MoveNext();
            Feeder feeder;
            switch (enumerator.Current)
            {
                case "Motor":
                    feeder = new MotoFeeder();
                    break;
                case "Press":
                    feeder = new PressFeeder();
                    break;
                default:
                    feeder = null;
                    break;
            }
            if (feeder != null)
            {
                feeder.name = name;
                feeder.cats = cats;
                feeder.tankCapacity = tankCap;
                feeder.speed = speed;
                feeder.schedules = new List<Schedule>();
            }
            return feeder;
        }
    }
}
