using System;
using System.Collections.Generic;
using System.Text;
using hashcode.march.Models;

namespace hashcode.march
{
    class Simulator
    {
        // return the score
        public int Simulate(State state, IGenerator generator, string outputFile)
        {
            List<Car> cars = new List<Car>(state.fleetCount);
            for (int carIndex = 0; carIndex < state.fleetCount; ++carIndex)
            {
                cars.Add(new Car());
            }

            for (int step = 0; step < state.stepCount; ++step)
            {
                //generator.CalcOrders(step, state, cars);
                generator.CalcOrders(state, cars);
            }
            foreach (var car in cars)
            {
                Helper.ConsoleLog(car.DumpRides(), outputFile);
            }

            return 0;
        }
    }
}
