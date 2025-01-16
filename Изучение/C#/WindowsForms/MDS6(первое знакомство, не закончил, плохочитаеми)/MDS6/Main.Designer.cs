namespace MDS6
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxName = new TextBox();
            textBoxHealth = new TextBox();
            textBoxDamage = new TextBox();
            buttonCreatePerson = new Button();
            groupBox1 = new GroupBox();
            labelInfoHero = new Label();
            btnAddPlayer = new Button();
            btnAcceptHero = new Button();
            groupBox2 = new GroupBox();
            labelInfoMap = new Label();
            btnAcceptMap = new Button();
            btnMapCreate = new Button();
            textBoxMapY = new TextBox();
            textBoxMapX = new TextBox();
            panelMapSee = new Panel();
            groupBox3 = new GroupBox();
            labelGameAspect = new Label();
            btnRunGame = new Button();
            flowLayoutPanelPlayers = new FlowLayoutPanel();
            flowLayoutPanelInfoPlayersMap = new FlowLayoutPanel();
            panelMaps = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxName.Location = new Point(12, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Имя";
            textBoxName.Size = new Size(122, 30);
            textBoxName.TabIndex = 0;
            // 
            // textBoxHealth
            // 
            textBoxHealth.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxHealth.Location = new Point(12, 48);
            textBoxHealth.Name = "textBoxHealth";
            textBoxHealth.PlaceholderText = "Здоровье";
            textBoxHealth.Size = new Size(121, 30);
            textBoxHealth.TabIndex = 1;
            // 
            // textBoxDamage
            // 
            textBoxDamage.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDamage.Location = new Point(12, 84);
            textBoxDamage.Name = "textBoxDamage";
            textBoxDamage.PlaceholderText = "Урон";
            textBoxDamage.Size = new Size(121, 30);
            textBoxDamage.TabIndex = 2;
            // 
            // buttonCreatePerson
            // 
            buttonCreatePerson.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCreatePerson.Location = new Point(12, 120);
            buttonCreatePerson.Name = "buttonCreatePerson";
            buttonCreatePerson.Size = new Size(122, 31);
            buttonCreatePerson.TabIndex = 3;
            buttonCreatePerson.Text = "Create person";
            buttonCreatePerson.UseVisualStyleBackColor = true;
            buttonCreatePerson.Click += buttonCreatePerson_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelInfoHero);
            groupBox1.Controls.Add(btnAddPlayer);
            groupBox1.Controls.Add(btnAcceptHero);
            groupBox1.Location = new Point(14, 157);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 165);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // labelInfoHero
            // 
            labelInfoHero.AutoSize = true;
            labelInfoHero.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelInfoHero.Location = new Point(6, 17);
            labelInfoHero.Name = "labelInfoHero";
            labelInfoHero.Size = new Size(24, 19);
            labelInfoHero.TabIndex = 7;
            labelInfoHero.Text = "...";
            // 
            // btnAddPlayer
            // 
            btnAddPlayer.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddPlayer.Location = new Point(6, 113);
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Size = new Size(164, 46);
            btnAddPlayer.TabIndex = 15;
            btnAddPlayer.Text = "Добавить игрока на карту";
            btnAddPlayer.UseVisualStyleBackColor = true;
            btnAddPlayer.Click += btnAddPlayer_Click;
            // 
            // btnAcceptHero
            // 
            btnAcceptHero.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAcceptHero.Location = new Point(6, 75);
            btnAcceptHero.Name = "btnAcceptHero";
            btnAcceptHero.Size = new Size(164, 32);
            btnAcceptHero.TabIndex = 0;
            btnAcceptHero.Text = "Выбрать героя";
            btnAcceptHero.UseVisualStyleBackColor = true;
            btnAcceptHero.Click += btnAcceptHero_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelInfoMap);
            groupBox2.Controls.Add(btnAcceptMap);
            groupBox2.Location = new Point(378, 157);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(176, 165);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // labelInfoMap
            // 
            labelInfoMap.AutoSize = true;
            labelInfoMap.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelInfoMap.Location = new Point(6, 17);
            labelInfoMap.Name = "labelInfoMap";
            labelInfoMap.Size = new Size(24, 19);
            labelInfoMap.TabIndex = 7;
            labelInfoMap.Text = "...";
            // 
            // btnAcceptMap
            // 
            btnAcceptMap.BackColor = SystemColors.Control;
            btnAcceptMap.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAcceptMap.Location = new Point(6, 127);
            btnAcceptMap.Name = "btnAcceptMap";
            btnAcceptMap.Size = new Size(164, 32);
            btnAcceptMap.TabIndex = 0;
            btnAcceptMap.Text = "Выбрать карту";
            btnAcceptMap.UseVisualStyleBackColor = true;
            btnAcceptMap.Click += btnAcceptMap_Click;
            // 
            // btnMapCreate
            // 
            btnMapCreate.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMapCreate.Location = new Point(384, 120);
            btnMapCreate.Name = "btnMapCreate";
            btnMapCreate.Size = new Size(137, 31);
            btnMapCreate.TabIndex = 11;
            btnMapCreate.Text = "Создать карту";
            btnMapCreate.UseVisualStyleBackColor = true;
            btnMapCreate.Click += btnMapCreate_Click;
            // 
            // textBoxMapY
            // 
            textBoxMapY.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMapY.Location = new Point(418, 84);
            textBoxMapY.Name = "textBoxMapY";
            textBoxMapY.PlaceholderText = "Y";
            textBoxMapY.Size = new Size(28, 30);
            textBoxMapY.TabIndex = 9;
            // 
            // textBoxMapX
            // 
            textBoxMapX.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMapX.Location = new Point(384, 84);
            textBoxMapX.Name = "textBoxMapX";
            textBoxMapX.PlaceholderText = "X";
            textBoxMapX.Size = new Size(28, 30);
            textBoxMapX.TabIndex = 8;
            // 
            // panelMapSee
            // 
            panelMapSee.AutoScroll = true;
            panelMapSee.Location = new Point(560, 157);
            panelMapSee.Name = "panelMapSee";
            panelMapSee.Size = new Size(227, 159);
            panelMapSee.TabIndex = 12;
            panelMapSee.Paint += panelMapSee_Paint;
            panelMapSee.MouseDown += panelMapSee_MouseDown;
            panelMapSee.MouseUp += panelMapSee_MouseUp;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(labelGameAspect);
            groupBox3.Controls.Add(btnRunGame);
            groupBox3.Location = new Point(196, 157);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(176, 165);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            // 
            // labelGameAspect
            // 
            labelGameAspect.AutoSize = true;
            labelGameAspect.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelGameAspect.Location = new Point(6, 17);
            labelGameAspect.Name = "labelGameAspect";
            labelGameAspect.Size = new Size(24, 19);
            labelGameAspect.TabIndex = 7;
            labelGameAspect.Text = "...";
            // 
            // btnRunGame
            // 
            btnRunGame.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRunGame.Location = new Point(6, 127);
            btnRunGame.Name = "btnRunGame";
            btnRunGame.Size = new Size(164, 32);
            btnRunGame.TabIndex = 0;
            btnRunGame.Text = "Начать";
            btnRunGame.UseVisualStyleBackColor = true;
            btnRunGame.Click += btnRunGame_Click;
            // 
            // flowLayoutPanelPlayers
            // 
            flowLayoutPanelPlayers.AutoScroll = true;
            flowLayoutPanelPlayers.Location = new Point(140, 14);
            flowLayoutPanelPlayers.Name = "flowLayoutPanelPlayers";
            flowLayoutPanelPlayers.Size = new Size(238, 137);
            flowLayoutPanelPlayers.TabIndex = 14;
            flowLayoutPanelPlayers.Paint += flowLayoutPanelPlayers_Paint;
            // 
            // flowLayoutPanelInfoPlayersMap
            // 
            flowLayoutPanelInfoPlayersMap.AutoScroll = true;
            flowLayoutPanelInfoPlayersMap.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelInfoPlayersMap.Location = new Point(384, 12);
            flowLayoutPanelInfoPlayersMap.Name = "flowLayoutPanelInfoPlayersMap";
            flowLayoutPanelInfoPlayersMap.Size = new Size(137, 66);
            flowLayoutPanelInfoPlayersMap.TabIndex = 15;
            // 
            // panelMaps
            // 
            panelMaps.AutoScroll = true;
            panelMaps.FlowDirection = FlowDirection.RightToLeft;
            panelMaps.Location = new Point(527, 14);
            panelMaps.Name = "panelMaps";
            panelMaps.Size = new Size(260, 137);
            panelMaps.TabIndex = 16;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 322);
            Controls.Add(panelMaps);
            Controls.Add(flowLayoutPanelInfoPlayersMap);
            Controls.Add(flowLayoutPanelPlayers);
            Controls.Add(groupBox3);
            Controls.Add(panelMapSee);
            Controls.Add(btnMapCreate);
            Controls.Add(textBoxMapY);
            Controls.Add(textBoxMapX);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonCreatePerson);
            Controls.Add(textBoxDamage);
            Controls.Add(textBoxHealth);
            Controls.Add(textBoxName);
            Name = "Main";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxHealth;
        private TextBox textBoxDamage;
        private Button buttonCreatePerson;
        private GroupBox groupBox1;
        private Button btnAcceptHero;
        private Label labelInfoHero;
        private GroupBox groupBox2;
        private Label labelInfoMap;
        private Button btnAcceptMap;
        private Button btnMapCreate;
        private TextBox textBoxMapY;
        private TextBox textBoxMapX;
        private Panel panelMapSee;
        private GroupBox groupBox3;
        private Label labelGameAspect;
        private Button btnRunGame;
        private FlowLayoutPanel flowLayoutPanelPlayers;
        private Button btnAddPlayer;
        private FlowLayoutPanel flowLayoutPanelInfoPlayersMap;
        private FlowLayoutPanel panelMaps;
    }
}