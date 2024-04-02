namespace Pizzaria
{
    public class Store
    {
        Dialog dialog = new Dialog();

        PizzaManager pizzaAdminstrationSystem;
        CustomerManager customerAdministrationSystem;
        OrderManager orderAdministrationSystem;

        int numericChoice = 0;

        public Store()
        {
            Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
            List<Pizza> pizzaList = new List<Pizza>();
            List<Order> orderList = new List<Order>();


            pizzaAdminstrationSystem = new PizzaManager(this, pizzaList);
            customerAdministrationSystem = new CustomerManager(this, customerDictionary);
            orderAdministrationSystem = new OrderManager(this, pizzaList, customerDictionary, orderList);
        }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine(dialog.PrintExitProgram);

            Console.WriteLine(dialog.PrintSAWelcome);

            Console.WriteLine(dialog.PrintSAPizza);
            Console.WriteLine(dialog.PrintSACustomer);
            Console.WriteLine(dialog.PrintSAOrder);

            Console.WriteLine(dialog.PrintEnterChoice);
            while ((numericChoice != 99))
            {
                numericChoice = 0;
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        pizzaAdminstrationSystem.PizzaAdminPage();
                        break;
                    case 2:
                        customerAdministrationSystem.CustomerAdminPage();
                        break;
                    case 3:
                        orderAdministrationSystem.OrderAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }
        
        public void NumericChoiceValidator()
        {
            while (true)
            {
                try
                {
                    numericChoice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(dialog.PrintWrongFormatNumberError);
                }
            }
        }
    }
}

