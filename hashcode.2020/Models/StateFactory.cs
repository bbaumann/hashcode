using hashcode.tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace hashcode._2020.Models
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
            State state = new State();
            string[] lines = s.Split('\n');
            string[] inputs = lines[0].Split(' ');
            //Parse the first line here here

            var bookCount = int.Parse(inputs[0]);
            var libCount = int.Parse(inputs[1]);
            state.NbDays = int.Parse(inputs[2]);

            // books score
            int lineIndex = 1;
            inputs = lines[lineIndex].Split(' ');

            for (var i_in = 0; i_in < bookCount; ++i_in)
            {
                state.ScoreByBookId.Add(i_in, int.Parse(inputs[i_in]));
            }
            ++lineIndex;

            var libIndex = 0;
            var isLibDef = true;
            for (; lineIndex < lines.Length && libIndex < libCount; lineIndex++)
            {
                inputs = lines[lineIndex].Split(' ');

                if (isLibDef)
                {
                    state.Libraries[libIndex] = new Library
                    {
                        Freq = int.Parse(inputs[2]),
                        NbDaysToSignup = int.Parse(inputs[1])
                    };
                } else {
                    state.Libraries[libIndex].Books = new List<Book>();
                    for (var i_in = 0; i_in < inputs.Length; ++i_in)
                    {
                        var id = int.Parse(inputs[i_in]);
                        state.Libraries[libIndex].Books.Add(new Book {
                            Id = id,
                            Score = state.ScoreByBookId[id]
                        });
                    }
                    ++libIndex;
                }

                isLibDef = !isLibDef;
            }

            return state;
        }
    }
}
