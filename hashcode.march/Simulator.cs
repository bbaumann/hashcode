using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode.march
{
    class Simulator
    {
        // return the score
        public int Simulate(State state, Generator generator)
        {
            Models.Car[] cars = new Models.Car[state.fleetCount];
            for (int carIndex = 0; carIndex < state.fleetCount; ++carIndex)
            {
                cars[carIndex] = new Models.Car();
            }

            for (int step = 0; step < state.stepCount; ++step)
            {
                generator.CalcOrders(step, state, cars);
            }

            for (int carIndex = 0; carIndex < state.fleetCount; ++carIndex)
            {
                Helper.ConsoleLog(cars[carIndex].DumpRides());
            }

            return 0;
        }
    }
}
