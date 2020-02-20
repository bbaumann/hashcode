using System;
using System.IO;

namespace hashcode.tools
{
    public static class FileHelper
    {
        public static string ReadFileContent(string fileName)
        {
            string res = null;
            try
            {
                res = File.ReadAllText(Path.GetFileName(fileName));
            }
            catch (IOException e)
            {
                Logger.Log(e);
            }
            return res;
        }

        public static void WriteFileContent(string fileName, string content, bool append)
        {
            try
            {
                if (append)
                {
                    File.AppendAllText(Path.GetFileName(fileName),content);
                }
                else
                {
                    File.WriteAllText(Path.GetFileName(fileName),content);
                }
            }
            catch (IOException e)
            {
                Logger.Log(e);
            }
        }
    }
}
