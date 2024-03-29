using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pizzaria
{
    public class Store
    {
        MenuCatalog menu = new MenuCatalog();
        private List<string> userChoices = new List<string>();
        private List<int> adminChoices = new List<int>();

        //Dialogs
        string printWelcome = "Hello and welcome to the Pizza Administration System\nLet's start with creating  3 Pizzas";

        string printName = "\nEnter the name of your pizza";
        string printTopping = "\nWhat toppings should it have?";
        string printPrice = "\nHow much should the pizza cost?";
        string printPizzaCreation = "\nYou have created:";

        string printPizza1CreaationConfirm = "3 Pizzas has now been created\nHere is the menu";
        string printPizzaNCreaationConfirm = "Pizza has now been created\nHere is the menu";
        string printAdminMove1 = "\n1. Add a new pizza";
        string printAdminMove2 = "2. Delete a pizza";
        string printAdminMove3 = "3. Update a pizza";
        string printAdminMove4 = "4. Search a pizza\n";
        string printAdminError = "Error - Write valid number please";

        //Dialog - Search pizza
        string pintSearchPizzaResults = "";


        public Store()
        {
            Console.WriteLine(printWelcome);

            //System start - Create 3 pizzas
            for (int i = 0; i < 3; i++)
            {
                AdminCreatePizza();
            }

            //Admin page
            while (true)
            {
                AdminPage();

                switch (adminChoices[0])
                {
                    case 0:
                        {
                            Console.WriteLine(printAdminError);
                            break;
                        }
                    case 1:
                        {
                            adminChoices.Clear();
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to create a new pizza?");
                            Console.WriteLine("1: Yes\n2: No");
                            if (Console.ReadLine() == "1")
                            {
                                AdminCreatePizza();
                            }
                            break;
                        }
                    case 2:
                        {
                            adminChoices.Clear();
                            Console.Clear();
                            Console.WriteLine("To be implemented");
                            break;
                        }
                    case 3:
                        {
                            adminChoices.Clear();
                            Console.Clear();
                            Console.WriteLine("To be implemented");
                            break;
                        }
                    case 4:
                        {
                            adminChoices.Clear();
                            Console.Clear();
                            Console.WriteLine("To be implemented");
                            break;
                        }
                }
            }
        }
        public void AdminPage()
        {
            Console.Clear();
            Console.WriteLine(printPizza1CreaationConfirm);
            menu.PrintMenu();

            Console.WriteLine(printAdminMove1);
            Console.WriteLine(printAdminMove2);
            Console.WriteLine(printAdminMove3);
            Console.WriteLine(printAdminMove4);
            adminChoices.Add(Convert.ToInt32(Console.ReadLine()));
        }
        public void AdminCreatePizza()
        {
            Console.WriteLine(printName);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(printTopping);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(printPrice);
            userChoices.Add(Console.ReadLine());

            menu.CreatePizza(userChoices[0], userChoices[1], Convert.ToInt32(userChoices[2]));
            Console.WriteLine(printPizzaCreation);
            menu.PrintMenu();
            userChoices.Clear();
        }
    }
}
