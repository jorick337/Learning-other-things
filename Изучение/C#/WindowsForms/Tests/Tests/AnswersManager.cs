using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class AnswersManager
    {
        // статический лист со всеми ответами на вопросы
        public static Answer Answers = new Answer();
        // обновление ответа на вопрос по id
        public static void UpdateAnswers(int Id, int AnswerValue)
        {
            Answers.NumberQuestionandAnswer![Id] = AnswerValue;
        }

        // создание пустых ячеек в Dictionary с ответами на вопросы,
        // чтобы UpdateAnswers работала коректно (перезаписывает одинаковые значения)
        public static Dictionary<int, int> AddCleanAnswerOnQuestion(int Size)
        {
            Dictionary<int, int> NewDictionary = new Dictionary<int, int>(Size);
            for (int numberquestion = 1; numberquestion <= Size; numberquestion++)
            {
                NewDictionary[numberquestion] = 0;
            }
            return NewDictionary;
        }
    }
}