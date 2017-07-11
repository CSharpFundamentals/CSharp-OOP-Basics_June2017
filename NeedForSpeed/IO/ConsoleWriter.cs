using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.IO
{
    public class ConsoleWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void WriteLine(string[] elements)
        {
            foreach (var element in elements)
            {
                Console.WriteLine(string.Format(element));

            }
        }
    }
}
