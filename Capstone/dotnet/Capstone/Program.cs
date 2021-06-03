using System;
using System.IO;
using System.Collections.Generic;
//C:\Users\Student\workspace\module1-capstone-c-team-1\Example Files\Inventory.txt
namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VendingMachineItem> listOfVendingMachineItems = new List<VendingMachineItem>();
            string filePath = @"C:\Users\Student\workspace\module1-capstone-c-team-1\Example Files\Inventory.txt";
            try
            {
                using  (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        VendingMachineItem vendingMachineItem = new VendingMachineItem(line);
                        listOfVendingMachineItems.Add(vendingMachineItem);
                    }
                    MainMenu.DisplayMainMenu();
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
