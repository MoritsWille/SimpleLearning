using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLearning
{
    interface INeuralNetwork
    {
        int Calculate(int[] inputs);
        double[] CalculateAndLearn();
    }
}
