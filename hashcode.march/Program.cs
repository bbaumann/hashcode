using System.Collections.Generic;
using System;
using hashcode.march.Models;

namespace hashcode.march
{
    class Program
    {
        public static void ConsoleLog(string inMsg) {
            Console.WriteLine(inMsg);
        }

        static string[] contentLines = null;
        static int contentLineIndex = 0;
        static string ReadLine()
        {
            if (contentLines != null)
            {
                return contentLines[contentLineIndex++];
            } else
            {
                string lResult = Console.ReadLine();
                Console.Error.WriteLine(lResult);
                return lResult;
            }
        }

        static void Main(string[] args)
        {
            contentLines = System.IO.File.ReadAllLines(@"./entries.txt");

            string[] inputs = ReadLine().Split(' ');
            int index = 0;
            int rowCount = int.Parse(inputs[index++]);
            int colCount = int.Parse(inputs[index++]);
            int fleetCount = int.Parse(inputs[index++]);
            int ridesCount = int.Parse(inputs[index++]);
            int bonusCount = int.Parse(inputs[index++]);
            int stepCount = int.Parse(inputs[index++]);

            List<Ride> rides = new List<Ride>();
            for (int rideIndex = 0; rideIndex < ridesCount; ++rideIndex) {
                inputs = ReadLine().Split(' ');
                rides.Add(new Ride() { StartingPoint =new Coord(int.Parse(inputs[0]), int.Parse(inputs[2])),
                                       FinishPoint = new Coord(int.Parse(inputs[1]), int.Parse(inputs[3])),
                                       EarliestStart = int.Parse(inputs[4]),
                                       LatestFinish = int.Parse(inputs[5])});
            }


            ConsoleLog("Hello World!");
            string dummy = Console.ReadLine();

        }
    }
}
