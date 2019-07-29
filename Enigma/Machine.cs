﻿using System;
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

        Dictionary<char, char> plug_board = new Dictionary<char, char>();
        
        public Machine()
        {
            for (int i=0; i<r.Length; i++)
            {
                r[i] = new Ring();
            }


        }

        public Machine(string key, string rottor, string ring, string plug) {
            string[] alpha = new string[] { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO" };
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
                r[i] = new Ring(ringSetting[i], alpha[i]);
            }


           



        }

        public string encrypt_Rings(string phrase)
        {
            char[] p = (phrase.ToUpper()).ToCharArray();

            for(int i= 0; i < p.Length; i++)
            {

                if ((int)p[i] <= (int)'Z' && (int)p[i] >= (int)'A')
                {
                    p[i] = r[1].Alphabet[r[0].Find(p[i])];
                    r[0].shiftLeft();
                    r[1].shiftRight();
                    p[i] = r[2].Alphabet[r[1].Find(p[i])];
                    r[1].shiftLeft();
                    r[2].shiftRight();
                }
            }


            return new string(p);


        }



        public string encrypt_Rings_back(string phrase) {
            char[] p = (phrase.ToUpper()).ToCharArray();

            for (int i = p.Length-1 ; i >= 0; i--)
            {
                if ((int)p[i] <= (int)'Z' && (int)p[i] >= (int)'A')
                {
                    r[2].shiftLeft();
                    r[1].shiftRight();
                    p[i] = r[1].Alphabet[r[2].Find(p[i])];
                    r[1].shiftLeft();
                    r[0].shiftRight();
                    p[i] = r[0].Alphabet[r[1].Find(p[i])];

                }
                
               

            }




            return new string(p);
        }
        

        public string Run(string phrase)
        {
            string ret;
            ret = this.CharSwap_Plugs(phrase);
          
            ret = this.encrypt_Rings(ret);
            ret = this.CharSwap_Plugs(ret);
            ret = this.encrypt_Rings_back(ret);

            return ret;

        }


        public string Generate_PlugBoard()
        {
            int count = 0;
            bool[] used = new bool[26];

            char[] c = new char[26];
            List<char> ret = new List<char>();

            int r = 0;
            while (count < 25)
            {
                r = rand.Next(0, 26);
                if (!used[r])
                {
                    used[r] = true;
                    ret.Add((char) ((int)'a' + r));
                    count++;
                    if (count%2 == 1)
                    {
                        ret.Add(' ');
                    }
                }
            }

            return new string(ret.ToArray());           
                               
        }
     


        private void SetPlugs(string plug)
        {
            string plugs = plug.ToUpper();
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
        
        
        private String CharSwap_Plugs(string Phrase)
        {
            string phrase = Phrase.ToUpper();
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

    }
}
