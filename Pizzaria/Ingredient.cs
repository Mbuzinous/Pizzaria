using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class Ingredient : Product
    {
        public Ingredient(string name, int price) : base(name, price)
        {
        }
    }
}
