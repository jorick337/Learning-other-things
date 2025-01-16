namespace TestForUser
{
    partial class ChoiceTests
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
            LabelWithNameUser = new Label();
            BtnExit = new Button();
            BtnChangePasswordUser = new Button();
            LabelWithPasswordUser = new Label();
            SuspendLayout();
            // 
            // LabelWithNameUser
            // 
            LabelWithNameUser.AutoSize = true;
            LabelWithNameUser.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelWithNameUser.Location = new Point(12, 9);
            LabelWithNameUser.Name = "LabelWithNameUser";
            LabelWithNameUser.Size = new Size(30, 25);
            LabelWithNameUser.TabIndex = 1;
            LabelWithNameUser.Text = "...";
            // 
            // BtnExit
            // 
            BtnExit.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnExit.Location = new Point(10, 400);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(170, 40);
            BtnExit.TabIndex = 2;
            BtnExit.Text = "Выйти";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnChangePasswordUser
            // 
            BtnChangePasswordUser.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            BtnChangePasswordUser.Location = new Point(12, 139);
            BtnChangePasswordUser.Name = "BtnChangePasswordUser";
            BtnChangePasswordUser.Size = new Size(170, 40);
            BtnChangePasswordUser.TabIndex = 3;
            BtnChangePasswordUser.Text = "Сменить";
            BtnChangePasswordUser.UseVisualStyleBackColor = true;
            BtnChangePasswordUser.Click += BtnChangePasswordUser_Click;
            // 
            // LabelWithPasswordUser
            // 
            LabelWithPasswordUser.AutoSize = true;
            LabelWithPasswordUser.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LabelWithPasswordUser.Location = new Point(12, 81);
            LabelWithPasswordUser.Name = "LabelWithPasswordUser";
            LabelWithPasswordUser.Size = new Size(30, 25);
            LabelWithPasswordUser.TabIndex = 4;
            LabelWithPasswordUser.Text = "...";
            // 
            // ChoiceTests
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LabelWithPasswordUser);
            Controls.Add(BtnChangePasswordUser);
            Controls.Add(BtnExit);
            Controls.Add(LabelWithNameUser);
            Name = "ChoiceTests";
            Text = "Тесты";
            FormClosed += ChoiceTests_FormClosed;
            Load += ChoiceTests_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LabelWithNameUser;
        private Button BtnExit;
        private Button BtnChangePasswordUser;
        private Label LabelWithPasswordUser;
    }
}