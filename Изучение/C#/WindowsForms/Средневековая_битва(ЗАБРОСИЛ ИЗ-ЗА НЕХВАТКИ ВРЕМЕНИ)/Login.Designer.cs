namespace Средневековая_битва
{
    partial class Login
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
            btnLogin = new Button();
            textBoxName = new TextBox();
            textBoxPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(124, 213);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(90, 39);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxName.Location = new Point(89, 37);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Имя пользователя";
            textBoxName.Size = new Size(167, 30);
            textBoxName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(89, 73);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.Size = new Size(167, 30);
            textBoxPassword.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 264);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxName);
            Controls.Add(btnLogin);
            Name = "Login";
            Text = "Login";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox textBoxName;
        private TextBox textBoxPassword;
    }
}