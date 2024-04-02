namespace Pizzaria
{
    public class Customer : Profile
    {
        //Constructor
        public Customer(int cpr, string firstname, string lastname, int age) : base(cpr, firstname, lastname, age)
        {

        }

        //Method
        public override string ToString()
        {
            return $"CPR:{"".PadRight(6)}{CPR}{"".PadRight(15)}Firstname: {Firstname.PadRight(15)} Lastname: {Lastname.PadRight(32)} Age: {Age}";
        }
    }
}
