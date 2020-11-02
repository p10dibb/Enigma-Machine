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
        char[] forwards = new  char[26];
        char[] backwards = new char[26];

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

       public int getForwardLetterIndex(char letter)
        {
         for(int i = 0; i < this.forwards.Length; i++) {

                if (forwards[i] == letter)
                {
                    return i;
                }
            }
            return -1;
        }

        public int setRingSetting(char key)
        {
            //if (key >= 'A' && key <= 'Z')
            //{
            //    int total = 0;
            //    while (key + total <= 'Z' && total<26)
            //    {
            //        currentLetterOrder[total] = (char)(key + total);
            //        total++;
            //    }
            //    int i = 0;
            //    while (total < 26)
            //    {
            //        currentLetterOrder[total] = (char)('A' + i);
            //        total++;
            //        i++;
            //    }
            //}

            for(int i=0; i < key - 'A'; i++)
            {
                this.rotate();
            }

            //calculateOutputs();

            return 0;

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
            this.calculateOutputsInitial();
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
            char temp = backwards[0];
            for (int i = 0; i < backwards.Length - 1; i++)
            {
                backwards[i] = backwards[i + 1];
            }
            backwards[backwards.Length - 1] = temp;

             temp = forwards[0];
            for (int i = 0; i < forwards.Length-1; i++)
            {
                forwards[i] = forwards[i + 1];
            }
            forwards[forwards.Length-1] = temp;
            calculateOutputs();
        }

        private void calculateOutputsInitial()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 26; i++)
            {
                char currentLetter = alphabet[i];
                char forwardletter = (char)(alphabet[i] + shiftValue[i]);

                if (forwardletter > 'Z')
                {
                    int newShift = (forwardletter - 'Z');
                    forwardletter = (char)('A' + newShift - 1);
                }
                else if (forwardletter < 'A')
                {
                    int newShift = 'A' - forwardletter;
                    forwardletter = (char)('Z' - newShift + 1);
                }

                this.forwards[i] = forwardletter;
                this.backwards[i] = currentLetter;
                 this.scramble[currentLetter] = forwardletter;
                this.unScramble[forwardletter] = currentLetter;               

            }
            for (int i = 0; i < 26; i++)
            {
                backwards[i] = unScramble[(char)('A' + i)];
            }
        }

        private void calculateOutputs()
        {
            for(int i=0; i < currentLetterOrder.Length; i++)
            {
                char currentLetter = currentLetterOrder[i];
                char scrambledLetter = forwards[i];
                char backwardsLetter = backwards[i];
                this.scramble[currentLetter] = scrambledLetter;
                this.unScramble[currentLetter] = backwardsLetter;

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
