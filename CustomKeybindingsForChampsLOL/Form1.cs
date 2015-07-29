using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CustomKeybindingsForChampsLOL
{
    public partial class Form1 : Form
    {
        private FileIO mFileIO;

        public Form1()
        {
            new KeybindingNamesConverter();
            new GlobalVariables();
            InitializeComponent();
            mFileIO = new FileIO();
            CheckIfKeybindingFileExist();
        }

        void CheckIfKeybindingFileExist()
        {
            string tFileName = GlobalVariables.KeybindingFileName + ".txt";
            if (!mFileIO.FilesExistInDataDirectory(tFileName))
            {
                mFileIO.WriteFileToDataDirectory(tFileName, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tChooseKeybindingBoxText = this.ChooseKeybindingBox.Text;
            string tChampionSelectionBoxText = this.ChampionSelectionBox.Text;

            if(FindControlsWithTag(Controls).Exists(item => item.Tag.ToString().Contains(tChooseKeybindingBoxText)))
            {
                return;
            }
            if (this.ChooseKeybindingBox.FindStringExact(tChooseKeybindingBoxText) != -1)
            {
                Keybinding tKeybinding = new Keybinding(tChampionSelectionBoxText, tChooseKeybindingBoxText,"");
                AddNewKeybinding(tChooseKeybindingBoxText);               
            }
        }

        private List<Control> FindControlsWithTag(Control.ControlCollection pControls)
        {
            List<Control> tControlsWithTag = new List<Control>();
            List<Control.ControlCollection> tControlCollections = new List<Control.ControlCollection>();
            List<Control.ControlCollection> tControlCollectionsToAdd = new List<Control.ControlCollection>();
            tControlCollections.Add(pControls);

            while(tControlCollections.Count > 0)
            {
                for (int tControlCollectionNumber = 0; tControlCollectionNumber < tControlCollections.Count; tControlCollectionNumber++)
                {
                    foreach (Control tControl in tControlCollections[tControlCollectionNumber])
                    {
                        if (tControl.Tag != null)
                            tControlsWithTag.Add(tControl);

                        if (tControl.HasChildren)
                            tControlCollectionsToAdd.Add(tControl.Controls);
                    }       
                }

                tControlCollections.Clear();

                for (int tControlCollectionAddNumber = 0; tControlCollectionAddNumber < tControlCollectionsToAdd.Count; tControlCollectionAddNumber++)
                {
                    tControlCollections.Add(tControlCollectionsToAdd[tControlCollectionAddNumber]);
                }

                tControlCollectionsToAdd.Clear();

            }

            return tControlsWithTag;
        }

        void AddNewKeybinding(string pKeybindingText)
        {
            int tPanelNumber = this.panel1.Controls.Count;
            Panel tPanel = new Panel();
            tPanel.Size = new Size(this.panel1.Width, this.AddKeybinding.Height);
            tPanel.Location = new Point(0, tPanelNumber * (AddKeybinding.Height + 5));

            Label tLabel = new Label();
            tLabel.Text = "Nothing yet";
            tLabel.Height = this.AddKeybinding.Height;
            tLabel.Location = new Point(tPanel.Right - tLabel.Width,0);
            tLabel.Name = "Label" + GlobalVariables.Separator+tPanelNumber;

            Button tButton = new Button();
            tButton.Click += ButtonClick;
            tButton.Text = "Press to set keybinding";
            tButton.Tag = pKeybindingText;
            tButton.Name = "Button"+GlobalVariables.Separator+tPanelNumber;

            tPanel.Controls.Add(tButton);
            tPanel.Controls.Add(tLabel);

            this.panel1.Controls.Add(tPanel);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button tButtonSender = (Button)sender;
            tButtonSender.KeyDown += KeyPressDown;
        }

        private void KeyPressDown(object sender, KeyEventArgs e)
        {
            Button tButtonSender = (Button)sender;
            tButtonSender.Parent.Controls[1].Text = e.KeyCode.ToString();
            Keybinding tKeybinding = new Keybinding(this.ChampionSelectionBox.Text, tButtonSender.Tag.ToString(), e.KeyCode.ToString());
        }

        private void ChampionSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tChampionSelectionBoxText = this.ChampionSelectionBox.Text;

            if(this.ChampionSelectionBox.FindStringExact(tChampionSelectionBoxText) != -1)
            {
                this.AddKeybinding.Show();
                this.ChooseKeybindingBox.Show();
            }
        }
    }
}
