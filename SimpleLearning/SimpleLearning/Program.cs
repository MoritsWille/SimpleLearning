﻿using System;
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
            XOR xor = new XOR();
            for (int i = 0; i < xor.Calculate().Length; ++i)
            {
                Console.WriteLine(xor.Calculate()[i]);
            }

            Console.ReadKey();
        }
    }
}
