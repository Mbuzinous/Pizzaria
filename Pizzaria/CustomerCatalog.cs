namespace Pizzaria
{
    public class CustomerCatalog : StoreManager
    {
        //Instance Field
        public Dictionary<int, Customer> customerDictionary;

        //Constuctor
        public CustomerCatalog(Store store, Dictionary<int, Customer> customerDictionary) : base(store)
        {
            this.customerDictionary = customerDictionary;

        }

        //Method - Create
        public void CreateCustomer(int cpr, string firstname, string lastname, int age)
        {
            Customer customer = new Customer(cpr, firstname, lastname, age);
            customerDictionary.Add(cpr, customer);
        }

        //Method - Read
        public void PrintCustomers()
        {
            foreach (Customer existingCustomer in customerDictionary.Values)
            {
                Console.WriteLine(existingCustomer);
            }
        }

        public void SearchCustomer(int cpr)
        {
            foreach (Customer existingCustomer in customerDictionary.Values)
            {
                if (existingCustomer.CPR == cpr)
                {
                    Console.WriteLine($"\nCustomer with CPR:{cpr} is found!");
                    Console.WriteLine(existingCustomer);
                    break;
                }
            }
            Console.WriteLine($"\nCustomer with CPR: {cpr} does not exist.");
        }

        //Method - Update
        public void UpdateCustomer(int cpr, string firstname, string lastname, int age)
        {
            Customer updatedCustomer = new Customer(cpr, firstname, lastname, age);
            customerDictionary[updatedCustomer.CPR] = updatedCustomer;
        }

        //Method - Delete
        public void DeleteCustomer(int cpr)
        {
            if (customerDictionary.Remove(cpr) == false)
            {
                Console.WriteLine($"Customer with CPR: {cpr} does not exist");
                return;
            }
            customerDictionary.Remove(cpr);
            Console.WriteLine($"Customer with CPR: {cpr} has been deleted");
        }
    }
}
