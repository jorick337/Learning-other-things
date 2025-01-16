using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class AnswersToQuestionsByCategory
    {
        // КЛАСС СОДЕРЖАЩИЙ ИНФОРМАЦИЮ ДЛЯ ОТВЕТОВ НА ВОПРОС

        // НАЗВАНИЕ КАТЕГОРИИ
        public string NameCategory { get; set; }
        public Dictionary<string,int> TextToAnswerAndAnswer { get; set; }
        public AnswersToQuestionsByCategory()
        {
            NameCategory = "Категория";
            TextToAnswerAndAnswer = new Dictionary<string, int>(){ {"Да",0}, { "Нет", 0 }, 
            { "Скорее да", 0 }, { "Скорее нет", 0 } };
        }
        public AnswersToQuestionsByCategory(string nameCategory,
            Dictionary<string, int> textToAnswerAndAnswer)
        {
            NameCategory = nameCategory;
            TextToAnswerAndAnswer = textToAnswerAndAnswer;
        }
    }
}
