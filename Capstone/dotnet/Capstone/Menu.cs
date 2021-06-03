using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    static class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine();
            Console.WriteLine("Please select an option:");
        }
        public static void DisplayPurchaseMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine("Please select an option");
        }
    }
}
