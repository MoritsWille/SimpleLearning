using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleLearning;
using System.IO;

namespace SimpleLearning
{
    public class Neuron
    {
        public Weight[] Weights;
        public double Value;

        public static void Save(Neuron[] neuron, string path)
        {   
            string data = JsonConvert.SerializeObject(neuron);
            File.WriteAllText(path, data);
        }

        public static Neuron[] Randomize(Neuron[] neurons)
        {
            Random random = new Random();
            for (int e = 0; e < neurons.Length; e++)
            {
                for (int i = 0; i < neurons[e].Weights.Length; ++i)
                {
                    neurons[e].Weights[i] = new Weight();
                    neurons[e].Weights[i].WeightValue = random.NextDouble() * 2.0 - 1.0;
                }
            }

            return neurons;
        }
    }
}
