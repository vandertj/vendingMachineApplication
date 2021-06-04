using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone
{
    static class Logging
    {

        static string directory = Environment.CurrentDirectory;
        static string sourceFile = @"Log.txt";
        static string fullInputPath = Path.Combine(directory, sourceFile);
        public static void FeedMoneyLog(decimal deposit, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullInputPath, true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY: ${deposit} ${balance}");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void PurchaseItemLog(string itemName, int desiredQuantity, string itemLocation, decimal itemPrice, decimal oldBalance, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullInputPath, true))
                {
                    string line = $"{ DateTime.Now } {desiredQuantity} x {itemName} {itemLocation} {(oldBalance).ToString("C")} {balance.ToString("C")}";
                    sw.WriteLine(line);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ReturnChangeLog(decimal balance, decimal oldBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullInputPath, true))
                {
                    sw.WriteLine($"{DateTime.Now} RETURN CHANGE: {oldBalance.ToString("C")} {balance.ToString("C")}");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //$"{NowDateTime()} action
        //we need to log a line when we:
        //1) call VendingMachine.AddMoney();
        //2) call VendingMachine.PurchaseItem();
        //3) call VendingMachine.ReturnCorrectChange();
        //is this static or not?
        //if not, what are its properties?
        //each line of text "MM/DD/YYYY HH:MM:SS AM/PM FEED MONEY: $5.00 {addedMoney} $5.00"
        //or Crunchie B4 $10.00 $8.50
    }
}
