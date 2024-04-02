using static System.Formats.Asn1.AsnWriter;

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
        /*public double CalculateTotalPrice()
        {
            _totalPrice += (_pizzaChoice1.Price + _pizzaChoice2.Price + _pizzaChoice3.Price) * _tax;
            //Here i assign the first customer to have free delivery
            if (_customer.Id == 100)
            {
                return _totalPrice;
            }
            else
            {
                _totalPrice += _deliveryCost;
                return _totalPrice;
            }
        }*/
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

