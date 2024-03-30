using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizzaria
{
    public class MenuCatalog
    {
        //Instance field
        public List<Pizza> pizzaList;

        //Constructor
        public MenuCatalog()
        {
            pizzaList = new List<Pizza>();
        }

        //Create
        public void CreatePizza(string name, string topping, int price)
        {
            Pizza pizza = new Pizza(name, topping, price);
            pizzaList.Add(pizza);
            foreach (Pizza pizzaId in pizzaList)
            {
                int index = pizzaList.IndexOf(pizzaId);
                pizzaId.MenuId = index + 1;
            }
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
            //Itererer i gennem alle pizzaer i pizzaListen og hvis menuiD matcher den angivet id, så udskriver vi pizzaen er fundet og udskriver den fundet pizza
            foreach (Pizza pizza in pizzaList)
                if (pizza.MenuId == id)
                {
                    Console.WriteLine($"\nNumber:{id} is found!");
                    Console.WriteLine(pizza);
                    //return her betyder, hvis pizzaen som matcher den angivet id er fundet og handlingerne er udført, afslutter løkken
                    return;
                }
            //ellers hvis den lillemand har gået i gennem alle pizzaer og ikke kunne finde en passende id, så udskriver vi dette:
            Console.WriteLine($"\nPizza Nr: {id} does not exist.");

        }

        //Update
        public void UpdatePizza(int menuNumber, string name, string toppings, int price)
        {
            //1. Laver en ny pizza og sætter de indtastet værdier i en ny pizza
            Pizza updatedPizza = new Pizza(name, toppings, price);

            //2. Skifter den gamle pizza ud med den nye i indexet [menuNumber - 1].
            //   (menuNumber starter på 1, men index starer på 0, så jeg skriver [menuNumber-1] for at jeg udskifter den korrekte gamle pizza i den korrekte index, ud med den nye)
            //   Brugeren kan kun se menu nummeret i PrintMenu. Det er bevidst da jeg ikke vil have et menu nummer der starter på 0.
            pizzaList[menuNumber - 1] = updatedPizza;

            //3. Opdatere den nye pizzas MenuId til det som er angivet (da MenuId pt. bliver automatisk lavet af counter++ i product super klassen)
            updatedPizza.MenuId = menuNumber;
        }

        //Delete
        public void DeletePizza(int menuNumber)
        {
            // Check if the menu number is valid
            if (menuNumber < 1 || menuNumber > pizzaList.Count)
            {
                Console.WriteLine($"Invalid menu number: {menuNumber}");
                return;
            }

            // Remove the pizza at the specified menu number
            pizzaList.RemoveAt(menuNumber - 1);
            Console.WriteLine($"Pizza Nr. {menuNumber} has been deleted");

            // Update the menu numbers of the remaining pizzas
            for (int i = menuNumber - 1; i < pizzaList.Count; i++)
            {
                pizzaList[i].MenuId = i + 1;
            }
        }
    }


}
