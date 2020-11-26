using Enigma;
using System; 
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Diagnostics;
using System.Linq;

namespace Bombe_BruteForce
{
    class Cracker
    {
        Random rand = new Random();

        Machine enigma = new Machine();
        string keySetting = "BFM";
        string rottorSetting = "415";
        string plugSetting = "AG BF OP KU QT ZX LI";
        string garenteedWord = "GOODBYEWORLD";
        string garenteedMiddleWord = "WEATHER";
        int maxPlugCombos = 10;
        //HAVEAWONDERFULLDAY
        Dictionary<char, char> AD = new Dictionary<char, char>();
        Dictionary<char, char> BE = new Dictionary<char, char>();
        Dictionary<char, char> CF = new Dictionary<char, char>();
        List<string> UnencryptedMessages = new List<string>();
        List<string> EncryptedMessages = new List<string>();
        NpgsqlConnection connection = new NpgsqlConnection();
        List<setting> possibleSettings = new List<setting>();
        Stopwatch stopwatch = new Stopwatch();
        

        List<string> possiblePlugCombos = new List<string>();
        List<scoreSetting> bestOptions = new List<scoreSetting>();
        int highestSimilarity = 0;
        List<int> stepHighest = new List<int>();

        List<int> weatherStartIndex = new List<int>();
        int bestMessage = 0;
        int currentMessage = 0;
        List<int> messages = new List<int>();

        //this.generatePermutationDict(message_key_encrypts);

        int count = 0;

        //DTQDTQTHEBROWNFOXSADLYHITBELOWFIVEWHITECAVEGOODBYEWORLD
        //BFRBFRONEREDHORSESLOWLYRANINFIVEGREENJUNGLEGOODBYEWORLD

        public Cracker()
        {
            connection = new NpgsqlConnection(buildConnectionString());
            connection.Open();
            try
            {
                this.UnencryptedMessages = System.IO.File.ReadAllLines(@"C:\Users\pauld\OneDrive\Desktop\Enigma-Machine\Bombe_BruteForce\message.text").ToList<string>();
                this.EncryptedMessages = System.IO.File.ReadAllLines(@"C:\Users\pauld\OneDrive\Desktop\Enigma-Machine\Bombe_BruteForce\ciphers.txt").ToList<string>();
            }
            catch
            {

            } 
        }


        private string buildConnectionString()
        {
            return "Server = localhost; Username = postgres; Password = 1234; Database = Enigma;";
        }




        public void runner()
        {
            stopwatch.Start();
            this.generateMessages(500);
            this.findBestMessage();


            messages.Add(this.bestMessage);
            for (int i = 10; i < 5; i++){
                messages.Add(rand.Next() % this.EncryptedMessages.Count);
            }


            this.testPlugFinderDynamicWeather();
            //testPlugFinder();
            stopwatch.Start();
            Console.WriteLine(stopwatch.Elapsed);

            for (int i = 0; i < this.bestOptions.Count; i++)
            {
                Console.WriteLine("Score:"+this.bestOptions[i].score+" "+this.bestOptions[i].ringsetting+" "+this.bestOptions[i].shiftsetting+" " +this.bestOptions[i].plugcombo);
            }
        }
        private List<int> testFindWeather( string str)
        {

            int bestCount = 5000;
            int bestIndex = 0;
            int count = 0;
            string weather = this.garenteedMiddleWord;
            int accurate = 0;
            List<int> indexOptions = new List<int>();
            for (int i = 5; i < str.Length - weather.Length; i++)
            {
                    accurate = 0;
                    for (int j = 0; j < weather.Length; j++)
                    {
                        if (weather[j] != str[i + j])
                        {
                            accurate++;
                        }
                        else { break; }

                    }
                    if (accurate == weather.Length)
                    {
                        count++;
                        indexOptions.Add(i);
                    }
                }

               
            

            return indexOptions;
        }

        private int findBestMessage()
        {

            int bestCount = 5000;
            int bestIndex = 0;
            int count = 0;
            string weather = this.garenteedMiddleWord;
            List<string> str = this.EncryptedMessages;
            int accurate = 0;
            List<int> indexOptions = new List<int>();

            for (int k = 0; k < str.Count(); k++)
            {
                indexOptions= this.testFindWeather(str[k]);


                if (indexOptions.Count < bestCount)
                {
                    bestCount = count;
                    bestIndex = k;
                    this.bestMessage = bestIndex;
                    this.weatherStartIndex.Clear();
                    for (int i = 0; i < indexOptions.Count; i++)
                    {
                        this.weatherStartIndex.Add(indexOptions[i]);
                    }
                }
                count = 0;
                indexOptions.Clear();
            }


            return count;
        }
       private string testPlugFinderDynamicWeather()
        {

            string key = this.generateDictionaryKey(this.EncryptedMessages);
            this.getOptionsfromDB(key);

            string message1 = this.EncryptedMessages[this.bestMessage];

            for (int i = 0; i < weatherStartIndex.Count; i++)
            {
                int highestCombo = 0;
                List<string> highestCombos = new List<string>();
                foreach (setting s in possibleSettings)
                {
                    enigma.setSettings("" , s.shiftsetting , s.ringsetting);
                    string decrypedMessage = enigma.decryptMessage(message1);
                    int baseline = this.garenteedWordSimilarityDynamicWeather(decrypedMessage, this.garenteedMiddleWord, weatherStartIndex[i]) +this.garenteedWordSimilarity(decrypedMessage);
                    this.recursiveGetStringDynamicWeather("", new bool[26], message1, baseline, 0, 0, this.maxPlugCombos, s.shiftsetting, s.ringsetting, this.garenteedMiddleWord, weatherStartIndex[i]);


                    if (this.highestSimilarity > highestCombo)
                    {
                        highestCombo = this.highestSimilarity;
                        highestCombos.Clear();
                    }

                    if (this.highestSimilarity >= highestCombo)
                    {
                        foreach (string str in possiblePlugCombos)
                        {
                            highestCombos.Add(s.ringsetting + " " + s.shiftsetting + " " + str);
                        }
                    }
                    this.stepHighest.Clear();
                    this.possiblePlugCombos.Clear();
                }
                foreach (string combo in highestCombos)
                {
                    string[] temp = combo.Split(" ");
                    string plug = temp[2];
                    for (int f = 3; f < temp.Length; f++)
                    {
                        plug = plug + " " + temp[f];
                    }
                    this.bestOptions.Add(new scoreSetting { score = this.highestSimilarity, ringsetting = temp[0], shiftsetting = temp[1], plugcombo = plug });
                }
                highestCombos.Clear();
                this.highestSimilarity = -500;

            }



            return "";
        }

        private void testPlugFinder()
        {

            string key = this.generateDictionaryKey(this.EncryptedMessages);
            this.getOptionsfromDB(key);


            string message1 = this.EncryptedMessages[this.bestMessage];
            int highestCombo = 0;
            List<string> highestCombos = new List<string>();
            foreach (setting s in possibleSettings)
            {
                int baseline = this.garenteedWordSimilarity(enigma.decryptMessage(message1));
                this.recursiveGetString("", new bool[26], message1, baseline, 0, 0, this.maxPlugCombos, s.shiftsetting, s.ringsetting);


                if (this.highestSimilarity > highestCombo)
                {
                    highestCombo = this.highestSimilarity;
                    highestCombos.Clear();
                }

                if (this.highestSimilarity >= highestCombo)
                {
                    foreach (string str in possiblePlugCombos)
                    {
                        highestCombos.Add(s.ringsetting + " " + s.shiftsetting + " " + str);
                    }
                }
                this.stepHighest.Clear();
                this.possiblePlugCombos.Clear();
            }
            Console.WriteLine("Combo Score");
            foreach (string combo in highestCombos)
            {
                Console.WriteLine(combo);
                string[] temp = combo.Split(" ");
                string plug = temp[2];
                for(int i = 3; i < temp.Length; i++)
                {
                    plug = plug +" "+ temp[i];
                }
                this.bestOptions.Add(new scoreSetting { score = this.highestSimilarity, ringsetting = temp[0], shiftsetting = temp[1], plugcombo = plug });

            }
            this.highestSimilarity = -500;

        }


        public string recursiveGetString(string prior, bool[] used, string message, int baseline,int step, int pass,int maxLength,string shiftSetting,string ringSetting)
        {
            if (step == maxLength)
            {
                return "";
            }

            if (this.stepHighest.Count-1 < step)
            {
                this.stepHighest.Add(baseline);
            }


                int currentValue = -500;
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
                            enigma.setSettings((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')),shiftSetting,ringSetting    );
                            currentValue = this.garenteedWordSimilarity(enigma.decryptMessage(message));

                            if (pass == 0)
                            {
                                if (currentValue > baseline && this.stepHighest[step] < currentValue)
                                {
                                    if (currentValue > this.stepHighest[step])
                                    {
                                        this.stepHighest[step] = currentValue;
                                    }
                                    if (this.highestSimilarity < currentValue)
                                    {
                                        this.possiblePlugCombos.Clear();

                                        this.highestSimilarity = currentValue;
                                        this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));

                                    }
                                    else if (this.highestSimilarity == currentValue){
                                        this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));

                                    }


                                    this.recursiveGetString(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used, message, currentValue, step + 1,pass,maxLength,shiftSetting,ringSetting);
                                }


                            }
                            else
                            {
                                if (currentValue >= baseline && this.stepHighest[step] <= currentValue)
                                {
                                    if (currentValue > this.stepHighest[step])
                                    {
                                        this.stepHighest[step] = currentValue;
                                    }
                                    if (this.highestSimilarity < currentValue)
                                    {
                                        this.possiblePlugCombos.Clear();

                                        this.highestSimilarity = currentValue;

                                    }

                                    this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));

                                    this.recursiveGetString(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used, message, currentValue, step + 1,pass,maxLength,shiftSetting,ringSetting);
                                }


                            }
                            used[letter2] = false;


                        }
                    }
                    used[letter1] = false;

                }

            }


            return "";
        }


        public string recursiveGetStringDynamicWeather(string prior, bool[] used, string message, int baseline, int step, int pass, int maxLength, string shiftSetting, string ringSetting, string garenteedWord,int startIndex)
        {
            if (step == maxLength)
            {
                return "";
            }

            if (this.stepHighest.Count - 1 < step)
            {
                this.stepHighest.Add(baseline);
            }


            int currentValue = -500;
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
                            enigma.setSettings((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')), shiftSetting, ringSetting);
                            string decryptedMessage = enigma.decryptMessage(message);
                            currentValue = this.garenteedWordSimilarityDynamicWeather(decryptedMessage, garenteedWord, startIndex)+this.garenteedWordSimilarity(decryptedMessage);
                   

                            if (pass == 0)
                            {
                                if (currentValue > baseline && this.stepHighest[step] < currentValue)
                                {
                                    if (currentValue > this.stepHighest[step])
                                    {
                                        this.stepHighest[step] = currentValue;
                                    }
                                    if (this.highestSimilarity < currentValue)
                                    {
                                        this.possiblePlugCombos.Clear();

                                        this.highestSimilarity = currentValue;
                                        this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));

                                    }
                                    else if (this.highestSimilarity == currentValue)
                                    {
                                        this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));

                                    }




                                    //Console.WriteLine("PASS: "+pass+" "+(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')) + ": " + currentValue);

                                    this.recursiveGetStringDynamicWeather(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used, message, currentValue, step + 1, pass, maxLength, shiftSetting, ringSetting,garenteedWord,startIndex);
                                }


                            }
                            else
                            {
                                if (currentValue >= baseline && this.stepHighest[step] <= currentValue)
                                {
                                    if (currentValue > this.stepHighest[step])
                                    {
                                        this.stepHighest[step] = currentValue;
                                    }
                                    if (this.highestSimilarity < currentValue)
                                    {
                                        this.possiblePlugCombos.Clear();

                                        this.highestSimilarity = currentValue;

                                    }

                                    this.possiblePlugCombos.Add((prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')));



                                    //Console.WriteLine("PASS: " + pass + " " + (prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A')) + ": " + currentValue);

                                    this.recursiveGetStringDynamicWeather(prior + "" + (char)(letter1 + 'A') + (char)(letter2 + 'A') + " ", used, message, currentValue, step + 1, pass, maxLength, shiftSetting, ringSetting,garenteedWord,startIndex);
                                }


                            }
                            used[letter2] = false;


                        }
                    }
                    used[letter1] = false;

                }

            }


            return "";
        }

        private int garenteedWordSimilarity(string message)
        {
            int similarity = 0;
            string check = this.garenteedWord;

            for (int i = 1; i <= check.Length; i++)
            {
                if (message[message.Length - i] == check[check.Length - i])
                {
                    similarity++;
                }
            }

            return similarity;
        }

        private int garenteedWordSimilarityDynamicWeather(string message, string garenteed, int startIndex)
        {
            int similarity = 0;
            string check = garenteed;

            for (int i = startIndex; i < startIndex+check.Length; i++)
            {
                if (message[i] == check[i-startIndex])
                {
                    similarity++;
                }
            }

            return similarity;
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
            this.EncryptedMessages.Clear();
            this.UnencryptedMessages.Clear();

            PermutationGenerator generator = new PermutationGenerator();
            string message = "";
            string cipher = "";

            for (int i=0; i < amount; i++)
            {
                message = generator.messageGenerator(this.garenteedMiddleWord, this.garenteedWord);
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
                Alphabet = Alphabet.Remove(Alphabet.IndexOf(nextChain), 1); 

                string Chain = ""+nextChain;
                while (nextLetter != Chain[0])
                {
                    Chain = Chain + nextLetter;
                    Alphabet = Alphabet.Remove(Alphabet.IndexOf(nextLetter), 1); 
                    nextLetter = dict[nextLetter];
                }
                Chains.Add(Chain);

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

    
    }
}
