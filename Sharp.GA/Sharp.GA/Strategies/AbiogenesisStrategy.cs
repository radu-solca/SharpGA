using System.Collections.Generic;

namespace Sharp.GA
{
    public abstract class AbiogenesisStrategy<TGenotype>
    {
        public abstract IList<TGenotype> CreateGeneration();
    }
}