using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class Customer : Profile
    {
        public Customer(string name, int id) : base(name, id)
        {
        }
    }
}
