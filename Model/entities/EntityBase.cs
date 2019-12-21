using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.entities
{
    public abstract class EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<string> log = new List<string>();
    }
}
