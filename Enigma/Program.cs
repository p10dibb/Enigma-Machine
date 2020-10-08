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

            //Machine m = new Machine("RS TU VW YZ LX MK JI HG EF QP CD ON AB", "ADS");

            //Console.WriteLine(m.encryptMessage("Hello"));
            //Console.WriteLine(m.decryptMessage("GBWXN"));



            Tester t = new Tester();
            t.testMachine();
            //t.testPlugBoard();
            //t.testRotors();
            //t.testRing();



            while (true) ;
        }

     
    }
}
