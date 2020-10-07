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

            string RingSettingSting = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-5,-3";
            string testString1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string testString2 = "AAAAA";
            Ring r = new Ring();

            Console.WriteLine(r.SetRing(RingSettingSting));
            for (int i = 0; i <testString1.Length; i++)
            {           
                Console.WriteLine(r.scrambleLetter(testString1[i]));

            }
            Console.WriteLine("------------------");
            for (int i = 0; i < testString2.Length; i++)
            {
                Console.WriteLine(r.scrambleLetter(testString2[i]));
                r.rotate();
            }

            while (true) ;

           


        }
    }
}
