using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingGum : VendingMachineItem
    {
        public VendingGum(string vendingItemString) : base(vendingItemString)
        {

        }
        public override string OutputPhrase()
        {
            return "Chew Chew, Yum!";
        }
    }
}
