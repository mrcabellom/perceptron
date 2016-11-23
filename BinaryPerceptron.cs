using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class BinaryPerceptron
    {
        public double LearningRate { set; get; }

        public double[] Weights { set; get; }

        public double Threshold { set; get; }

        public BinaryPerceptron(int inputCount, double learningRate = 0.1, double threshold = 0.5)
        {
            Weights = new double[inputCount];
            LearningRate = learningRate;
            Threshold = threshold;
        }

        public bool GetResult(params double[] inputs)
        {
            if (inputs.Length != Weights.Length)
            {
                throw new ArgumentException("Invalid number of inputs. Expected: " + Weights.Length);
            }

            return DotProduct(inputs, Weights) > Threshold;
        }

        public bool Learn(bool expectedResult, params double[] inputs)
        {
            bool result = GetResult(inputs);

            if (result != expectedResult)
            {
                double error = (expectedResult ? 1 : 0) - (result ? 1 : 0);
                for (int i = 0; i < Weights.Length; i++)
                {
                    Weights[i] += LearningRate * error * inputs[i];
                }
            }

            return result;
        }

        private double DotProduct(double[] inputs, double[] weights)
        {
            return inputs.Zip(weights, (value, weight) => value * weight).Sum();
        }
    }
}
