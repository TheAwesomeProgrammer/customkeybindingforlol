using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomKeybindingsForChampsLOL
{
    class KeybindingNamesConverter
    {
        private static List<KeybindingNameConverter> mKeybindingNames;

        public KeybindingNamesConverter()
        {
            mKeybindingNames = new List<KeybindingNameConverter>();
            mKeybindingNames.Add(new KeybindingNameConverter("Spell 1", "evtCastSpell1"));
            mKeybindingNames.Add(new KeybindingNameConverter("Spell 2", "evtCastSpell2"));
            mKeybindingNames.Add(new KeybindingNameConverter("Spell 3", "evtCastSpell3"));
            mKeybindingNames.Add(new KeybindingNameConverter("Spell 4", "evtCastSpell4"));
        }

        public static string ConvertFromUINameToInGameName(string pUIName)
        {
            KeybindingNameConverter tKeybindingNameConverter = mKeybindingNames.Find(item => item.UIName.Contains(pUIName));

            if(tKeybindingNameConverter != null)
            {
                return tKeybindingNameConverter.InGameName;
            }

            return "";
           
        }

    }

    class KeybindingNameConverter
    {
        public string UIName { get; private set; }
        public string InGameName { get; private set; }

        public KeybindingNameConverter(string pUIName,string pInGameName)
        {
            UIName = pUIName;
            InGameName = pInGameName;
        }
    }
}
