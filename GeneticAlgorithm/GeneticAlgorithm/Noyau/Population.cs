using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    class Population
    {
        // Fields.

        Individual[] individuals;

        // Constructor.

        public Population(int populationSize, bool initialise)
        {
            individuals = new Individual[populationSize];
            // Initialisation de la population.
            if (initialise)
            {
                for (int i = 0; i < size(); i++)
                {
                    Individual newIndividual = new Individual();
                    newIndividual.generateIndividual();
                    saveIndividual(i, newIndividual);
                }
            }
        }

        // Get & Set.
        public int size()
        {
            return individuals.Length;
        }
        public Individual getIndividual(int index)
        {
            return individuals[index];
        }
        public Individual getFittest()
        {
            Individual fittest = individuals[0];
            // Loop through individuals to find fittest
            for (int i = 0; i < size(); i++)
            {
                if (fittest.getFitness() <= getIndividual(i).getFitness())
                {
                    fittest = getIndividual(i);
                }
            }
            return fittest;
        }

        // Methods.
        public void saveIndividual(int index, Individual newIndividual)
        {
            individuals[index] = newIndividual;
        }
    }
}
