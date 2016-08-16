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
            int[] i = new int[2];
            int ideal;
            double error;
            double[] w = new double[9];
            double[] wDeriv = new double[9];
            double[] h = new double[2];
            double[] hDeriv = new double[2];
            double o;
            double oout;
            double oDeriv;
            start:
            for (int t = 1; t < 5; t++)
            {
                //read values from xml
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Environment.CurrentDirectory + "/XORtraining.xml");
                i[0] = Convert.ToInt16(xDoc.SelectSingleNode("training/inputs/in" + t.ToString() + "/i1").InnerText);
                i[1] = Convert.ToInt16(xDoc.SelectSingleNode("training/inputs/in" + t.ToString() + "/i2").InnerText);
                ideal = Convert.ToInt16(xDoc.SelectSingleNode("training/outputs/o" + t.ToString()).InnerText);

                xDoc.Load(Environment.CurrentDirectory + "/XORsettings.xml");

                for (int e = 0; e < 9; e++)
                {
                    w[e] = Convert.ToDouble(xDoc.SelectSingleNode("weights/w" + e.ToString()).InnerText);
                }

                //read values from user
                //Console.WriteLine("Type Input 1, Input 2, ideal");
                //[0] = Convert.ToInt16(Console.ReadLine());
                //i[1] = Convert.ToInt16(Console.ReadLine());
                //ideal = Convert.ToInt16(Console.ReadLine());


                //from input to hidden
                h[0] = i[0] * w[0] + i[1] * w[2] + w[4];
                h[1] = i[0] * w[1] + i[1] * w[3] + w[5];

                //from hidden to output
                o = h[0] * w[6] + h[1] * w[7] + w[8];

                //calculate output with sigmoid
                oout = 1 / (1 + Math.Pow(Math.E, o / -1));

                //calculate error and derivatives
                error = 0.5 * Math.Pow((ideal - oout), 2);
                oDeriv = -(ideal - oout);
                hDeriv[0] = oout * (1 - oout) * oDeriv;
                hDeriv[1] = oout * (1 - oout) * oDeriv;
                wDeriv[0] = i[0] * hDeriv[0];
                wDeriv[1] = i[0] * hDeriv[1];
                wDeriv[2] = i[1] * hDeriv[0];
                wDeriv[3] = i[1] * hDeriv[1];
                wDeriv[4] = hDeriv[0];
                wDeriv[5] = hDeriv[1];
                wDeriv[6] = hDeriv[0] * oDeriv;
                wDeriv[7] = hDeriv[1] * oDeriv;
                wDeriv[8] = oDeriv;

                //Update weights and save xml
                for (int e = 0; e < 9; e++)
                {
                    w[e] = w[e] * -2 * wDeriv[e];
                    xDoc.SelectSingleNode("weights/w" + e.ToString()).InnerText = w[e].ToString();
                }
                xDoc.Save(Environment.CurrentDirectory + "/XORsettings.xml");

                Console.WriteLine(oout.ToString() + " Error: " + error.ToString());
            }
            Console.ReadKey();
            goto start;
        }
    }
}
