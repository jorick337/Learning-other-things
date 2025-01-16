using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Средневековая_битва
{
    internal class ValidationClass
    {
        // Класс, который выводит сообщение, если что-то при вводе данных пошло не так
        // Лейбл, текст которого сообщает об нарушении
        public static Label helptext { get; set; }

        // если данный textbox не имеет значений, то вывести рядом с ним предупреждение
        public static bool TextBoxNull(TextBox textBox,Login login) 
        {
            // удаляем старую помощь
            login.Controls.Remove(helptext);
            if(textBox == null) 
            {
                // label будет находиться справа от textbox, поэтому меняем Location
                Point point = textBox.Location;
                point.X += 20;
                helptext = new Label()
                {
                    Text = "Это поле должно быть заполнено",
                    Location = textBox.Location,
                    Font = new Font("Tahoma",14),
                    Size = textBox.Size,
                };
                // добавляем на форму helptext, который только что создали
                login.Controls.Add(helptext);
                // выводит false поясняя, что валидация на пустоту textbox нашла эту пустоту
                return false;
            }
            else return true;


        }
    }
}
