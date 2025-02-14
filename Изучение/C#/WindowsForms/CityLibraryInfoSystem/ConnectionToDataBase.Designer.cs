namespace CityLibraryInfoSystem
{
    partial class ConnectionToDataBase
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
            textBox_ServerName = new TextBox();
            textBox_PasswordUser = new TextBox();
            textBox_NameUser = new TextBox();
            textBox_NameDatabase = new TextBox();
            label_HelpText = new Label();
            button_Connect = new Button();
            checkBox_ShowPasswordUser = new CheckBox();
            SuspendLayout();
            // 
            // textBox_ServerName
            // 
            textBox_ServerName.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_ServerName.Location = new Point(250, 78);
            textBox_ServerName.Name = "textBox_ServerName";
            textBox_ServerName.PlaceholderText = "Имя сервера";
            textBox_ServerName.Size = new Size(200, 39);
            textBox_ServerName.TabIndex = 0;
            textBox_ServerName.Text = "localhost";
            // 
            // textBox_PasswordUser
            // 
            textBox_PasswordUser.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_PasswordUser.Location = new Point(250, 213);
            textBox_PasswordUser.Name = "textBox_PasswordUser";
            textBox_PasswordUser.PasswordChar = '*';
            textBox_PasswordUser.PlaceholderText = "Пароль";
            textBox_PasswordUser.Size = new Size(200, 39);
            textBox_PasswordUser.TabIndex = 1;
            textBox_PasswordUser.Text = "12345";
            // 
            // textBox_NameUser
            // 
            textBox_NameUser.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_NameUser.Location = new Point(250, 168);
            textBox_NameUser.Name = "textBox_NameUser";
            textBox_NameUser.PlaceholderText = "Имя пользователя";
            textBox_NameUser.Size = new Size(200, 39);
            textBox_NameUser.TabIndex = 2;
            textBox_NameUser.Text = "root";
            // 
            // textBox_NameDatabase
            // 
            textBox_NameDatabase.BackColor = SystemColors.Window;
            textBox_NameDatabase.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_NameDatabase.Location = new Point(250, 123);
            textBox_NameDatabase.Name = "textBox_NameDatabase";
            textBox_NameDatabase.PlaceholderText = "Имя базы данных";
            textBox_NameDatabase.Size = new Size(200, 39);
            textBox_NameDatabase.TabIndex = 3;
            textBox_NameDatabase.Text = "informationsystemofcitylibraries";
            // 
            // label_HelpText
            // 
            label_HelpText.AutoSize = true;
            label_HelpText.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_HelpText.Location = new Point(73, 29);
            label_HelpText.Name = "label_HelpText";
            label_HelpText.Size = new Size(554, 46);
            label_HelpText.TabIndex = 4;
            label_HelpText.Text = "Добро пожаловать в \"CityLibraryInfoSystem\"!\r\nПожалуйста укажите в какой базе данных вы хотите работать:\r\n";
            label_HelpText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_Connect
            // 
            button_Connect.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button_Connect.Location = new Point(250, 258);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(200, 39);
            button_Connect.TabIndex = 5;
            button_Connect.Text = "Загрузить";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // checkBox_ShowPasswordUser
            // 
            checkBox_ShowPasswordUser.AutoSize = true;
            checkBox_ShowPasswordUser.Location = new Point(456, 228);
            checkBox_ShowPasswordUser.Name = "checkBox_ShowPasswordUser";
            checkBox_ShowPasswordUser.Size = new Size(15, 14);
            checkBox_ShowPasswordUser.TabIndex = 6;
            checkBox_ShowPasswordUser.UseVisualStyleBackColor = true;
            checkBox_ShowPasswordUser.CheckedChanged += checkBox_ShowPasswordUser_CheckedChanged;
            // 
            // ConnectionToDataBase
            // 
            AcceptButton = button_Connect;
            AccessibleRole = AccessibleRole.WhiteSpace;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 465);
            Controls.Add(checkBox_ShowPasswordUser);
            Controls.Add(button_Connect);
            Controls.Add(label_HelpText);
            Controls.Add(textBox_NameDatabase);
            Controls.Add(textBox_NameUser);
            Controls.Add(textBox_PasswordUser);
            Controls.Add(textBox_ServerName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ConnectionToDataBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CityLibraryInfoSystem";
            FormClosed += ConnectionToDataBase_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ServerName;
        private TextBox textBox_PasswordUser;
        private TextBox textBox_NameUser;
        private TextBox textBox_NameDatabase;
        private Label label_HelpText;
        private Button button_Connect;
        private CheckBox checkBox_ShowPasswordUser;
    }
}
