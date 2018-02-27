using System;

namespace hashcode.tools
{
    public interface IEdge<N> where N: INode
    {
	    N Execute(N node);
    }
}
