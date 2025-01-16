using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.VisualBasic.ApplicationServices;

namespace Средневековая_битва
{
    internal class FileManager
    {
        // Это место где при помощи json мы достаём из файлов данные или ложим их туда

        // Опция для Сериализации или Десиаризации: добавляет русский язык
        private static JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.Cyrillic,UnicodeRanges.BasicLatin),
        };

        // Функция: читает файл с пользователями
        public static List<User> ReadUsers()
        {
            using (FileStream fs = new FileStream("users.json",FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<User>>(fs)!;
            }
        }

        // Функция: записывает файл с пользователями
        public static void WriteUsers()
        {
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<User>>(fs, UsersManager.Users,options);
            }
        }
        
        // Функция: читает файл с капчами
        public static List<Captcha> ReadCaptcha()
        {
            using (FileStream fs = new FileStream("Captcha.json", FileMode.Truncate))
            {
                List<Captcha> captchas = new List<Captcha>() { };
                JsonSerializer.Serialize(fs, captchas, options);
                return captchas;
            }
        }

        // Функция: записывает капчи в файл
        public static List<Captcha> WriteCaptcha()
        {
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Captcha>>(fs, options)!;
            }
        }
    }
}
