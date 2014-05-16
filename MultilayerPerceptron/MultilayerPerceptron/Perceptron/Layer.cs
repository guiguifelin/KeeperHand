using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultilayerPerceptron
{
    class Layer : List<Neuron>
    {
        // Fields.

        // Constructor.
        public Layer(int size) 
        {
            for (int i = 0; i < size; i++)
            {
                base.Add(new Neuron());
            }
        }

        public Layer(int size, Layer layer, Random rnd)
        {
            for (int i = 0; i < size; i++)
            {
                base.Add(new Neuron(layer, rnd));
            }
        }

        // Get & Set.
        // Methods.
    }
}
