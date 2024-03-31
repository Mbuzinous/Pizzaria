using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    /*Simply using a class for my strings for testing purposes, no idea if it's a good idea :-D
    It's a little easier to keep track of the string on my 2nd monitor as i can take the class window to my other monitor
    Where as of otherwise i would have to scroll up and down if the strings were in the same class*/
    public class Dialog
    {
        //General
        private string printExitProgram = "99. Exit Program";
        private string printEnterChoice = "\nEnter your choice";
        private string printAgainOrBack = "1. Try again\n2. Go back to Admin page";
        private string printInvalidNumberError = "Error - Write a valid number please";
        private string printWrongFormatNumberError = "\nError - Wrong format, please write a number";

        //Pizza Adminstration (PA)
        private string printPACreate = "\n1. Add a new pizza";
        private string printPASearch = "2. Search a pizza";
        private string printPAUpdate = "3. Update a pizza";
        private string printPADelete = "4. Delete a pizza";
        private string printPANoPizzaError = "\nError - NO pizzas has been created. Please create one first. (press 1.)";
        private string printPACreateName = "Enter the name of your pizza";
        private string printPACreateTopping = "\nWhat are the toppings?";
        private string printPACreatePrice = "\nHow much sohuld the pizza cost?";
        private string printPACreateSuccess = "\nCongratulations you have created a pizza!\nHere's the menu:";
        private string printPASearchMenuNumber = "\nEnter the menu Nr. of the pizza you want to SEARCH for";
        private string printPAUpdateMenuNumber = "\nEnter the menu Nr. of the pizza you want to UPDATE";
        private string printPADeleteMenuNumber = "\nEnter the menu Nr. of the pizza you want to DELETE";

        public Dialog() { }

        //General
        public string PrintExitProgram { get => printExitProgram; }
        public string PrintEnterChoice { get => printEnterChoice; }
        public string PrintAgainOrBack { get => printAgainOrBack; }
        public string PrintInvalidNumberError { get => printInvalidNumberError; }
        public string PrintWrongFormatNumberError { get => printWrongFormatNumberError; }

        //Pizza Adminstration (PA)
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
    }
}
