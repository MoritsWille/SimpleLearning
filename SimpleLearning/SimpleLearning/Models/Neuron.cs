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
        public string Name;
        public List<Weight> Weights;
        public float Value;

        public static  void Save(Neuron neuron, string path)
        {   
            string data = JsonConvert.SerializeObject(neuron);
            File.WriteAllText(path, data);
        }

        public static Neuron Randomize(Neuron neuron)
        {
            Random random = new Random();
            foreach (Weight weight in neuron.Weights)
            {
                weight.WeightValue = random.Next(-100, 100) / 100;
            }

            return neuron;
        }
    }
}
