using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class CategoriesManager
    {
        // класс для категорий, подсчета значений

        public CategoriesManager() { }

        // ФУНКЦИЯ ВЫВОДИТ РЕЗУЛЬТАТ ПО КАТЕГОРИИ, СЧИТАЕТ КОЛИЧЕСТВО БАЛЛОВ ПО КАТЕГОРИИ У ВСЕХ ВОПРОСОВ
        public static string ShowResults(Category ChoiceCategory)
        {
            int NumberOfPointsOnCategory = 0;
            foreach (var Question in TestsManager.MainTest.Questions!)
            {
                AnswersToQuestionsByCategory ChoiceAnswer =
                    Question.AnswersToQuestionsByCategories.Find(x => x.NameCategory == ChoiceCategory.NameCategory)!; // Категория и ответы к ней по вопросу
                int IdAnswer = AnswersManager.Answers.NumberQuestionandAnswer!.ElementAt(Question.IdQuestion).Value; // Ответ (4,3,2,1,0)
                NumberOfPointsOnCategory += ChoiceAnswer.TextToAnswerAndAnswer.ElementAt(IdAnswer-1).Value;
            }
            string Result = "";
            MessageBox.Show(NumberOfPointsOnCategory.ToString() + ChoiceCategory.MaxValueCategory.ToString());
            
            if (ChoiceCategory.AverageValueCategory < NumberOfPointsOnCategory && NumberOfPointsOnCategory < ChoiceCategory.MaxValueCategory)
                    Result = ChoiceCategory.ConditionsText["Между средним и максимальным"];
            if (NumberOfPointsOnCategory == ChoiceCategory.AverageValueCategory) Result = ChoiceCategory.ConditionsText["Среднее число баллов"];
            if (NumberOfPointsOnCategory > ChoiceCategory.MinValueCategory && NumberOfPointsOnCategory < ChoiceCategory.AverageValueCategory)
                Result = ChoiceCategory.ConditionsText["Между средним и минимальным"];
            if (NumberOfPointsOnCategory <= ChoiceCategory.MinValueCategory) Result = ChoiceCategory.ConditionsText["Минимальное число баллов"];
            if (NumberOfPointsOnCategory >= ChoiceCategory.MaxValueCategory) Result = ChoiceCategory.ConditionsText["Максимальное число баллов"];
            return Result;
        }
    }
}
