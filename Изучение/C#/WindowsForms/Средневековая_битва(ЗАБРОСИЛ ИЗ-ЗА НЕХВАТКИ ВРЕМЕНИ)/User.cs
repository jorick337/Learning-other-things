using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Средневековая_битва
{
    internal class User
    {
        // Это пользователь со своим id, именем и паролем
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Имя")]
        public string Name { get; set; }
        [JsonPropertyName("Пароль")]
        public string Password { get; set; }
        [JsonPropertyName("Привелегия уровня")]
        public string Privelege { get; set; }
        public static List<string> Priveleges = new List<string>() { "administration","user","quest"};
        public User() { }
        public User(int id,string name,string password)
        {
            Id = id;
            Name = name;
            Password = password;
            Privelege = Priveleges[2];
        }
        
    }
}
