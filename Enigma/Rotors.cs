﻿using System;

namespace Enigma
{


    class Rotors
    {
        const int ringAmount = 3;
        const int AlphabetLength = 26;

        private Ring[] rings = new Ring[ringAmount];
        private Ring reflector = new Ring();
        private string[] ringShifts = new string[ringAmount];
        private string reflectorString = "";
        private int totalLettersScrambled = 0;
        private int[] ringRotations = new int[3];

        public Rotors()
        {
            this.setRingShiftStrings();
            this.setRingShifts();
        }

        public Rotors(string rotorSetting)
        {
            this.setRingShiftStrings();
            this.setRingShifts();
            this.setRotorSetting(rotorSetting);
        }

        private void setRingShiftStrings()
        {
            reflectorString = "24,16,18,4,12,13,5,-4,7,14,3,-5,2,-3,-2,-7,-12,-16,-13,6,-18,1,-1,-14,-24,-6";

            for (int i = 0; i < ringAmount; i++)
            {
                ringShifts[i] = "";
            }
            ringShifts[0] = "4,9,10,2,7,1,-3,9,13,16,3,8,2,9,10,-8,7,3,0,-4,-20,-13,-21,-6,-22,-16";
            ringShifts[1] = "0,8,1,7,14,3,11,13,15,-8,1,-4,10,6,-2,-13,0,-11,7,-6,-5,3,-17,-2,-10,-21";
            ringShifts[2] = "1,2,3,4,5,6,-4,8,9,10,13,10,13,0,10,-11,-8,5,-12,-19,-10,-9,-2,-5,-8,-11";
        }

        private void setRingShifts()
        {
            this.reflector.SetRing(reflectorString);

            for (int i = 0; i < ringAmount; i++)
            {
                rings[i] = new Ring();
                rings[i].SetRing(ringShifts[i]);
            }
        }

        public string setRotorSetting(string rotorSetting)
        {
            if (rotorSetting.Length != ringAmount)
            {
                return "not a valid setting";
            }

            for(int i = 0; i < ringAmount; i++)
            {
                this.rings[i].setRingSetting(rotorSetting[i]);
            }

            return "success";
        }

        public char encryptLetter(char letter)
        {
            char newLetter = letter;
            totalLettersScrambled += 1;
            this.rotateRings();
            newLetter = rings[0].scrambleLetter(newLetter);

            for (int i = 1; i < ringAmount; i++)
            {

                newLetter = rings[i].scrambleLetter(wrapLetter((char)(newLetter-(ringRotations[i-1]))));
            }

            newLetter = reflector.scrambleLetter(newLetter);
            newLetter = rings[ringAmount - 1].unScrambleLetter(newLetter);

            for (int i = ringAmount - 2; i >= 0; i--)
            {
                newLetter = rings[i].unScrambleLetter(wrapLetter((char)(newLetter - (ringRotations[i + 1]))));
            }


            newLetter= (char)(newLetter - ringRotations[0]);
      
            return wrapLetter(newLetter);
        }

        private char wrapLetter(char letter)
        {
            char newLetter = letter;
            if (newLetter > 'Z')
            {
                int newShift = (newLetter - 'Z');
                newLetter = (char)('A' + newShift - 1);
            }
            else if (newLetter < 'A')
            {
                int newShift = 'A' - newLetter;
                newLetter = (char)('Z' - newShift + 1);
            }
            return newLetter;

        }

        public char decryptLetter(char letter)
        {
            char newLetter = letter;
        
            for (int i = 0; i < ringAmount; i++)
            {
                newLetter = rings[i].unScrambleLetter(newLetter);
            }


            newLetter = reflector.unScrambleLetter(newLetter);
            for (int i = ringAmount - 1; i >= 0; i--)
            {
                newLetter = rings[i].unScrambleLetter(newLetter);
            }

            totalLettersScrambled += 1;
            this.rotateRings();
            return newLetter;
        }

        private void rotateRings()
        {
            for(int i=ringAmount; i > 0; i--)
            {
                if (totalLettersScrambled % (Math.Pow(AlphabetLength, i)) ==0)
                {
                    rings[i - 1].rotate();
                    ringRotations[i-1]++;

                    return;
                }
                
            }
            rings[0].rotate();
            ringRotations[0]++;
        }
    }
}
