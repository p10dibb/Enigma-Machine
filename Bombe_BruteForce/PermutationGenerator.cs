using Enigma;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Threading;

namespace Bombe_BruteForce
{
    class PermutationGenerator
    {

        Machine machine = new Machine();
        string currentMessage = "";
        Cracker cracker = new Cracker();
        Random rand = new Random();
        int count = 0;
        NpgsqlConnection connection = new NpgsqlConnection();


        public PermutationGenerator()
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


            for (int i=0; i < 100; i++)
            {
                Console.WriteLine("Round" + i);
                this.generateRottorShiftOptions("");
                Console.WriteLine("error amount:" + count);
                count = 0;
            }
       
        }
        private void AddItemToDB(string key,string ringSetting,string shiftSetting)
        {

                using (var cmd = new NpgsqlCommand())
                {

                    cmd.Connection = connection;
                    cmd.CommandText = "insert into settings(settingkey, ringsetting, shiftsetting) Values('"+key + "', '" + ringSetting + "', '" + shiftSetting + "')";

                    try
                    {
                        cmd.ExecuteNonQuery();

                    }
                    catch (NpgsqlException ex)
                    {
                        //Console.WriteLine(ex.Message.ToString());
                    }
                 

                }



            

        }

        public void populateDB(string shiftString, string rotorsetting)
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            List<string> currentEncryptedKeys = new List<string>();


            for (int i = 0; i < 200; i++)
            {
                currentMessage = "" + (char)(Alphabet[rand.Next() % 26]) + (char)(Alphabet[rand.Next() % 26]) + (char)(Alphabet[rand.Next() % 26]);
                currentMessage = currentMessage + currentMessage;
                machine.setSettings("", shiftString, rotorsetting);
                string x = machine.encryptMessage(currentMessage);
                currentEncryptedKeys.Add(x);
            }
            try
            {
                
                string key =cracker.generateDictionaryKey(currentEncryptedKeys);
                this.AddItemToDB(key, rotorsetting, shiftString);

            }
            catch
            {
                count += 1;
                //Console.WriteLine("error: " + shiftString + " " + rotorsetting) ;
            }
        }

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
                                
                                this.populateDB(shiftString, "" + rotor1 + "" + rotor2 + "" + rotor3);

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

        public string messageGenerator(string garenteedEndPhrase)
        {
            string returnString = "";
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //For the first 6 char of each message
            string messageKey = "" + Alphabet[rand.Next() % 26] + Alphabet[rand.Next() % 26] + Alphabet[rand.Next() % 26];
            messageKey = messageKey + messageKey;
            returnString = messageKey;

            //allows 10^9 differnt messages to be generated
            string[] word1 = { "A", "THE", "SEVERAL", "FEW", "ONE", "TWO", "THREE", "MANY", "FOUR", "FIVE" };
            string[] word2 = { "BROWN", "RED", "BLACK", "WHITE", "LARGE", "SMALL", "GREEN", "BLUE", "YELLOW", "PURPLE" };
            string[] word3 = { "FOX", "DOG", "FISH", "FROG", "BIRD", "DINOSAUR", "BUG", "DEER", "HORSE", "COW" };
            string[] word4 = { "QUICKLY", "SLOWLY", "SKILLFULLY", "UNSKILLFULLY", "RAPIDLY", "LATHARGICALY", "SADLY", "HAPPILY", "CRAZILY", "WILDLY" };
            string[] word5 = { "RAN", "FLEW", "JUMPED", "SLEPT", "FELL", "HIT", "ATTACKED", "WALKED", "CRAWLED", "LEAPED" };
            string[] word6 = { "OVER", "UNDER", "AGAINST", "ON", "ATOP", "BELOW", "THREW", "BESIDE", "AROUND", "IN" };
            string[] word7 = { "A", "THE", "SEVERAL", "FEW", "ONE", "TWO", "THREE", "MANY", "FOUR", "FIVE" };
            string[] word8 = { "BROWN", "RED", "BLACK", "WHITE", "LARGE", "SMALL", "GREEN", "BLUE", "YELLOW", "PURPLE" };
            string[] word9 = { "WALL", "DOOR", "HILL", "CAVE", "JUNGLE", "SMALL", "PIT", "TREE", "ROCK", "MOUNTAIN" };

            returnString = returnString + word1[rand.Next() % word1.Length] + word2[rand.Next() % word2.Length] + word3[rand.Next() % word3.Length] + word4[rand.Next() % word4.Length];
            returnString = returnString + word5[rand.Next() % word5.Length] + word6[rand.Next() % word6.Length] + word7[rand.Next() % word7.Length] + word8[rand.Next() % word8.Length] + word9[rand.Next() % word9.Length];


            //the garentteed ending of the message like the heil hitler during WWII
            returnString = returnString + garenteedEndPhrase;

            return returnString;
        }

    }
}
