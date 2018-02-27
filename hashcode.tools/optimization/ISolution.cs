using System;

namespace hashcode.tools
{
    public interface ISolution<State>
    {
        double Value(State s);
        
        String ToOutputFormat();
    }
}
