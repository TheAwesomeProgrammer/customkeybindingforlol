using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace CustomKeybindingsForChampsLOL
{
    public enum PlatformType
    {
        EUW,
        NA,
        BR,
        LA,
        OC,
        EUNE,
        TR,
        RU,
        KR
    }

    public class Platform
    {
        public PlatformType Type;
        public string ID;
        
        public Platform(PlatformType pPlatformType,string pPlatformID)
        {
            Type = pPlatformType;
            ID = pPlatformID;
        }
    } 

    class SummonerInfo
    {
        public List<Platform> mPlatforms = new List<Platform>();

        public SummonerInfo()
        {
            mPlatforms = new List<Platform>();
        }

        void AddPlatforms(string[] pPlatformIDs,List<Platform> pPlatforms)
        {
            int tCounter = 0;

            foreach (PlatformType tPlatformType in Enum.GetValues(typeof(PlatformType)))
            {
                pPlatforms.Add(new Platform(tPlatformType, pPlatformIDs[tCounter]));
                tCounter++;
            }
        }



        public string FindValueInJSON(string pJson,string pIDOfJsonValue)
        {
            string tValueWithIDInJson = "";

            bool tFoundID = false;

            JsonTextReader reader = new JsonTextReader(new StringReader(pJson));

            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    string tValue = reader.Value.ToString(); 
                              
                    if(tFoundID)
                    {
                        tValueWithIDInJson = tValue;
                        break;
                    }

                    if(tValue.ToLower() == pIDOfJsonValue.ToLower())
                    {
                        tFoundID = true;
                    }       
                }
            }

            return tValueWithIDInJson;
        }

        public string Search(string pUrlToSearch)
        {

            WebClient myClient = new WebClient();
            string tDataFromInternet = "";

            try
            {
                Stream response = myClient.OpenRead(pUrlToSearch);
            

                using (StreamReader tStreamReader = new StreamReader(response))
                {
                    tDataFromInternet += tStreamReader.ReadLine();
                }

                response.Close();
            }
            catch(WebException pWebException)
            {
                using (StreamWriter stream = File.AppendText(@"C:\Users\philip\Documents\DebugMessages\DebugMessage2.txt"))
                {                    
                        stream.WriteLine("ERROR"+ pWebException.Response);
                        stream.Close();                    
                }
            }


            return tDataFromInternet;
        }

        
        public void StartSearch()
        {
            string tSummonerJson = Search("https://euw.api.pvp.net/api/lol/euw/v1.4/summoner/by-name/awesomeprogramme?api_key=" + GlobalVariables.ApiKey);
            int tSummonerID = 0;
            int.TryParse(FindValueInJSON(tSummonerJson, "id"),out tSummonerID);
            string tJsonInGame = Search(@"https://euw.api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/EUW1/"+tSummonerID+"?api_key=" + GlobalVariables.ApiKey);
            string tChampID = FindValueInJSON(tJsonInGame, "championId");
            if(tChampID != "")
            {
                string tJsonChampInfo= Search(@"https://global.api.pvp.net/api/lol/static-data/euw/v1.2/champion/" + tChampID + "?champData=info&api_key=a844b973-c48a-49b8-91da-50cf9e4f9cbe");
                string tChampName = FindValueInJSON(tJsonChampInfo, "name");
                GlobalVariables.DetectGameStart.ChangeInputFile(tChampName);
                GlobalVariables.DetectGameStart.Stop();
                try
                {
                    using (StreamWriter stream = File.AppendText(@"C:\Users\philip\Documents\DebugMessages\DebugMessage2.txt"))
                    {
                        stream.WriteLine("FOUND GAME " + tChampName);
                        stream.Close();
                    }
                }
                catch (IOException IOException)
                {

                }
            }
     
          
        }



    }
}
