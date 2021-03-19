using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class UI

    { 
        private MoneyFunctions moneyFunctions = new MoneyFunctions();
        public Machine machine = new Machine(new Dictionary<string, Snacks>());
        //Test if it starts
        public void Start()
        {
            Console.WriteLine("Hello! This is a Vending Machine.");
            machine.CreateSnackInventory();
            MainMenu();
        }
        public void MainMenu()
        {
            bool allDone = false;

            while (!allDone)
            {
                Console.WriteLine("\nThis is the Main Menu \nTo view the items for sale, please press 1 \nTo purchase an item, please press 2" +
                    "\nTo exit the vending machine realm, please press 3");
                string mainMenuUserInput = Console.ReadLine().Trim();
                //Console.WriteLine($"Your snack buying power is: ${moneyFunctions.CurrentBalance}");
                switch (mainMenuUserInput)
                {
                    case "1":
                        Console.WriteLine("Ok, here is the list of items followed the number available of each.");
                        machine.DisplayInventory();
                        allDone = false;
                        break;

                    case "2":
                        PurchaseMenu();
                        allDone = true;
                        break;

                    case "3":
                        Console.WriteLine("Ok, bye bye.");
                        allDone = true;
                        break;

                    default:
                        Console.WriteLine("I don't have that option. Try again.");
                        allDone = false;
                        break;
                }
            }
        }

        public void PurchaseMenu()
        {
            bool allDone = false;

            while (!allDone)
            {
                Console.WriteLine("This is the Purchasing Menu \nTo feed me money, please press 1  \nTo choose an item to buy, please press 2" +
                    "\nTo complete your transaction, please press 3");
                //Console.WriteLine($"Your snack buying power is: ${moneyFunctions.CurrentBalance}");
                string purchaseMenuUserInput = Console.ReadLine().Trim();

                switch (purchaseMenuUserInput)
                {
                    case "1":
                        Console.WriteLine("Please feed me money by entering a whole dollar amount.");
                        try
                        {
                            moneyFunctions.FeedMoney(Console.ReadLine());
                            Console.WriteLine($"Your snack buying power is: ${moneyFunctions.CurrentBalance}");
                            allDone = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            allDone = false;
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Please select an item to purchase by entering the corresponding code from the list provided." +
                            $"\nYour snack buying power is ${moneyFunctions.CurrentBalance} " +
                            $"\nTo return to the Purchasing Menu press any other key");
                        machine.DisplayItemInfo();
                        string userSelectedCode = Console.ReadLine().ToUpper();

                        if (machine.Inventory.ContainsKey(userSelectedCode) && moneyFunctions.PurchaseTransaction(machine.Inventory[userSelectedCode]))
                        {
                            machine.Dispense(userSelectedCode);
                        } 
                        else if(!machine.Inventory.ContainsKey(userSelectedCode))
                        {
                            Console.WriteLine("No Snack for you.");
                        }
                            allDone = false;
                        break;

                    case "3":
                        Console.WriteLine("Completing transaction.");
                        moneyFunctions.MakeChange();
                        allDone = true;
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("I don't have that option. Try again.");
                        allDone = false;
                        break;

                }
            }
        }
    }
}












                //                //    private FileFunctions workerClass { get; set; }
                //                //    /// <summary>
                //                //    /// The method that controls what is displayed when to the user
                //                //    /// </summary>
                //                //    public void Start()
                //                //    {
                //                //        bool gotFile = false; 
                //                //        do
                //                //        {
                //                //            try
                //                //            {
                //                //                string fileToUse = AskForFileMenu();
                //                //                workerClass = new FileFunctions(fileToUse);
                //                //                gotFile = true;
                //                //            }
                //                //            catch (Exception error)
                //                //            {
                //                //                Console.Clear();
                //                //                Console.WriteLine("Sorry, seems like I'm having difficulty, please try again.");
                //                //                Console.WriteLine(error.Message);
                //                //            }

                //                //        } while (!gotFile);
                //                //        Console.WriteLine();
                //                //        UserChoiceMenu();
                //                //    }
                //                //    /// <summary>
                //                //    /// This method prompts the user for a path and file name
                //                //    /// </summary>
                //                //    /// <returns>Fully qualified path to the input file</returns>
                //                //    public string AskForFileMenu()
                //                //    {
                //                //        Console.WriteLine("Please enter the path to your input file: ");
                //                //        string pathToFile = Console.ReadLine();
                //                //        Console.Write("Please enter the name of your input file: ");
                //                //        string fileName = Console.ReadLine();
                //                //        return Path.Combine(pathToFile, fileName);
                //                //    }
                //                //    /// <summary>
                //                //    /// Menu for what function to perform
                //                //    /// </summary>
                //                //    public void UserChoiceMenu()
                //                //    {
                //                //        bool allDone = false;
                //                //        while (!allDone)
                //                //        {
                //                //            Console.WriteLine("Great, what do you want to do?\n");
                //                //            Console.WriteLine("Press 1 for word count\n" +
                //                //                "Press 2 for sentence count\n" +
                //                //                "Press 3 to search and replace\n" +
                //                //                "Press 4 to display a file\n" +
                //                //                "Any other key to exit");
                //                //            string userInput = Console.ReadLine().Trim();
                //                //            switch (userInput)
                //                //            {
                //                //                case "1":
                //                //                    Console.WriteLine("You've opted for a word count");
                //                //                    Console.WriteLine($"There are {workerClass.WordCount()} words in the file.");
                //                //                    break;
                //                //                case "2":
                //                //                    Console.WriteLine("You've opted for a sentence count");
                //                //                    Console.WriteLine($"There are {workerClass.SentenceCount()} sentences in the file.");
                //                //                    break;
                //                //                case "3":
                //                //                    Console.WriteLine("You've opted for search and replace");
                //                //                    if (PromptForSearchAndReplace())
                //                //                    {
                //                //                        Console.WriteLine("The output file has been created.");
                //                //                    }
                //                //                    else
                //                //                    {
                //                //                        Console.WriteLine("Ooopsie, please try again.");
                //                //                    }
                //                //                    break;
                //                //                case "4":
                //                //                    Console.WriteLine("You've opted to display a file.");
                //                //                    break;
                //                //                default:
                //                //                    Console.WriteLine("Bye bye");
                //                //                    allDone = true;
                //                //                    break;
                //                //            }

                //                //        }
                //                //    }
                //                //    /// <summary>
                //                //    /// Sub menu for search and replace
                //                //    /// </summary>
                //                //    /// <returns>Whether it succeeded</returns>
                //                //    public bool PromptForSearchAndReplace()
                //                //    {
                //                //        Console.WriteLine("What word or phrase should I search for?");
                //                //        string searchFor = Console.ReadLine();
                //                //        Console.WriteLine("What word or phrase should I replace it with for?");
                //                //        string replaceWith = Console.ReadLine();
                //                //        Console.WriteLine("Should this be case sensitive?");
                //                //        string isCaseSensitive = Console.ReadLine();
                //                //        //Console.WriteLine("What is the name of the file for the results?");
                //                //        string fileName = AskForFileMenu();
                //                //        try
                //                //        {
                //                //            workerClass.SearchAndReplace(searchFor, replaceWith, fileName, isCaseSensitive);
                //                //            return true;
                //                //        }
                //                //        catch (Exception e)
                //                //        {
                //                //            Console.WriteLine(e.Message);
                //                //            return false;
                //                //        }

                //                //    }

                //                //    public 
                //            }
            
