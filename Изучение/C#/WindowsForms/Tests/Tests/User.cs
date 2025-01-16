using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class User
    {
        // класс пользователя, имеющего имя, пароль и id для идентификации
        [JsonPropertyName ("id")]
        public int IdUser { get; set; }
        [JsonPropertyName("Имя")]
        public string NameUser { get; set; }
        [JsonPropertyName("Пароль")]
        public string Password { get; set; }
        [JsonPropertyName("Привелегия")]
        public string PrivelegeUser { get; set; }
        public List<Answer> Answers { get; set; }
        // выдайм по умолчанию доступ уровня гостя
        public static List<string> Priveleges = new List<string>() { "administration", "user", "quest" };

        // если убрать,то json не может десериализовать почему-то файл
        public User() 
        {
            IdUser = UsersManager.Users.Count;
            NameUser = "ИМЯ";
            Password = "ПАРОЛЬ";
            PrivelegeUser = Priveleges[2];
            Answers = new List<Answer>() { };
        }
        public User(int id,string name,string password,List<Answer> answers) 
        {
            IdUser = id;
            NameUser = name;
            Password = password;
            PrivelegeUser = Priveleges[2];
            Answers = answers;
        }
    }
}
