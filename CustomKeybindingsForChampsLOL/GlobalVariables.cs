using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomKeybindingsForChampsLOL
{
    class GlobalVariables
    {
        private static DetectGameStart mDetectGameStart;

        public GlobalVariables()
        {
            mDetectGameStart = new DetectGameStart();
        }

        public static string Separator
        {
            get { return ":"; }
            private set { }
        }
        
        public static string KeybindingFileName
        {
            get { return "KeyBindingInfo"; }
            private set { }
        }

          public static string LolGameLogsPath
        {
            get { return @"C:\Riot Games\League of Legends\Logs\Game - R3d Logs\"; }
            private set { }
        }

        public static string ApiKey
        {
            get { return "a844b973-c48a-49b8-91da-50cf9e4f9cbe"; }
            private set { }
        }

        public static DetectGameStart DetectGameStart
        {
            get { return mDetectGameStart; }
            private set { }
        }
     

    }
}
