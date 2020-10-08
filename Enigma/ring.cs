using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
     public class Ring
    {
        const int AlphabetLength= 26;
        int[] shiftValue = new int[AlphabetLength];
        char[] currentLetterOrder = new char[AlphabetLength];
        Dictionary<char, char> scramble = new Dictionary<char, char>();
        Dictionary<char, char> unScramble = new Dictionary<char, char>();


        public Ring()
        {
            SetRingDefault();
            calculateOutputs();
        }

        public Ring(char key,string shiftString)
        {
            SetRing(shiftString);

            setRingSetting(key);
            calculateOutputs();
        }

        public void setRingSetting(char key)
        {
            if (key >= 'A' && key <= 'Z')
            {
                int total = 0;
                while (key + total <= 'Z' && total<26)
                {
                    currentLetterOrder[total] = (char)(key + total);
                    total++;
                }
                int i = 0;
                while (total < 26)
                {
                    currentLetterOrder[total] = (char)('A' + i);
                    total++;
                    i++;
                }
            }
       
            calculateOutputs();

        }

        public string SetRing(string set)
        {

           string[] shiftValueString= set.Split(',');

            if (shiftValueString.Length != AlphabetLength)
            {
                SetRingDefault();
                return "Not enough inputs";
            }

            bool[] used =new bool[AlphabetLength];      

            for(int i=0;i< shiftValueString.Length; i++)
            {
                if(Int32.TryParse(shiftValueString[i], out int numval))
                {
                    this.shiftValue[i] = numval;
                }
                else
                {
                    SetRingDefault();
                    return "could not parse " + shiftValueString[i];
                }

            }

          for(int i=0; i > this.shiftValue.Length; i++)
            {
                if (used[i + this.shiftValue[i]])
                {
                    SetRingDefault();
                    return "dublicate wiring";
                }
                else
                {
                    used[i + this.shiftValue[i]] = true;
                }
            }
            return "success";
        }
        private void SetRingDefault()
        {
            setDefaultShift();
            setDefaultLetterOrder();
        }

        private void setDefaultShift() {
            for (int i = 0; i < AlphabetLength; i++)
            {
                shiftValue[i] = 0;
            }
        }

        private void setDefaultLetterOrder()
        {
            for(int i=0; i < AlphabetLength; i++)
            {
                currentLetterOrder[i] = (char)('A' + i);
            }
            calculateOutputs();

        }

        public void rotate()
        {
            char temp = currentLetterOrder[0];
            for (int i = 0; i < currentLetterOrder.Length-1; i++)
            {
                currentLetterOrder[i] = currentLetterOrder[i + 1];
            }
            currentLetterOrder[currentLetterOrder.Length-1] = temp;
            calculateOutputs();
        }

        private void calculateOutputs()
        {
            for(int i=0; i < currentLetterOrder.Length; i++)
            {
                char currentLetter = currentLetterOrder[i];
                char scrambledLetter = (char)(currentLetterOrder[i] + shiftValue[i]);

                if (scrambledLetter > 'Z')
                {
                    int newShift = (scrambledLetter - 'Z');
                    scrambledLetter = (char)('A' + newShift-1);
                }
                else if (scrambledLetter < 'A')
                {
                    int newShift =  'A'-scrambledLetter;
                    scrambledLetter = (char)('Z' - newShift+1);
                }
              

                this.scramble[currentLetter] = scrambledLetter;
                this.unScramble[scrambledLetter] = currentLetter;

            }
        }

        public void displayAll()
        {
                Console.WriteLine(shiftValue);
            
        }

        public int[] getRingShift
        {
            get { return this.shiftValue; }
        }

        public char scrambleLetter(char letter)
        {
           if(letter<'A' ||letter>'Z')
            {
                return letter;
            }
           
            return scramble[letter];
        }
        public char unScrambleLetter(char letter)
        {
            if (letter < 'A' || letter > 'Z')
            {
                return letter;
            }

            return unScramble[letter];

        }
    }
}
