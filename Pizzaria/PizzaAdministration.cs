using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class PizzaAdministration
    {
        //Instance Field

        //Instanceiating so i can use the methods of the classes
        MenuCatalog menu = new MenuCatalog();
        Dialog dialog = new Dialog();

        private List<string> userChoices = new List<string>();
        int numericChoice = 0;
        int numericChoice2 = 0;

        //Constructor - Currently set so when PizzaAdminsration is instantiated, i also call the method PizzaAdminPage()
        public PizzaAdministration()
        {
            PizzaAdminPage();
        }

        //Methods - Pizza System
        public void PizzaAdminPage()
        {
            //Console.Clear for a clean page everytime method is called
            Console.Clear();
            Console.WriteLine(dialog.PrintExitProgram);
            menu.PrintMenu();

            Console.WriteLine(dialog.PrintPACreate);
            Console.WriteLine(dialog.PrintPASearch);
            Console.WriteLine(dialog.PrintPAUpdate);
            Console.WriteLine(dialog.PrintPADelete);

            Console.WriteLine(dialog.PrintEnterChoice);
            //Regardless of any actions we do, Admin Page will be there unless we do one of the actions in the switch
            while (numericChoice != 99)
            {
                //Validates what's written, is the type int and not anything else
                NumericChoiceValidator();
                //Whichever the number after "case" we write, we are taken into the method
                switch (numericChoice)
                {
                    //We can always create a pizza, but in order to do any of the other methods, we need to have atleast 1 pizza created
                    case 1:
                        AdminCreatePizza();
                        break;
                    case 2:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminSearchPizza();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintPANoPizzaError);
                        }
                        break;
                    case 3:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminUpdatePizza();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintPANoPizzaError);
                        }
                        break;
                    case 4:
                        if (menu.pizzaList.Count >= 1)
                        {
                            AdminDeletePizza();
                        }
                        else
                        {
                            Console.WriteLine(dialog.PrintPANoPizzaError);
                        }
                        break;
                    //Write 99 and ENTER then program will exit
                    case 99:
                        Environment.Exit(0);
                        break;
                    //If none of the things you typed are in the "cases" then write error
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Create
        public void AdminCreatePizza()
        {
            Console.Clear();
            menu.PrintMenu();

            //String list for user choices as i have more than one of the same type of answer
            Console.WriteLine(dialog.PrintPACreateName);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(dialog.PrintPACreateTopping);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(dialog.PrintPACreatePrice);
            NumericChoiceValidator();

            //Takes the users choices and uses them as arguements for the CreatePizza parameter
            menu.CreatePizza(userChoices[0], userChoices[1], numericChoice);
            userChoices.Clear();

            Console.WriteLine(dialog.PrintPACreateSuccess);
            menu.PrintMenu();

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);

            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        //CallMethodDelegate would be here
                        AdminCreatePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Read
        public void AdminSearchPizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(dialog.PrintPASearchMenuNumber);
            NumericChoiceValidator();

            menu.SearchPizza(numericChoice);

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        //CallMethodDelegate would be here
                        AdminSearchPizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Update
        public void AdminUpdatePizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(dialog.PrintPAUpdateMenuNumber);
            NumericChoiceValidator();

            //Erro if the provided menu Nr. is (less than or equals 0) or is greater than the amount of created pizzas
            if ((numericChoice <= 0) || (numericChoice > menu.pizzaList.Count))
            {
                Console.WriteLine($"\nCannot UPDATE Pizza Nr: {numericChoice} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                Console.WriteLine(dialog.PrintPACreateName);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(dialog.PrintPACreateTopping);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(dialog.PrintPACreatePrice);
                //Infinite loop as long as provided price is not int.
                while (true)
                {
                    try
                    {
                        numericChoice2 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    //When user writes something that isn't int, FormatException is catched
                    catch (FormatException)
                    {
                        Console.WriteLine(dialog.PrintWrongFormatNumberError);
                    }
                }
                menu.UpdatePizza(numericChoice, userChoices[0], userChoices[1], numericChoice2);
                userChoices.Clear();
            }

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        //CallMethodDelegate would be here
                        AdminUpdatePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Delete
        public void AdminDeletePizza()
        {
            Console.Clear();
            menu.PrintMenu();

            Console.WriteLine(dialog.PrintPADeleteMenuNumber);
            NumericChoiceValidator();

            //Erro if the provided menu Nr. is (less than or equals 0) or is greater than the amount of created pizzas
            if ((numericChoice <= 0) || (numericChoice > menu.pizzaList.Count))
            {
                Console.WriteLine($"\nCannot DELETE Pizza Nr: {numericChoice} ---- Does not exist");
            }
            //Otherwise it's possible to delete a pizza
            else
            {
                menu.DeletePizza(numericChoice);
            }

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(dialog.PrintEnterChoice);
            Console.WriteLine(dialog.PrintAgainOrBack);
            Console.WriteLine(dialog.PrintExitProgram);
            while ((numericChoice != 99))
            {
                NumericChoiceValidator();
                switch (numericChoice)
                {
                    case 1:
                        //CallMethodDelegate would be here
                        AdminDeletePizza();
                        break;
                    case 2:
                        PizzaAdminPage();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Found myself repeating these lines of codes
        //It's just to make sure user doesn't write letters when they should write numbers, as it would close the program if that happened
        public void NumericChoiceValidator()
        {
            while (true)
            {
                try
                {
                    //Reads whatever the user wrote and converts it into Int, then places it inside the numericChoice variable
                    numericChoice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                //If what's written is not of the type Integer, we catch FormatException to not close the program and inform user to write an Int number
                catch (FormatException)
                {
                    Console.WriteLine(dialog.PrintWrongFormatNumberError);
                }
            }
        }
    }
}


