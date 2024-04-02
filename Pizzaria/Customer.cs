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
            return $"CPR: {CPR}     Surname: {Surname.PadRight(15)} Lastname: {Lastname.PadRight(15)} Age: {Age}";
        }
    }
}
