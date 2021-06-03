using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachineItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Location { get; }
        public string Type { get; }
        public int Quantity { get; set; } = 5;


        public VendingMachineItem(string vendingItemString)
        {
            string[] splitItemString = vendingItemString.Split("|");
            this.Location = splitItemString[0];
            this.Name = splitItemString[1];
            this.Price = decimal.Parse(splitItemString[2]);
            this.Type = splitItemString[3];
        }
        public string PurchaseItem(int purchaseQuantity, decimal inputMoney)
        {
            if (inputMoney >= (purchaseQuantity * Price) && purchaseQuantity <= Quantity)
            {
                Quantity = Quantity - purchaseQuantity;
                return "Purchase succesfully completed.";
            }
            else if (purchaseQuantity > Quantity)
            {
                return "Sorry, product is sold out";
            }
            else
            {
                return "Insufficient funds, please insert more money";
            }

        }

        //other methods to calculate change coin amounts & output crunch/yum/whatever
        public decimal CalculateChange(decimal inputMoney, int purchaseQuantity)
        {
            return inputMoney - (Price * purchaseQuantity); 
        }

        public string OutputPhrase(string itemCode)
        {
            if(Type.ToLower() == "chip")
            {
                return "Crunch Crunch, Yum!";
            }else if(Type.ToLower() == "candy") 
            {
                return "Munch Munch, Yum!";
            }else if(Type.ToLower() == "drink")
            {
                return "Glug Glug, Yum!";
            }
            else
            {
                return "Chew Chew, Yum!";
            }
        }
    }
}
