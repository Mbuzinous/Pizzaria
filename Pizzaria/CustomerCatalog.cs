namespace Pizzaria
{
    //CRUD Methods of Customers
    public class CustomerCatalog
    {
        //Instance Field
        public List<Customer> customerList;

        //Constuctor
        public CustomerCatalog()
        {
            customerList = new List<Customer>();
        }

        //Method - Create
        public void CreateCustomer(string surname, string lastsurname, int age)
        {
            Customer customer = new Customer(surname, lastsurname, age);
            customerList.Add(customer);
            foreach (Customer createdCustomer in customerList)
            {
                int index = customerList.IndexOf(createdCustomer);
                createdCustomer.ID = index + 1;
            }
        }

        //Method - Read
        public void PrintCustomers()
        {
            foreach (Customer createdCustomer in customerList)
            {
                Console.WriteLine(createdCustomer);
            }
        }

        public void SearchCustomer(int id)
        {
            foreach (Customer createdCustomer in customerList)
            {
                if (createdCustomer.ID == id)
                {
                    Console.WriteLine($"\nCustomer with ID:{id} is found!");
                    Console.WriteLine(createdCustomer);
                    return;
                }
            }
            Console.WriteLine($"\nCustomer ID: {id} does not exist.");
        }

        //Method - Update
        public void UpdateCustomer(int id, string surname, string lastsurnames, int age)
        {
            Customer updatedCustomer = new Customer(surname, lastsurnames, age);
            customerList[id - 1] = updatedCustomer;
            updatedCustomer.ID = id;
        }

        //Method - Delete
        public void DeleteCustomer(int id)
        {
            if (id < 1 || id > customerList.Count)
            {
                return;
            }

            customerList.RemoveAt(id - 1);
            Console.WriteLine($"Customer with ID: {id} has been deleted");

            for (int i = id - 1; i < customerList.Count; i++)
            {
                customerList[i].ID = i + 1;
            }
        }
    }
}
