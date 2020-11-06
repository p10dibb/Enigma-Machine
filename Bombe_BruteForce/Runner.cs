using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Bombe_BruteForce
{
    class Runner
    {
        Enigma.Machine machine = new Enigma.Machine();

        //V II III  ZGH AN EF UR PD WJ ZM LX
        string EncryptedMessage = "QKPTVHLZJO";
        string expectedString = "HELLOWORLD";
        List<string> RottorSelectionOptions = new List<string>();
        List<string> RottorShiftOptions = new List<string>();
        Stopwatch stopwatch = new Stopwatch();
        

        int count = 0;

        public void runner()
        {

            stopwatch.Start();
            //this.generateRottorSelectionOptions();
            //Console.WriteLine("selection generation complete");
            //Console.WriteLine("shift generation complete");



            this.generatePlugComboOptions();

            //this.generateRottorShiftOptions("AN EF UR PD WJ ZM LX");


            stopwatch.Stop();
        }


        //public void threadPlay()
        //{
        //    Thread t = new Thread(new ThreadStart(ThreadProc));

        //}

        //public void threadProc() { 
        //Console.WriteLine()
        
        //}

        public void generateRottorSelectionOptions(string plugString, string shiftString)
        {
            bool[] used = new bool[5];

            for (int rotor1 = 1; rotor1 <= 5; rotor1++)
            {
                used[rotor1 - 1] = true;
                for (int rotor2 = 1; rotor2 <= 5; rotor2++)
                {
                    if (!used[rotor2 - 1])
                    {
                        used[rotor2 - 1] = true;
                        for (int rotor3 = 1; rotor3 <= 5; rotor3++)
                        {
                            if (!used[rotor3 - 1])
                            {
                                //machine = new Enigma.Machine(plugString, shiftString, "" + rotor1 + "" + rotor2 + "" + rotor3);
                                machine.setSettings(plugString, shiftString, "" + rotor1 + "" + rotor2 + "" + rotor3);
                                if (machine.decryptMessage(this.EncryptedMessage) == this.expectedString)
                                {
                                    Console.WriteLine(plugString + " " + shiftString + " " + rotor1 + "" + rotor2 + "" + rotor3);

                                }

                            }
                        }
                        used[rotor2 - 1] = false;

                    }

                }

                used[rotor1 - 1] = false;
            }

        }

        public void generateRottorShiftOptions(string plugString)
        {
            for (int rotor1 = 0; rotor1 < 26; rotor1++)
            {
                for (int rotor2 = 0; rotor2 < 26; rotor2++)
                {
                    for (int rotor3 = 0; rotor3 < 26; rotor3++)
                    {
                        this.generateRottorSelectionOptions(plugString, "" + (char)(rotor1 + 'A') + "" + (char)(rotor2 + 'A') + "" + (char)(rotor3 + 'A'));
                    }

                }

            }

        }
    
        public void generatePlugComboOptions()
        {
            bool[] used = new bool[26];
            recursiveGetString("", used);

           
        }
    
        public string recursiveGetString(string prior, bool[] used)
        {
            for (int letter1 = 0; letter1 < 26; letter1++)
            {
                if (!used[letter1])
                {
                    used[letter1] = true;
                    for (int letter2 = 0; letter2 < 26; letter2++)
                    {
                        if (!used[letter2] && letter1<letter2)
                        {
                            used[letter2] = true;
                            this.recursiveGetString(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used);
                            //this.RunMachineShiftsAndSelections(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A'));
                            this.generateRottorShiftOptions(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ");
                            stopwatch.Stop();
                           Console.WriteLine(stopwatch.Elapsed);
                            
                            used[letter2] = false;
                         

                        }
                    }
                    used[letter1] = false;

                }

            }


            return "";
        }
    

        private void RunMachineShiftsAndSelections(string plugboard)
        {

            string expectedString = "HELLOWORLD";

            for (int j = 0; j < this.RottorShiftOptions.Count; j++)
            {
                for (int i = 0; i < this.RottorSelectionOptions.Count; i++)
                {
                    machine = new Enigma.Machine(plugboard, this.RottorShiftOptions[j], this.RottorSelectionOptions[i]);
                    if (machine.decryptMessage(this.EncryptedMessage) == expectedString)
                    {
                        Console.WriteLine(this.RottorShiftOptions[j] + "" + this.RottorSelectionOptions[i]);
                        
                    }
                }
            }
        }

    }
}
