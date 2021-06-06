using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void ValidItemTestFail() //a bad item code should make this method return false
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            Assert.AreEqual(false, vendingMachine.CheckIfItemValid("Z10"));
        }
        [TestMethod]
        public void ValidItemTestPass()// input item code to match an item in the list
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            Assert.AreEqual(true, vendingMachine.CheckIfItemValid("B3"));
        }
        [TestMethod]
        public void RejectPurchaseInsufficientFunds()//insufficient funds rejects purchase
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            vendingMachine.Balance = 1.00M;
            Assert.AreEqual(false, vendingMachine.PurchaseItem(1, "C3"));
        }
        [TestMethod]
        public void PurchaseItemWithSufficientFunds()//sufficient funds accepts purchase
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            vendingMachine.Balance = 1.00M;
            Assert.AreEqual(true, vendingMachine.PurchaseItem(1, "D2"));
        }
        [TestMethod]
        public void NotEnoughInStockToFulfill()//should return false if machine lacks required inventory
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            vendingMachine.Balance = 6.00M;
            Assert.AreEqual(false, vendingMachine.PurchaseItem(6, "D2"));
        }

        [TestMethod]
        public void PurchaseItemUpdatesBalance()//A successful purchase should lower balance accordingly
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            vendingMachine.Balance = 1.00M;
            vendingMachine.PurchaseItem(1, "D2");
            Assert.AreEqual(0.05M, vendingMachine.Balance);
        }

        [TestMethod]
        public void ReturnChangeSetsBalanceToZero() //after returning change, balance should be 0
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            vendingMachine.Balance = 1.65M;
            vendingMachine.ReturnCorrectChange();
            Assert.AreEqual(0, vendingMachine.Balance);
        }
        [TestMethod]
        public void CreateInventoryListAddsCorrectNumberOfObjects() //each line should add an object to listOfVendingMachineItems
        {
            string directory = @"C:\Users\Student\workspace\module1-capstone-c-team-1\Capstone\dotnet\";
            string sourceFile = @"vendingmachine.csv";
            string fullInputPath = Path.Combine(directory, sourceFile);
            Assert.AreEqual(16, (CreateInventoryList.InputInventory()).Count);
        }
        [TestMethod]
        public void OutputPhraseDrink() // checks that a drink item outputs the correct output phrase
        {
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            Assert.AreEqual("Glug Glug, Yum!", drink.OutputPhrase());
        }
        [TestMethod]
        public void OutputPhraseGum() // checks that a drink item outputs the correct output phrase
        {
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            Assert.AreEqual("Chew Chew, Yum!", gum.OutputPhrase());
        }
        [TestMethod]
        public void OutputPhraseChip() // checks that a drink item outputs the correct output phrase
        {
            VendingChip chip = new VendingChip("C2|Pringles|1.35|Chip");
            Assert.AreEqual("Crunch Crunch, Yum!", chip.OutputPhrase());
        }
        [TestMethod]
        public void OutputPhraseCandy() // checks that a drink item outputs the correct output phrase
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            Assert.AreEqual("Munch Munch, Yum!", candy.OutputPhrase());
        }
        [TestMethod]
        public void AddingMoney() // Balance should update when user feeds in money
        {
            VendingCandy candy = new VendingCandy("B3|Wonka Bar|1.50|Candy");
            VendingGum gum = new VendingGum("D2|Little League Chew|0.95|Gum");
            VendingDrink drink = new VendingDrink("C3|Mountain Melter|1.50|Drink");
            List<VendingMachineItem> sampleList = new List<VendingMachineItem>() { candy, gum, drink };
            VendingMachine vendingMachine = new VendingMachine(sampleList);
            decimal addedMoney = 15.00M;
            vendingMachine.AddMoney(addedMoney);
            Assert.AreEqual(15.00M, vendingMachine.Balance);

        }
    }
}
