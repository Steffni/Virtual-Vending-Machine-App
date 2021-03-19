using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Machine
    {

        public Machine(Dictionary<string, Snacks> inventory)
        {
            Inventory = inventory;
        }
        public Dictionary<string, Snacks> Inventory { get; set; }
        
        public Dictionary<string, Snacks> CreateSnackInventory()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "Vendingmachine.csv";
            string filePath = Path.Combine(directory, fileName);

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] snackDetails = line.Split('|');
                        //SnackCode | SnackName | SnackPrice | SnackType | SnackQuantity
                        if (snackDetails[3] == "Chip") 
                        {
                            ChipSnack chip = new ChipSnack
                                (snackDetails[0], snackDetails[1], decimal.Parse(snackDetails[2]), snackDetails[3], 5);
                            Inventory.Add(snackDetails[0], chip);
                        }
                        else if (snackDetails[3] == "Drink")
                        {
                            DrinkSnack drink = new DrinkSnack
                                (snackDetails[0], snackDetails[1], decimal.Parse(snackDetails[2]), snackDetails[3], 5);
                            Inventory.Add(snackDetails[0], drink);
                        }
                        else if (snackDetails[3] == "Candy")
                        {
                            CandySnack candy = new CandySnack
                                (snackDetails[0], snackDetails[1], decimal.Parse(snackDetails[2]), snackDetails[3], 5);
                            Inventory.Add(snackDetails[0], candy);
                        }
                        else if (snackDetails[3] == "Gum")
                        {
                            GumSnack gum = new GumSnack
                                (snackDetails[0], snackDetails[1], decimal.Parse(snackDetails[2]), snackDetails[3], 5);
                            Inventory.Add(snackDetails[0], gum);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, something went wrong." + ex.Message);
            }
            return Inventory;
        }
        public void DisplayInventory()
        {
            foreach (KeyValuePair<string, Snacks> kvp in Inventory)
            {
                Console.WriteLine($"{kvp.Value.SnackName.PadRight(20, ' ')} {kvp.Value.SnackQuantity}"); 
            }
        }
        public void DisplayItemInfo()
        {
            foreach (KeyValuePair<string, Snacks> kvp in Inventory)
            {
                //Lookup how to pad console spacing
                Console.WriteLine($"Code: {kvp.Key.PadRight(3, ' ')}  Item: {kvp.Value.SnackName.PadRight(20, ' ')}  Price: {kvp.Value.SnackPrice}");
            }
        }
        //Removed the Dictionary return type, because the Dispense() already has access to the Dictionary
        //Changed the return type to Snacks, so we can return the snack for testing purposes
        public Snacks Dispense(string userEnteredCode)
        {

            if (Inventory.ContainsKey(userEnteredCode) && Inventory[userEnteredCode].SnackQuantity > 0)
            {
                Snacks selectedSnack = Inventory[userEnteredCode]; 
                selectedSnack.SnackQuantity -= 1;
                Inventory[userEnteredCode] = selectedSnack;
                //moneyFunctions.PurchaseTransaction(selectedSnack); 
                Console.WriteLine(selectedSnack.Message());
                return selectedSnack;
            }
            else if (Inventory.ContainsKey(userEnteredCode) && Inventory[userEnteredCode].SnackQuantity == 0)
            {
                Console.WriteLine("Sorry, that one is sold out!");
                return null;
            }
            else
            {
                Console.WriteLine("Hm, coudln't find that code... Let's go back to the Purchasing Menu");
                return null;
            }
             
        } 
    }
}
