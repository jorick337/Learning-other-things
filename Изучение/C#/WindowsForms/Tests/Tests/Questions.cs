using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class Question
    {
        // класс в котором храняться только вопросы и их id для progress bar и изменения ответа на вопрос
        [JsonPropertyName("id")]
        public int IdQuestion { get; set; }
        [JsonPropertyName("question")]
        public string TextQuestion { get; set; }
        // словарь, отвечающий за то сколько балов дают при ответе для определённой категории
        // Например: {Категория,{{Да,0},{Нет,0},{Скорее да,0},{Скорее нет,0}}}
        public List<AnswersToQuestionsByCategory> AnswersToQuestionsByCategories { get; set; }
        public Question()
        {
            IdQuestion = 0;
            TextQuestion = "Вопрос";
            AnswersToQuestionsByCategories = new List<AnswersToQuestionsByCategory>();
        }
        public Question(int idquestion,string question,
            List<AnswersToQuestionsByCategory> answerstoquestionsbycategories)
        {
            IdQuestion = idquestion;
            TextQuestion = question;
            AnswersToQuestionsByCategories = answerstoquestionsbycategories;
        }
        public override string ToString()
        {
            return $"{IdQuestion+1}) {TextQuestion}?";
        }
    }
}
