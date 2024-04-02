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
        public string Topping { get => _topping; set => _topping = value; }

        //Method
        public override string ToString()
        {
            return $"Nr:{"".PadRight(7)}{MenuNr}{"".PadRight(15)}Name: {Name.PadRight(19)} Topping: {Topping.PadRight(30)} Price: {Price}";
        }
    }
}
