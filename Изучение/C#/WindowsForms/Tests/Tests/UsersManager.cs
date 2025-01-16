using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class UsersManager
    {
        // Список со всеми пользователями и их паролями
        public static List<User> Users = new List<User>();
        // конкректный пользователь
        public static User MainUser = new User();

        // загрузка
        public static void Load()
        {
            Users = FileManager.ReadUsers();
        }

        // запись
        public static void Write()
        {
            FileManager.WriteUsers();
        }

        // Логин если есть совпадени со списком выдаёт true для разрешения входа на следующую форму
        public static bool Login(User login)
        {
            foreach (var user in Users)
            {
                if (user.NameUser == login.NameUser && user.Password == login.Password)
                {
                    MainUser = user;
                    return true;
                }
            }
            return false;
        }

        // находим через имя уровень привелегии для вывода на соответствующую форму
        public static bool UserPrivelege(User login)
        {
            if (Users.Find(u => u.NameUser == login.NameUser)?.PrivelegeUser == User.Priveleges[0])
            {
                return true;
            }
            return false;
        }

        // добваление нового пользователя в список и запись его в json с iduser
        public static void UserAdd(User user)
        {
            user.IdUser = Users.Count+1;
            Users.Add(user);
            Write();
        }

        // СОХРАНЯЕМ ОТВЕТЫ
        public static void WriteAnswer()
        {
            if (MainUser.Answers.Find(u => u.NumberTest == TestsManager.MainTest.IdTest) != null)
            {
                int IdAnswerMainUser = Users[MainUser.IdUser].Answers.FindIndex(a => a.NumberTest == TestsManager.MainTest.IdTest);
                Users[MainUser.IdUser].Answers[IdAnswerMainUser] = AnswersManager.Answers;
            }
            else Users[MainUser.IdUser].Answers.Add(AnswersManager.Answers);
            Write();
        }

        // МЕНЯЕМ ПАРОЛЬ У ГЛАВНОГО ПОЛЬЗОВАТЕЛЯ
        public static void ChangePassword(string NewPassword)
        {
            MainUser.Password = NewPassword;
            Users[MainUser.IdUser].Password = NewPassword;
            Write();
        }
    }
}
