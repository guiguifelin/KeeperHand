using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    class Individual
    {
        // Fields.

        /* Attention class particulière */
        static int defaultGeneLenght = 64;
        private Byte[] genes = new Byte[defaultGeneLenght];
        private int fitness = 0;
        private Random rand = new Random();

        // Constructor.

        /* Il n'y a pas de constructeur, c'est géré par "generateIndividual" */

        // Get & Set.

        /* Ceci est un getter/setter particulier */
        public static void setDefaultLenght(int lenght)
        {
            defaultGeneLenght = lenght;
        }

        // Methods.

        /* Génération d'un individu */
        public void generateIndividual()
        {
            for (int i = 0; i < size(); i++)
            {
                Byte gene = (Byte)Math.Round(rand.NextDouble());
                genes[i] = gene;
            }
        }
        public int size()
        {
            return genes.Length;
        }
        public Byte getGene(int index)
        {
            return genes[index];
        }
        public void setGene(int index, Byte value)
        {
            genes[index] = value;
            fitness = 0;
        }
        public int getFitness()
        {
            if (fitness == 0)
            {
                fitness = FitnessCalc.getFitness(this);
            }
            return fitness;
        }
        override public string ToString() 
        {
            String geneString = "";
            for (int i = 0; i < size(); i++) 
            {
                geneString += getGene(i);
            }
            return geneString;
        }

    }
}
