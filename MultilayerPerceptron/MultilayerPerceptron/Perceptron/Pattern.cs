using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultilayerPerceptron
{
    class Pattern
    {
        // Fields.
        private double[] _inputs;
        private double _output;

        // Constructor.
        public Pattern(string value, int inputSize)
        {
            string[] line = value.Split('/');
            if (line.Length - 1 != inputSize)
            {
                throw new Exception("Input does not match network configuration");
            }

            _inputs = new double[inputSize];

            for (int i = 0; i < inputSize; i++)
            {
                _inputs[i] = double.Parse(line[i]);
            }
            _output = double.Parse(line[inputSize]);
        }

        // Get & Set.

        public double[] Inputs
        {
            get { return _inputs; }
        }
        public double Output
        {
            get { return _output; }
        }

        // Methods.
    }
}
