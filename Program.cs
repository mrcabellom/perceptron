using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            InputItem[] trainingSet =
            {
                new InputItem(true, 5.1, 3.5, 1.4, 0.2),
                new InputItem(true, 4.9, 3.0, 1.4, 0.2),
                new InputItem(true, 4.7, 3.2, 1.3, 0.2),
                new InputItem(false, 7.0, 3.2, 4.7, 1.4),
                new InputItem(false, 7.0, 3.2, 4.7, 1.4),
                new InputItem(false, 6.4, 3.2, 4.5, 1.5),
                new InputItem(false, 6.9, 3.1, 4.9, 1.5)
            };

            var perceptron = new BinaryPerceptron(4);

            while (true)
            {
                int errorCount = 0;
                foreach (var item in trainingSet)
                {
                    var output = perceptron.Learn(item.Output, item.Inputs);
                    if (output != item.Output)
                    {
                        errorCount++;
                    }
                }

                if (errorCount == 0)
                {
                    break;
                }
            }
            Console.WriteLine(perceptron.GetResult(5.4, 3.9, 1.7, 0.4));
            Console.WriteLine(perceptron.GetResult(6.1, 2.9, 4.7, 1.4));
            Console.ReadLine();
        }
    }
}