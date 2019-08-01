using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {

            Machine m = new Machine();


             Console.WriteLine(m.Generate_PlugBoard());
             Console.WriteLine( m.encrypt("hello World"));
           





        }
    }
}
