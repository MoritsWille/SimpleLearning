using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLearning
{
    public class Weight
    {
        public double WeightValue;
        public double DeltaWeight;

        public void Update(double LearningRate)
        {
            WeightValue -= LearningRate * DeltaWeight; 
        }

    }
}
