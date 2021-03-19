using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class ChipSnack : Snacks
    {
        public override string Message()
        {
            return "Crunch Crunch, Yum!";
        }
        public ChipSnack(string snackCode, string snackName, decimal snackPrice, string snackType, int snackQuantity)
            : base(snackCode, snackName, snackPrice, snackType, snackQuantity) { }
    }
}
