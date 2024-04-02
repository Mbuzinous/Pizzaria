namespace Pizzaria
{
    public class PizzaManager : StoreManager
    {
        MenuCatalog menuCatalog;
        public PizzaManager(Store store) : base(store)
        {
            menuCatalog = new MenuCatalog(store);
        }

        //Methods - Pizza System
        public void PizzaAdminPage()
        {
            //Console.Clear for a clean page everytime method is called
            Console.Clear();

            Console.WriteLine(Dialog.PrintExitProgram);
            menuCatalog.PrintMenu();

            Console.WriteLine(Dialog.PrintPACreate);
            Console.WriteLine(Dialog.PrintPASearch);
            Console.WriteLine(Dialog.PrintPAUpdate);
            Console.WriteLine(Dialog.PrintPADelete);
            Console.WriteLine(Dialog.PrintBackToFront);

            Console.WriteLine(Dialog.PrintEnterChoice);

            NumericChoice = 0;
            //Regardless of any actions we do, Admin Page will be there unless we do one of the actions in the switch
            while (true)
            {
                //Validates what's written, is the type int and not anything else
                NumericChoiceValidator();
                //Whichever the number after "case" we write, we are taken into the method
                switch (NumericChoice)
                {
                    //We can always create a pizza, but in order to do any of the other methods, we need to have atleast 1 pizza created
                    case 1:
                        AdminCreatePizza();
                        break;
                    case 2:
                        if (PizzaList.Count >= 1)
                        {
                            AdminSearchPizza();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintPANoPizzaError);
                        }
                        break;
                    case 3:
                        if (PizzaList.Count >= 1)
                        {
                            AdminUpdatePizza();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintPANoPizzaError);
                        }
                        break;
                    case 4:
                        if (PizzaList.Count >= 1)
                        {
                            AdminDeletePizza();
                        }
                        else
                        {
                            Console.WriteLine(Dialog.PrintPANoPizzaError);
                        }
                        break;
                    //Write 5 and you return to front page
                    case 5:
                        FrontPage();
                        break;
                    //Write 99 and ENTER then program will exit
                    case 99:
                        Environment.Exit(0);
                        break;
                    //If none of the things you typed are in the "cases" then write error
                    default:
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Create
        public void AdminCreatePizza()
        {
            Console.Clear();
            menuCatalog.PrintMenu();

            //String list for user choices as i have more than one of the same type of answer
            Console.WriteLine(Dialog.PrintPACreateName);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(Dialog.PrintPACreateTopping);
            userChoices.Add(Console.ReadLine());

            Console.WriteLine(Dialog.PrintPACreatePrice);
            NumericChoiceValidator();

            //Takes the users choices and uses them as arguements for the CreatePizza parameter
            menuCatalog.CreatePizza(userChoices[0], userChoices[1], NumericChoice);
            userChoices.Clear();

            Console.WriteLine(Dialog.PrintPACreateSuccess);
            menuCatalog.PrintMenu();

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
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
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Read
        public void AdminSearchPizza()
        {
            Console.Clear();
            menuCatalog.PrintMenu();

            Console.WriteLine(Dialog.PrintPASearchMenuNumber);
            NumericChoiceValidator();

            menuCatalog.SearchPizza(NumericChoice);

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
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
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Update
        public void AdminUpdatePizza()
        {
            Console.Clear();
            menuCatalog.PrintMenu();

            Console.WriteLine(Dialog.PrintPAUpdateMenuNumber);
            NumericChoiceValidator();

            //Erro if the provided menu Nr. is (less than or equals 0) or is greater than the amount of created pizzas
            if ((NumericChoice <= 0) || (NumericChoice > PizzaList.Count))
            {
                Console.WriteLine($"\nCannot UPDATE Pizza Nr: {NumericChoice} ---- Does not exist");
                userChoices.Clear();
            }
            else
            {
                Console.WriteLine(Dialog.PrintPACreateName);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintPACreateTopping);
                userChoices.Add(Console.ReadLine());

                Console.WriteLine(Dialog.PrintPACreatePrice);
                NumericChoiceValidator2();
                menuCatalog.UpdatePizza(NumericChoice, userChoices[0], userChoices[1], NumericChoice2);
                userChoices.Clear();
            }

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
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
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }

        //Delete
        public void AdminDeletePizza()
        {
            Console.Clear();
            menuCatalog.PrintMenu();

            Console.WriteLine(Dialog.PrintPADeleteMenuNumber);
            NumericChoiceValidator();

            //Erro if the provided menu Nr. is (less than or equals 0) or is greater than the amount of created pizzas
            if ((NumericChoice <= 0) || (NumericChoice > PizzaList.Count))
            {
                Console.WriteLine($"\nCannot DELETE Pizza Nr: {NumericChoice} ---- Does not exist");
            }
            //Otherwise it's possible to delete a pizza
            else
            {
                menuCatalog.DeletePizza(NumericChoice);
            }

            //Could use delegates for this repeated code here but we haven't learned that yet ;-)
            Console.WriteLine(Dialog.PrintEnterChoice);
            Console.WriteLine(Dialog.PrintAgainOrBack);
            Console.WriteLine(Dialog.PrintExitProgram);
            NumericChoice = 0;
            while ((NumericChoice != 99))
            {
                NumericChoiceValidator();
                switch (NumericChoice)
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
                        Console.WriteLine(Dialog.PrintInvalidNumberError);
                        break;
                }
            }
        }
    }
}


