namespace CustomKeybindingsForChampsLOL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChampionSelectionBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddKeybinding = new System.Windows.Forms.Button();
            this.ChooseKeybindingBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ChampionSelectionBox
            // 
            this.ChampionSelectionBox.FormattingEnabled = true;
            this.ChampionSelectionBox.Items.AddRange(new object[] {
            "Aatrox",
            "Ahri",
            "Akali",
            "Alistar",
            "Amumu",
            "Anivia",
            "Annie",
            "Ashe",
            "Azir",
            "Bard",
            "Blitzcrank",
            "Brand",
            "Braum",
            "Caitlyn",
            "Cassiopeia",
            "Cho\'Gath",
            "Corki",
            "Darius",
            "Diana",
            "Dr.Mundo",
            "Draven",
            "Ekko",
            "Elise",
            "Evelynn",
            "Ezreal",
            "Fiddlesticks",
            "Fiora",
            "Fizz",
            "Galio",
            "Gangplank",
            "Garen",
            "Gnar",
            "Gragas",
            "Graves",
            "Hecarim",
            "Heimerdinger",
            "Irelia",
            "Janna",
            "Jarvan IV",
            "Jax",
            "Jayce",
            "Jinx",
            "Kalista",
            "Karma",
            "Karthus",
            "Kassadin",
            "Katarina",
            "Kayle",
            "Kennen",
            "Kha\'Zix",
            "Kog\'Maw",
            "LeBlanc",
            "LeeSin",
            "Leona",
            "Lissandra",
            "Lucian",
            "Lulu",
            "Lux",
            "Malphite",
            "Malzahar",
            "Maokai",
            "Master Yi",
            "MissFortune",
            "Mordekaiser",
            "Morgana",
            "Nami",
            "Nasus",
            "Nautilus",
            "Nidalee",
            "Nocturne",
            "Nunu",
            "Olaf",
            "Orianna",
            "Pantheon",
            "Poppy",
            "Quinn",
            "Rammus",
            "Rek\'Sai",
            "Renekton",
            "Rengar",
            "Riven",
            "Rumble",
            "Ryze",
            "Sejuani",
            "Shaco",
            "Shen",
            "Shyvana",
            "Singed",
            "Sion",
            "Sivir",
            "Skarner",
            "Sona",
            "Soraka",
            "Swain",
            "Syndra",
            "Tahm Kench",
            "Talon",
            "Taric",
            "Teemo",
            "Thresh",
            "Tristana",
            "Trundle",
            "Tryndamere",
            "TwistedFate",
            "Twitch",
            "Udyr",
            "Urgot",
            "Varus",
            "Vayne",
            "Veigar",
            "Vel\'Koz",
            "Vi",
            "Viktor",
            "Vladimir",
            "Volibear",
            "Warwick",
            "Wukong",
            "Xerath",
            "Xin Zhao",
            "Yasuo",
            "Yorick",
            "Zac",
            "Zed",
            "Ziggs",
            "Zilean",
            "Zyra"});
            this.ChampionSelectionBox.Location = new System.Drawing.Point(239, 29);
            this.ChampionSelectionBox.Name = "ChampionSelectionBox";
            this.ChampionSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.ChampionSelectionBox.TabIndex = 0;
            this.ChampionSelectionBox.SelectedIndexChanged += new System.EventHandler(this.ChampionSelectionBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(112, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Choose champion";
            // 
            // AddKeybinding
            // 
            this.AddKeybinding.Location = new System.Drawing.Point(115, 72);
            this.AddKeybinding.Name = "AddKeybinding";
            this.AddKeybinding.Size = new System.Drawing.Size(118, 23);
            this.AddKeybinding.TabIndex = 2;
            this.AddKeybinding.Tag = "";
            this.AddKeybinding.Text = "Add keybinding";
            this.AddKeybinding.UseVisualStyleBackColor = true;
            this.AddKeybinding.Visible = false;
            this.AddKeybinding.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChooseKeybindingBox
            // 
            this.ChooseKeybindingBox.FormattingEnabled = true;
            this.ChooseKeybindingBox.Items.AddRange(new object[] {
            "Spell 1",
            "Spell 2",
            "Spell 3",
            "Spell 4"});
            this.ChooseKeybindingBox.Location = new System.Drawing.Point(239, 74);
            this.ChooseKeybindingBox.Name = "ChooseKeybindingBox";
            this.ChooseKeybindingBox.Size = new System.Drawing.Size(121, 21);
            this.ChooseKeybindingBox.TabIndex = 3;
            this.ChooseKeybindingBox.Text = "Choose keybinding";
            this.ChooseKeybindingBox.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(115, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 234);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(509, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChooseKeybindingBox);
            this.Controls.Add(this.AddKeybinding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChampionSelectionBox);
            this.Name = "Form1";
            this.Text = "Custom keybindings for lol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ChampionSelectionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddKeybinding;
        private System.Windows.Forms.ComboBox ChooseKeybindingBox;
        private System.Windows.Forms.Panel panel1;
    }
}

