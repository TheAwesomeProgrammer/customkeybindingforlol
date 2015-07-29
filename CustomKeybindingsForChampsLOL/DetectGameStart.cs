using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace CustomKeybindingsForChampsLOL
{
    class DetectGameStart
    {
        private int mNumberOfFiles;

        private FileIO mFileIO;

        private Timer mTimer;
        
        public DetectGameStart()
        {
            mTimer = new Timer();
            Start();
            mFileIO = new FileIO();
            mNumberOfFiles = new DirectoryInfo(GlobalVariables.LolGameLogsPath).GetFiles().Length;
        }

        public void Start()
        {            
            mTimer.Elapsed += new ElapsedEventHandler(Detecting);
            mTimer.Interval = 500;
            mTimer.Enabled = true;
        }

        public void Stop()
        {
            mTimer.Stop();
            mTimer.Enabled = false;
        }

        void Detecting(object source, ElapsedEventArgs e)
        {
            if (mNumberOfFiles != new DirectoryInfo(GlobalVariables.LolGameLogsPath).GetFiles().Length)
            {
                new SummonerInfo().StartSearch();            
            }

            mNumberOfFiles = new DirectoryInfo(GlobalVariables.LolGameLogsPath).GetFiles().Length;
        }

        public void ChangeInputFile(string pChampName)
        {         
            string tKeybindings = mFileIO.GetFileFromDataDirectory(GlobalVariables.KeybindingFileName + ".txt").ToLower();
            string tChampName = pChampName.ToLower();
            int tKeybindingExist = 0;
            int tSearchStartPoint = 0;
            while (tKeybindingExist >= 0)
            {
                tKeybindingExist = tKeybindings.IndexOf(tChampName + GlobalVariables.Separator, tSearchStartPoint);
                if (tKeybindingExist >= 0)
                {
                    int tStartOfKeybinding = tKeybindingExist + tChampName.Length + GlobalVariables.Separator.Length;
                    int tEndOfKeybinding = tKeybindings.IndexOf(GlobalVariables.Separator, tStartOfKeybinding);
                    string tKeybindingInGameName = KeybindingNamesConverter.ConvertFromUINameToInGameName(
                        tKeybindings.Substring(tStartOfKeybinding, tEndOfKeybinding - tStartOfKeybinding));

                    int tStartOfKeybindingValue = tEndOfKeybinding + GlobalVariables.Separator.Length;
                    int tEndOfKeybindingValue = tKeybindings.IndexOf(Environment.NewLine, tStartOfKeybindingValue);

                    string tKeybindingValue = tKeybindings.Substring(tStartOfKeybindingValue, tEndOfKeybindingValue - tStartOfKeybindingValue);

                    SetInputFileNewValues(tKeybindingInGameName, tKeybindingValue);

                    tSearchStartPoint = tEndOfKeybinding;
                }
            }
        }

        void SetInputFileNewValues(string pKeybinding, string pKeybindingValue)
        {
            string tInputFile = mFileIO.GetInputText();

            int tStartOfInputKeybinding = tInputFile.IndexOf(pKeybinding+"=");

            if (tStartOfInputKeybinding >= 0)
            {
                int tEndOfInputKeybinding = tInputFile.IndexOf(Environment.NewLine, tStartOfInputKeybinding);

                string tKeybindingFromInput = tInputFile.Substring(tStartOfInputKeybinding, tEndOfInputKeybinding - tStartOfInputKeybinding);

                tInputFile =  tInputFile.Replace(tKeybindingFromInput, pKeybinding + "=" + pKeybindingValue);
            }
            else if(tStartOfInputKeybinding < 0)
            {
                tInputFile += pKeybinding + "=" + pKeybindingValue;
            }

            mFileIO.OverwriteInputfile(tInputFile);
        }
    }

}
