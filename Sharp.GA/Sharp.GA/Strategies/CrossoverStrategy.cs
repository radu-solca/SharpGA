using System.Collections.Generic;

namespace Sharp.GA
{
    public abstract class CrossoverStrategy<TGenotype>
    {
        public abstract TGenotype Crossover(TGenotype firstParent, TGenotype secondParent);

        public IList<TGenotype> Crossover(IList<TGenotype> candidates, double crossoverRate)
        {
            var numberOfChildren = crossoverRate * candidates.Count * 2;

            var children = new List<TGenotype>();

            for (int i = 0; i < numberOfChildren; i++)
            {
                var firstParent = candidates.PickRandom();
                var secondParent = candidates.PickRandom();

                children.Add(Crossover(firstParent, secondParent));
            }

            return children;
        }
    }
}