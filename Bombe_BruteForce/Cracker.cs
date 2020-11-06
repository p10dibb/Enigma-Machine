using Enigma;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Diagnostics;

namespace Bombe_BruteForce
{
    class Cracker
    {
        Machine enigma = new Machine();
        string keySetting = "ZAC";
        string rottorSetting = "531";
        string plugSetting = "AG BF OP KU QT";
        string garenteedWord = "GOODBYEWORLD";
        Dictionary<char, char> AD = new Dictionary<char, char>();
        Dictionary<char, char> BE = new Dictionary<char, char>();
        Dictionary<char, char> CF = new Dictionary<char, char>();
        List<string> UnencryptedMessages = new List<string>();
        List<string> EncryptedMessages = new List<string>();
        NpgsqlConnection connection = new NpgsqlConnection();
        List<setting> possibleSettings = new List<setting>();
        Stopwatch stopwatch = new Stopwatch();
        //this.generatePermutationDict(message_key_encrypts);

        int count = 0;

        public Cracker()
        {
            connection = new NpgsqlConnection(buildConnectionString());
            connection.Open();
        }

        private string buildConnectionString()
        {
            return "Server = localhost; Username = postgres; Password = 1234; Database = Enigma;";
        }


        public void runner()
        {

            string message = "HELLOWORLD";
            enigma.setSettings("", keySetting, rottorSetting);
            string encryptedMessage = enigma.encryptMessage(message);
            this.generateMessages(500);

           string key= this.generateDictionaryKey(this.EncryptedMessages);

            Console.WriteLine(key);
            this.getOptionsfromDB(key);

            Console.WriteLine(possibleSettings.Count);
            foreach(setting s in possibleSettings)
            {

                Console.WriteLine("-------" + s.shiftsetting + "---" + s.ringsetting);
                enigma.setSettings("", s.shiftsetting, s.ringsetting);
                Console.WriteLine(enigma.decryptMessage(this.EncryptedMessages[0]));
                enigma.setSettings("", s.shiftsetting, s.ringsetting);
                Console.WriteLine(enigma.decryptMessage(this.EncryptedMessages[1]));
                //stopwatch.Start();
                //this.generatePlugComboOptions( s.ringsetting, s.shiftsetting);

            }



        }

        private bool isGoodbyeWorldAtEnd(string message)
        {
            string check = "GOODBYEWORLD";

            for(int i = 1; i <= check.Length; i++)
            {
                if (message[message.Length - i] != check[check.Length - i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool tryPlugs(setting currentSetting)
        {
            string encrypted = this.EncryptedMessages[0];

            string garenteed = "GOODBYEWORLD";

            return true;
        }
        

        private void getOptionsfromDB(string key)
        {
            using (var cmd = new NpgsqlCommand())
            {


                cmd.Connection = connection;
                //                            0         1           2           3            4         5         6      7         8            9       10
                cmd.CommandText = "SELECT settingkey,ringsetting,shiftsetting  FROM settings WHERE settingkey= '" + key+"'" ;
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        possibleSettings.Add(new setting() {settingkey=reader.GetString(0), ringsetting=reader.GetString(1),shiftsetting=reader.GetString(2) });
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
              
            }
        }


        private void printPermutationDict(Dictionary<char,char> dict)
        {
            foreach (KeyValuePair<char, char> keyValue in dict)
            {
                Console.WriteLine(keyValue.Key + " " + keyValue.Value);

            }

        }


        private void generatePermutationDict(List<string> message_encrypts)
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letter in Alphabet)
            {
                AD[letter] = '\0';
                BE[letter] = '\0' ;
                CF[letter] = '\0';
            }

            int i = 0;
            while (i < message_encrypts.Count && (AD.ContainsValue('\0') || BE.ContainsValue('\0') || CF.ContainsValue('\0')))
            {
                string currentMessage = message_encrypts[i];
                if (AD[currentMessage[0]] == '\0' && !AD.ContainsValue(currentMessage[3]))
                {
                    AD[currentMessage[0]] = currentMessage[3];
                }
                if (BE[currentMessage[1]] == '\0' && !BE.ContainsValue(currentMessage[4]))
                {
                    BE[currentMessage[1]] = currentMessage[4];
                }
                if (CF[currentMessage[2]] == '\0' && !CF.ContainsValue(currentMessage[5]))
                {

                    CF[currentMessage[2]] = currentMessage[5];
                }
                i++;
            }


        }

        private void generateMessages(int amount)
        {
           System.IO.StreamWriter messageOutfile = new System.IO.StreamWriter(@"C:\Users\pauld\OneDrive\Desktop\Enigma-Machine\Bombe_BruteForce\message.text");
            System.IO.StreamWriter cipherOutfile = new System.IO.StreamWriter(@"C:\Users\pauld\OneDrive\Desktop\Enigma-Machine\Bombe_BruteForce\ciphers.txt");


            PermutationGenerator generator = new PermutationGenerator();
            string message = "";
            string cipher = "";

            for (int i=0; i < amount; i++)
            {
                message = generator.messageGenerator(this.garenteedWord);
                enigma.setSettings(this.plugSetting, this.keySetting, this.rottorSetting);
                cipher = enigma.encryptMessage(message);
                messageOutfile.WriteLine(message);
                cipherOutfile.WriteLine(cipher);

                this.EncryptedMessages.Add(cipher);
                this.UnencryptedMessages.Add(message);
            }

            messageOutfile.Close();
            cipherOutfile.Close();
        }

        private List<string> makeChainsFromPermutatuinDict(Dictionary<char,char> dict) {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            List<string> Chains = new List<string>();

            while (Alphabet.Length > 0)
            {
                char nextChain = dict[Alphabet[0]];
                char nextLetter = dict[nextChain];
                //Alphabet = Alphabet.Remove(Alphabet.IndexOf(Alphabet[0]), 1);
                Alphabet = Alphabet.Remove(Alphabet.IndexOf(nextChain), 1); 

                string Chain = ""+nextChain;
                while (nextLetter != Chain[0])
                {
                    Chain = Chain + nextLetter;
                    Alphabet = Alphabet.Remove(Alphabet.IndexOf(nextLetter), 1); 
                    nextLetter = dict[nextLetter];
                }
                Chains.Add(Chain);
                //Alphabet = Alphabet.Remove(Alphabet.IndexOf(nextLetter),1);

            }
            return Chains;

        }

        public string generateDictionaryKey(List<string> encryptedKeys)
        {
            string returnString = "";
            
            this.generatePermutationDict(encryptedKeys);


            List<string> ADChain = this.makeChainsFromPermutatuinDict(AD);
            List<string> BEChain = this.makeChainsFromPermutatuinDict(BE);
            List<string> CFChain = this.makeChainsFromPermutatuinDict(CF);

            List<int> stringLengths = new List<int>();

            for(int i = 0; i < ADChain.Count; i++)
            {
                stringLengths.Add(ADChain[i].Length);
            }
            stringLengths.Sort();
            returnString = "AD:";
            for (int i = 0; i < stringLengths.Count; i++) {

                returnString = returnString + "" + stringLengths[i];
            }
            returnString =returnString+ " ";

            stringLengths.Clear();

            for (int i = 0; i < BEChain.Count; i++)
            {
                stringLengths.Add(BEChain[i].Length);
            }
            stringLengths.Sort();
            returnString = returnString+ "BE:";
            for (int i = 0; i < stringLengths.Count; i++)
            {

                returnString = returnString + "" + stringLengths[i];
            }
            returnString = returnString + " ";

            stringLengths.Clear();

            for (int i = 0; i < CFChain.Count; i++)
            {
                stringLengths.Add(CFChain[i].Length);
            }
            stringLengths.Sort();
            returnString = returnString+ "CF:";
            for (int i = 0; i < stringLengths.Count; i++)
            {

                returnString = returnString + "" + stringLengths[i];
            }

            return returnString;
        }


        public void generatePlugComboOptions(string rotorSetting, string shiftSetting)
        {
            bool[] used = new bool[26];

            //test for no plug swaps
            enigma.setSettings("", shiftSetting, rotorSetting);

            if (isGoodbyeWorldAtEnd(enigma.decryptMessage(this.EncryptedMessages[0])))
            {
                Console.WriteLine( ""+" "+ shiftSetting+" "+rotorSetting);
            }

            recursiveGetString("", used, rotorSetting, shiftSetting);


        }

        public string recursiveGetString(string prior, bool[] used , string rotorSetting, string shiftSetting)
        {
            for (int letter1 = 0; letter1 < 26; letter1++)
            {
                if (!used[letter1])
                {
                    used[letter1] = true;
                    for (int letter2 = 0; letter2 < 26; letter2++)
                    {
                        if (!used[letter2] && letter1 < letter2)
                        {
                            count += 1;
                            used[letter2] = true;
                            enigma.setSettings((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')),shiftSetting,rotorSetting);
                            if (count == 100000)
                            {
                                stopwatch.Stop();
                                Console.WriteLine(stopwatch.Elapsed);
                            }
                            if (isGoodbyeWorldAtEnd(enigma.decryptMessage(this.EncryptedMessages[0])))
                            {
                                Console.WriteLine((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A'))+" "+ shiftSetting+ " "+rotorSetting);
                            }
                            this.recursiveGetString(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used, rotorSetting, shiftSetting);

                            used[letter2] = false;


                        }
                    }
                    used[letter1] = false;

                }

            }


            return "";
        }


    }
}
