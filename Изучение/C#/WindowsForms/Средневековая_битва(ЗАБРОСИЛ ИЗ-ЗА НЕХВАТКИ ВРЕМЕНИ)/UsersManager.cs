using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Средневековая_битва
{
    internal class UsersManager
    {
        // Это менеджер где есть команды для работы с классом

        // Статический лист в котором будут все пользователи какие есть в файле json
        public static List<User> Users = new List<User>();

        // Эта функция загружает из json всех пользователей, какие есть
        public static void Load()
        {
            Users = FileManager.ReadUsers();
        }

        // обновление списка пользователей, запись их в файл
        public static void Write()
        {
            User user = new User() { Id=1,Name="admin",Password="12345"};
            Users.Add(user);
            FileManager.WriteUsers();
        }

        // добавление нового пользователя в общий лист со всеми пользователями
        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        // Изменение значений у пользователя, добавление на его место изменнёной версии
        public static void ChangeUserValue(User user)
        {
            Users.Insert(user.Id,user);
        }

        // Проверка при входе есть ли пользователь и подходит ли пароль
        public static bool LoginUserandPassword(User user)
        {
            // если пароль и имя совпадают то дать вывести true
            foreach (var item in Users)
            {
                if (item.Name==user.Name && item.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }

        // Проверка на уровень доступа
        public static bool UserPrivelege(User user)
        {
            if (user.Privelege == User.Priveleges[0])
            {
                return true;
            }
            return false;
        }
    }
}
