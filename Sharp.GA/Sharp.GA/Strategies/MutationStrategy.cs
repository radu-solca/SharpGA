using System.Collections.Generic;

namespace Sharp.GA
{
    public abstract class MutationStrategy<TGenotype>
    {
        public abstract TGenotype Mutate(TGenotype victim);

        public IList<TGenotype> Mutate(IList<TGenotype> candidates, double mutationRate)
        {
            var numberOfChildren = mutationRate * candidates.Count;

            var children = new List<TGenotype>();

            for (int i = 0; i < numberOfChildren; i++)
            {
                var parent = candidates.PickRandom();

                children.Add(Mutate(parent));
            }

            return children;
        }
    }
}