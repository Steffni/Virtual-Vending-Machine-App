using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public abstract class Snacks : IYumYum
    {
        public string SnackCode { get; set; }
        public string SnackName { get; set; }
        public decimal SnackPrice { get; set; }
        public string SnackType { get; set; }
        public int SnackQuantity { get; set; } = 5;

        public Snacks(string snackCode, string snackName, decimal snackPrice, string snackType, int snackQuantity)
        {
            SnackCode = snackCode;
            SnackName = snackName;
            SnackPrice = snackPrice;
            SnackType = snackType;
            SnackQuantity = snackQuantity;
        }
        public abstract string Message();
    }
}