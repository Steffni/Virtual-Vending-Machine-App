using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class DrinkSnack : Snacks
    {
        public override string Message()
        {
            return "Glug Glug, Yum!";
        }
        public DrinkSnack(string snackCode, string snackName, decimal snackPrice, string snackType, int snackQuantity)
            : base(snackCode, snackName, snackPrice, snackType, snackQuantity) { }
    }
}
