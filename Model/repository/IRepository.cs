using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.repository
{
    public interface IRepository <T> //where T : class
    {
        int create(T obj);
        T read(int id);
        void update(T obj);
        void delete(int id);
        IEnumerable<T> readAll();

        T readByName(string name);
    }
}
