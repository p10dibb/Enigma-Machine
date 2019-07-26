using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Ring
    {
        char[] alphabet= new char[26];

        public Ring()
        {
            SetRingDefault();
    

           

        }

        public Ring(char key,string letterorder)
        {
            SetRing(letterorder);

            int shift = (int)key - 'A';
            for (int i=0; i < shift; i++)
            {
                shiftRight();
            }

        }

        

        private string SetRing(string set)
        {
            if (set.Length != 26)
            {
                SetRingDefault();
                return "Not enough char";
            }

            bool[] used =new bool[26];
            string letters = set.ToUpper();
            for (int i=0; i < 26; i++)
            {
                if (used[(int)letters[i]-(int)'A'])
                {
                    SetRingDefault();
                    return "multiple of same letter";
                }
                alphabet[i] = letters[i];
                used[(int)letters[i] - (int)'A'] = true;
            }


            return "success";
        }
        private void SetRingDefault()
        {
            alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                char x = (char)((int)'A' + i);

                alphabet[i] = x;
            }

        }

        public void shiftLeft()
        {
            char temp = alphabet[0];
            char hold = '\0';
            for (int i = 0; i <alphabet.Length-1; i++)
            {
                alphabet[i] = alphabet[i + 1];
            }
            alphabet[25] = temp;



        }
        public void shiftRight()
        {
            char temp = alphabet[25];
            char hold = '\0';
            for (int i = alphabet.Length-1; i >  0; i--)
            {
                alphabet[i] = alphabet[i-1 ];
            }
            alphabet[0] = temp;



        }

        public void displayAll()
        {
            for (int i =0; i < alphabet.Length; i++)
            {
                Console.WriteLine(alphabet[i]);
            }
        }

        public char[] Alphabet
        {
            get { return this.alphabet; }
        }

        public int Find(char c)
        {
            for(int i=0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
