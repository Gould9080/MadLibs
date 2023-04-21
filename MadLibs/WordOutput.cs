using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MadLibs
{
    public class WordOutput
    {
        // class to output random words from list
        public string NounFile { get; private set; }
        public string VerbFile { get; private set; }
        public string AdjectiveFile { get; private set; }
        public string AdverbFile { get; private set; }


        private string filePath = @"C:\Users\Student\source\repos\JamesSideProjects\MadLibs\";

        private string nounFile = "nouns.txt";
        private string verbFile = "verbs.txt";
        private string adjectiveFile = "adjectives.txt";
        private string adverbFile = "adverbs.txt";

        public WordOutput()
        {
            this.NounFile = filePath + nounFile;
            this.VerbFile = filePath + verbFile;
            this.AdjectiveFile = filePath + adjectiveFile;
            this.AdverbFile = filePath + adverbFile;
        }

        public List<string> NounList = new List<string>();
        public List<string> VerbList = new List<string>();
        public List<string> AdjectiveList = new List<string>();
        public List<string> AdverbList = new List<string>();
        public List<List<string>> TotalWordList = new List<List<string>>();

        public void LoadVerbs()
        {
            using(StreamReader reader = new StreamReader(VerbFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    VerbList.Add(line);
                }
            }
        }







        // List Shuffler
        private readonly Random randomizer = new Random();

        public void ShuffleList(List<string> list)
        {
            
            int i = list.Count;
            while (i > 1)
            {
                i--;
                int j = randomizer.Next(i + 1);
                string value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
            
            /*
            for (int i = list.Count-1; i >= 0; i--)
            {
                int j = randomizer.Next(i + 1);
                string value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
            */
        }

    }
}
