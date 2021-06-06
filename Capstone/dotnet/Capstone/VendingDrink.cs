using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingDrink : VendingMachineItem
    {
        public VendingDrink(string vendingItemString) : base(vendingItemString)
        {

        }
        public override string OutputPhrase()
        {
            return "Glug Glug, Yum!";
        }
    }
}
