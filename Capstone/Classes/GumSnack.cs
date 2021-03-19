using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class GumSnack : Snacks
    {
        public override string Message()
        {
            return "Chew Chew, Yum!";
        }
        public GumSnack(string snackCode, string snackName, decimal snackPrice, string snackType, int snackQuantity)
            : base(snackCode, snackName, snackPrice, snackType, snackQuantity) { }
    }
}
