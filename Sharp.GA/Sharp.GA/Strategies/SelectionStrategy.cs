using System;
using System.Collections.Generic;

namespace Sharp.GA
{
    public abstract class SelectionStrategy<TGenotype>
    {
        public abstract IList<TGenotype> Select(IList<TGenotype> oldGeneration, Func<TGenotype, double> fitnessFunction);
    }
}