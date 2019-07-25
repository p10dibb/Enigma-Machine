using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Ring
    {
        char[] alphabet;

        public Ring()
        {
            Console.Write("woot");
            alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                char x=(char)(97 + i);
              
                alphabet[i] = x;
            }

           

        }

        public Ring(char key)
        {
            alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                
                int cur= (int)key + i;
                if (cur > (int)'z')
                {
                    key = (char)((int)'a' - i);
                }


                char x = (char)((int)key + i);



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
    }
}
