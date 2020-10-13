using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class StringGenerator
    {
        string newString = "";

        public string GenerateRingShift()
        {
            var rand = new Random();

            bool[] AlphabetUsed = new bool[26];
            int currentShift = 0;
            int attempts = 0;
            bool success = false;
            for(int i = 0; i < 26; i++)
            {
                while (!success&& attempts<5)
                {
                    currentShift = rand.Next()%26;
                    if (!AlphabetUsed[currentShift])
                    {
                        int shiftAmount = currentShift - i;
                        newString = newString + shiftAmount;
                        if (i < 25)
                        {
                            newString = newString + ',';
                        }

                        success = true;
                    }
                    else
                    {
                        attempts++;
                    }
                }
                if (!success)
                {
                    int j = 0;
                    while (!success)
                    {
                        if (AlphabetUsed[j])
                        {
                            j++;
                        }
                        else
                        {
                            //add to string;
                            success = true;
                        }
                    }
                }
                success = false;
                attempts = 0;
            }


            return newString;
        }

        public string CalculateRingShift(string shiftAlphabet) {
            int alphabetLength = 26;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string shiftstring = "";
            if (shiftAlphabet.Length != alphabetLength)
            {
                return "Invalid Shift String";
            }

            for(int i=0; i < alphabetLength; i++)
            {
                shiftstring = shiftstring + (shiftAlphabet[i] - alphabet[i]);
                              
                if (i < alphabetLength - 1)
                {
                    shiftstring = shiftstring + ',';
                }
            }          


            return shiftstring;
        
        }

    }
}
