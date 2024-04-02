namespace Pizzaria
{
    /*Simply using a class for my strings for testing purposes, no idea if it's a good idea :-D
    It's a little easier to keep track of the string on my 2nd monitor as i can take the class window to my other monitor
    Where as of otherwise i would have to scroll up and down if the strings were in the same class*/
    public class Dialog
    {
        //General
        private string printExitProgram = "99. Exit Program";
        private string printEnterChoice = "\nEnter your choice (number)";
        private string printAgainOrBack = "1. Try again\n2. Go back to Admin page";
        private string printInvalidNumberError = "Error - Write a valid number please";
        private string printWrongFormatNumberError = "\nError - Wrong format, please write a number";
        private string printBackToFront = "5. Back to front page";

        //Store Administration (SA)
        private string printSAWelcome = "\nHello and welcome to Big Mama Pizza, choose one of the following:";
        private string printSAPizza = "\n1. Pizza Administration";
        private string printSACustomer = "2. Customer Administration";
        private string printSAOrder = "3. Order a pizza";

        //Pizza Administration (PA)
        private string printPACreate = "\n1. Add a new pizza";
        private string printPASearch = "2. Search a pizza";
        private string printPAUpdate = "3. Update a pizza";
        private string printPADelete = "4. Delete a pizza";
        private string printPANoPizzaError = "\nError - NO pizzas has been created. Please create one first";
        private string printPACreateName = "Enter the name of your pizza";
        private string printPACreateTopping = "\nWhat are the toppings?";
        private string printPACreatePrice = "\nHow much sohuld the pizza cost?";
        private string printPACreateSuccess = "\nCongratulations you have created a pizza!\nHere's the menu:";
        private string printPASearchMenuNumber = "\nEnter the menu Nr. of the pizza you want to SEARCH for";
        private string printPAUpdateMenuNumber = "\nEnter the menu Nr. of the pizza you want to UPDATE";
        private string printPADeleteMenuNumber = "\nEnter the menu Nr. of the pizza you want to DELETE";

        //Customer Administration (CA)
        private string printCACreate = "\n1. Add a new customer";
        private string printCASearch = "2. Search for a customer";
        private string printCAUpdate = "3. Update a customer";
        private string printCADelete = "4. Delete a customer";
        private string printCANoCustomerError = "\nError - NO customers have been added. Please add one first.";
        private string printCAFirstname = "\nEnter the firstname";
        private string printCALastname = "\nEnter the lastname";
        private string printCAAge = "\nEnter the age";
        private string printCACPR = "\nEnter the CPR";
        private string printCACreateSuccess = "\nCongratulations customer has been added!\nHere's the list of customers:";
        private string printCASearchCPR = "\nEnter the CPR of the customer you want to SEARCH for";
        private string printCAUpdateCPR = "\nEnter the CPR of the customer you want to UPDATE";
        private string printCADeleteCPR = "\nEnter the CPR of the customer you want to DELETE";

        //Order Administration (OA)
        private string printOACreate = "\n1. Create a new order";
        private string printOASearch = "2. Search for an order";
        private string printOAUpdate = "3. Update an order";
        private string printOADelete = "4. Delete an order";
        private string printOANoCustomerError = "\nError - NO orders have been added. Please add one first.";

        public Dialog() { }

        //General
        public string PrintExitProgram { get => printExitProgram; }
        public string PrintEnterChoice { get => printEnterChoice; }
        public string PrintAgainOrBack { get => printAgainOrBack; }
        public string PrintInvalidNumberError { get => printInvalidNumberError; }
        public string PrintWrongFormatNumberError { get => printWrongFormatNumberError; }
        public string PrintBackToFront { get => printBackToFront; }

        //Store Administration (SA)
        public string PrintSAWelcome { get => printSAWelcome; }
        public string PrintSAPizza { get => printSAPizza; }
        public string PrintSACustomer { get => printSACustomer; }
        public string PrintSAOrder { get => printSAOrder; }

        //Pizza Administration (PA)
        public string PrintPACreate { get => printPACreate; }
        public string PrintPASearch { get => printPASearch; }
        public string PrintPAUpdate { get => printPAUpdate; }
        public string PrintPADelete { get => printPADelete; }
        public string PrintPANoPizzaError { get => printPANoPizzaError; }
        public string PrintPACreateName { get => printPACreateName; }
        public string PrintPACreateTopping { get => printPACreateTopping; }
        public string PrintPACreatePrice { get => printPACreatePrice; }
        public string PrintPACreateSuccess { get => printPACreateSuccess; }
        public string PrintPASearchMenuNumber { get => printPASearchMenuNumber; }
        public string PrintPAUpdateMenuNumber { get => printPAUpdateMenuNumber; }
        public string PrintPADeleteMenuNumber { get => printPADeleteMenuNumber; }

        //Customer Administration
        public string PrintCACreate { get => printCACreate; }
        public string PrintCASearch { get => printCASearch; }
        public string PrintCAUpdate { get => printCAUpdate; }
        public string PrintCADelete { get => printCADelete; }
        public string PrintCANoCustomerError { get => printCANoCustomerError; }
        public string PrintCAFirstname { get => printCAFirstname; }
        public string PrintCALastname { get => printCALastname; }
        public string PrintCAAge { get => printCAAge; }
        public string PrintCACPR { get => printCACPR; }
        public string PrintCACreateSuccess { get => printCACreateSuccess; }
        public string PrintCASearchCPR { get => printCASearchCPR; }
        public string PrintCAUpdateCPR { get => printCAUpdateCPR; }
        public string PrintCADeleteCPR { get => printCADeleteCPR; }

        //Order Administration (OA)
        public string PrintOACreate { get => printOACreate; }
        public string PrintOASearch { get => printOASearch; }
        public string PrintOAUpdate { get => printOAUpdate; }
        public string PrintOADelete { get => printOADelete; }
        public string PrintOANoCustomerError { get => printOANoCustomerError; }
    }
}
