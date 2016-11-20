using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLearning
{
    interface INeuralNetwork
    {
        float Error { get; set; }
        int Output { get; set; }
        void Initialize();
        int Calculate();
        float CalculateAndLearn();
    }
}
