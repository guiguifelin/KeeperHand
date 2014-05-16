using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLP___Multiple_Outputs
{
    class Neuron
    {
        // Fields.

        private double bias; // Bias value.
        private double error; // Somme des erreurs.
        private double input; // Somme des entrées.
        private double gradient = 5; // Coefficient directeur de la courbe sigmoïde.
        private double learnRate = 0.01; // Coefficient d'apprentissage.
        private double output = double.MinValue; // Valeur prédéfinie d'un neurone.
        private List<Weight> weights; // Liste des poids.

        // Constructor.

        public Neuron() { }
        public Neuron(Layer inputs, Random rand)
        {
            weights = new List<Weight>();
            foreach(Neuron input in inputs)
            {
                Weight w = new Weight();
                w.Input = input;
                w.value = rand.NextDouble() * 2 - 1;
                weights.Add(w);
            }
        }

        // Get & Set.
        public double Output
        {
            get
            {
                if (output != double.MinValue)
                {
                    return output;
                }
                return 1 / (1 + Math.Exp(-gradient * (input + bias)));
            }
            set
            {
                output = value;
            }
        }

        // Methods.
        public void Activate()
        {
            error = 0;
            input = 0;
            foreach(Weight w in weights)
            {
                input += w.value * w.Input.Output;
            }
        }
        public void CollectError(double delta)
        {
            if (weights != null)
            {
                error += delta;
                foreach (Weight w in weights)
                {
                    w.Input.CollectError(error * w.value);
                }
            }
        }
        public void AdjustWeights()
        {
            for (int i = 0; i < weights.Count; i++)
            {
                weights[i].value += error * Derivative * learnRate * weights[i].Input.Output;
            }
            bias += error * Derivative * learnRate;
        }
        private double Derivative
        {
            get
            {
                double activation = Output;
                return activation * (1 - activation);
            }
        }
        public double[] HyperPlane
        {
            get
            {
                double[] line = new double[3];
                line[0] = weights[0].value;
                line[1] = weights[1].value;
                line[2] = bias;
                return line;
            }
        }
    }
}
