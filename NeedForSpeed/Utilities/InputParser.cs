using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.Utilities
{
    public class InputParser
    {
        public List<string> parseInput(string inputLine)
        {
            return new List<String>(inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
