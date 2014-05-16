using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    class Algorithm
    {
        // Fields.

        /* GA Parameters */
        private const double uniformRate = 0.5;
        private const double mutationRate = 0.015;
        private const int tournamentSize = 5;
        private static bool elitism = true;

        // Constructor.

        // Get & Set.

        // Methods.

        public static Population evolvePopulation(Population oldPopulation)
        {
            Population newPopulation = new Population(oldPopulation.size(), false);
            int elitismOffset;

            if (elitism) // Crossover population
            {
                newPopulation.saveIndividual(0, oldPopulation.getFittest());
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }

            for (int i = elitismOffset; i < oldPopulation.size(); i++)
            {
                Individual indiv1 = TournamentSelection(oldPopulation);
                Individual indiv2 = TournamentSelection(oldPopulation);
                Individual newIndiv = Crossover(indiv1, indiv2);
                newPopulation.saveIndividual(i, newIndiv);
            }

            // Mutate population
            for (int i = elitismOffset; i < newPopulation.size(); i++)
            {
                Mutate(newPopulation.getIndividual(i));
            }

            return newPopulation;
        }

        // Select individuals for crossover
        private static Individual TournamentSelection(Population pop)
        {
            // Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            Random rand = new Random();
            // For each place in the tournament get a random individual
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(rand.NextDouble() * pop.size());
                tournament.saveIndividual(i, pop.getIndividual(randomId));
            }
            // Get the fittest
            Individual fittest = tournament.getFittest();
            return fittest;
        }
        // Crossover individuals
        private static Individual Crossover(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual();
            Random rand = new Random();
            // Loop through genes
            for (int i = 0; i < indiv1.size(); i++)
            {
                // Crossover
                if (rand.NextDouble() <= uniformRate)
                {
                    newSol.setGene(i, indiv1.getGene(i));
                }
                else
                {
                    newSol.setGene(i, indiv2.getGene(i));
                }
            }
            return newSol;
        }
        // Mutate an individual
        private static void Mutate(Individual indiv)
        {
            Random rand = new Random();
            // Loop through genes
            for (int i = 0; i < indiv.size(); i++)
            {
                if (rand.NextDouble() <= mutationRate)
                {
                    // Create random gene
                    Byte gene = (Byte)Math.Round(rand.NextDouble());
                    indiv.setGene(i, gene);
                }
            }
        }
    }
}
