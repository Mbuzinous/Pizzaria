namespace Pizzaria
{
    public class OrderManager : StoreManager
    {
        OrderCatalog orderCatalog;
        public List<Pizza> pizzaList;
        public Dictionary<int, Customer> customerDictionary;
        public List<Order> orderList;
        public OrderManager(Store store, List<Pizza> pizzaList, Dictionary<int, Customer> customerDictionary, List<Order> orderList) : base(store)
        {
            orderCatalog = new OrderCatalog(store, pizzaList, customerDictionary, orderList);
            this.pizzaList = pizzaList;
            this.customerDictionary = customerDictionary;
            this.orderList = orderList;

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
                        if (pizzaList.Count >= 1)
                        {
                            AdminCreateOrder();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintPANoPizzaError);
                        }
                        break;
                    case 2:
                        if (orderList.Count >= 1)
                        {
                            AdminSearchOrder();
                        }
                        else
                        {
                            Console.WriteLine("ERROR - No orders have been made, please make an order first. (Press 1.)");
                        }
                        break;
                    case 3:
                        if (orderList.Count >= 1)
                        {
                            AdminUpdateOrder();
                        }
                        else
                        {
                            Console.WriteLine("ERROR - No orders have been made, please make an order first. (Press 1.)");
                        }
                        break;
                    case 4:
                        if (orderList.Count >= 1)
                        {
                            AdminDeleteOrder();
                        }
                        else
                        {
                            Console.WriteLine("ERROR - No orders have been made, please make an order first. (Press 1.)");
                        }
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
            foreach (Customer existingCustomer in customerDictionary.Values)
            {
                Console.WriteLine(existingCustomer);
            }
            Console.WriteLine("\nAre you already a member?");
            Console.WriteLine("1. Yes\n2. No");
            NumericChoiceValidator();
            int decision = NumericChoice;
            //Customer exists
            if (decision == 1)
            {
                Console.WriteLine("\nPlease write your CPR number");
                NumericChoiceValidator2();
                if (customerDictionary.ContainsKey(NumericChoice2))
                {
                    Customer existingCustomer = customerDictionary[NumericChoice2];
                    Console.WriteLine($"\nCustomer with CPR:{NumericChoice2} is found!");
                    Console.WriteLine($"{existingCustomer}\n");

                    Console.WriteLine("Pizza Menu");
                    foreach (Pizza createdPizza in pizzaList)
                    {
                        Console.WriteLine(createdPizza);
                    }

                    Console.WriteLine("\nEnter the menu number of the pizza you want to order");
                    NumericChoice3 = 0;
                    while ((NumericChoice3 <= 0) || (NumericChoice3 > pizzaList.Count))
                    {
                        NumericChoiceValidator3();
                        if ((NumericChoice3 <= 0) || (NumericChoice3 > pizzaList.Count))
                        {
                            Console.WriteLine($"\nCannot SELECT Pizza Nr: {NumericChoice3} ---- Does not exist");
                        }
                        else
                        {
                            orderCatalog.CreateOrder(NumericChoice2, NumericChoice3);
                            Console.WriteLine("\nCongratulations order has been created!\n\nHere's your order confirmation:");
                            orderCatalog.PrintOrderConfirmation(NumericChoice2, NumericChoice3);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\nCustomer with CPR: {NumericChoice2} does not exist.");
                }
            }
            //Customer does not exist
            else if (decision == 2)
            {
                Console.WriteLine("\nPlease write your CPR number");
                NumericChoiceValidator2();
                if (customerDictionary.ContainsKey(NumericChoice2))
                {
                    Console.WriteLine($"Customer with CPR: {NumericChoice2} already exists!");
                }
                else if (!customerDictionary.ContainsKey(NumericChoice2))
                {
                    Console.WriteLine("\nWhat's your surname?");
                    userChoices.Add(Console.ReadLine());

                    Console.WriteLine("\nWhat is your lastname?");
                    userChoices.Add(Console.ReadLine());

                    Console.WriteLine("\nHow old are you?");
                    NumericChoiceValidator3();

                    Customer customer = new Customer(NumericChoice2, userChoices[0], userChoices[1], NumericChoice3);
                    customerDictionary.Add(NumericChoice2, customer);
                    userChoices.Clear();

                    Console.WriteLine("\nCongratulations you're now a member of Big Mama pizza!\nHere's a list of our pizzas\n");
                    Console.WriteLine("Pizza Menu");
                    foreach (Pizza createdPizza in pizzaList)
                    {
                        Console.WriteLine(createdPizza);
                    }

                    Console.WriteLine("\nEnter the menu number of the pizza you want to order");
                    NumericChoice4 = 0;
                    while ((NumericChoice4 <= 0) || (NumericChoice4 > pizzaList.Count))
                    {
                        NumericChoiceValidator4();
                        if ((NumericChoice4 <= 0) || (NumericChoice4 > pizzaList.Count))
                        {
                            Console.WriteLine($"\nCannot SELECT Pizza Nr: {NumericChoice4} ---- Does not exist");
                        }
                        else
                        {
                            orderCatalog.CreateOrder(NumericChoice2, NumericChoice4);
                            Console.WriteLine("\nCongratulations order has been created!\n\nHere's your order confirmation:");
                            orderCatalog.PrintOrderConfirmation(NumericChoice2, NumericChoice4);
                            break;
                        }
                    }
                }

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
            Console.WriteLine("Here's the list of orders");
            foreach (Order existingOrder in orderList)
            {
                foreach (Pizza existingPizza in pizzaList)
                {
                    if (existingPizza.MenuNr == existingOrder.Pizza.MenuNr)
                    {
                        foreach (Customer existingCustomer in customerDictionary.Values)
                        {
                            if (existingCustomer.CPR == existingOrder.Customer.CPR)
                            {
                                Console.WriteLine($"\n{existingOrder}");
                                Console.WriteLine($"{existingPizza}");
                                Console.WriteLine($"{existingCustomer}\n");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Enter the order number you want to UPDATE");
            NumericChoiceValidator();

            if ((NumericChoice <= 0) || (NumericChoice > orderList.Count))
            {
                Console.WriteLine($"\nCannot UPDATE Order with ID: {NumericChoice} ---- Does not exist");
            }
            else
            {
                Console.WriteLine("\nHere's the Pizza menu");
                foreach (Pizza createdPizza in pizzaList)
                {
                    Console.WriteLine(createdPizza);
                }

                Console.WriteLine("\nChoose your new pizza");
                while (true)
                {
                    NumericChoiceValidator2();
                    if (NumericChoice2 < 1 || NumericChoice2 > pizzaList.Count)
                    {
                        Console.WriteLine("Pizza does not exist - Please write an existing pizza number");
                    }
                    else
                    {
                        orderCatalog.UpdateOrder(NumericChoice, NumericChoice2);
                        Console.WriteLine("\nCongrats your order has been updated!");
                        break;
                    }
                }
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

            if ((NumericChoice <= 0) || (NumericChoice > orderList.Count))
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



