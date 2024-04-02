using static System.Formats.Asn1.AsnWriter;

namespace Pizzaria
{
    //CRUD Methods of Customers
    public class CustomerCatalog : StoreManager
    {
        //Constuctor
        public CustomerCatalog(Store store) : base(store)
        {
        }

        //Method - Create
        public void CreateCustomer(int cpr, string surname, string lastsurname, int age)
        {
            Customer customer = new Customer(cpr, surname, lastsurname, age);
            CustomerDictionary.Add(customer.CPR, customer);
        }

        //Method - Read
        public void PrintCustomers()
        {
            foreach (Customer existingCustomer in CustomerDictionary.Values)
            {
                Console.WriteLine(existingCustomer);
            }
        }

        public void SearchCustomer(int cpr)
        {
            foreach (Customer existingCustomer in CustomerDictionary.Values)
            {
                if (existingCustomer.CPR == cpr)
                {
                    Console.WriteLine($"\nCustomer with CPR:{cpr} is found!");
                    Console.WriteLine(existingCustomer);
                }
            }
            Console.WriteLine($"\nCustomer with CPR: {cpr} does not exist.");
        }

        //Method - Update
        public void UpdateCustomer(int cpr, string surname, string lastsurname, int age)
        {
            Customer updatedCustomer = new Customer(cpr, surname, lastsurname, age);
            CustomerDictionary[updatedCustomer.CPR] = updatedCustomer;
        }

        //Method - Delete
        public void DeleteCustomer(int cpr)
        {
            if (CustomerDictionary.Remove(cpr) == false)
            {
                Console.WriteLine($"Customer with CPR: {cpr} does not exist");
                return;
            }
            CustomerDictionary.Remove(cpr);
            Console.WriteLine($"Customer with CPR: {cpr} has been deleted");
        }
    }
}
