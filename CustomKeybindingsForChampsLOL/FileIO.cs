using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomKeybindingsForChampsLOL
{
    class FileIO
    {
        private string mPathToInputFile;
        private string mDataPath;

        public FileIO()
        {
            mPathToInputFile = @"C:\Riot Games\League of Legends\Config\input.ini";
            mDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            /*using (Stream stream = File.Create(@"C:\Users\philip\Documents\DebugMessages\DebugMessage2.txt"))
            {
                TextWriter tw = new StreamWriter(stream); 
                tw.WriteLine(GetNewestFileInDirectory(@"C:\Riot Games\League of Legends\Logs\Game - R3d Logs\"));
                tw.Close();
            }*/
        }
        public bool FilesExistInDataDirectory(string pFileName)
        {
            return File.Exists(mDataPath + @"\" + pFileName);
        }

        public void WriteFileToDataDirectory(string pFileName,string pContentOfFile)
        {
            File.WriteAllText(mDataPath + @"\"+pFileName, pContentOfFile);
        }

       public string GetFileFromDataDirectory(string pFileName)
        {
            if (File.Exists(mDataPath + @"\" + pFileName))
            {
                return File.ReadAllText(mDataPath + @"\" + pFileName);
            }
            return "FILE DOSN'T EXIST";
        }

        public string GetInputText()
        {
            return GetText(mPathToInputFile);
        }

        public string GetText(string pPath)
        {
            string tText = "";

            using (FileStream stream = File.Open(pPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        tText += reader.ReadLine() + Environment.NewLine;
                    }
                }
            }

            return tText;
        }

        public string GetLineWithText(string pNewText)
        {
            string tInputText = GetInputText();
            int tStartOfKeyBinding = tInputText.IndexOf(pNewText);
            int tEndOfKeyBinding = tInputText.IndexOf("\r", tStartOfKeyBinding);

            return tInputText.Substring(tStartOfKeyBinding, tEndOfKeyBinding - tStartOfKeyBinding);
        }

        public string GetNewestFileInDirectory(string pPathToDirectory)
        {
            DirectoryInfo tDirectioryInfo =  new DirectoryInfo(pPathToDirectory);

            DateTime tLowestDateTime = new DateTime(1, 1, 1,0,0,0);
            string tPathToNewestFile = "";

            foreach (FileInfo tFileInfo in tDirectioryInfo.GetFiles())
            {

                DateTime tFileDateTime = tFileInfo.CreationTime;
                TimeSpan tDiffDate = tFileDateTime.Subtract(tLowestDateTime);
                if (tDiffDate.TotalDays >= 0 && tDiffDate.TotalHours >= 0 && tDiffDate.TotalMinutes > 0 && tDiffDate.TotalSeconds > 0)
                {
                    tLowestDateTime = tFileDateTime;
                    tPathToNewestFile = tFileInfo.FullName;
                }
            }

            return GetText(tPathToNewestFile);    
        }

  

        public bool IsTextInFile(string pTextToSearchFor)
        {
            bool tTextIsInFile = false;

            string tInputText = File.ReadAllText(mPathToInputFile);
            
            if(tInputText.IndexOf(pTextToSearchFor) != -1)
            {
                tTextIsInFile = true;
            }

            return tTextIsInFile;
        }

        public void OverwriteInputfile(string pNewContent)
        {
            using (FileStream stream = new FileStream(mPathToInputFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter tWriter = new StreamWriter(stream))
                {
                    int tEndReached = 0;
                    int tCurrentSearchPosition = 0;

                    while(tEndReached >= 0)
                    {                        
                        tEndReached = pNewContent.IndexOf(Environment.NewLine, tCurrentSearchPosition+Environment.NewLine.Length);
                        if (tEndReached >= 0)
                        {
                            tWriter.WriteLine(pNewContent.Substring(tCurrentSearchPosition, tEndReached - tCurrentSearchPosition)
                                +Environment.NewLine.Length);
                            tCurrentSearchPosition = tEndReached;
                        }
                    }
                }
            }
           
        }

    }
}
