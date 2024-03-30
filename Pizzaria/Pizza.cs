using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class Pizza : Product
    {
        private string _topping;
        public Pizza(string name, string topping, int price) : base(name, price)
        {
            _topping = topping;
        }

        public string Topping { get => _topping; private set => _topping = value; }

        public override string ToString()
        {
            return $"Nr: {MenuId} Name: {Name.PadRight(20)} Topping: {Topping.PadRight(30)} Price: {Price}";
        }
    }
}
