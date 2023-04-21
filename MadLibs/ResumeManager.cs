using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace MadLibs
{
    public class ResumeManager
    {
        // class that pulls a resume (currently .txt) and writes a new resume with words replaced.

        // so resume manager can call GetRandomWord
        WordOutput wordOutput = new WordOutput();

        public string InputResume { get; private set; }
        public string OutputResume { get; private set; }

        public ResumeManager()
        {
            this.InputResume = filePath + oldResume;
            this.OutputResume = filePath + newResume;
        }

        private string filePath = @"C:\Users\Student\source\repos\JamesSideProjects\MadLibs\";
        private string oldResume = "TestResume.txt";
        private string newResume = "BestResume.txt";


        public void FixResume()
        {
        // load words onto their lists from outside files
            wordOutput.LoadVerbs();
            // shuffle that list
            wordOutput.ShuffleList(wordOutput.VerbList);
            // open streamreader to read resume and writer to replace
            using (StreamReader reader = new StreamReader(InputResume))
            {
                using (StreamWriter writer = new StreamWriter(OutputResume))
                {
                    // counter to go up and represent index of VerbList
                    int verbCounter = 0;

                    while (!reader.EndOfStream)
                    {
                        // if more than one verb per line, will repeat the same verb
                        string readLine = reader.ReadLine();
                        string writeLine;
                        if (readLine.Contains("<verb>"))
                        {
                        writeLine = readLine.Replace("<verb>", wordOutput.VerbList[verbCounter]);
                        verbCounter++;
                        }
                       else
                        {
                         writeLine = readLine;
                        }

                        writer.WriteLine(writeLine);

                    }
                }
            }
        }




    }
}

