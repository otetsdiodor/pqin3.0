using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMF
{
    public interface IAuthRepo<T> : IRepository<T>
    {
        T GetByName(string name);
    }
}
