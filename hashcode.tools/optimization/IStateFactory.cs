using System;

namespace hashcode.tools
{
    public interface IStateFactory<State>
    {
	    State fromString(string s);
    }
}
