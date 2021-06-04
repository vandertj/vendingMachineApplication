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
            try
            {
                using (StreamReader sr = new StreamReader(fullInputPath))
                {
                    while (!sr.EndOfStream)
                    {
                        //string[] line = sr.ReadLine().Split(" ");
                        string wholeLine = sr.ReadLine();
                        int currentNumberSold = 0;
                        string logItemName = "";
                        if (!wholeLine.Contains("FEED") && !wholeLine.Contains("CHANGE"))
                        {
                            string[] line = wholeLine.Split(" ");
                            int quantitySold = int.Parse(line[3]);
                            logItemName = wholeLine;
                            //nameAndSold[item.Name] += quantitySold;

                            //creating a dictionary with all items, set to 0
                            //foreach (VendingMachineItem item in listOfVendingMachineItems)
                            //{
                            //    if (nameAndSold.ContainsKey(item.Name))
                            //    {
                            //        nameAndSold[item.Name] += quantitySold;
                            //    } else if (!nameAndSold.ContainsKey(item.Name))
                            //    {
                            //        nameAndSold.Add(item.Name, currentNumberSold);
                            //    }

                            //}
                            //foreach (KeyValuePair<string, int> nameSold in nameAndSold)
                            //{
                            //    if (logItemName.Contains(nameSold.Key))
                            //    {
                            //        int currentAmount = nameSold.Value;
                            //        //nameAndSold.Remove(nameSold.Key);
                            //        //nameAndSold.Add(nameSold.Key, currentAmount + quantitySold);
                            //        finalDictionary[nameSold.Key] = currentAmount + quantitySold;

                            //    }
                            //}
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(fullOutputPath))
                {
                    foreach (KeyValuePair<string, int> nameSold in nameAndSold)
                    {
                        sw.WriteLine($"{nameSold.Key}|{nameSold.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}
