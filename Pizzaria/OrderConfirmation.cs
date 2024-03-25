using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class OrderConfirmation
    {
        private int _id;
        private static int _idCounter = 5000;
        private DateTime _date;

        private double _tax = 1.25;
        private double _deliveryCost = 40;
        private double _totalPrice;
        public OrderConfirmation()
        {
            _id = _idCounter;
            _idCounter++;
            _date = DateTime.Now;
        }
    }
}
