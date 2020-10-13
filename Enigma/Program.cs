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
            StringGenerator s = new StringGenerator();

            Console.WriteLine(s.CalculateRingShift("YRUHQSLDPXNGOKMIEBFZCWVJAT"));
            


            Tester t = new Tester();
            t.testMachine();
            //t.testPlugBoard();
            //t.testRotors();
            //t.testRing();



            while (true) ;
        }

     
    }
}
