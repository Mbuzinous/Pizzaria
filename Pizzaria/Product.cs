using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public abstract class Product
    {
        private int _menuId;
        private static int _idCounter = 1;
        private string _name;
        private int _price;
        public Product(string name, int price)
        {
            _name = name;
            _price = price;
            _menuId = _idCounter;
            _idCounter++;
        }

        public int MenuId { get => _menuId; set => _menuId = value; }
        public string Name { get => _name; protected set => _name = value; }
        public int Price { get => _price; protected set => _price = value; }
    }
}
