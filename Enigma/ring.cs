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
        int[] ringShift = new int[AlphabetLength];
        

        public Ring()
        {
            SetRingDefault();

           

        }

        public Ring(char key,string shiftString)
        {
            SetRing(shiftString);

            int shift = (int)key - 'A';
            for (int i=0; i < shift; i++)
            {
                rotate();
            }

        }

        

        //private string SetRing(string set)
        //{
        //    if (set.Length != 71)
        //    {
        //        SetRingDefault();
        //        return "Not enough char";
        //    }
        //}

        public string SetRing(string set)
        {

           string[] ringShiftString= set.Split(',');

            if (ringShiftString.Length != AlphabetLength)
            {
                SetRingDefault();
                return "Not enough inputs";
            }

            bool[] used =new bool[AlphabetLength];
            

            
            
            for(int i=0;i< ringShiftString.Length; i++)
            {
                if(Int32.TryParse(ringShiftString[i], out int numval))
                {
                    this.ringShift[i] = numval;
                }
                else
                {
                    SetRingDefault();
                    return "could not parse " + ringShiftString[i];
                }

            }

          for(int i=0; i > this.ringShift.Length; i++)
            {
                if (used[i + this.ringShift[i]])
                {
                    SetRingDefault();
                    return "dublicate wiring";
                }
                else
                {
                    used[i + this.ringShift[i]] = true;
                }
            }

            return "success";
        }
        private void SetRingDefault()
        {
            for(int i = 0; i < AlphabetLength; i++)
            {
                ringShift[i] = 2;

            }

        }


        public void rotate()
        {
            int temp = ringShift[0];
            for (int i = 0; i <ringShift.Length-1; i++)
            {
                ringShift[i] = ringShift[i + 1];
            }
            ringShift[ringShift.Length-1] = temp;



        }

        public void displayAll()
        {
                Console.WriteLine(ringShift);
            
        }

        public int[] getRingShift
        {
            get { return this.ringShift; }
        }

        public char scrambleLetter(char letter)
        {
           if(letter<'A' ||letter>'Z')
            {
                return'+';
            }

            int letterIndex = letter - 'A';
            
            char newLetter = (char)((int)letter + ringShift[letterIndex]);
            if (newLetter < 'A')
            {
                newLetter = (char)('Z' - ('A' - newLetter)+1); 
            }else if (newLetter > 'Z')
            {
                newLetter = (char)('A' + (newLetter - 'Z')-1);
            }
            return newLetter;
        }
    }
}
