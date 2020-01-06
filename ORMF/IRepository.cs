using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMF
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetTs();
        T GetById(string id);
        void Update(T item);
        void Delete(string id);
        void Add(T item);
    }
}
