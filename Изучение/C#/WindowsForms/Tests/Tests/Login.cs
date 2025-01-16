using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForUser
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // загружаем пользователей
            UsersManager.Load();
            // загружаем все тесты
            TestsManager.Load();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // если пароль и логин совпадают выводим новую форму для выбора теста, старую скрываем
            // пользователь которого вводят
            User user = new User()
            {
                NameUser = textBoxName.Text,
                Password = textBoxPassword.Text
            };
            if (UsersManager.Login(user))
            {
                this.Hide();
                // форма для администрации
                if (UsersManager.UserPrivelege(user))
                {
                    Administration administration = new Administration();
                    administration.Show();
                }
                else
                {// форма для гостей и пользователей
                    ChoiceTests choiceTests = new ChoiceTests();
                    choiceTests.Show();
                }
                textBoxName.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {// закрытие всех форм
            Application.Exit();
        }
    }
}
