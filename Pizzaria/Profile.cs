using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public abstract class Profile
    {
        //If time permits
        private string _name;
        private int _id;
        public Profile (string name, int id) 
        {
            _name = name;
            _id = id;
        }
    }
}
