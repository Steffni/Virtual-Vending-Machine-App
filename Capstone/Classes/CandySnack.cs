using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class CandySnack : Snacks
    {
        public override string Message()
        {
            return "Munch Munch, Yum!";
        }
        public CandySnack(string snackCode, string snackName, decimal snackPrice, string snackType, int snackQuantity)
            : base(snackCode, snackName, snackPrice, snackType, snackQuantity) { }
    }
}
