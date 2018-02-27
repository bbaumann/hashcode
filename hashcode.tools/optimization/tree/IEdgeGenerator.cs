using System;
using System.Collections.Generic;

namespace hashcode.tools
{
    public interface IEdgeGenerator<E,N> where E :IEdge<N> where N : INode
    {
	    List<E> Generate(N node);
    }
}
