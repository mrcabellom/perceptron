using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class InputItem
    {
        public double[] Inputs { get; private set; }
        public bool Output { get; private set; }
        public InputItem(bool expectedOutput, params double[] inputs)
        {
            Inputs = inputs;
            Output = expectedOutput;
        }
    }
}
