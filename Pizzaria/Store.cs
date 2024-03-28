using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class Store
    {
        MenuCatalog menu;
        public Store()
        {
            menu = new MenuCatalog();

            //Create
            menu.CreatePizza("Margherita", "Tomato & Cheese", 69);
            menu.CreatePizza("Vesuvio", "Tomato, Cheese & Ham", 75);
            menu.CreatePizza("Capricciosa", "Tomato, Cheese, Ham & Mushroom", 80);
            menu.CreatePizza("Calzone", "Baked pizza with Tomato, Cheese, Ham & Mushrooms", 80);
            menu.CreatePizza("Quattro Stagioni", "Tomato, Cheese, Ham, Mushrooms, Shrimp & Peppers", 85);

            //Read
            Console.WriteLine("\nThis is the menu");
            menu.PrintMenu();

            Console.WriteLine("\nThis is your search results");
            menu.SearchPizza(0);
            Console.WriteLine("\n");
            menu.SearchPizza(1);
            Console.WriteLine("\n");
            menu.SearchPizza(2);
            Console.WriteLine("\n");
            menu.SearchPizza(3);
            Console.WriteLine("\n");
            menu.SearchPizza(4);
            Console.WriteLine("\n");
            menu.SearchPizza(5);
            Console.WriteLine("\n");
            menu.SearchPizza(6);
            Console.WriteLine("\n");

            //Update
            menu.UpdatePizza(0, "VEGETARIANA ", "Tomat, ost & grønsager", 98);
            menu.UpdatePizza(1, "MARINARA", "Tomat, ost, rejer, muslinger & hvidløg", 97);
            
            Console.WriteLine("\nThis is the updated menu");
            menu.PrintMenu();

            Console.WriteLine("\nThis is your updated search results");
            menu.SearchPizza(0);
            Console.WriteLine("\n");
            menu.SearchPizza(1);
            Console.WriteLine("\n");
            menu.SearchPizza(2);
            Console.WriteLine("\n");
            menu.SearchPizza(3);
            Console.WriteLine("\n");
            menu.SearchPizza(4);
            Console.WriteLine("\n");
            menu.SearchPizza(5);
            Console.WriteLine("\n");
            menu.SearchPizza(6);
            Console.WriteLine("\n");

            //Delete
            menu.DeletePizza(0);
            menu.DeletePizza(1);

            menu.UpdatePizza(0, "VEGETARIANA ", "Tomat, ost & grønsager", 98);
            menu.UpdatePizza(1, "MARINARA", "Tomat, ost, rejer, muslinger & hvidløg", 97);

            Console.WriteLine("\nThis is the updated menu");
            menu.PrintMenu();

            Console.WriteLine("\nThis is your updated search results");
            menu.SearchPizza(0);
            Console.WriteLine("\n");
            menu.SearchPizza(1);
            Console.WriteLine("\n");
            menu.SearchPizza(2);
            Console.WriteLine("\n");
            menu.SearchPizza(3);
            Console.WriteLine("\n");
            menu.SearchPizza(4);
            Console.WriteLine("\n");
            menu.SearchPizza(5);
            Console.WriteLine("\n");
            menu.SearchPizza(6);
            Console.WriteLine("\n");

            //public int MenuChoice(List<string> menuItems)
            //{
            //}

        }
    }
}
