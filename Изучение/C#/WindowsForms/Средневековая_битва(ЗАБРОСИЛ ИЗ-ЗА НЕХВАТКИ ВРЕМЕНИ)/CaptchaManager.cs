using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Средневековая_битва
{
    internal class CaptchaManager
    {
        public static List<Captcha> CaptchaList = new List<Captcha>() { };

        // читает капчи какие есть в json
        public static void Load()
        {
            CaptchaList = FileManager.ReadCaptcha();
        }

        // запись капчи в json
        public static void Write()
        {
            FileManager.WriteCaptcha();
        }

        // добавление капчи в общий список 
        public static void Add(Captcha captcha)
        {
            CaptchaList.Add(captcha);
        }
    }
}
