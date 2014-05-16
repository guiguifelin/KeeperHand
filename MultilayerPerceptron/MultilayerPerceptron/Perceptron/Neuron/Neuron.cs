using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultilayerPerceptron
{
    class Neuron
    {
        // Fields.

        private double _bias; // Truc pour la formule magique !
        private double _error; // Variable contenant la somme des erreurs.
        private double _input; // Variable contentnant la somme des inputs.
        private double _lambda = 6; // Coefficient de la sigmoïd.
        private double _learnRate = 0.5; // Coefficient d'apprentissage.
        private double _output = double.MinValue; // Valeur prédéfinie d'un neuron.
        private List<Weight> _weights; // Liste des poids synaptiques.

        // Constructor.

        public Neuron() { }
        public Neuron(Layer inputs, Random rand)
        {
            _weights = new List<Weight>();
            foreach (Neuron input in inputs)
            {
                Weight w = new Weight();
                w.Input = input;
                w.value = rand.NextDouble() * 2 - 1;
                _weights.Add(w);
            }
        }

        // Get & Set.

        public double Output
        {
            get
            {
                if (_output != double.MinValue)
                {
                    return _output;
                }
                return 1 / (1 + Math.Exp(-_lambda * (_input + _bias)));
            }
            set
            {
                _output = value;
            }
        }
        private double Derivative
        {
            get
            {
                double activation = Output;
                return activation * (1 - activation);
            }
        }

        // Methods.

        public void Activate()
        {
            _input = 0;
            foreach (Weight w in _weights)
            {
                _input += w.value * w.Input.Output;
            }
        }
        public double ErrorFeedBack(Neuron input)
        {
            Weight w = _weights.Find(delegate(Weight t) { return t.Input == input; });
            return _error * Derivative * w.value;
        }
        public void AdjustWeights(double value)
        {
            _error = value;
            for (int i = 0; i < _weights.Count; i++)
            {
                _weights[i].value += _error * Derivative * _learnRate * _weights[i].Input.Output;
            }
            _bias += _error * Derivative * _learnRate;
        }
    }
}
