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

                   // ROTOR I 	
               Console.WriteLine(s.CalculateRingShift("EKMFLGDQVZNTOWYHXUSPAIBRCJ"));
                //ROTOR II 	
               Console.WriteLine(s.CalculateRingShift("AJDKSIRUXBLHWTMCQGZNPYFVOE"));
                //Rotor III 
              Console.WriteLine(s.CalculateRingShift("BDFHJLCPRTXVZNYEIWGAKMUSQO"));
                //Rotor IV 	
                Console.WriteLine(s.CalculateRingShift("ESOVPZJAYQUIRHXLNFTGKDCMWB")); 
                //Rotor V
            Console.WriteLine(s.CalculateRingShift("VZBRGITYUPSDNHLXAWMJQOFECK"));


            //Tester t = new Tester();
            //t.testMachine();
            //t.testPlugBoard();
            //t.testRotors();
            //t.testRing();



            while (true) ;
        }

     
    }
}
