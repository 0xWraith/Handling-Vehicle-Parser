using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Veh
{
    class Program
    {
        static void Main(string[] args)
        {
            string vehicleIDE = @"C:\Users\dimad\Desktop\vehicles.ide";
            string handlingCFG = @"C:\Users\dimad\Desktop\handling.cfg";
            int counter = 0;

            List<string> models = new List<string>() { };

            using (StreamReader sr = new StreamReader(vehicleIDE, Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    counter++;
                    models.Add(words[4]);
                    Console.WriteLine($"{words[4]}");
                }
            }
            Console.WriteLine($"{counter}");
            while(counter > 0)
            {
                using (StreamReader sr = new StreamReader(handlingCFG, Encoding.Default))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if(line.Contains(';') || line.Contains('^') || line.Contains('!') || line.Contains('$') || line.Contains('%'))
                            continue;

                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (counter == 0)
                            break;

                        if (words[0].Contains(models[249 - counter]))
                        {
                            //Console.WriteLine($"{{{words[12]}, {words[13]}, {words[17]}, {words[9]}}},");
                            Console.WriteLine($"{{{words[12]}, {words[13]}, {words[17]}, {words[9]}}},");
                            counter--;
                        }
                    }
                }    
            }

            Console.ReadKey();
        }
    }
}
