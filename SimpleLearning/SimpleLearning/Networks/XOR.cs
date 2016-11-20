using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleLearning
{
    class XOR : INeuralNetwork
    {
        LearningSet[] _learningSet;
        Neuron[] _neuron;
        string _learningSetPath;
        string _neuronPath;
        public float Error;
        public int Output;

        public void Initialize()
        {
            GetPathValues();
            if (File.Exists(_learningSetPath))
            {
                _learningSet = JsonConvert.DeserializeObject<LearningSet[]>(File.ReadAllText(_learningSetPath));
            }
            else
            {
                _learningSet[0] = new LearningSet();
                _learningSet[0].Input = new int[2] { 1, 1 };
                _learningSet[0].Output = new int[1] { 0 };

                _learningSet[1] = new LearningSet();
                _learningSet[1].Input = new int[2] { 1, 0 };
                _learningSet[1].Output = new int[1] { 1 };

                _learningSet[2] = new LearningSet();
                _learningSet[2].Input = new int[2] { 0, 1 };
                _learningSet[2].Output = new int[1] { 1 };

                _learningSet[3] = new LearningSet();
                _learningSet[3].Input = new int[2] { 0, 0 };
                _learningSet[3].Output = new int[1] { 0 };

                LearningSet.Save(_learningSet, _learningSetPath);
            }

            if (File.Exists(_neuronPath))
            {
                _neuron = JsonConvert.DeserializeObject<Neuron[]>(File.ReadAllText(_neuronPath));
            }
            else
            {
                _neuron[0].Weights.Add(new Weight());
                _neuron[0].Weights.Add(new Weight());
                Neuron.Randomize(_neuron[0]);
            }

        }

        public int Calculate()
        {
            return 0;
        }

        public float CalculateAndLearn()
        {
            return 0;
        }

        void GetPathValues()
        {
            _learningSetPath = System.Reflection.Assembly.GetExecutingAssembly().Location + @"/XORSet.json";
            _neuronPath = System.Reflection.Assembly.GetExecutingAssembly().Location + @"/XORNeuron.json";
        }
    }
}
