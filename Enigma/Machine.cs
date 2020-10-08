using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Machine
    {
        Rotors rotor = new Rotors();
        PlugBoard plugBoard = new PlugBoard();
        
        public Machine()
        {
           
        }

        public Machine(string plugSwaps,string rotorShifts)
        {
            plugBoard.setPlugs(plugSwaps);
            rotor.setRotorSetting(rotorShifts);
        }
    
        public void resetMachine()
        {
            rotor = new Rotors();
            plugBoard = new PlugBoard();
        }

        public char encryptLetter(char letter)
        {
            char newLetter = plugBoard.swapLetter(letter);

            newLetter = rotor.scrambleLetter(newLetter);

            plugBoard.swapLetter(newLetter);

            return newLetter;
        }

        public string encryptMessage(string message)
        {
            message = message.ToUpper();

            string output = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] < 'A' || message[i] > 'Z')
                {
                    output = output + message[i];
                }
                else
                {
                    output = output + encryptLetter(message[i]);
                }
            }

            return output;
        }
    }

}
