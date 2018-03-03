using System;

namespace hashcode.tools
{
    public interface ISolverFactory<State, S> where S : ISolution<State>
    {
	    ISolver<State, S> newInstance();
    }
}
