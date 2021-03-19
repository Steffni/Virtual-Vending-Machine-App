using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
   public class MachineTest
    {
        //ARRANGE - begin by arranging the conditions of the test, such as setting up test data.
        //ACT - perform the action of interest—meaning, the thing you're testing.
        //ASSERT - validate that the expected outcome occurred by means of an assertion—that is,---
            //--- a certain value was returned, or a file exists.

        //Test is this index giving the right type of snack X
        //Did it make the dictionary X
        //(snackDetails[0], snackDetails[1], decimal.Parse(snackDetails[2]), snackDetails[3]);

        [TestMethod]
        public void CorrectSnackInventory()
        {
            Machine correctSnack = new Machine(new Dictionary<string, Snacks>());
            correctSnack.CreateSnackInventory();

            Snacks potatoCrisps = correctSnack.Inventory["A1"];
            Snacks moonPie = correctSnack.Inventory["B1"];
            Snacks drSalt = correctSnack.Inventory["C2"];
            Snacks tripleMint = correctSnack.Inventory["D4"];

            Assert.AreEqual("Potato Crisps", potatoCrisps.SnackName);
            Assert.AreEqual(decimal.Parse("3.05"), potatoCrisps.SnackPrice);
            Assert.AreEqual("Chip", potatoCrisps.SnackType);
            Assert.AreEqual(5, potatoCrisps.SnackQuantity);

            Assert.AreEqual("Moon Pie", moonPie.SnackName);
            Assert.AreEqual(decimal.Parse("1.80"), moonPie.SnackPrice);
            Assert.AreEqual("Candy", moonPie.SnackType);
            Assert.AreEqual(5, moonPie.SnackQuantity);

            Assert.AreEqual("Dr. Salt", drSalt.SnackName);
            Assert.AreEqual(decimal.Parse("1.50"), drSalt.SnackPrice);
            Assert.AreEqual("Drink", drSalt.SnackType);
            Assert.AreEqual(5, drSalt.SnackQuantity);

            Assert.AreEqual("Triplemint", tripleMint.SnackName);
            Assert.AreEqual(decimal.Parse("0.75"), tripleMint.SnackPrice);
            Assert.AreEqual("Gum", tripleMint.SnackType);
            Assert.AreEqual(5, tripleMint.SnackQuantity);

        }

        [TestMethod]
        public void CorrectQuantityInInventory()
        {
            Machine quantityOfInventory = new Machine(new Dictionary<string, Snacks>());

            //Checking inventory before snacks are added
            Assert.AreEqual(0, quantityOfInventory.Inventory.Count);

            //Checking inventory after snacks are added
            //had to invoke CreateSnackInventory(), because that's where snacks are added in
                
            quantityOfInventory.CreateSnackInventory();

            Assert.AreEqual(16, quantityOfInventory.Inventory.Count);
        }

        //does it change the quantity in the inventory if you buy one
        //does it reduce the snack quantity
        //does inputing Snack Code return the snack 
        //does Dispense return null if quantity is 0
        //does Dispense return null if it couldn't find SnackCode

        [TestMethod]
        public void InventoryChangeAfterSnackPurchase()
        {
            Machine quantityAfterPurchase = new Machine(new Dictionary<string, Snacks>());

            quantityAfterPurchase.Dispense();


        }

        [TestMethod]
        public void DoesMachineDispenseSnack()
        {
            Machine quantityOfInventory = new Machine(new Dictionary<string, Snacks>());



        }

        [TestMethod]
        public void SnackMessageTest()
        { 
            Machine snackMessage = new Machine(new Dictionary<string, Snacks>());


        }
    }
}
