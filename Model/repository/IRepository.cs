using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.repository
{
    interface IRepository <T>
    {
        int create(T obj);
        T read(int id);
        void update(T obj);
        void delete(int id);
        IEnumerable<T> readAll();
    }
}
