using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SimpleLearning
{
    public class LearningSet
    {
        public int[] Input;
        public int[] Output;

        public static void Save(LearningSet[] learningSet, string path)
        {
            string data = JsonConvert.SerializeObject(learningSet);
            File.WriteAllText(path, data);
        }
    }
}
