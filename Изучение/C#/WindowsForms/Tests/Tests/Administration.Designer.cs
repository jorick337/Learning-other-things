namespace TestForUser
{
    partial class Administration
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
            btnCreater = new Button();
            btnChanges = new Button();
            BtnMenu = new Button();
            BtnToTests = new Button();
            SuspendLayout();
            // 
            // btnCreater
            // 
            btnCreater.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreater.Location = new Point(10, 50);
            btnCreater.Name = "btnCreater";
            btnCreater.Size = new Size(170, 40);
            btnCreater.TabIndex = 0;
            btnCreater.Text = "Конструктор";
            btnCreater.UseVisualStyleBackColor = true;
            btnCreater.Click += btnCreater_Click;
            // 
            // btnChanges
            // 
            btnChanges.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnChanges.Location = new Point(10, 100);
            btnChanges.Name = "btnChanges";
            btnChanges.Size = new Size(170, 40);
            btnChanges.TabIndex = 2;
            btnChanges.Text = "Экземпляры";
            btnChanges.UseVisualStyleBackColor = true;
            btnChanges.Click += btnChanges_Click;
            // 
            // BtnMenu
            // 
            BtnMenu.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnMenu.Location = new Point(10, 4);
            BtnMenu.Name = "BtnMenu";
            BtnMenu.Size = new Size(170, 40);
            BtnMenu.TabIndex = 3;
            BtnMenu.Text = "Меню";
            BtnMenu.UseVisualStyleBackColor = true;
            BtnMenu.Click += BtnMenu_Click;
            // 
            // BtnToTests
            // 
            BtnToTests.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnToTests.Location = new Point(10, 146);
            BtnToTests.Name = "BtnToTests";
            BtnToTests.Size = new Size(170, 40);
            BtnToTests.TabIndex = 4;
            BtnToTests.Text = "К тестам";
            BtnToTests.UseVisualStyleBackColor = true;
            BtnToTests.Click += BtnToTests_Click;
            // 
            // Administration
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnToTests);
            Controls.Add(BtnMenu);
            Controls.Add(btnChanges);
            Controls.Add(btnCreater);
            Name = "Administration";
            Text = "Administration";
            FormClosed += Administration_FormClosed;
            Load += Administration_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreater;
        private Button btnChanges;
        private DataGridView dataGridView1;
        private Button BtnMenu;
        private Button BtnToTests;
    }
}