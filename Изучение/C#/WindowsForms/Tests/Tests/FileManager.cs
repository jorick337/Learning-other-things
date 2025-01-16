using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace TestForUser
{
    internal class FileManager
    {

        // опция для считывания и записывания русского языка
        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create( UnicodeRanges.Cyrillic,UnicodeRanges.BasicLatin),
        };

        // загрузить пользователей
        public static List<User> ReadUsers()
        {
            using FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate);
            return JsonSerializer.Deserialize<List<User>>(fs)!;
        }

        // добавление пользователей
        public static void WriteUsers()
        {
            using FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate);
            JsonSerializer.Serialize(fs, UsersManager.Users, options);
        }

        // Функция : Читаю из файла вопросы для теста
        public static List<Test> ReadTests()
        {
            using FileStream fs = new FileStream("tests.json", FileMode.OpenOrCreate);
            return JsonSerializer.Deserialize<List<Test>>(fs)!;
        }

        // Функция : Запись тестов
        public static void WriteTests()
        {
            using FileStream fs = new FileStream("tests.json", FileMode.OpenOrCreate);
            JsonSerializer.Serialize(fs, TestsManager.Tests, options);
        }

        // Функция : считывать ответы
        public static List<Answer> ReadAnswers()
        {
            using (FileStream fs = new FileStream("answers.json", FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Answer>>(fs)!;
            }
        }

        // Функция : Записываю ответы к отдельному пользователю для определённого теста
        public static void WriteAnswer(List<Answer> answers)
        {
            using (FileStream fs = new FileStream("answers.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs,answers,options);
            }
        }
    }
}
