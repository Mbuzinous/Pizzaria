using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pizzaria
{
    public class Store
    {
        MenuCatalog menu = new MenuCatalog();

        //Choices
        private List<string> userChoices = new List<string>();
        int aChoices = 0;

        //Dialogs
        string printExitProgram = "9. Exit Program";
        string printAdminMenuAddPizza = "\n1. Add a new pizza";
        string printAdminMenuDeletePizza = "2. Delete a pizza";
        string printAdminMenuUpdatePizza = "3. Update a pizza";
        string printAdminMenuSearchPizza = "4. Search a pizza";
        string printAdminMenuEnterChoice = "\nEnter your choice";
        string printAdminError = "Error - Write a valid number please";
        string printNoPizzaCreatedError = "\nError - NO pizzas has been created. Please create one first. (press 1.)";

        string printName = "Enter the name of your pizza";
        string printTopping = "\nWhat are the toppings?";
        string printPrice = "\nHow much sohuld the pizza cost?";
        string printPizzaCreated = "\nCongratulations you have created a pizza!\nHere's the menu:";

        string printDelete = "\nEnter the menu Nr. of the pizza you want to DELETE";
        string printUpdateMenuNumber = "\nEnter the menu Nr. of the pizza you want to UPDATE";
        string printSearchPizza = "\nEnter the menu Nr. of the pizza you want to SEARCH for";

        string printTryAgainOrBackToAdmin = "1. Try again\n2. Go back to Admin page";


        public Store()
        {

        }
        public void Run()
        {
            PizzaAdminPage();
        }
        public void PizzaAdminPage()
        {
            Console.Clear();
            Console.WriteLine(printExitProgram);
            menu.PrintMenu();

            Console.WriteLine(printAdminMenuAddPizza);
            Console.WriteLine(printAdminMenuDeletePizza);
            Console.WriteLine(printAdminMenuUpdatePizza);
            Console.WriteLine(printAdminMenuSearchPizza);

            Console.WriteLine(printAdminMenuEnterChoice);
            while (aChoices != 9)
            {
                aChoices = Convert.ToInt32(Console.ReadLine());
                switch (aChoices)
                {
                    case 1:
                        AdminCreatePizza();
                        break;
                    case 2:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminDeletePizza();
                        }
                        else
                        {
                            Console.WriteLine(printNoPizzaCreatedError);
                        }
                        break;
                    case 3:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminUpdatePizza();
                        }
                        else
                        {
                            Console.WriteLine(printNoPizzaCreatedError);
                        }
                        break;
                    case 4:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminSearchPizza();
                        }
                        else
                        {
                            Console.WriteLine(printNoPizzaCreatedError);
                        }
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(printAdminError);
                        break;
                }
            }
        }

        public void AdminCreatePizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(printName);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(printTopping);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(printPrice);
            userChoices.Add(Console.ReadLine());

            menu.CreatePizza(userChoices[0], userChoices[1], Convert.ToInt32(userChoices[2]));
            userChoices.Clear();

            Console.WriteLine(printPizzaCreated);
            menu.PrintMenu();

            Console.WriteLine(printAdminMenuEnterChoice);
            Console.WriteLine(printTryAgainOrBackToAdmin);
            Console.WriteLine(printExitProgram);
            while ((aChoices != 9))
            {
                aChoices = Convert.ToInt32(Console.ReadLine());
                switch (aChoices)
                {
                    case 1:
                        AdminCreatePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(printAdminError);
                        break;
                }
            }
        }

        public void AdminDeletePizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(printDelete);
            userChoices.Add(Console.ReadLine());

            if (((Convert.ToInt32(userChoices[0]) <= 0) || ((Convert.ToInt32(userChoices[0])) > menu.pizzaList.Count)))
            {
                Console.WriteLine($"\nCannot DELETE Pizza Nr: {userChoices[0]} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                menu.DeletePizza(Convert.ToInt32(userChoices[0]));
                userChoices.Clear();
            }

            Console.WriteLine(printAdminMenuEnterChoice);
            Console.WriteLine(printTryAgainOrBackToAdmin);
            Console.WriteLine(printExitProgram);
            while ((aChoices != 9))
            {
                aChoices = Convert.ToInt32(Console.ReadLine());
                switch (aChoices)
                {
                    case 1:
                        AdminDeletePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(printAdminError);
                        break;
                }
            }
        }

        public void AdminUpdatePizza()
        {
                Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(printUpdateMenuNumber);
            userChoices.Add(Console.ReadLine());

            if (((Convert.ToInt32(userChoices[0]) <= 0) || ((Convert.ToInt32(userChoices[0])) > menu.pizzaList.Count)))
            {
                Console.WriteLine($"\nCannot UPDATE Pizza Nr: {userChoices[0]} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                Console.WriteLine(printName);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(printTopping);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(printPrice);
                userChoices.Add(Console.ReadLine());

                menu.UpdatePizza(Convert.ToInt32(userChoices[0]), userChoices[1], userChoices[2], Convert.ToInt32(userChoices[3]));
                userChoices.Clear();
            }

            Console.WriteLine(printAdminMenuEnterChoice);
            Console.WriteLine(printTryAgainOrBackToAdmin);
            Console.WriteLine(printExitProgram);
            while ((aChoices != 9))
            {
                aChoices = Convert.ToInt32(Console.ReadLine());
                switch (aChoices)
                {
                    case 1:
                        AdminUpdatePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(printAdminError);
                        break;
                }
            }
        }
        public void AdminSearchPizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(printSearchPizza);
            userChoices.Add(Console.ReadLine());

            menu.SearchPizza(Convert.ToInt32(userChoices[0]));
            userChoices.Clear();

            Console.WriteLine(printAdminMenuEnterChoice);
            Console.WriteLine(printTryAgainOrBackToAdmin);
            Console.WriteLine(printExitProgram);
            while ((aChoices != 9))
            {
                aChoices = Convert.ToInt32(Console.ReadLine());
                switch (aChoices)
                {
                    case 1:
                        AdminSearchPizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(printAdminError);
                        break;
                }
            }
        }
    }
}
