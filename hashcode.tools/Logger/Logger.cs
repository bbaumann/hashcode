using System;

namespace hashcode.tools
{
    public static class Logger
    {
        public static void Log(string s)
        {
            Console.WriteLine(s);   
        }

        public static void Log(Exception e)
        {
            Console.WriteLine("ERROR: "+e.Message);
            Console.WriteLine(e.StackTrace);
        }

    }
}
