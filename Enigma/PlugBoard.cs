using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class PlugBoard
    {
        Dictionary<char, char> boardSwaps = new Dictionary<char, char>();

        public PlugBoard()
        {
            setDefaultPlugs();
        }

        public PlugBoard(string letterSwaps) {
            setDefaultPlugs();
            this.setPlugs(letterSwaps);
        }

        private void setDefaultPlugs()
        {
            char start = 'A';
            for (int i = 0; i < 26; i++)
            {
                boardSwaps[(char) (start + i)] = (char)(start + i);
            }
        }

    
        public void setPlugs(string letterSwaps)
        {
            this.setDefaultPlugs();
            string[] combos = letterSwaps.Split(' ');
            for (int i = 0; i < combos.Length;i++)
            {
                if (combos[i].Length == 2)
                {
                    char letter1= combos[i][0];
                    char letter2 = combos[i][1];
                    boardSwaps[letter2] = letter1;

                    boardSwaps[letter1] = letter2;

                }
            }

        }

        public char swapLetter(char letter)
        {
            return boardSwaps[letter];
        }
    }
}
