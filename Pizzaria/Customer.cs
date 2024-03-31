namespace Pizzaria
{
    public class Customer : Profile
    {
        //Constructor
        public Customer(string surname, string lastname, int age) : base(surname, lastname, age)
        {
        }

        //Method
        public override string ToString()
        {
            return $"ID: {ID} Surname: {Surname.PadRight(20)} Lastname: {Lastname.PadRight(30)} Age: {Age}";
        }
    }
}
