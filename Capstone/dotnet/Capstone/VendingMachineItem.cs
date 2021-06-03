using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    abstract public class VendingMachineItem
    {
        //properties of the class VendingMachineItem
        public string Name { get; }
        public decimal Price { get; }
        public string Location { get; }
        public string Type { get; }
        public int Quantity { get; set; } = 5;

        //public string Output {get; } 

        //constructor requires one parameter for instantiation
        public VendingMachineItem(string vendingItemString)
        {
            string[] splitItemString = vendingItemString.Split("|");
            this.Location = splitItemString[0];
            this.Name = splitItemString[1];
            this.Price = decimal.Parse(splitItemString[2]);
            this.Type = splitItemString[3];
        }
        public void PurchaseItem(int purchaseQuantity, decimal inputMoney)
        {
            if (inputMoney >= (purchaseQuantity * Price) && purchaseQuantity <= Quantity)
            {
                Quantity = Quantity - purchaseQuantity;
                inputMoney -= purchaseQuantity * Price;
                Console.WriteLine($"You purchased {purchaseQuantity} {Name}(s) for {Price.ToString("C")} a piece.");
                Console.WriteLine($"You have {inputMoney.ToString("C")} remaining. {OutputPhrase()}");
            }
            else if (purchaseQuantity > Quantity)
            {
                Console.WriteLine("Sorry, product is sold out");
            }
            else
            {
                Console.WriteLine("Insufficient funds, please insert more money");
            }

        }

        //other methods to calculate change coin amounts & output crunch/yum/whatever
        public decimal CalculateChange(decimal inputMoney, int purchaseQuantity)
        {
            return inputMoney - (Price * purchaseQuantity); 
        }

        public abstract string OutputPhrase();
    }
}
