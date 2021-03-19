using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.TestClasses
{
    [TestClass]
    public class MoneyFunctionsTests
    {
        // 7 Tests for FeedMoney Method

        [TestMethod]

        public void FeedMoneyHappyPathTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "5";
            functionstoTest.CurrentBalance = 3M;
            decimal expectedResult = 8.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(108.00M, functionstoTest.FeedMoney("103"));
            Assert.AreEqual(47.00M, functionstoTest.FeedMoney("45"));
            Assert.AreEqual(1.75M, functionstoTest.FeedMoney("1"));
            Assert.AreEqual(3.05M, functionstoTest.FeedMoney("2"));
        }

        [TestMethod]
        public void FeedMoneyEnteredWithDecimalTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "5.00";
            decimal balance = 3M;
            decimal expectedResult = 8.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(103.00M, functionstoTest.FeedMoney("103.00", 0M));
            Assert.AreEqual(47.00M, functionstoTest.FeedMoney("45.0", 42));
            Assert.AreEqual(1.75M, functionstoTest.FeedMoney("1.00", .75M));
            Assert.AreEqual(3.05M, functionstoTest.FeedMoney("2.0", 1.05M));
        }

        [TestMethod]
        public void FeedMoneyZeroEntryTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "0";
            decimal balance = 3M;
            decimal expectedResult = 3.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(0.00M, functionstoTest.FeedMoney("0", 0M));
            Assert.AreEqual(42.00M, functionstoTest.FeedMoney("0.00", 42));
            Assert.AreEqual(0.75M, functionstoTest.FeedMoney("0.0", .75M));
            Assert.AreEqual(1.05M, functionstoTest.FeedMoney(".00", 1.05M));
        }

        [TestMethod]
        public void FeedMoneyNotIntTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "5.50";
            decimal balance = 3M;
            decimal expectedResult = 3.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(0.00M, functionstoTest.FeedMoney("103.13", 0M));
            Assert.AreEqual(42.00M, functionstoTest.FeedMoney("45.01", 42));
            Assert.AreEqual(.75M, functionstoTest.FeedMoney("1.333333333", .75M));
            Assert.AreEqual(1.05M, functionstoTest.FeedMoney("2.0000005", 1.05M));
        }

        [TestMethod]
        public void FeedMoneyNegativeEntryTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "-5";
            decimal balance = 3M;
            decimal expectedResult = 3.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(0.00M, functionstoTest.FeedMoney("-103.00", 0M));
            Assert.AreEqual(42.00M, functionstoTest.FeedMoney("-45.5", 42));
            Assert.AreEqual(.75M, functionstoTest.FeedMoney("-0", .75M));
            Assert.AreEqual(1.05M, functionstoTest.FeedMoney("-2.0", 1.05M));
        }

        [TestMethod]
        public void FeedMoneyWordTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "five";
            decimal balance = 3M;
            decimal expectedResult = 3.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);


            Assert.AreEqual(0.00M, functionstoTest.FeedMoney("a;weifjw", 0M));
            Assert.AreEqual(42.00M, functionstoTest.FeedMoney("(2*30)", 42));
        }

        [TestMethod]
        public void FeedMoneyEmptyStringTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            string paidInAmount = "";
            decimal balance = 3M;
            decimal expectedResult = 3.00M;

            decimal actualResult = functionstoTest.FeedMoney(paidInAmount, balance);

            Assert.AreEqual(expectedResult, actualResult);

            Assert.AreEqual(0.00M, functionstoTest.FeedMoney("", 0M));
        }

        // Tests for PurchaseTransaction Method

        [TestMethod]
        public void PurchaseTransactionHappyPathTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            Snacks snackBeingSold = new Snacks();
            decimal balance = 3M;

            bool expectedResult = true;

            bool actualResult = functionstoTest.PurchaseTransaction(snackBeingSold, balance);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void PurchaseTransactionNotEnough()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            Snacks snackBeingSold = new Snacks();
            snackBeingSold.SnackPrice = 1.05M;
            decimal balance = 1.00M;

            bool expectedResult = false;

            bool actualResult = functionstoTest.PurchaseTransaction(snackBeingSold);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void PurchaseTransactionHappyPathTest()
        {
            MoneyFunctions functionstoTest = new MoneyFunctions();

            Snacks snackBeingSold = new Snacks();
            snackBeingSold.SnackPrice = 1.05M;
            decimal balance = 3M;

            bool expectedResult = true;

            bool actualResult = functionstoTest.PurchaseTransaction(snackBeingSold, balance);

            Assert.AreEqual(expectedResult, actualResult);

        }



    }
}
