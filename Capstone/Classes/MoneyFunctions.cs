using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
     public class MoneyFunctions
    {
        public decimal CurrentBalance { get; set; } = 0.00M;

        public decimal FeedMoney(string paidInAmount)
        {
            decimal moneyFed = decimal.Parse(paidInAmount);
            if((moneyFed %1 != 0.00M) || moneyFed < 0.00M)
            {
                throw new Exception ("Sorry, the number you entered was not a whole dollar amount.");
            }
            else 
            {
                CurrentBalance += moneyFed;
                AuditEntry.CreateFeedMoneyEntry(moneyFed, CurrentBalance);
            }
            return CurrentBalance;
        }

        public bool PurchaseTransaction(Snacks snackBeingSold)
        {
            bool transactionSuccessful;
            if(snackBeingSold.SnackPrice > CurrentBalance)
            {
                transactionSuccessful = false;
                Console.WriteLine("You didn't feed me enough money to buy that. Munny pweeeez!");
            }
            else
            {
                transactionSuccessful = true;
                AuditEntry.CreatePurchaseEntry(snackBeingSold, CurrentBalance);
                CurrentBalance -= snackBeingSold.SnackPrice;
               
            }
            return transactionSuccessful;
        }

        public decimal MakeChange()
        {
            int changeInCents = (int)(CurrentBalance * 100);
            int[] Coins = new int[3] { 25, 10, 5 };
            int[] NumberOfEach = new int[3];
            
            if(CurrentBalance == 0.0M)
            {
                Console.WriteLine("There is no change from your transaction.");
            }
            else
            {
                for (int i=0; i<3; i++)
                {
                    int numberOfCoin = changeInCents / Coins[i];
                    changeInCents -= (numberOfCoin * Coins[i]);
                    NumberOfEach[i] = numberOfCoin;
                }
                
                Console.WriteLine($"Here's your change: {NumberOfEach[0]} Quarters, " +
                    $"{NumberOfEach[1]} Dimes and {NumberOfEach[2]} Nickels");
                CurrentBalance = 0.00M;
                AuditEntry.CreateMakeChangeEntry(CurrentBalance);
            } 
            return CurrentBalance;
        }
    }
}
