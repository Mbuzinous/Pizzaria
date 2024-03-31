using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    //Abstract as i don't want class Product to be instantiated
    public abstract class Product
    {
        //Instance Field
        private int _menuNr;
        private string _name;
        private int _price;

        //Constuctor
        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        //Properties
        public int MenuNr { get => _menuNr; set => _menuNr = value; }
        public string Name { get => _name; protected set => _name = value; }
        public int Price { get => _price; protected set => _price = value; }
    }
}
