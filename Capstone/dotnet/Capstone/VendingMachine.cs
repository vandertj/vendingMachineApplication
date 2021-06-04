using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {


        //properties of a vending machine: inventory list, balance
        public decimal Balance { get; set; } = 0M;
        public List<VendingMachineItem> Inventory { get; private set; } = new List<VendingMachineItem>();

        public VendingMachine(List<VendingMachineItem> listOfVendingMachineItems)
        {
            Inventory = listOfVendingMachineItems;
        }

        //what does a vending machine do?
        //method to print inventory
        public void PrintInventory()
        {
            foreach (VendingMachineItem item in Inventory)
            {
                if (item.Quantity == 0)
                { //Displays Item is sold out if Quantity reaches 0
                    Console.WriteLine($"{item.Location}, {item.Name}, ${item.Price}, SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{item.Location}, {item.Name}, ${item.Price}, {item.Quantity} remaining");
                }
            }
        }

        //method to compare if selected item location is valid
        public bool CheckIfItemValid(string chosenItem)
        {
            List<string> listOfVendingMachineCodes = new List<string>();
            foreach (VendingMachineItem item in Inventory)
            {
                //matching item code with item
                listOfVendingMachineCodes.Add(item.Location);
                if (item.Location == chosenItem)
                {
                    return true;
                }
            }
            return false;
        }

        //method to keep track of Balance
        public void AddMoney(decimal addedMoney)
        {
            Balance += addedMoney;
            Console.WriteLine($"Current Balance: {Balance.ToString("C")}");
            Console.WriteLine();
            Logging.FeedMoneyLog(addedMoney, Balance);
        }

        //return change
        public void ReturnCorrectChange()
        {
            int numQuarters = 0;
            int numDimes = 0;
            int numNickels = 0;
            decimal quarter = 0.25M;
            decimal dime = 0.10M;
            decimal nickel = 0.05M;
            decimal oldBalance = Balance;
            while (Balance - quarter >= 0)
            {
                numQuarters++;
                Balance -= quarter;
            }
            while (Balance - dime >= 0)
            {
                numDimes++;
                Balance -= dime;
            }
            while (Balance - nickel >= 0)
            {
                numNickels++;
                Balance -= nickel;
            }
            Console.WriteLine($"Your change is {numQuarters} quarter(s), {numDimes} dime(s), and {numNickels} nickel(s)");
            Logging.ReturnChangeLog(Balance, oldBalance);
        }
        public bool PurchaseItem(int purchaseQuantity, string chosenItem)
        {
            foreach (VendingMachineItem item in Inventory)
            {
                if (item.Location == chosenItem)
                {
                    if (Balance >= (purchaseQuantity * item.Price) && purchaseQuantity <= item.Quantity)
                    {
                        item.Quantity = item.Quantity - purchaseQuantity;
                        decimal oldBalance = Balance;
                        Balance -= purchaseQuantity * item.Price;
                        Console.WriteLine($"You purchased {purchaseQuantity} {item.Name}(s) for {item.Price.ToString("C")} a piece.");
                        Console.WriteLine($"You have {Balance.ToString("C")} remaining. {item.OutputPhrase()}");
                        Logging.PurchaseItemLog(item.Name, purchaseQuantity, item.Location, item.Price, oldBalance, Balance);
                        return true;
                    }
                    else if (purchaseQuantity > item.Quantity)
                    {
                        Console.WriteLine("Sorry, product is sold out");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds, please insert more money");
                        return false;
                    }
                }
            }
            return false;

        }

    }
}
