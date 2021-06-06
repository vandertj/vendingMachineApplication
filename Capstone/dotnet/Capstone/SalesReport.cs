using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone
{
    static class SalesReport
    {
        static string directory = Environment.CurrentDirectory;
        static string sourceFile = @"Log.txt";
        static string outputFile = @$"Sales_Report{DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’_’mm’_’ss")}.txt";
        static string fullInputPath = Path.Combine(directory, sourceFile);
        static string fullOutputPath = Path.Combine(directory, outputFile);


        public static void WriteReport(List<VendingMachineItem> listOfVendingMachineItems)
        {
            Dictionary<string, int> nameAndSold = new Dictionary<string, int>();
            //creating a dictionary with all items, set to 0
            foreach (VendingMachineItem item in listOfVendingMachineItems)
            {
                nameAndSold.Add(item.Name, 0);
            }
            //creating name/price dictionary
            Dictionary<string, decimal> nameAndPrice = new Dictionary<string, decimal>();
            foreach (VendingMachineItem item in listOfVendingMachineItems)
            {
                nameAndPrice.Add(item.Name, item.Price);
            }
            try
            {
                decimal totalSales = 0.00M;
                using (StreamReader sr = new StreamReader(fullInputPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string wholeLine = sr.ReadLine();
                        string logItemName = "";
                        //we only want the purchase lines
                        if (!wholeLine.Contains("FEED") && !wholeLine.Contains("CHANGE"))
                        {
                            string[] line = wholeLine.Split(" ");
                            int quantitySold = int.Parse(line[3]);
                            if (line.Length == 10)
                            {
                                logItemName = $"{line[5]} {line[6]}";
                            }
                            else if (line.Length == 11)
                            {
                                logItemName = $"{line[5]} {line[6]} {line[7]}";
                            }
                            else
                            {
                                logItemName = line[5];
                            }
                            if (nameAndSold.ContainsKey(logItemName))
                            {
                                nameAndSold[logItemName] += quantitySold;
                                totalSales += nameAndPrice[logItemName] * quantitySold;
                            }
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(fullOutputPath))
                {
                    foreach (KeyValuePair<string, int> nameSold in nameAndSold)
                    {
                        sw.WriteLine($"{nameSold.Key}|{nameSold.Value}");
                    }
                    sw.WriteLine();
                    sw.WriteLine($"Total Sales: ${totalSales}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
