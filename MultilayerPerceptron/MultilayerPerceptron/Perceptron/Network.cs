using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MultilayerPerceptron
{
    class Network
    {
        // Fields.

        private int _hiddenDims; // Nombre de neurones intra input/ouput.
        private int _inputDims; // Nombres de neurones en input.
        private int _iteration; // Nombres d'itération durant l'entrainement.
        private int _restartAfter = 2000; // Limite d'arrêt d'itérations possibles.
        private Layer _hidden; // Liste de neurones cachés.
        private Layer _inputs; // Liste de neurones en entrée.
        private List<Pattern> _patterns; // Liste de patterns.
        private Neuron _output; // Neurone de sortie.
        private Random _rand = new Random(); // Générateur de nombre aléatoire.

        // Constructor.

        public Network()
        {
            NetworkConf();
            LoadPatterns();
            Initialise();
            Train();
            Test();
        }

        // Get & Set.

        // Methods.

        private void NetworkConf()
        {
            Console.Write("Enter the number of hidden dimensions : ");
            _hiddenDims = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the number of input neurons : ");
            _inputDims = Convert.ToInt32(Console.ReadLine());
        }

        private void Train()
        {
            double error;
            do
            {
                error = 0;
                foreach (Pattern pattern in _patterns)
                {
                    double delta = pattern.Output - Activate(pattern);
                    AdjustWeights(delta);
                    error += Math.Pow(delta, 2);
                }
                Console.WriteLine("Iteration {0}\tError {1:0.000}", _iteration, error);
                _iteration++;
                if (_iteration > _restartAfter) Initialise();
            } while (error > 0.1);
        }

        private void Test()
        {
            Console.WriteLine("\nBegin network testing\nPress Ctrl C to exit\n");
            while (1 == 1)
            {
                try
                {
                    Console.Write("Input x, y: ");
                    string values = Console.ReadLine() + "/0";
                    Console.WriteLine("{0:0}\n", Activate(new Pattern(values, _inputDims)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private double Activate(Pattern pattern)
        {
            for (int i = 0; i < pattern.Inputs.Length; i++)
            {
                _inputs[i].Output = pattern.Inputs[i];
            }
            foreach (Neuron neuron in _hidden)
            {
                neuron.Activate();
            }
            _output.Activate();
            return _output.Output;
        }

        private void AdjustWeights(double delta)
        {
            _output.AdjustWeights(delta);
            foreach (Neuron neuron in _hidden)
            {
                neuron.AdjustWeights(_output.ErrorFeedBack(neuron));
            }
        }

        private void Initialise()
        {
            _inputs = new Layer(_inputDims);
            _hidden = new Layer(_hiddenDims, _inputs, _rand);
            _output = new Neuron(_hidden, _rand);
            _iteration = 0;
            Console.WriteLine("Network Initialised");
        }

        private void LoadPatterns()
        {
            _patterns = new List<Pattern>();
            Console.Write("Give me the name of the patterns file : ");
            string fileName = Console.ReadLine();
            StreamReader file = File.OpenText(Environment.CurrentDirectory + "\\" + fileName);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                _patterns.Add(new Pattern(line, _inputDims));
            }
            file.Close();
        }
    }
}
