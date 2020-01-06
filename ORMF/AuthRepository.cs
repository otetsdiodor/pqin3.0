using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMF
{
    public class AuthRepository<T> : Repository<T>, IAuthRepo<T>
    {
        NastedContext context = new NastedContext();

        public T GetByName(string name)
        {
            return (T)context.GetByName(typeof(T), name);
        }
    }
}
