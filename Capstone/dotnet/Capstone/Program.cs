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
            decimal currentMoney = (decimal)0;
            List<VendingMachineItem> listOfVendingMachineItems = new List<VendingMachineItem>();
            List<string> listOfVendingMachineCodes = new List<string>();
            string filePath = @"C:\Users\Student\workspace\module1-capstone-c-team-1\Example Files\Inventory.txt";
            try
            {
                using  (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        //for each line, creating an object of a subclass of "VendingMachineItem"
                        string line = sr.ReadLine();
                        if (line.ToLower().Contains("gum"))
                        {
                            VendingGum vendingGum = new VendingGum(line);
                            listOfVendingMachineItems.Add(vendingGum);
                        } else if (line.ToLower().Contains("chip"))
                        {
                            VendingChip vendingChip = new VendingChip(line);
                            listOfVendingMachineItems.Add(vendingChip);
                        }else if (line.ToLower().Contains("drink"))
                        {
                            VendingDrink vendingDrink = new VendingDrink(line);
                            listOfVendingMachineItems.Add(vendingDrink);
                        }else if (line.ToLower().Contains("candy"))
                        {
                            VendingCandy vendingCandy = new VendingCandy(line);
                            listOfVendingMachineItems.Add(vendingCandy);
                        }
                    }
                    //Calling a method that displays main menu from static class Menu
                    Menu.DisplayMainMenu();
                    string userInput = Console.ReadLine();
                    //user will enter 1, 2, or 3 as prompted by menu
                    while (userInput != "3")
                    {
                        while (userInput == "1")
                        {
                            //User has requested a list of all items
                            foreach (VendingMachineItem item in listOfVendingMachineItems)
                            {
                                if(item.Quantity == 0)
                                { //Displays Item is sold out if Quantity reaches 0
                                    Console.WriteLine($"{item.Location}, {item.Name}, ${item.Price}, SOLD OUT");
                                } else
                                {
                                    Console.WriteLine($"{item.Location}, {item.Name}, ${item.Price}, {item.Quantity} remaining");
                                }
                            }
                            Console.WriteLine();
                            //resets user input to 0 and returns you to the main menu
                            userInput = "0";
                            Menu.DisplayMainMenu();
                            userInput = Console.ReadLine();

                        }
                        while (userInput == "2")
                        {
                            //user has requested the purchase menu
                            Menu.DisplayPurchaseMenu();
                            string purchaseInput = Console.ReadLine();
                            if (purchaseInput == "1")
                            {
                                //user is adding money
                                while(purchaseInput == "1")
                                {
                                    Console.WriteLine("Please enter how many dollars you are adding");
                                    decimal addedMoney = decimal.Parse(Console.ReadLine());
                                    currentMoney += addedMoney;
                                    Console.WriteLine($"Current Balance: {currentMoney.ToString("C")}");
                                    Console.WriteLine();
                                    Console.WriteLine("To add more money, please enter 1; if you are finished, enter 2");
                                    purchaseInput = Console.ReadLine();
                                }
                                
                            } 
                            else if (purchaseInput == "2")
                            {
                                //user is selecting an item and quantity
                                foreach (VendingMachineItem item in listOfVendingMachineItems)
                                {
                                    Console.WriteLine($"{item.Name}, ${item.Price}, {item.Location}, {item.Quantity} remaining");
                                }
                                Console.WriteLine("Input the location of the item you want:");
                                string chosenItem = Console.ReadLine().ToUpper();
                                Console.WriteLine("How many would you like to purchase?");
                                int desiredQuantity = int.Parse(Console.ReadLine());
                                foreach (VendingMachineItem item in listOfVendingMachineItems)
                                {
                                    //matching item code with item
                                    listOfVendingMachineCodes.Add(item.Location);
                                    if (item.Location == chosenItem)
                                    {
                                        item.PurchaseItem(desiredQuantity, currentMoney);
                                        currentMoney -= desiredQuantity * item.Price;
                                    } 
                                }
                                //checking to make sure the code is valid
                                if (!listOfVendingMachineCodes.Contains(chosenItem))
                                {
                                    Console.WriteLine("Sorry, item not found");
                                }

                            } 
                            else if (purchaseInput == "3")
                            {

                            }
                        }
                        while (userInput == "3")
                        {
                            Console.WriteLine("Thank you, have a nice day");
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
