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
        LearningSet[] _learningSets;
        Neuron[] _neuron;
        string _learningSetPath;
        string _neuronPath;

        public void Initialize()
        {
            _neuron = new Neuron[6];
            _learningSets = new LearningSet[4];



            GetPathValues();
            if (File.Exists(_learningSetPath))
            {
                _learningSets = JsonConvert.DeserializeObject<LearningSet[]>(File.ReadAllText(_learningSetPath));
            }
            else
            {
                _learningSets[0] = new LearningSet();
                _learningSets[0].Input = new int[2] { 1, 1 };
                _learningSets[0].Output = new int[1] { 0 };

                _learningSets[1] = new LearningSet();
                _learningSets[1].Input = new int[2] { 1, 0 };
                _learningSets[1].Output = new int[1] { 1 };

                _learningSets[2] = new LearningSet();
                _learningSets[2].Input = new int[2] { 0, 1 };
                _learningSets[2].Output = new int[1] { 1 };

                _learningSets[3] = new LearningSet();
                _learningSets[3].Input = new int[2] { 0, 0 };
                _learningSets[3].Output = new int[1] { 0 };

                LearningSet.Save(_learningSets, _learningSetPath);
            }

            if (File.Exists(_neuronPath))
            {
                _neuron = JsonConvert.DeserializeObject<Neuron[]>(File.ReadAllText(_neuronPath));
            }
            else
            {
                _neuron[0] = new Neuron();
                _neuron[0].Weights = new Weight[2];

                _neuron[1] = new Neuron();
                _neuron[1].Weights = new Weight[2];

                _neuron[2] = new Neuron();
                _neuron[2].Weights = new Weight[2];

                _neuron[3] = new Neuron();
                _neuron[3].Weights = new Weight[1];

                _neuron[4] = new Neuron();
                _neuron[4].Weights = new Weight[1];

                _neuron[5] = new Neuron();
                _neuron[5].Weights = new Weight[1];

                _neuron = Neuron.Randomize(_neuron);
                Neuron.Save(_neuron, _neuronPath);
            }

        }

        public int[] Calculate()
        {
            Initialize();
            int i = 0;
            int[] output = new int[4];
            foreach (LearningSet _learningSet  in _learningSets)
            {
                //make all bias neurons be 1
                _neuron[2].Value = 1;
                _neuron[5].Value = 1;

                //define input values
                _neuron[0].Value = _learningSet.Input[0];
                _neuron[1].Value = _learningSet.Input[1];

                //calculate neurons values in hidden layer
                _neuron[3].Value = _neuron[0].Value * _neuron[0].Weights[0].WeightValue + _neuron[1].Value * _neuron[1].Weights[0].WeightValue + _neuron[2].Value * _neuron[2].Weights[0].WeightValue;
                _neuron[4].Value = _neuron[0].Value * _neuron[0].Weights[1].WeightValue + _neuron[1].Value * _neuron[1].Weights[1].WeightValue + _neuron[2].Value * _neuron[2].Weights[1].WeightValue;

                //get output
                output[i] = Convert.ToInt16(_neuron[3].Value * _neuron[3].Weights[0].WeightValue + _neuron[4].Value * _neuron[4].Weights[0].WeightValue + _neuron[5].Value * _neuron[5].Weights[0].WeightValue);

                i++;
            }
            return output;
        }

        public void CalculateAndLearn()
        {
        }

        void GetPathValues()
        {
            _learningSetPath = Directory.GetCurrentDirectory() + @"/XORSet.json";
            _neuronPath = Directory.GetCurrentDirectory() + @"/XORNeuron.json";
        }
    }
}
