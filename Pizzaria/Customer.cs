namespace Pizzaria
{
    public class Customer : Profile
    {
        //Constructor
        public Customer(int cpr, string surname, string lastname, int age) : base(cpr, surname, lastname, age)
        {
        }

        //Method
        public override string ToString()
        {
            return $"CPR:{"".PadRight(6)}{CPR}{"".PadRight(15)}Surname: {Surname.PadRight(15)} Lastname: {Lastname.PadRight(32)} Age: {Age}";
        }
    }
}
