namespace Pizzaria
{
    public class OrderCatalog : StoreManager
    {

        //Constuctor
        public OrderCatalog(Store store) : base(store)
        {
        }

        public void CreateOrder(int customerCPR, int pizzaMenuNumber)
        {
            Order order = new Order(CustomerDictionary[customerCPR], PizzaList[pizzaMenuNumber - 1]);
            OrderList.Add(order);
            foreach (Order createdOrder in OrderList)
            {
                int index = OrderList.IndexOf(createdOrder);
                createdOrder.ID = index + 1;
            }
        }

        //Method - Read
        public void PrintOrders()
        {
            foreach (Order existingOrder in OrderList)
            {
                Console.WriteLine(existingOrder);
            }
        }
        public void PrintOrderConfirmation(int pizzaMenuNumber)
        {
            foreach (Order existingOrder in OrderList)
            {
                    foreach (Pizza existingPizza in PizzaList)
                    {
                        if (existingPizza.MenuNr == pizzaMenuNumber)
                        {
                            Console.WriteLine($"\n{existingOrder}{existingPizza}");
                            break;
                        }
                    }
            }
        }

        public void SearchOrder(int orderID)
        {
            foreach (Order existingOrder in OrderList)
            {
                if (existingOrder.ID == orderID)
                {
                    Console.WriteLine($"\nOrder with ID:{orderID} is found!");
                    Console.WriteLine(existingOrder);
                    return;
                }
            }
            Console.WriteLine($"\nOrder with ID: {orderID} does not exist.");
        }

        //Method - Update
        public void UpdateOrder(int orderID, int customerCPR, int pizzaMenuNumber, string name, string toppings, int price)
        {
                Pizza updatedPizza = new Pizza(name, toppings, price);
                PizzaList[pizzaMenuNumber - 1] = updatedPizza;
                updatedPizza.MenuNr = pizzaMenuNumber;

                Order updatedOrder = new Order(CustomerDictionary[customerCPR], PizzaList[pizzaMenuNumber - 1]);
                OrderList[orderID - 1] = updatedOrder;
                updatedOrder.ID = orderID;
        }


        //Method - Delete
        public void DeleteOrder(int orderID)
        {
            if (orderID < 1 || orderID > OrderList.Count)
            {
                Console.WriteLine($"Order with ID: {orderID} does not exist");
                return;
            }

            OrderList.RemoveAt(orderID - 1);
            Console.WriteLine($"Order with ID: {orderID} has been deleted");

            for (int i = orderID - 1; i < OrderList.Count; i++)
            {
                OrderList[i].ID = i + 1;
            }
        }
    }
}


