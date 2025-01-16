using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Средневековая_битва
{
    internal class Captcha
    {
        public int Id { get; set; } // номер капчи
        public Bitmap Img { get; set; } // изображение которое и является капчей
        public Random Rnd { get; set; } // отвечает за генерацию различных свойств капчи
        public int Xpos { get; set; } // позиция текста на картинке
        public int Ypos { get; set; } // позиция текста на картинке
        public Color Colors { get; set; } // варианты цвета для текста
        public Pen ColorPens { get; set; } // варианты цвета для линий
        public FontStyle Fontstyle {get;set;} // варианты стиля текста
        public int Rotate { get; set; } // варианты угла поворота текста


    }
}
