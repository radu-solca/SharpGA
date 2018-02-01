using System;
using System.Collections.Generic;

namespace Sharp.GA
{
    public class GeneticAlgorithm<TGenotype>
    {
        private AbiogenesisStrategy<TGenotype> abiogenesisStrategy;
        private SelectionStrategy<TGenotype> selectionStrategy;
        private CrossoverStrategy<TGenotype> crossoverStrategy;
        private MutationStrategy<TGenotype> mutationStrategy;

        private Func<TGenotype, double> fitnessFunction;

        private IList<TGenotype> currentGeneration;

        public void Run()
        {
            // TODO: Defensive coding (check if strategies are null)

            currentGeneration = abiogenesisStrategy.CreateGeneration();

            // TODO: Implement stop conditions.
            while (true)
            {
                // TODO: Do not hardcode mutation/crossover rates.
                // TODO: Find a better way to apply crossover and mutations (currently they just replace the old generation, not modify it)
                currentGeneration = selectionStrategy.Select(currentGeneration, fitnessFunction);
                currentGeneration = crossoverStrategy.Crossover(currentGeneration, 0.7);
                currentGeneration = mutationStrategy.Mutate(currentGeneration, 0.3);
            }
        }

        public GeneticAlgorithm<TGenotype> SetAbiogenesisStrategy(AbiogenesisStrategy<TGenotype> newStrategy)
        {
            abiogenesisStrategy = newStrategy;
            return this;
        }

        public GeneticAlgorithm<TGenotype> SetSelectionStrategy(SelectionStrategy<TGenotype> newStrategy)
        {
            selectionStrategy = newStrategy;
            return this;
        }

        public GeneticAlgorithm<TGenotype> SetCrossoverStrategy(CrossoverStrategy<TGenotype> newStrategy)
        {
            crossoverStrategy = newStrategy;
            return this;
        }

        public GeneticAlgorithm<TGenotype> SetMutationStrategy(MutationStrategy<TGenotype> newStrategy)
        {
            mutationStrategy = newStrategy;
            return this;
        }

        public GeneticAlgorithm<TGenotype> SetFitnessFunction(Func<TGenotype, double> newFitness)
        {
            fitnessFunction = newFitness;
            return this;
        }

        // TODO: Create lifecycle hooks (e.g. BeforeSelection AfterSelection etc.)
    }
}