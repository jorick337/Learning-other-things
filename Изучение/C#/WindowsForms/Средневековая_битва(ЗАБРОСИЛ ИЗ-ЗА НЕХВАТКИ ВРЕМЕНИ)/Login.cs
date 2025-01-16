namespace Средневековая_битва
{
    public partial class Login : Form
    {
        // Стек с формами которые надо будет использовать при закрытии
        public static Stack<Form> forms = new Stack<Form>();
        public Login()
        {
            InitializeComponent();
            //forms.Push(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // добавляю эту форму в стек на случай закрытия
            forms.Push(this);
            // загружаем пользователей в статическую переменную класса UsersManager
            UsersManager.Load();
            // загружаем все капчи в статическую переменную класса CaptchaManager для проверки пользователя
            //CaptchaManager.Load();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // проверяет нет ли пустых полей в логине и пароле, если есть говорит об этом
            if (ValidationClass.TextBoxNull(textBoxName, this)
                && ValidationClass.TextBoxNull(textBoxPassword, this))
            {
                // создаём нового user с паролем и именем из textbox
                User user = new User()
                {
                    Name = textBoxName.Text,
                    Password = textBoxPassword.Text,
                };

                //Проверяем ееть ли данный пользователь в json
                if (UsersManager.LoginUserandPassword(user))
                {
                    // если есть то выводим форму, в соответствии с уровнем доступа
                    if (UsersManager.UserPrivelege(user))
                    {
                        Administration administration = new Administration();
                        administration.Show();
                    }
                    else
                    {
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                    }
                    this.Hide();
                }
            }




        }


        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Для закрытия всех форм при закрытии
            //foreach (Form form in Login.forms)
            //{
            //    form.Close();
            //}
            this.Close();
        }
    }
}