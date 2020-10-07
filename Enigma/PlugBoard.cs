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
            string[] combos = letterSwaps.Split(' ');
            for (int i = 0; i < combos.Length;i++)
            {
                if (combos[i].Length == 2)
                {
                    boardSwaps[combos[i][0]] = boardSwaps[combos[i][1]];
                    boardSwaps[combos[i][1]] = boardSwaps[combos[i][0]];
                }
            }

        }

        public char swapLetter(char letter)
        {
            return boardSwaps[letter];
        }
    }
}
