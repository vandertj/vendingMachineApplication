using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingCandy : VendingMachineItem
    {
        public string Output { get; } = "Munch Munch, Yum!";
        public VendingCandy(string vendingItemString) : base(vendingItemString)
        {

        }
        public override string OutputPhrase()
        {
            return "Munch Munch, Yum!";
        }
    }
}
