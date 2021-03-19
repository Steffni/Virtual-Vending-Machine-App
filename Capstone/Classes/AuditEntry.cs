using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{

   // All purchases must be audited to prevent theft from the vending machine:
   //- Each purchase must generate a line in a file called `Log.txt`.
   //- The audit entry must be in the format:
   //     >```
   //     > 01/01/2016 12:00:00 PM FEED MONEY: $5.00 $5.00
   //      >01/01/2016 12:00:15 PM FEED MONEY: $5.00 $10.00
   //      >01/01/2016 12:00:20 PM Crunchie B4 $10.00 $8.50
   //      >01/01/2016 12:01:25 PM Cowtales B2 $8.50 $7.50
   //      >01/01/2016 12:01:35 PM GIVE CHANGE: $7.50 $0.00
   //      >```
    public class AuditEntry
    {
        public static bool CreateFeedMoneyEntry(decimal moneyFed, decimal balance)
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            bool wroteAuditEntry;

            try 
            {
                if (!File.Exists(fullPath))
                {
                    using (StreamWriter sw = File.CreateText(fullPath));
                }
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.Write(DateTime.Now);
                    sw.Write("  FEED MONEY: ");
                    sw.Write($"  ${moneyFed}  ${balance}\n");
                    wroteAuditEntry = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                wroteAuditEntry = false;
            }
            return wroteAuditEntry;

        }

        public static bool CreateMakeChangeEntry(decimal balance)
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            bool wroteAuditEntry;
            decimal zeroBalance = 0.00M;

            try
            {
                if (!File.Exists(fullPath))
                {
                    using (StreamWriter sw = File.CreateText(fullPath));
                }
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.Write(DateTime.Now);
                    sw.Write("  GIVE MONEY: ");
                    sw.Write($"  ${balance}  ${zeroBalance}\n");
                    wroteAuditEntry = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                wroteAuditEntry = false;
            }
            return wroteAuditEntry;

        }

        public static bool CreatePurchaseEntry(Snacks snackBeingSold, decimal balanceBefore)
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            bool wroteAuditEntry;

            try
            {
                if(!File.Exists(fullPath))
                {
                    using (StreamWriter sw = File.CreateText(fullPath));
                }
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.Write(DateTime.Now);
                    sw.Write($"  {snackBeingSold.SnackName} {snackBeingSold.SnackCode}");
                    sw.Write($"  ${balanceBefore}  ${balanceBefore - snackBeingSold.SnackPrice}\n");
                    wroteAuditEntry = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                wroteAuditEntry = false;
            }
            return wroteAuditEntry;

        }
    }
}
