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
        private List<Pizza> pizzaList;

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
                    Console.WriteLine($"Pizza with ID:{id} does exist");
                    Console.WriteLine(pizza);
                    //return her betyder, hvis pizzaen som matcher den angivet id er fundet og handlingerne er udført, afslutter løkken
                    return;
                }

            //ellers hvis den lillemand har gået i gennem alle pizzaer og ikke kunne finde en passende id, så udskriver vi dette:
            Console.WriteLine($"Pizza with ID:{id} is not found!");
        }

        //Update
        public void UpdatePizza(int menuNumber, string name, string toppings, int price)
        {
            //1. Laver en ny pizza og sætter de indtastet værdier i en ny pizza
            Pizza updatedPizza = new Pizza(name, toppings, price);

            //2. Opdatere den nye pizzas MenuId til det som er angivet (da MenuId pt. bliver automatisk lavet af counter++ i product super klassen)
            updatedPizza.MenuId = menuNumber;

            //3. Skifter den gamle pizza ud med den nye i indexet [menuNumber - 1].
            //   (menuNumber starter på 1, men index starer på 0, så jeg skriver [menuNumber-1] for at jeg udskifter den korrekte gamle pizza i den korrekte index, ud med den nye)
            //   Brugeren kan kun se menu nummeret i PrintMenu. Det er bevidst da jeg ikke vil have et menu nummer der starter på 0.
            pizzaList[menuNumber - 1] = updatedPizza;
        }

        //Delete
        public void DeletePizza(int menuNumber)
        {
            //Sørger for at vi kun kan fjerne en pizza hvis den eksistere og at den menuNumber som er angivet matcher indexet den er i.
            //(menuNumber 1 er index 0, menuNumber 2 er index 1 etc, derfor vælger jeg at sige (menuNumber-1) for at den korrekte index bliver fjernet)
            if ((menuNumber <= pizzaList.Count) && (menuNumber >= 1))
            {
                pizzaList.RemoveAt(menuNumber-1);

                //Itererer alle pizzaer i pizzaListen og hvis menuId er større end menuNumber, så opdatere vi menuID til at matche dets nye menuNumber
                foreach (Pizza pizza in pizzaList)
                {
                    if (pizza.MenuId > menuNumber)
                    {
                        pizza.MenuId = pizza.MenuId - 1;
                    }
                }
            }
            else
            {
                Console.WriteLine($"!!! INVALID !!! Attempted to delete pizza Nr. {menuNumber} - Please write a valid menu number!!");
            }
        }
    }


}
