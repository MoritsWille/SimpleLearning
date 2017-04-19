using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLearning.Properties;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SimpleLearning
{

    class Program
    {
        static void Main(string[] args)
        {
            start:
            string Go = "";
            XOR xor = new XOR();
            
            while (Go == "")
            {
                double[] error = new double[4];

                for (int Iter = 0; Iter < 1000; Iter++)
                {
                    xor.CalculateAndLearn();
                }
                error = xor.CalculateAndLearn();
                Console.Write(error[0] + "\n" + error[1] + "\n" + error[2] + "\n" + error[3] + "\n");
                Go = Console.ReadLine();
            }
            int[] i = new int[2];
            i[0] = Convert.ToInt32(Console.ReadLine());
            i[1] = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(xor.Calculate(i));
            Console.ReadKey();
            goto start;
        }
    }
}
