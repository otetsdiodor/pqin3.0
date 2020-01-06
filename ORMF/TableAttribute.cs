using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMF
{
    public class TableAttribute : System.Attribute
    {
        public string Name { get; set; }

        public TableAttribute()
        { }

        public TableAttribute(string name)
        {
            Name = name;
        }
    }
}
