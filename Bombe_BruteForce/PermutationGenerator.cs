using Enigma;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bombe_BruteForce
{
    class PermutationGenerator
    {

        Machine machine = new Machine();
        string currentMessage = "";
        List<string> currentEncryptedKeys=new List<string>();
        Cracker cracker = new Cracker();
        Random rand = new Random();
        public void runner()
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";




            machine.setSettings("", "AAA", "123");
            for(int i = 0; i < 1000; i++)
            {
            currentMessage =""+(char)(Alphabet[rand.Next() % 26]) + (char)(Alphabet[rand.Next() % 26]) + (char)(Alphabet[rand.Next() % 26]);
                currentMessage = currentMessage + currentMessage;
                string x = machine.encryptMessage(currentMessage);
                currentEncryptedKeys.Add(x);
                Console.WriteLine(currentMessage + ": " + x + "\n");
            }

            Console.WriteLine(cracker.generateDictionaryKey(currentEncryptedKeys));

        }

        public void generateRottorSelectionOptions(string plugString, string shiftString)
        {
            bool[] used = new bool[5];

            for (int rotor1 = 1; rotor1 <= 5; rotor1++)
            {
                used[rotor1 - 1] = true;
                for (int rotor2 = 1; rotor2 <= 5; rotor2++)
                {
                    if (!used[rotor2 - 1])
                    {
                        used[rotor2 - 1] = true;
                        for (int rotor3 = 1; rotor3 <= 5; rotor3++)
                        {
                            if (!used[rotor3 - 1])
                            {
                                //machine = new Enigma.Machine(plugString, shiftString, "" + rotor1 + "" + rotor2 + "" + rotor3);
                                machine.setSettings(plugString, shiftString, "" + rotor1 + "" + rotor2 + "" + rotor3);
                              

                            }
                        }
                        used[rotor2 - 1] = false;

                    }

                }

                used[rotor1 - 1] = false;
            }

        }

        public void generateRottorShiftOptions(string plugString)
        {
            for (int rotor1 = 0; rotor1 < 26; rotor1++)
            {
                for (int rotor2 = 0; rotor2 < 26; rotor2++)
                {
                    for (int rotor3 = 0; rotor3 < 26; rotor3++)
                    {
                        this.generateRottorSelectionOptions(plugString, "" + (char)(rotor1 + 'A') + "" + (char)(rotor2 + 'A') + "" + (char)(rotor3 + 'A'));
                    }

                }

            }

        }

    }
}
