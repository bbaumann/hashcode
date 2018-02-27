using System;

namespace hashcode.tools
{
    public interface ISolutionGeneratorFactory<State, S> where S : ISolution<State>
    {
	    ISolutionGenerator<State, S> newInstance();
    }
}
