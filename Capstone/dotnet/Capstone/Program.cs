using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//C:\Users\Student\workspace\module1-capstone-c-team-1\Example Files\Inventory.txt
namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VendingMachineItem> listOfVendingMachineItems = new List<VendingMachineItem>();
            //Calling method that inputs the inventory and creates our list of items in the inventory
            VendingMachine vending = new VendingMachine(CreateInventoryList.InputInventory());
            //Calling a method that displays main menu from static class Menu
            Menu.DisplayMainMenu();
            string userInput = Console.ReadLine();
            //user will enter 1, 2, or 3 as prompted by menu
            while (userInput != "3")
            {
                if (userInput == "1")
                {
                    //User has requested a list of all items
                    vending.PrintInventory();
                    Console.WriteLine();
                    //resets user input to 0 and returns you to the main menu
                    userInput = "0";
                    Menu.DisplayMainMenu();
                    userInput = Console.ReadLine();
                }
                else if (userInput == "2")
                {
                    //user has requested the purchase menu
                    Menu.DisplayPurchaseMenu();
                    string purchaseInput = Console.ReadLine();
                    while (purchaseInput != "3")
                    {
                        //user is adding money
                        while (purchaseInput != "2")
                        {
                            Console.WriteLine("Please enter how many dollars you are adding");
                            decimal addedMoney = decimal.Parse(Console.ReadLine());
                            vending.AddMoney(addedMoney);
                            Console.WriteLine("To add more money, please enter 1; if you are finished, enter 2");
                            purchaseInput = Console.ReadLine();
                        }
                        if (purchaseInput == "2")
                        {
                            //user is selecting an item and quantity
                            vending.PrintInventory();
                            Console.WriteLine();
                            Console.WriteLine("Input the location of the item you want:");
                            string chosenItem = Console.ReadLine().ToUpper();
                            Console.WriteLine("How many would you like to purchase?");
                            int desiredQuantity = int.Parse(Console.ReadLine());
                            //if item code is valid, attempt purchase of desired quantity
                            if (vending.CheckIfItemValid(chosenItem))
                            {
                                vending.PurchaseItem(desiredQuantity, chosenItem);
                            }
                            //if item code is not valid, do not attempt purchase
                            if (!vending.CheckIfItemValid(chosenItem))
                            {
                                Console.WriteLine("Sorry, item not found");
                            }
                            Console.WriteLine("To make another purchase, please enter 2");
                            Console.WriteLine("To finish your transaction, please enter 3");
                            purchaseInput = Console.ReadLine();
                        }
                    }
                    if (purchaseInput == "3")
                    {
                        vending.ReturnCorrectChange();
                        Console.WriteLine();
                        userInput = "0";
                        Menu.DisplayMainMenu();
                        userInput = Console.ReadLine();
                    }
                   
                }
                if (userInput == "4")
                {
                    SalesReport.WriteReport(vending.Inventory);
                }
                //input string not in correct format
            }
            if (userInput == "3")
            {
                Console.WriteLine("Thank you, have a nice day");
            }
        }
    }
}
