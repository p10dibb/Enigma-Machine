using System;
using System.Collections.Generic;
using System.Text;

namespace Bombe_BruteForce
{
    class Cracker
    {

        Dictionary<char, char> AD = new Dictionary<char, char>();
        Dictionary<char, char> BE = new Dictionary<char, char>();
        Dictionary<char, char> CF = new Dictionary<char, char>();

        //this.generatePermutationDict(message_key_encrypts);

        public void runner()
        {
            List<string> message_key_encrypts = new List<string>(){"ESQWUQ", "WULGNP", "ZEVUMG", "COWNTR", "WLEGZX", "KFOPPO", "NEKFMZ", "XETJMD", "SQAISY", "UQGRSK", "YVMBOC", "JJMQHC", "DACZLS", "ZBXURF", "VZSDQE", "FLOMZO", "SRZIII", "CPGNKK", "FEGMMK", "VILDVP", "PDQLFQ", "SBGIRK", "EJHWHB", "JTYQGM", "TNLOYP", "XLMJZC", "FYKMDZ", "ZWAUBY", "OXGEAK", "BYDVDV", "YMCBCS", "JFQQPQ", "RQLSSP", "BWYVBM", "FRIMIL", "YLMBZC", "WJIGHL", "UMFRCH", "XMKJCZ", "HUFANH", "UTNRGJ", "VCXDWF", "VZUDQT", "EMBWCN", "KRRPIU", "SHBIEN", "RCVSWG", "BUUVNT", "ASNKUJ", "RAISLL", "XKRJXU", "KJNPHJ", "NDKFFZ", "NUQFNQ", "GZMHQC", "BMRVCU", "GMHHCB", "PSZLUI", "ZRAUIY", "AMHKCB", "IEDCMV", "TPGOKK", "VSADUY", "NSKFUZ", "EVTWOD", "OHHEEB", "CRSNIE", "IDUCFT", "UHBREN", "DYXZDF", "JYJQDA", "BTWVGR", "LRTXID", "WNPGYW", "SBSIRE", "KDFPFH", "FCOMWO", "WTFGGH", "WXHGAB", "VURDNU", "AAJKLA", "FIGMVK", "OKREXU", "FIKMVZ", "JPPQKW", "EXVWAG", "XFQJPQ", "GVFHOH", "NEUFMT", "UMDRCV", "EGWWJR", "XLEJZX", "CEWNMR", "QCGTWK", "KLZPZI", "WBZGRI", "YKEBXX", "TYNODJ", "OFYEPM", "UELRMP", "BJOVHO", "HLMAZC", "YVNBOJ", "NWYFBM", "ZYCUDS", "SSJIUA", "HFCAPS", "EZHWQB", "PYRLDU", "ONFEYH", "JJMQHC", "DJSZHE", "ROHSTB", "YLDBZV", "SOKITZ", "GRQHIQ", "JFCQPS", "DRKZIZ", "PMSLCE", "PXPLAW", "UBGRRK", "NRBFIN", "HCGAWK", "YQBBSN", "EQCWSS", "ABNKRJ", "VDXDFF", "OWLEBP", "HNSAYE", "KPYPKM", "UIRRVU", "KZIPQL", "OUFENH", "VGSDJE", "DHZZEI", "OJAEHY", "IMSCCE", "NZUFQT", "NGGFJK", "QPKTKZ", "RWVSBG", "MUDYNV"};


            //this.generateDictionaryKey(message_key_encrypts);
            //this.printPermutationDict(CF);


            //List<string> BECHAIN = this.makeChainsFromPermutatuinDict(BE);

            //foreach (string a in BECHAIN)
            //{
            //    Console.WriteLine(a);
            //}

            Console.WriteLine(this.generateDictionaryKey(message_key_encrypts));



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

            for (int i = 0; i < message_encrypts.Count; i++)
            {     



                string currentMessage = message_encrypts[i];
                if (AD[currentMessage[0]]=='\0')
                {
                    if (currentMessage[0] == 'L')
                    {
                        Console.WriteLine();
                    }
                    AD[currentMessage[0]] = currentMessage[3];
                }
                if (BE[currentMessage[1]] == '\0')
                {
                BE[currentMessage[1]] = currentMessage[4];
                }
                if (CF[currentMessage[2]] == '\0')
                {

                CF[currentMessage[2]] = currentMessage[5];
                }

            }

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
    }
}
