using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Machine
    {
        Ring[] r = new Ring[3];
        private Random rand = new Random();
        Dictionary<int, char> alphabet = new Dictionary<int, char>();
        Dictionary<char, char> plug_board = new Dictionary<char, char>();
        
        public Machine()
        {
           
        }

        public Machine(string key, string rottor, string ring, string plug) {

            this.Set_Alphabet();

            string[] alpha = new string[] { "7Q$He21wsnd49;cIPVu3RC:oAXbm&jy,vDx@EOMTNYWkz#pfr6G%g5Z0UaBLFhJl8 StK.iq", "k C6gWpn5;EqJfuFs3OZ89zLl4b$hUQXT&Ba.0x#eH,2dm:7Sc@iRPjwtIGv1NVr%YAyDoMK","wnu3#xBP6ypahmb:M0YlZ ef%sEdJUN9G@SQt&V.RFXjAi4LqHvr125T,K7zWcog8I;$COkD" };
            string ringSetting = ring.ToUpper();

            this.SetPlugs(plug);

            if (ringSetting.Length != r.Length)
            {
                Console.WriteLine("not valid ring setting");
                ringSetting = "AAA"; //shud be variable amount of As or trigger setting to just pass in A's
            }
            else
            {
                foreach(char x in ringSetting)
                {

                    if ((int)x > (int)'Z' || (int)x < (int)'A') {
                        Console.WriteLine("not valid ring setting");
                        ringSetting = "AAA";
                        break;
                    }
                }
            }

            for(int i = 0; i < r.Length; i++)
            {
                Console.WriteLine(alpha[i].Length);
                r[i] = new Ring(ringSetting[i], alpha[i]);
            }


           



        }

        public string encrypt_Rings(string phrase)
        {
            char[] p = phrase.ToCharArray();

            for(int i= 0; i < p.Length; i++)
            {

                if (alphabet.ContainsValue(p[i]))
                {
                    for (int j = 0; j < r.Length - 1; j++)
                    {
                       
                     
                        //p[i] = r[j+1].Alphabet[r[j].Find(p[i])];
                        //r[j].shiftLeft();
                        //r[j+1].shiftRight();
                    }
         
                }
            }


            return new string(p);


        }



        public string reflection(string phrase) {
            char[] p = phrase.ToCharArray();

            for (int i = p.Length-1 ; i >= 0; i--)
            {
                if (alphabet.ContainsValue(p[i]))
                {

                    for (int j = r.Length - 1; j >= 1; j--)
                    {
                        //r[j].shiftLeft();
                        //r[j - 1].shiftRight();
                        //p[i] = r[j - 1].Alphabet[r[j].Find(p[i])];
                    }
      

                }
                
               

            }




            return new string(p);
        }
        

        public string encrypt(string phrase)
        {
            string ret;
            ret = this.CharSwap_Plugs(phrase);
          
            ret = this.encrypt_Rings(ret);
            ret = this.CharSwap_Plugs(ret);
            ret = this.reflection(ret);

            return ret;

        }

        public string decrypt(string phrase)
        {
            string ret;
           

            ret = this.encrypt_Rings(phrase);
            ret = this.CharSwap_Plugs(ret);
            ret = this.reflection(ret);
            ret = this.CharSwap_Plugs(ret);
            return ret;

        }


        public string Generate_PlugBoard()
        {
            int count = 0;
            bool[] used = new bool[72];

            char[] c = new char[72];
            List<char> ret = new List<char>();

            int r = 0;
            while (count < 72)
            {
                
                r = rand.Next(0, 72);
                if (!used[r])
                {
                    used[r] = true;
                    ret.Add(alphabet[r]);
                    count++;
                    if (count%2 == 0)
                    {
                        ret.Add(' ');
                    }
               
                }
            }

            return new string(ret.ToArray());           
                               
        }

        public string Generate_RingSetting(string amt)
        {
            if (amt.Length == 1 && ((int)amt[0] >= (int)'0' && (int)amt[0] <= (int)'9'))
            {
                int a = (int)amt[0] - (int)'0';

                char[] ret = new char[a];
                int c;
                for (int i = 0; i < a; i++)
                {
                    c = rand.Next(0, 25);
                    ret[i] = (char)((int)'A' + c);
                }
                return new string(ret);
            }


            return "";
         
        }    

        private void Set_Alphabet()
        {
            for (int i = 0; i < 26; i++)
            {
                this.alphabet[i] = (char)((int)'A' + i);
            }
            for (int i=0; i<26; i++)
            {
                this.alphabet[i+26] = (char)((int)'a' + i);
            }
            for (int i=0; i < 10; i++)
            {
                this.alphabet[i+52]= (char)((int)'0' + i);
            }

            this.alphabet[62] = '@';
            this.alphabet[63] = ' ';
            this.alphabet[64] = '.';
            this.alphabet[65] = ',';
            this.alphabet[66] = '$';
            this.alphabet[67] = ';';
            this.alphabet[68] = ':';
            this.alphabet[69] = '#';
            this.alphabet[70] = '&';
            this.alphabet[71] = '%';

        }
        private void SetPlugs(string plugs)
        {
            
            int count = 0;
            string[] sets = plugs.Split(' ');
            for (int i = 0; i < sets.Length; i++)
            {
                
                if (sets[i].Length == 2&& !plug_board.ContainsKey(sets[i][0])&& !plug_board.ContainsKey(sets[i][1]))
                {
                    plug_board[sets[i][0]] = sets[i][1];
                    plug_board[sets[i][1]] = sets[i][0];
                }
            }



        }
        
        
        private String CharSwap_Plugs(string phrase)
        {
           
            char[] c = new char[phrase.Length];
            for (int i = 0; i < phrase.Length;i++)
            {
                if (plug_board.ContainsKey(phrase[i]))
                {
                    c[i] = plug_board[phrase[i]];
                }
                else
                {
                    c[i] = phrase[i];
                }
            }

            string ret = new string(c);

            return ret;
        }
       
        

        public Ring[] Rings
        {
            get { return this.r; }
            set { this.r = value; }
        }
        public string DisplayAll()
        {
            char[] c = new char[72];

            for (int i = 0; i < 72; i++)
            {
                c[i] = this.alphabet[i];
            }

            return new string(c);
        }

        public string makeString()
        {
            char[] c = new char[72];
            bool[] used = new bool[72];
            int count = 0;
            int r = 0;
            while (count < 72)
            {
                r = rand.Next(0, 72);
                if (!used[r])
                {
                    
                    used[r] = true;
                    c[count] = this.alphabet[r];
                    count++;
                }
               
            }

            return new string(c);
        }

    }

}
