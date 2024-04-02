namespace Pizzaria
{
    public class OrderManager : StoreManager
    {
        OrderCatalog orderCatalog;
        public OrderManager(Store store) : base(store)
        {
            orderCatalog = new OrderCatalog(store);
        }

        public void OrderAdminPage()
        {
            Console.Clear();
            Console.WriteLine(Dialog.PrintExitProgram);
            orderCatalog.PrintOrders();

            Console.WriteLine(Dialog.PrintOACreate);
            Console.WriteLine(Dialog.PrintOASearch);
            Console.WriteLine(Dialog.PrintOAUpdate);
            Console.WriteLine(Dialog.PrintOADelete);
            Console.WriteLine(Dialog.PrintBackToFront);

            Console.WriteLine(Dialog.PrintEnterChoice);

            while (true)
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                            AdminCreateOrder();
                        break;
                    case 2:
                            AdminSearchOrder();
                        break;
                    case 3:
                            AdminUpdateOrder();
                        break;
                    case 4:
                            AdminDeleteOrder();
                        break;
                    //Write 5 and you return to front page
                    case 5:
                        FrontPage();
                        break;
                    //Write 99 and ENTER then program will exit
                    case 99:
                        Environment.Exit(0);
                        break;
                    //If none of the things you typed are in the "cases" then write error
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Create
        public void AdminCreateOrder()
        {
            Console.Clear();

            Console.WriteLine("\nAre you already a member?");
            Console.WriteLine("1. Yes\n2. No");
            NumericChoiceValidator();
            int decision = NumericChoice;
            //Customer exists
            if (decision == 1)
            {
                Console.WriteLine("\nPlease write your CPR number");
                NumericChoiceValidator();
                foreach (Customer existingCustomer in CustomerDictionary.Values)
                {
                    if (existingCustomer.CPR == NumericChoice)
                    {
                        Console.WriteLine($"\nCustomer with CPR:{NumericChoice} is found!");
                        Console.WriteLine($"{existingCustomer}\n");

                        foreach (Pizza createdPizza in PizzaList)
                        {
                            Console.WriteLine(createdPizza);
                        }

                        Console.WriteLine("\nEnter the menu number of the pizza you want to order");
                        NumericChoiceValidator2();

                        orderCatalog.CreateOrder(NumericChoice, NumericChoice2);
                        Console.WriteLine("\nCongratulations order has been created!\nHere's your order confirmation:");
                        orderCatalog.PrintOrderConfirmation(NumericChoice2);
                        break;
                    }
                    Console.WriteLine($"\nCustomer with CPR: {NumericChoice} does not exist.");
                    break;
                }

            }
            //Customer does not exist
            else if (decision == 2)
            {
                Console.WriteLine("\nPlease write your CPR number");
                NumericChoiceValidator();

                Console.WriteLine("\nWhat's your surname?");
                userChoices.Add(Console.ReadLine());

                Console.WriteLine("\nWhat is your lastname?");
                userChoices.Add(Console.ReadLine());

                Console.WriteLine("\nHow old are you?");
                NumericChoiceValidator2();

                Customer customer = new Customer(NumericChoice, userChoices[0], userChoices[1], NumericChoice2);
                CustomerDictionary.Add(customer.CPR, customer);
                userChoices.Clear();

                Console.WriteLine("\nCongratulations you're now a member of Big Mama pizza!\nHere's a list of our pizzas");
                foreach (Pizza createdPizza in PizzaList)
                {
                    Console.WriteLine(createdPizza);
                }

                Console.WriteLine("\nEnter the menu number of the pizza you want to order");
                NumericChoiceValidator3();

                orderCatalog.CreateOrder(NumericChoice, NumericChoice3);
                Console.WriteLine("\nCongratulations order has been created!\nHere's your order confirmation:");
                orderCatalog.PrintOrderConfirmation(NumericChoice2);
            }
            else
            {
                Console.WriteLine(Dialog.PrintInvalidNumberError);
            }

            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;

            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                        AdminCreateOrder();
                        break;
                    case 2:
                        OrderAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }


        //Read
        public void AdminSearchOrder()
        {
            Console.Clear();
            orderCatalog.PrintOrders();

            Console.WriteLine("Enter the order-number of the order you want to SEARCH for");
            NumericChoiceValidator();

            orderCatalog.SearchOrder(NumericChoice);

            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                        AdminSearchOrder();
                        break;
                    case 2:
                        OrderAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Update
        public void AdminUpdateOrder()
        {
            Console.Clear();
            orderCatalog.PrintOrders();

            Console.WriteLine("Enter the order-number of the order you want to UPDATE");
            NumericChoiceValidator();
            int orderNum = NumericChoice;

            if ((NumericChoice <= 0) || (NumericChoice > OrderList.Count))
            {
                Console.WriteLine($"\nCannot UPDATE Order with ID: {NumericChoice} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nPlease write the CPR number");
                NumericChoiceValidator();
                int cprNum = NumericChoice;

                orderCatalog.PrintOrders();
                Console.WriteLine("\nWrite the menu number of the pizza you want to update");
                NumericChoiceValidator();
                int menuNum = NumericChoice;

                foreach (Pizza createdPizza in PizzaList)
                {
                    Console.WriteLine(createdPizza);
                }
                Console.WriteLine("\nWhich other pizza would you like to choose?");
                NumericChoiceValidator();
                int menuNum2 = NumericChoice;

                foreach (Pizza createdPizza in PizzaList)
                {
                    if (createdPizza.MenuNr == menuNum2)
                    {
                        string iteratedPizzaName = createdPizza.Name;
                        string iteratedPizzaTopping = createdPizza.Topping;
                        int iteratedPizzaPrice = createdPizza.Price;
                        orderCatalog.UpdateOrder(orderNum, cprNum, menuNum, iteratedPizzaName, iteratedPizzaTopping, iteratedPizzaPrice);
                        break;
                    }
                }
                Console.WriteLine("\nCongrats your order has been update!");
            }

            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                        AdminUpdateOrder();
                        break;
                    case 2:
                        OrderAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Delete
        public void AdminDeleteOrder()
        {
            Console.Clear();
            orderCatalog.PrintOrders();

            Console.WriteLine(Dialog.PrintOADelete);
            NumericChoiceValidator();

            if ((NumericChoice <= 0) || (NumericChoice > OrderList.Count))
            {
                Console.WriteLine($"\nCannot DELETE Order with ID: {NumericChoice} ---- Does not exist");
            }
            else
            {
                orderCatalog.DeleteOrder(NumericChoice);
            }

            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                        AdminDeleteOrder();
                        break;
                    case 2:
                        OrderAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }
    }
}



