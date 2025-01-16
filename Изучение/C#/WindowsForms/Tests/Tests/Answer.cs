using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class Answer
    {
        // класс в котором будут храниться ответы по id теста

        // запоминаю какой именно тест и пользователь даёт ответы
        public int NumberTest { get;set; }
        public string NameUser { get;set; }
        // Словарь с значениями по типу вопрос : ответ
        public Dictionary<int, int>? NumberQuestionandAnswer { get; set; }
        public Answer() 
        {
            NumberTest = 0;
            NameUser = "Пользователь";
            NumberQuestionandAnswer = new Dictionary<int, int>();
        }
        public Answer(int numbertest, string nameUser,Dictionary<int, int> numberquestandanswer)
        {
            NumberTest = numbertest;
            NameUser = nameUser;
            NumberQuestionandAnswer = numberquestandanswer;
            
        }
    }
}
