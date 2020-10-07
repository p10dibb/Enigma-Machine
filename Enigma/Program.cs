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

            //Machine m = new Machine();


            //Console.WriteLine(m.Generate_PlugBoard());
            //Console.WriteLine( m.encrypt("hello World"));

            //"RS TU VW YZ LX MK JI HG EF QP CD ON AB"
          PlugBoard p = new PlugBoard("RS TU VW YZ LX MK JI HG EF QP CD ON AB");

            Console.WriteLine(p.swapLetter('J'));
            while (true) ;

           


        }
    }
}
