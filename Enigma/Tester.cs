using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Tester
    {

        public void testMachine()
        {
            //"RS TU VW YZ LX MK JI HG EF QP CD ON AB"
            Machine m = new Machine("", "AAA");

            Console.WriteLine(m.encryptMessage("HELLO"));
            m = new Machine("", "AAA");

            Console.WriteLine(m.encryptMessage("MFNCZ"));

            //Console.WriteLine(m.encryptMessage("V"));

        }

        public void testPlugBoard()
        {
            PlugBoard p = new PlugBoard();

            p.setPlugs("RS TU VW YZ LX MK JI HG EF QP CD ON AB");

            Console.WriteLine(p.swapLetter('R'));
            Console.WriteLine(p.swapLetter('S'));

        }

        public void testRotors()
        {
            Rotors r1 = new Rotors();
            Rotors r2 = new Rotors();

            Console.WriteLine("-------Rotor Test-----");
            for (int i = 0; i < 26; i++)
            {
                char startLetter = (char)('A' + i);
                char scrambledLetter = r1.encryptLetter(startLetter);
                char unscrambleLetter = r2.decryptLetter(scrambledLetter);
                Console.WriteLine(startLetter + "->" + scrambledLetter + "->" + unscrambleLetter + ": " + (startLetter == unscrambleLetter).ToString());
           
            }

            Console.WriteLine("-------------------------");

        }

        public void testRing()
        {
            int inputAmt = 26;
            string[] results = new string[inputAmt];

          
            Console.WriteLine(testRoterEncrypt_Decrypt_Rotations('A',1));


        }

        private string testRoterEncrypt_Decrypt(char letter)
        {
            int ringAmt = 4;

            Ring[] r = new Ring[ringAmt];
            for (int i = 0; i < ringAmt; i++)
            {
                r[i] = new Ring('A', "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3");
            }


            char newLetter = letter;
            Console.WriteLine();
            Console.WriteLine("===== Encrypt " + newLetter + "=======");
            for (int i = 0; i < ringAmt - 1; i++)
            {

                newLetter = r[i].scrambleLetter(newLetter);
                Console.WriteLine("R" + i + "->" + newLetter);

            }

            newLetter = r[3].scrambleLetter(newLetter);
            Console.WriteLine("Reflector" + "->" + newLetter);


            for (int i = ringAmt - 2; i >= 0; i--)
            {
                newLetter = r[i].scrambleLetter(newLetter);
                Console.WriteLine("R" + i + "->" + newLetter);

            }
            Console.WriteLine("===== Decrypt " + newLetter + "=======");

            for (int i = ringAmt - 2; i >= 0; i--)
            {
                newLetter = r[i].unScrambleLetter(newLetter);
                Console.WriteLine("R" + i + "->" + newLetter);

            }


            newLetter = r[3].unScrambleLetter(newLetter);
            Console.WriteLine("Reflector" + "->" + newLetter);


            for (int i = 0; i < ringAmt - 1; i++)
            {
                newLetter = r[i].unScrambleLetter(newLetter);
                Console.WriteLine("R" + i + "->" + newLetter);

            }
            Console.WriteLine();
            return ("SUCCESS " + letter + "==" + newLetter + ": " + (letter == newLetter).ToString());
        }

        private string testRoterEncrypt_Decrypt_Rotations(char letter, int rotationAmt)
        {
            {
                int ringAmt = 4;

                Ring[] r = new Ring[ringAmt];
                for (int i = 0; i < ringAmt; i++)
                {
                    r[i] = new Ring('A', "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3");
                }

                for( int i=0; i < rotationAmt; i++)
                {
                    r[0].rotate();
                }


                char newLetter = letter;
                Console.WriteLine();
                Console.WriteLine("===== Encrypt " + newLetter + "=======");
                for (int i = 0; i < ringAmt - 1; i++)
                {

                    newLetter = r[i].scrambleLetter(newLetter);
                    Console.WriteLine("R" + i + "->" + newLetter);

                }

                newLetter = r[3].scrambleLetter(newLetter);
                Console.WriteLine("Reflector" + "->" + newLetter);


                for (int i = ringAmt - 2; i >= 0; i--)
                {
                    newLetter = r[i].scrambleLetter(newLetter);
                    Console.WriteLine("R" + i + "->" + newLetter);

                }
                Console.WriteLine("===== Decrypt " + newLetter + "=======");

              
                for (int i = 0; i < ringAmt - 1; i++)
                {
                    newLetter = r[i].unScrambleLetter(newLetter);
                    Console.WriteLine("R" + i + "->" + newLetter);

                }

                newLetter = r[3].unScrambleLetter(newLetter);
                Console.WriteLine("Reflector" + "->" + newLetter);

                for (int i = ringAmt - 2; i >= 0; i--)
                {
                    newLetter = r[i].unScrambleLetter(newLetter);
                    Console.WriteLine("R" + i + "->" + newLetter);

                }

                Console.WriteLine();
                return ("SUCCESS " + letter + "==" + newLetter + ": " + (letter == newLetter).ToString());
            }
        }
    }
}
