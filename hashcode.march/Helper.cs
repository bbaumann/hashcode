﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hashcode.march
{
    class Helper
    {
        public static void ConsoleLog(string inMsg)
        {
            //Console.WriteLine(inMsg);
            File.AppendAllText(@"result.txt", inMsg + Environment.NewLine);
        }
    }
}
