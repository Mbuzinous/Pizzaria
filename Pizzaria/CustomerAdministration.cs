using Pizzaria;

namespace Customerria
{
    public class CustomerAdministration
    {
        CustomerCatalog customerCatalog = new CustomerCatalog();
        Dialog dialog = new Dialog();
        private List<string> userChoices = new List<string>();
        int numericChoice = 0;
        int numericChoice2 = 0;

        public CustomerAdministration()
        {
            CustomerAdminPage();
        }

        public void CustomerAdminPage()
        {
            Console.Clear();
            Console.WriteLine(dialog.PrintExitProgram);
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintCACreate);
            Console.WriteLine(dialog.PrintCASearch);
            Console.WriteLine(dialog.PrintCAUpdate);
            Console.WriteLine(dialog.PrintCADelete);

            Console.WriteLine(dialog.PrintEnterChoice);
            numericChoice = 0;
            while (numericChoice != 99)
            {
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        AdminCreateCustomer();
                        break;
                    case 2:
                        if (customerCatalog.customerList.Count >= 1)
                        {
                            AdminSearchCustomer();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintCANoCustomerError);
                        }
                        break;
                    case 3:
                        if (customerCatalog.customerList.Count >= 1)
                        {
                            AdminUpdateCustomer();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintCANoCustomerError);
                        }
                        break;
                    case 4:
                        if (customerCatalog.customerList.Count >= 1)
                        {
                            AdminDeleteCustomer();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintCANoCustomerError);
                        }
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

        //Create
        public void AdminCreateCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintCASurname);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(dialog.PrintCALastname);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(dialog.PrintCAAge);
            NumericChoiceValidator();

            customerCatalog.CreateCustomer(userChoices[0], userChoices[1], numericChoice);
            userChoices.Clear();

            Console.WriteLine(dialog.PrintCACreateSuccess);
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            numericChoice = 0;
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
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
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Read
        public void AdminSearchCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintCASearchID);
            NumericChoiceValidator();

            customerCatalog.SearchCustomer(numericChoice);

            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            numericChoice = 0;
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
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
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Update
        public void AdminUpdateCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintCAUpdateID);
            NumericChoiceValidator();

            if ((numericChoice <= 0) || (numericChoice > customerCatalog.customerList.Count))
            {
                Console.WriteLine($"\nCannot UPDATE Customer with ID: {numericChoice} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                Console.WriteLine(dialog.PrintCASurname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(dialog.PrintCALastname);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(dialog.PrintCAAge);
                while (true)
                {
                    try
                    {
                        numericChoice2 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(dialog.PrintWrongFormatNumberError);
                    }
                }
                customerCatalog.UpdateCustomer(numericChoice, userChoices[0], userChoices[1], numericChoice2);
                userChoices.Clear();
            }

            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            numericChoice = 0;
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
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
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Delete
        public void AdminDeleteCustomer()
        {
            Console.Clear();
            customerCatalog.PrintCustomers();

            Console.WriteLine(dialog.PrintCADeleteID);
            NumericChoiceValidator();

            if ((numericChoice <= 0) || (numericChoice > customerCatalog.customerList.Count))
            {
                Console.WriteLine($"\nCannot DELETE Customer with ID: {numericChoice} ---- Does not exist");
            }
            else
            {
                customerCatalog.DeleteCustomer(numericChoice);
            }

            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            numericChoice = 0;
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
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


