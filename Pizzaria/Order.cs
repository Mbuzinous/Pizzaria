namespace Pizzaria
{
    public class Order
    {
        private int _id;
        private DateTime _date;

        //No time left to implement calculate total price, including multiple pizzas per order
        private double _tax = 1.25;
        private double _deliveryCost = 40;
        private double _totalPrice;
        private Customer _customer;
        private Pizza _pizza;

        public Order(Customer customer, Pizza pizza) 
        {
            _date = DateTime.Now;
            _customer = customer;
            _pizza = pizza;
        }

        public int ID { get => _id; set => _id = value; }
        public Customer Customer { get => _customer; }
        public Pizza Pizza { get => _pizza; }
        public object Date { get; internal set; }

        public override string ToString()
        {
            return $"Order ID:{"".PadRight(1)}{_id}{"".PadRight(15)}Date: {_date.ToString("dd-MM-yy : Clock : HH:mm:ss:ff")}";
        }
    }
}
