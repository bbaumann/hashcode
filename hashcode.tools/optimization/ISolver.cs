using System;

namespace hashcode.tools
{
    public interface ISolver<State, S>  where S : ISolution<State>
    {
	    S Solve(State state);
    }
}
