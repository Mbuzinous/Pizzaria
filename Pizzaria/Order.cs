namespace Pizzaria
{
    public class Order
    {
        private int _id;
        private DateTime _date;

        private double _tax = 1.25;
        private double _deliveryCost = 40;
        private double _totalPrice;

        public Order(Customer customer, Pizza pizza) 
        {
            _date = DateTime.Now;
        }
        public int ID { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"Order ID: {_id}   Date: {_date.ToString("dd-MM-yy : Clock : HH:mm:ss:ff")}\n";
        }
    }
}
