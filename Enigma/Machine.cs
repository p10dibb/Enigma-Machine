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
        string rotorKey = "";
        public Machine()
        {
           
        }

        public Machine(string plugSwaps,string rotorShifts,string rotorSelection)
        {
            plugBoard.setPlugs(plugSwaps);
            rotor = new Rotors(rotorShifts, rotorSelection);
            rotorKey = rotorShifts;
        }

        public void setSettings(string plugSwaps, string rotorShifts, string rotorSelection)
        {
            plugBoard.setPlugs(plugSwaps);
            rotor.setRotorSettings(rotorShifts, rotorSelection);
            rotorKey = rotorShifts;
        }
        public void resetMachine()
        {
            resetRotors();
            resetPlugBoard();
        }

        public void resetRotors()
        {
            if (rotorKey == "")
            {
                resetDefaultRotor();
            }
            rotor.setRotorSetting(rotorKey);
        }

        public void resetDefaultRotor()
        {
            rotor = new Rotors();

        }

        public void resetPlugBoard()
        {
            plugBoard = new PlugBoard();
        }

        private char encryptLetter(char letter)
        {
            char newLetter = plugBoard.swapLetter(letter);

            newLetter = rotor.encryptLetter(newLetter);

            newLetter=plugBoard.swapLetter(newLetter);

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
            this.resetRotors();
            return output;
        }

        private char decryptLetter(char letter)
        {
            char newLetter = plugBoard.swapLetter(letter);

            newLetter = rotor.decryptLetter(newLetter);

            newLetter=plugBoard.swapLetter(newLetter);
            return newLetter;
        }

        public string decryptMessage(string message)
        {
            
            return this.encryptMessage(message);
        }

    }

}
