using System;
using System.Collections.Generic;

namespace hashcode.tools
{
    public interface ISolverFactory<State, S> where S : ISolution<State>
    {
	    ISolver<State, S> newInstance();

        List<ISolver<State, S>> GetAllBaseSolvers();

        List<ISolver<State, S>> GetAllSolversWithFallback();
    }
}
