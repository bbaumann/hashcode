using System;

namespace hashcode.tools
{
    public interface ISolutionGenerator<State, S>  where S : ISolution<State>
    {
	    S Next(State state);
    }
}
