using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizzaria
{
    public class MenuCatalog
    {
        private List<Pizza> pizzaList;
        private Pizza pizza;

        //Reads all the information about pizzas from Pizzamanger and organises them to be printable
        public MenuCatalog()
        {
            pizzaList = new List<Pizza>();
        }

        //Create
        public void CreatePizza(string name, string topping, int price)
        {
            pizza = new Pizza(name, topping, price);
            pizzaList.Add(pizza);
            Console.WriteLine($"{name} added!");
        }

        //Read
        public void PrintMenu()
        {
            foreach (Pizza pizzaItem in pizzaList)
            {
                Console.WriteLine(pizzaItem);
            }
        }

        public void SearchPizza(int id)
        {
            for (int i = 0; i < pizzaList.Count; i++)
            {
                Pizza pizzaItem = pizzaList[i];
                if (pizzaItem.MenuId == id)
                {
                    Console.WriteLine($"Pizza with ID:{id} does exist");
                    Console.WriteLine(pizzaItem);
                    return;
                }
            }
            Console.WriteLine($"Pizza with ID:{id} is not found!");
        }

        //Update
        public void UpdatePizza(int menuNumber, string name, string toppings, int price)
        {
            Pizza updatedPizza = new Pizza(name, toppings, price);
            updatedPizza.MenuId = menuNumber;
            pizzaList[menuNumber] = updatedPizza;
        }

        //Delete
        public void DeletePizza(int menuNumber)
        {
            pizzaList.RemoveAt(menuNumber);
            Console.WriteLine($"Pizza with Nr:{menuNumber} is deleted!");
        }
    }


}
