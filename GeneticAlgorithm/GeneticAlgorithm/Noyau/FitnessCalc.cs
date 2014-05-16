using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    class FitnessCalc
    {
        /* Classe particulière encore sans constructeur */
        // Fields.
        private static Byte[] solution = new Byte[64];

        // Methods.
        /* Déifnir une solution possible comme un tableau de bits */
        public static void setSolution(Byte[] newSolution)
        {
            solution = newSolution;
        }
        public static void setSolution(string newSolution)
        {
            solution = new Byte[newSolution.Length];
            for (int i = 0; i < newSolution.Length; i++)
            {
                string character = newSolution.Substring(i, 1);
                if (character.Contains('0') || character.Contains('1'))
                {
                    solution[i] = Byte.Parse(character);
                }
                else
                {
                    solution[i] = 0;
                }
            }
        }
        public static int getFitness(Individual individual)
        {
            int fitness = 0;
            for (int i = 0; i < individual.size() && i < solution.Length; i++)
            {
                if (individual.getGene(i) == solution[i])
                {
                    fitness++;
                }
            }

            return fitness;
        }
        public static int getMaxFitness()
        {
            return solution.Length;
        }
    }
}
