namespace Pizzaria
{
    public class Pizza : Product
    {
        //Instance Field
        private string _topping;

        //Constructor
        public Pizza(string name, string topping, int price) : base(name, price)
        {
            _topping = topping;
        }

        //Property
        public string Topping { get => _topping; }

        //Method
        public override string ToString()
        {
            return $"Nr: {MenuNr} Name: {Name.PadRight(20)} Topping: {Topping.PadRight(30)} Price: {Price}";
        }
    }
}
