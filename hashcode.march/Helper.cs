using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hashcode.march
{
    class Helper
    {
        public static void InitResult(string entryFile)
        {
            if (File.Exists(entryFile + ".out"))
                File.Delete(entryFile + ".out");
        }

        public static void ConsoleLog(string inMsg, string outputFile)
        {
            //Console.WriteLine(inMsg);
            File.AppendAllText(outputFile, inMsg + Environment.NewLine);
        }
    }
}
