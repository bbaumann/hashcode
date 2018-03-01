﻿using System.Collections.Generic;
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
            //List<string> entries = new List<string>() { "./a_example.in", "./b_should_be_easy.in", "./c_no_hurry.in", "./d_metropolis.in", "./e_high_bonus.in" };
            List<string> entries = new List<string>() { "./e_high_bonus.in" };
            foreach (var entry in entries)
            {
                contentLines = System.IO.File.ReadAllLines(entry);

                Helper.InitResult(entry);
                State state = new State();

                string[] inputs = ReadLine().Split(' ');
                int index = 0;
                state.rowCount = int.Parse(inputs[index++]);
                state.colCount = int.Parse(inputs[index++]);
                state.fleetCount = int.Parse(inputs[index++]);
                state.ridesCount = int.Parse(inputs[index++]);
                state.bonusCount = int.Parse(inputs[index++]);
                Settings.BonusPointForStartingOnTime = state.bonusCount;
                state.stepCount = int.Parse(inputs[index++]);
                Settings.MaxStep = state.stepCount - 1;

                List<Ride> rides = new List<Ride>();
                for (int rideIndex = 0; rideIndex < state.ridesCount; ++rideIndex)
                {
                    inputs = ReadLine().Split(' ');
                    state.rides.Add(new Ride()
                    {
                        StartingPoint = new Coord(int.Parse(inputs[0]), int.Parse(inputs[1])),
                        FinishPoint = new Coord(int.Parse(inputs[2]), int.Parse(inputs[3])),
                        EarliestStart = int.Parse(inputs[4]),
                        LatestFinish = int.Parse(inputs[5]),
                        Id = rideIndex
                    });
                }

                IGenerator gen = new StartOnTimeGenerator();
                Simulator sim = new Simulator();
                sim.Simulate(state, gen, entry+".out");
                Console.WriteLine(entry);
            }

            string dummy = Console.ReadLine();

        }
    }
}
