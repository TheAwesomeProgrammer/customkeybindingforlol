using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomKeybindingsForChampsLOL
{
    class KeybindingButton
    {
        private FileIO mFileIO;

        private string mKeybindText;
        private string mKeybindBlock;

        public KeybindingButton(string pKeybindText)
        {
            mFileIO = new FileIO();
            mKeybindText = pKeybindText;
            mKeybindBlock = "[GameEvents]";
        }

        public void ChangeKeybinding(string pNewContent)
        {
            string tInputText = mFileIO.GetInputText();

            string tInputFileWithNewKeybind = "";

            if (tInputText.LastIndexOf(mKeybindText) > tInputText.IndexOf(mKeybindBlock))
            {
                tInputFileWithNewKeybind = tInputText.Remove(tInputText.LastIndexOf(mKeybindText), mFileIO.GetLineWithText(mKeybindText).Length-1);
                tInputFileWithNewKeybind = tInputFileWithNewKeybind.Insert(tInputText.LastIndexOf(mKeybindText), 
                    mKeybindText + "=" + pNewContent + Environment.NewLine);
            }
            else
            {
                int tEndOfKeybindBlock = tInputText.IndexOf(mKeybindBlock)+ mKeybindBlock.Length;
                tInputFileWithNewKeybind = tInputText.Insert(tEndOfKeybindBlock, Environment.NewLine + mKeybindText + "=" + pNewContent);
                
            }

            mFileIO.OverwriteInputfile(tInputFileWithNewKeybind);
        }

    }
}
