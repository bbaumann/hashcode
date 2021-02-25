using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashcode._2021.Models
{
    public class StateFactory : IStateFactory<State>
    {
        /// <summary>
        /// Parse the problem input and returns a State modelizing it
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public State fromString(string s)
        {

            /*
             * an integer D (1 ≤ D ≤ 10 4
) - the duration of the simulation, in seconds,
○ an integer I (2 ≤ I ≤ 10 5
) - the number of intersections (with IDs from 0
to I -1 ),
○ an integer S (2 ≤ S ≤ 10 5
) - the number of streets,
○ an integer V (1 ≤ V ≤ 10 3
) - the number of cars,
○ an integer F (1 ≤ F ≤ 10 3
) - the bonus points for each car that reaches
its destination before time D .
● The next S lines contain descriptions of streets. Each line contains:
○ two integers B and E (0 ≤ B < I , 0 ≤ E < I ) - the intersections at the sta
and the end of the street, respectively,
○ the street name (a string consisting of between 3 and 30 lowercase
ASCII characters a -z and the character - ),
○ an integer L (1 ≤ L ≤ D ) - the time it takes a car to get from the
beginning to the end of that street.
● The next V lines describe the paths of each car. Each line contains:
○ an integer P (2 ≤ P ≤ 10 3
) - the number of streets that the car wants to
travel,
○ followed by P names of the streets: The car stas at the end of the
rst street (i.e. it waits for the green light to move to the next street)
and follows the path until the end of the last street. The path of a car is
always valid, i.e. the streets will be connected by intersections.

             * */

            int i = 0;

            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[i].Split(' ');
            //Parse the first line here here

            var simulationDuration = int.Parse(inputs[0]);
            var nbIntersections = int.Parse(inputs[1]); //ids from 0 to I-1
            var nbStreets = int.Parse(inputs[2]);
            var nbCars = int.Parse(inputs[3]);
            var bonusPoint = int.Parse(inputs[4]);

            state.BonusPoint = bonusPoint;
            state.SimulationDuration = simulationDuration;

            Dictionary<int, Intersection> intersections = new Dictionary<int, Intersection>();
            Dictionary<string, Street> streets = new Dictionary<string, Street>();

            for (i=1; i< nbStreets+1; i++)
            {
                inputs = lines[i].Split(' ');
                var sourceId = int.Parse(inputs[0]);
                Intersection source = null;

                if (!intersections.TryGetValue(sourceId, out source))
                {
                    source = new Intersection
                    {
                        Id = sourceId
                    };
                    intersections.Add(sourceId, source);
                }

                var destinationId = int.Parse(inputs[1]);
                Intersection destination = null;

                if (!intersections.TryGetValue(destinationId, out destination))
                {
                    destination = new Intersection
                    {
                        Id = destinationId
                    };
                    intersections.Add(destinationId, destination);
                }

                string name = inputs[2];
                int travelDuration = int.Parse(inputs[3]);

                Street street = new Street()
                {
                    Destination = destination,
                    Name = name,
                    Source = source,
                    TravelTime = travelDuration
                };

                state.AddStreet(street);
                streets.Add(name, street);

                source.AddOutgoingStreet(street);
                destination.AddIncomingStreet(street);
            }

            for (i = nbStreets + 1; i < nbStreets + 1 + nbCars + 1; i++)
            {
                inputs = lines[i].Split(' ');

                var nbStreetsForThisCar = int.Parse(inputs[0]);

                for (int j = 1; j < nbStreetsForThisCar; j++)
                {
                    Car car = new Car();
                    string streetName = inputs[j];
                    car.AddStep(streets[streetName]);
                    state.AddCar(car);
                }
            }

            return state;
        }
    }
}
