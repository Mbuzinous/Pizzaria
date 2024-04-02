namespace Pizzaria
{
    public class MenuCatalog : StoreManager
    {
        //Instance Field
        public List<Pizza> pizzaList;

        //Constructor
        public MenuCatalog(Store store, List<Pizza> pizzaList) : base(store)
        {
            this.pizzaList = pizzaList;
        }

        //Method - Create
        public void CreatePizza(string name, string topping, int price)
        {
            /*1. When CreatePizza is called and is filled out, it creates a new pizza object and puts it in the pizzaList
              2. It then iterates through all the pizzas in the pizzaList and finds the current pizza's index.
              3. Then sets the pizza's menu Nr. to match it's index+1 (As i want the lowest pizza menu Nr. to be 1 and not 0 on the menu).
              4. This ensures that all the pizzas in the pizzaList, has a dynamically growing menu Nr. when a pizza is created,
                 (otherwise when you have created 4 pizzas then delete 2
                 the next pizza you create will have menu Nr. 5, instead of having a "dinamically growing menu Nr. 2")*/
            Pizza pizza = new Pizza(name, topping, price);
            pizzaList.Add(pizza);
            foreach (Pizza createdPizza in pizzaList)
            {
                int index = pizzaList.IndexOf(createdPizza);
                createdPizza.MenuNr = index + 1;
            }
        }

        //Method - Read
        public void PrintMenu()
        {
            /*Iterates through all the created pizzas in the pizzaList
              and writes each one of them one by one, until the last created pizza in the pizzalist.
              It will write what's written in the ToString method under the Pizza class*/
            foreach (Pizza createdPizza in pizzaList)
            {
                Console.WriteLine(createdPizza);
            }
        }

        public void SearchPizza(int menuNr)
        {
            /*Iterates through all the pizzas in pizzaList:
              If the currently iterating pizza's menu Nr. matches the provided-menu Nr. it then tells us the pizza exist, and the METHOD exits (return;)
              If none of the pizza's menu Nr. matches the provided-menu Nr., then it writes the provided-menu Nr. does not exist*/
            foreach (Pizza createdPizza in pizzaList)
            {
                if (createdPizza.MenuNr == menuNr)
                {
                    Console.WriteLine($"\nNumber:{menuNr} is found!");
                    Console.WriteLine(createdPizza);
                    return;
                }
            }
            Console.WriteLine($"\nPizza Nr: {menuNr} does not exist.");
        }

        //Method - Update
        public void UpdatePizza(int menuNumber, string name, string toppings, int price)
        {
            /*1. When UpdatePizza is called and is filled out, it creates a new pizza object called updatedPizza.
              2. Then the new pizza replaces the old one inside the index of the provided menu Nr. - 1
                 (Menu number is set to start at 1, while index starts at 0, so menu number will always be 1 higher than the index)
              3. Then the updatedPizza's menu Nr. is set to whatver menu Nr. the user had provided*/
            Pizza updatedPizza = new Pizza(name, toppings, price);
            pizzaList[menuNumber - 1] = updatedPizza;
            updatedPizza.MenuNr = menuNumber;
        }

        //Method - Delete
        public void DeletePizza(int menuNumber)
        {
            /*1. User provides a menu Nr.
              2. Then the method checks if the provided-menu Nr. is INVALID, if it's INVALID, then it exits the method. (return;)
                    a. If the Nr. is less than 1
                    b. If the Nr. is greater than amount of pizzas created (Nr. of created pizzas and highest menu Nr. is 1:1)
              3. If the provided-menu Nr. is valid, then the pizza at the provided-menu Nr. will be deleted in the [provided menu Nr. - 1] index
              4. Then iterates through all the remaining pizzas in the pizzalist, starting from the index at the [provided menu Nr. - 1]
                 and updates their menu Nr. to be [at their current idex + 1]
                 (Otherwise when a pizza is deleted, the menu numbers above it, remains with their old menu number i.e.
                  5 pizzas has been created, i delete nr. 3, then the list would say mr. 1, 2, 4, 5 instead of a "dynamical 1, 2, 3, 4")*/
            if (menuNumber < 1 || menuNumber > pizzaList.Count)
            {
                return;
            }
            pizzaList.RemoveAt(menuNumber - 1);
            Console.WriteLine($"Pizza Nr. {menuNumber} has been deleted");
            // Update the menu numbers of the remaining pizzas
            for (int i = menuNumber - 1; i < pizzaList.Count; i++)
            {
                pizzaList[i].MenuNr = i + 1;
            }
        }
    }
}
