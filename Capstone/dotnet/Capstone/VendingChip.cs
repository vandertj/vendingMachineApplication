using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class VendingChip : VendingMachineItem
    {
        public string Output { get; }
        public VendingChip(string vendingItemString) : base(vendingItemString)
        {

        }
        public override string OutputPhrase()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
