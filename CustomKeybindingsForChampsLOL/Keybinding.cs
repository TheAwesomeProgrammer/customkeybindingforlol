using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomKeybindingsForChampsLOL
{
    class Keybinding
    {
        private string mKeybinding;
        private string mKeybindingValue;
        private string mChampion;

        private FileIO mFileIO;        

        public Keybinding(string pChampion)
        {
            Init();
            mChampion = pChampion; 
            string tKeybindingInfo = LoadKeybindingInfo(mChampion, GlobalVariables.KeybindingFileName + ".txt");
            mKeybinding = tKeybindingInfo.Substring(0,tKeybindingInfo.IndexOf(GlobalVariables.Separator));

            mKeybindingValue = tKeybindingInfo.Substring(tKeybindingInfo.IndexOf(GlobalVariables.Separator), 
                tKeybindingInfo.IndexOf(Environment.NewLine)- tKeybindingInfo.IndexOf(GlobalVariables.Separator));
        }

        public Keybinding(string pChampion, string pKeybinding, string pKeybindingValue)
        {
            Init();
            mChampion = pChampion;
            mKeybinding = pKeybinding;
            mKeybindingValue = pKeybindingValue;
            SaveKeybindingInfo(mChampion, pKeybinding, GlobalVariables.KeybindingFileName+".txt",pKeybindingValue);
        }

        void Init()
        {
            mFileIO = new FileIO();
        }

      

        void SaveKeybindingInfo(string pChampion,string pKeybinding,string pFileName,string pKeybindingValue)
        {
            string tDataFile = mFileIO.GetFileFromDataDirectory(pFileName);
            int tKeybindingExist = tDataFile.IndexOf(pChampion+ GlobalVariables.Separator + pKeybinding);

            if(tKeybindingExist <= -1)
            {
                tDataFile += pChampion + GlobalVariables.Separator+ pKeybinding + 
                    GlobalVariables.Separator+ pKeybindingValue + Environment.NewLine;               
            }
            else if(tKeybindingExist > -1)
            {
                int tKeybindingStart = tDataFile.IndexOf(pChampion + GlobalVariables.Separator + pKeybinding) + pChampion.Length + GlobalVariables.Separator.Length;
                int tKeybindingEnd = tDataFile.IndexOf(Environment.NewLine, tKeybindingStart);
                tDataFile = tDataFile.Replace(tDataFile.Substring(tKeybindingStart, tKeybindingEnd - tKeybindingStart),
                    pKeybinding + GlobalVariables.Separator+ pKeybindingValue);
            }

            mFileIO.WriteFileToDataDirectory(pFileName, tDataFile);
        }

        string LoadKeybindingInfo(string pChampion,string pFileName)
        {
            string tDataFile = mFileIO.GetFileFromDataDirectory(pFileName);
            int tKeybindingStart = tDataFile.IndexOf(pChampion) + pChampion.Length + GlobalVariables.Separator.Length;
            int tKeybindingEnd = tDataFile.IndexOf(Environment.NewLine, tKeybindingStart);

            return tDataFile.Substring(tKeybindingStart, tKeybindingEnd - tKeybindingStart);
        }
       

    }
}
