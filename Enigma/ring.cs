using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
     public class Ring
    {

        string def = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@ .,$;:#&%";
        char[] alphabet= new char[72];

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

        

        //private string SetRing(string set)
        //{
        //    if (set.Length != 71)
        //    {
        //        SetRingDefault();
        //        return "Not enough char";
        //    }
        //}

        private string SetRing(string set)
        {
            Console.WriteLine(set.Length);
            if (set.Length != 72)
            {
                SetRingDefault();
                return "Not enough char";
            }

            bool[] used =new bool[72];
            
            for (int i=0; i < 72; i++)
            {
                for (int j = 0; j < def.Length; j++)
                {
                    if (def[j] == set[i] && !used[j])
                    {
                        SetRingDefault();
                        return "multiple of same letter";
                    }
                    else
                    {
                        used[j] = true;
                        alphabet[i] = set[i];
                        break;
                    }

                }
          
             
            }


            return "success";
        }
        private void SetRingDefault()
        {
  
            alphabet=def.ToCharArray();

        }

        //private void SetRingDefault(Dictionary<int,char> c)
        //{
        //    alphabet = new char[71];

        //    for (int i = 0; i < 71; i++)
        //    {
        //        alphabet[i] = c[i];
        //    }


        //}

        public void shiftLeft()
        {
            char temp = alphabet[0];
            char hold = '\0';
            for (int i = 0; i <alphabet.Length-1; i++)
            {
                alphabet[i] = alphabet[i + 1];
            }
            alphabet[alphabet.Length-1] = temp;



        }
        public void shiftRight()
        {
            char temp = alphabet[alphabet.Length-1];
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
                char df = alphabet[i];
                if (c == alphabet[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
