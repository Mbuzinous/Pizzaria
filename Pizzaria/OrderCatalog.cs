namespace Pizzaria
{
    public class OrderCatalog : StoreManager
    {
        public List<Pizza> pizzaList;
        public Dictionary<int, Customer> customerDictionary;
        public List<Order> orderList;
        //Constuctor
        public OrderCatalog(Store store, List<Pizza> pizzaList, Dictionary<int, Customer> customerDictionary, List<Order> orderList) : base(store)
        {
            this.pizzaList = pizzaList;
            this.customerDictionary = customerDictionary;
            this.orderList = orderList;
        }

        public void CreateOrder(int customerCPR, int pizzaMenuNumber)
        {
            Order order = new Order(customerDictionary[customerCPR], pizzaList[pizzaMenuNumber - 1]);
            orderList.Add(order);
            foreach (Order createdOrder in orderList)
            {
                int index = orderList.IndexOf(createdOrder);
                createdOrder.ID = index + 1;
            }
        }

        //Method - Read
        public void PrintOrders()
        {
            foreach (Order existingOrder in orderList)
            {
                foreach (Pizza existingPizza in pizzaList)
                {
                    if (existingPizza.MenuNr == existingOrder.Pizza.MenuNr)
                    {
                        foreach (Customer existingCustomer in customerDictionary.Values)
                        {
                            if (existingCustomer.CPR == existingOrder.Customer.CPR)
                            {
                                Console.WriteLine($"\n{existingOrder}");
                                Console.WriteLine($"{existingPizza}");
                                Console.WriteLine($"{existingCustomer}\n");
                            }
                        }
                    }
                }
            }
        }
        public void PrintOrderConfirmation(int customerCPR, int pizzaMenuNumber)
        {
            foreach (Order existingOrder in orderList)
            {
                foreach (Pizza existingPizza in pizzaList)
                {
                    if (existingPizza.MenuNr == pizzaMenuNumber)
                    {
                        foreach (Customer existingCustomer in customerDictionary.Values)
                        {
                            if (existingCustomer.CPR == customerCPR)
                            {
                                Console.WriteLine($"\n{existingOrder}");
                                Console.WriteLine($"{existingPizza}");
                                Console.WriteLine($"{existingCustomer}\n");
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void SearchOrder(int orderID)
        {
            foreach (Order existingOrder in orderList)
            {
                if (existingOrder.ID == orderID)
                {
                    Pizza pizza = existingOrder.Pizza;
                    Customer customer = existingOrder.Customer;
                    Console.WriteLine($"\nOrder with ID:{orderID} is found!");
                    Console.WriteLine($"{existingOrder}");
                    Console.WriteLine($"{pizza}");
                    Console.WriteLine($"{customer}");
                    return;
                }
            }
            Console.WriteLine($"\nOrder with ID: {orderID} does not exist.");
        }

        //Method - Update
        public void UpdateOrder(int orderID, int pizzaMenuNumber)
        {
            foreach (Order existingOrder in orderList)
            {
                if (existingOrder.ID == orderID)
                {
                    Order updatedOrder = new Order(customerDictionary[existingOrder.Customer.CPR], pizzaList[pizzaMenuNumber - 1]);
                    orderList[orderID - 1] = updatedOrder;
                    updatedOrder.ID = orderID;
                    return;
                }
            }

        }


        //Method - Delete
        public void DeleteOrder(int orderID)
        {
            if (orderID < 1 || orderID > orderList.Count)
            {
                Console.WriteLine($"Order with ID: {orderID} does not exist");
                return;
            }

            orderList.RemoveAt(orderID - 1);
            Console.WriteLine($"Order with ID: {orderID} has been deleted");

            for (int i = orderID - 1; i < orderList.Count; i++)
            {
                orderList[i].ID = i + 1;
            }
        }
    }
}


