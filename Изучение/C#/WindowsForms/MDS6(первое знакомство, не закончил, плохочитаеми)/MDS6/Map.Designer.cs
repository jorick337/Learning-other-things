namespace MDS6
{
    partial class Map
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
            panelFight = new Panel();
            button1 = new Button();
            btnDefense = new Button();
            btnRunFight = new Button();
            btnAtack = new Button();
            panelInventory = new Panel();
            labelHeroDamage = new Label();
            labelHeroName = new Label();
            progressBarHeroHealth = new ProgressBar();
            panelMap = new Panel();
            panel3 = new Panel();
            button4 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            panel2 = new Panel();
            button3 = new Button();
            panelFight.SuspendLayout();
            panelInventory.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelFight
            // 
            panelFight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFight.Controls.Add(button1);
            panelFight.Location = new Point(929, 12);
            panelFight.Name = "panelFight";
            panelFight.Size = new Size(350, 546);
            panelFight.TabIndex = 1;
            panelFight.TabStop = true;
            panelFight.Paint += panelFight_Paint;
            // 
            // button1
            // 
            button1.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(-70, 351);
            button1.Name = "button1";
            button1.Size = new Size(71, 38);
            button1.TabIndex = 3;
            button1.Text = "Атаковать";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnDefense
            // 
            btnDefense.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDefense.Location = new Point(123, 3);
            btnDefense.Name = "btnDefense";
            btnDefense.Size = new Size(125, 38);
            btnDefense.TabIndex = 1;
            btnDefense.Text = "Защищаться";
            btnDefense.UseVisualStyleBackColor = true;
            btnDefense.Click += btnDefense_Click;
            // 
            // btnRunFight
            // 
            btnRunFight.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnRunFight.Location = new Point(254, 3);
            btnRunFight.Name = "btnRunFight";
            btnRunFight.Size = new Size(104, 38);
            btnRunFight.TabIndex = 2;
            btnRunFight.Text = "Убежать";
            btnRunFight.UseVisualStyleBackColor = true;
            btnRunFight.Click += btnRunFight_Click;
            // 
            // btnAtack
            // 
            btnAtack.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAtack.Location = new Point(3, 3);
            btnAtack.Name = "btnAtack";
            btnAtack.Size = new Size(118, 38);
            btnAtack.TabIndex = 0;
            btnAtack.Text = "Атаковать";
            btnAtack.UseVisualStyleBackColor = true;
            btnAtack.Click += btnAtack_Click;
            // 
            // panelInventory
            // 
            panelInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelInventory.Controls.Add(labelHeroDamage);
            panelInventory.Controls.Add(labelHeroName);
            panelInventory.Controls.Add(progressBarHeroHealth);
            panelInventory.Location = new Point(9, 595);
            panelInventory.Name = "panelInventory";
            panelInventory.Size = new Size(838, 146);
            panelInventory.TabIndex = 2;
            panelInventory.TabStop = true;
            // 
            // labelHeroDamage
            // 
            labelHeroDamage.AutoSize = true;
            labelHeroDamage.Font = new Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelHeroDamage.Location = new Point(3, 36);
            labelHeroDamage.Name = "labelHeroDamage";
            labelHeroDamage.Size = new Size(76, 33);
            labelHeroDamage.TabIndex = 2;
            labelHeroDamage.Text = "Урон";
            // 
            // labelHeroName
            // 
            labelHeroName.AutoSize = true;
            labelHeroName.Font = new Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelHeroName.Location = new Point(3, 3);
            labelHeroName.Name = "labelHeroName";
            labelHeroName.Size = new Size(64, 33);
            labelHeroName.TabIndex = 1;
            labelHeroName.Text = "Имя";
            // 
            // progressBarHeroHealth
            // 
            progressBarHeroHealth.Location = new Point(117, 6);
            progressBarHeroHealth.Name = "progressBarHeroHealth";
            progressBarHeroHealth.Size = new Size(228, 16);
            progressBarHeroHealth.TabIndex = 0;
            // 
            // panelMap
            // 
            panelMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMap.AutoScroll = true;
            panelMap.Location = new Point(12, 12);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(835, 655);
            panelMap.TabIndex = 0;
            panelMap.TabStop = true;
            panelMap.Paint += panelMap_Paint;
            panelMap.MouseMove += panelMap_MouseMove;
            panelMap.MouseUp += panelMap_MouseUp;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(button4);
            panel3.Location = new Point(9, 564);
            panel3.Name = "panel3";
            panel3.Size = new Size(838, 22);
            panel3.TabIndex = 5;
            panel3.TabStop = true;
            // 
            // button4
            // 
            button4.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(-70, 351);
            button4.Name = "button4";
            button4.Size = new Size(71, 38);
            button4.TabIndex = 3;
            button4.Text = "Атаковать";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnDefense);
            panel1.Controls.Add(btnRunFight);
            panel1.Controls.Add(btnAtack);
            panel1.Location = new Point(929, 564);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 85);
            panel1.TabIndex = 4;
            panel1.TabStop = true;
            // 
            // button2
            // 
            button2.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(-70, 351);
            button2.Name = "button2";
            button2.Size = new Size(71, 38);
            button2.TabIndex = 3;
            button2.Text = "Атаковать";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(button3);
            panel2.Location = new Point(913, 13);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 636);
            panel2.TabIndex = 4;
            panel2.TabStop = true;
            // 
            // button3
            // 
            button3.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(-70, 351);
            button3.Name = "button3";
            button3.Size = new Size(71, 38);
            button3.TabIndex = 3;
            button3.Text = "Атаковать";
            button3.UseVisualStyleBackColor = true;
            // 
            // Map
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1284, 753);
            Controls.Add(panelInventory);
            Controls.Add(panelFight);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panelMap);
            KeyPreview = true;
            Name = "Map";
            Text = "Map";
            WindowState = FormWindowState.Maximized;
            FormClosing += Map_FormClosing;
            FormClosed += Map_FormClosed;
            Load += Map_Load;
            KeyDown += Map_KeyDown;
            panelFight.ResumeLayout(false);
            panelInventory.ResumeLayout(false);
            panelInventory.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Panel panelFight;
        public Panel panelInventory;
        public Button btnRunFight;
        public Button btnDefense;
        public Button btnAtack;
        public ProgressBar progressBarHeroHealth;
        public Label labelHeroName;
        public Label labelHeroDamage;
        public Button button1;
        public Panel panelMap;
        public Panel panel1;
        public Button button2;
        public Panel panel2;
        public Button button3;
        public Panel panel3;
        public Button button4;
    }
}