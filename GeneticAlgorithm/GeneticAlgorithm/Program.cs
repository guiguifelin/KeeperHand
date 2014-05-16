using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Genetic Algorithm";
            // Définir une solution idéale.
            FitnessCalc.setSolution("1111000000000000000000000000000000000000000000000000000000001111");

            do
            {
                /* Modifiable : */
                Console.Write("Taille de la population : ");
                int populationSize = (int)Convert.ToInt64(Console.ReadLine());

                // Créer une population initiale.
                Population population = new Population(populationSize, true);

                // Evolution de la population jusqu'à la solution optimale.
                int generationCount = 0;
                while (population.getFittest().getFitness() < FitnessCalc.getMaxFitness())
                {
                    generationCount++;
                    Console.WriteLine("Generation: {0} Fittest: {1}", generationCount, population.getFittest().getFitness());
                    population = Algorithm.evolvePopulation(population);
                }

                Console.WriteLine("Solution found !");
                Console.WriteLine("Generation : {0}", generationCount);
                Console.WriteLine("Genes : {0}", population.getFittest());
            } while (Console.ReadLine() != "exit");
        }
    }
}
