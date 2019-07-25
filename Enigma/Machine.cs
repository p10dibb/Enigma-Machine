using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Machine
    {
        Ring[] r = new Ring[3];

        Dictionary<char, char> plug_board = new Dictionary<char, char>();
        
        public Machine()
        {

        }

        public Machine(string key, string rottor, string ring, string plug) {



        }

        public void SetPlugs(string plug)
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
        
        
        public String CharSwap_Plugs(string Phrase)
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
       

    }
}
