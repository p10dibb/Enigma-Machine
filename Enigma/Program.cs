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
            m.SetPlugs("Ab CD");
           string x= m.CharSwap_Plugs("the cat");

            Console.WriteLine(x);

        }
    }
}
