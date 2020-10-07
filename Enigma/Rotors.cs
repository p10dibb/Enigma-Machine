using System;

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
            reflectorString = "7,19,9,13,8,13,11,2,11,-7,3,5,-10,-11,-14,6,-2,-2,6,-8,-7,4,-9,-19,-24,-11";

            for(int i = 0; i < ringAmount; i++)
            {
                ringShifts[i] = "";
            }
            ringShifts[0] = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-5,-3";
            ringShifts[1] = "23,9,13,0,9,-1,14,2,0,-9,-2,0,7,-5,11,-9,9,-16,5,-7,-3,-12,-2,-17,-13,-9";
            ringShifts[2] = "0,8,10,-2,-1,14,15,-2,14,16,8,-1,2,6,10,-2,-14,-16,0,-13,0,-17,-17,-18,-2,-15";
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

        public char scrambleLetter(char letter)
        {
            char newLetter = letter;
            for(int i = 0; i < ringAmount; i++)
            {
                newLetter = rings[i].scrambleLetter(newLetter);
            }

            newLetter = reflector.scrambleLetter(newLetter);

            for(int i=ringAmount-1; i >= 0; i--)
            {
                newLetter = rings[i].scrambleLetter(newLetter);
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
                    return;
                }
                
            }
            rings[0].rotate();
        }
    }
}
