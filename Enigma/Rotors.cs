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
            reflectorString = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3";

            for (int i = 0; i < ringAmount; i++)
            {
                ringShifts[i] = "";
            }
            ringShifts[0] = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3";
            ringShifts[1] = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3";
            ringShifts[2] = "1,2,-2,1,-2,1,-1,3,1,-2,-2,5,3,1,-3,-3,-3,1,-1,6,4,2,-1,-4,-4,-3";
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
                    return;
                }
                
            }
            rings[0].rotate();
        }
    }
}
