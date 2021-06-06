using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public static class CreateInventoryList
    {
        //C:\Users\Student\workspace\module1-capstone-c-team-1\Capstone\dotnet\
        static string directory = @"C:\Users\Student\workspace\module1-capstone-c-team-1\Capstone\dotnet\";
        static string sourceFile = @"vendingmachine.csv";
        static string fullInputPath = Path.Combine(directory, sourceFile);
        public static List<VendingMachineItem> InputInventory()
        {
            List<VendingMachineItem> listOfVendingMachineItems = new List<VendingMachineItem>();
            try
            {
                using (StreamReader sr = new StreamReader(fullInputPath))
                {

                    while (!sr.EndOfStream)
                    {
                        //for each line, creating an object of a subclass of "VendingMachineItem"
                        string line = sr.ReadLine();
                        if (line.ToLower().Contains("gum"))
                        {
                            VendingGum vendingGum = new VendingGum(line);
                            listOfVendingMachineItems.Add(vendingGum);
                        }
                        else if (line.ToLower().Contains("chip"))
                        {
                            VendingChip vendingChip = new VendingChip(line);
                            listOfVendingMachineItems.Add(vendingChip);
                        }
                        else if (line.ToLower().Contains("drink"))
                        {
                            VendingDrink vendingDrink = new VendingDrink(line);
                            listOfVendingMachineItems.Add(vendingDrink);
                        }
                        else if (line.ToLower().Contains("candy"))
                        {
                            VendingCandy vendingCandy = new VendingCandy(line);
                            listOfVendingMachineItems.Add(vendingCandy);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return listOfVendingMachineItems;
        }
    }
}
