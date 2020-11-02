using System;

namespace Enigma
{


    class Rotors
    {
        const int ringAmount = 3;
        const int AlphabetLength = 26;
        StringGenerator generator= new StringGenerator();
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


        {   //Reflector B YRUHQSLDPXNGOKMIEBFZCWVJAT
            reflectorString = "24,16,18,4,12,13,5,-4,7,14,3,-5,2,-3,-2,-7,-12,-16,-13,6,-18,1,-1,-14,-24,-6";

         
            ringShifts[0] = this.getRotor(1);
            ringShifts[1] = this.getRotor(2);
            ringShifts[2] = this.getRotor(3);
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

            for (int i = 0; i < rotorSetting.Length; i++)
            {

                this.rings[i].setRingSetting(rotorSetting[i]);
                this.ringRotations[i] = rotorSetting[i] - 'A';                   
                    
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

                newLetter = rings[i].scrambleLetter(wrapLetter((char)(newLetter-(ringRotations[i-1] % 26))));
            }

            newLetter = reflector.scrambleLetter(wrapLetter((char)(newLetter - (ringRotations[ringAmount-1] % 26))));
            newLetter = rings[ringAmount - 1].unScrambleLetter(newLetter);

            for (int i = ringAmount - 2; i >= 0; i--)
            {
                newLetter = rings[i].unScrambleLetter(wrapLetter((char)(newLetter - (ringRotations[i + 1] % 26))));
            }


            newLetter = (char)(newLetter - ringRotations[0]%26);

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
    
        private string getRotor(int number)
        {
            switch (number)
            {
                // ROTOR I 	
                case 1: return generator.CalculateRingShift("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
                //ROTOR II 	
                case 2: return generator.CalculateRingShift("AJDKSIRUXBLHWTMCQGZNPYFVOE");
                //Rotor III 
                case 3: return generator.CalculateRingShift("BDFHJLCPRTXVZNYEIWGAKMUSQO");
                //Rotor IV 	
                case 4: return generator.CalculateRingShift("ESOVPZJAYQUIRHXLNFTGKDCMWB"); 
                //Rotor V
                case 5: return generator.CalculateRingShift("VZBRGITYUPSDNHLXAWMJQOFECK"); 
                default:return "";
            }
        }
    }
}
