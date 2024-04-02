namespace Pizzaria
{
    public class CustomerManager : StoreManager
    {
        CustomerCatalog customerCatalog;
        public Dictionary<int, Customer> customerDictionary;
        public CustomerManager(Store store, Dictionary<int, Customer> customerDictionary) : base(store)
        {
            customerCatalog = new CustomerCatalog(store, customerDictionary);
            this.customerDictionary = customerDictionary;
        }

        public void CustomerAdminPage()
        {
            Console.Clear();
            Console.WriteLine(Dialog.PrintExitProgram);
            customerCatalog.PrintCustomers();

            Console.WriteLine(Dialog.PrintCACreate);
            Console.WriteLine(Dialog.PrintCASearch);
            Console.WriteLine(Dialog.PrintCAUpdate);
            Console.WriteLine(Dialog.PrintCADelete);
            Console.WriteLine(Dialog.PrintBackToFront);

            Console.WriteLine(Dialog.PrintEnterChoice);
            while (true)
            {
                NumericChoiceValidator();
                switch (NumericChoice)
                {
                    case 1:
                        AdminCreateCustomer();
                        break;
                    case 2:
                        if (customerDictionary.Count >= 1)
                        {
                            AdminSearchCustomer();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintCANoCustomerError);
                        }
                        break;
                    case 3:
                        if (customerDictionary.Count >= 1)
                        {
                            AdminUpdateCustomer();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintCANoCustomerError);
                        }
                        break;
                    case 4:
                        if (customerDictionary.Count >= 1)
                        {
                            AdminDeleteCustomer();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintCANoCustomerError);
                        }
                        break;
                    case 5:
                        FrontPage();
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

        //Create
        public void AdminCreateCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(Dialog.PrintCACPR);
            NumericChoiceValidator();
            if (customerDictionary.ContainsKey(NumericChoice))
            {
                Console.WriteLine($"Customer with CPR: {NumericChoice} already exists!");
            }
            else if (!customerDictionary.ContainsKey(NumericChoice))
            {
                Console.WriteLine(Dialog.PrintCAFirstname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintCALastname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintCAAge);
                NumericChoiceValidator2();

                customerCatalog.CreateCustomer(NumericChoice, userChoices[0], userChoices[1], NumericChoice2);
                userChoices.Clear();

                Console.WriteLine(Dialog.PrintCACreateSuccess);
                customerCatalog.PrintCustomers();
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
                        AdminCreateCustomer();
                        break;
                    case 2:
                        CustomerAdminPage();
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
        public void AdminSearchCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(Dialog.PrintCASearchCPR);
            NumericChoiceValidator();

            customerCatalog.SearchCustomer(NumericChoice);

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
                        AdminSearchCustomer();
                        break;
                    case 2:
                        CustomerAdminPage();
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
        public void AdminUpdateCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(Dialog.PrintCAUpdateCPR);
            NumericChoiceValidator();

            if (!customerDictionary.ContainsKey(NumericChoice))
            {
                Console.WriteLine($"\nCannot UPDATE Customer with ID: {NumericChoice} ---- Does not exist");
            }
            else
            {
                Console.WriteLine(Dialog.PrintCAFirstname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintCALastname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintCAAge);
                NumericChoiceValidator2();

                customerCatalog.UpdateCustomer(NumericChoice, userChoices[0], userChoices[1], NumericChoice2);
                userChoices.Clear();
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
                        AdminUpdateCustomer();
                        break;
                    case 2:
                        CustomerAdminPage();
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
        public void AdminDeleteCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(Dialog.PrintCADeleteCPR);
            NumericChoiceValidator();

            if (!customerDictionary.ContainsKey(NumericChoice))
            {
                Console.WriteLine($"\nCannot DELETE Customer with ID: {NumericChoice} ---- Does not exist");
            }
            else
            {
                customerCatalog.DeleteCustomer(NumericChoice);
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
                        AdminDeleteCustomer();
                        break;
                    case 2:
                        CustomerAdminPage();
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


