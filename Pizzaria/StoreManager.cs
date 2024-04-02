using System.Collections.Generic;

namespace Pizzaria
{
    public abstract class StoreManager 
    {
        
        //private List<Order> orderList = new List<Order>();
        //private Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
        //private List<Pizza> pizzaList = new List<Pizza>();
        private Dialog dialog = new Dialog();

        public List<string> userChoices = new List<string>();

        private int numericChoice = 0;
        private int numericChoice2 = 0;
        private int numericChoice3 = 0;

        Store bigMama;


        public StoreManager(Store bigMama)
        {
            this.bigMama = bigMama;
        }

        public int NumericChoice { get => numericChoice; set => numericChoice = value; }
        public int NumericChoice2 { get => numericChoice2; set => numericChoice2 = value; }
        public int NumericChoice3 { get => numericChoice3; set => numericChoice3 = value; }
        //public Dictionary<int, Customer> CustomerDictionary { get => customerDictionary; set => customerDictionary = value; }
        //public List<Pizza> PizzaList { get => pizzaList; set => pizzaList = value; }
        //public List<Order> OrderList { get => orderList; set => orderList = value; }
        public Dialog Dialog { get => dialog; set => dialog = value; }


        //Found myself repeating these lines of codes
        //It's just to make sure user doesn't write letters when they should write numbers, as it would close the program if that happened

        public void FrontPage()
        {
            bigMama.Run();
        }
        public void NumericChoiceValidator()
        {
            while (true)
            {
                try
                {
                    NumericChoice = Convert.ToInt32(Console.ReadLine());

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Dialog.PrintWrongFormatNumberError);
                }
            }
        }

        public void NumericChoiceValidator2()
        {
            while (true)
            {
                try
                {
                    NumericChoice2 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                //When user writes something that isn't int, FormatException is catched
                catch (FormatException)
                {
                    Console.WriteLine(Dialog.PrintWrongFormatNumberError);
                }
            }
        }
        public void NumericChoiceValidator3()
        {
            while (true)
            {
                try
                {
                    NumericChoice3 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                //When user writes something that isn't int, FormatException is catched
                catch (FormatException)
                {
                    Console.WriteLine(Dialog.PrintWrongFormatNumberError);
                }
            }
        }
    }
}
