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



        //other methods to calculate change coin amounts & output crunch/yum/whatever
        public decimal CalculateChange(decimal inputMoney, int purchaseQuantity)
        {
            return inputMoney - (Price * purchaseQuantity);
        }

        public abstract string OutputPhrase();
    }
}
