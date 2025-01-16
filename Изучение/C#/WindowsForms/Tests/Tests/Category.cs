using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class Category
    {
        // класс в котором будут храниться категории ответов на вопросы, чтобы в конце теста
        // выводить итог прохождения

        public int IdCategory { get; set; }
        // сама категория
        public string NameCategory { get; set; }
        // означает полный успех в этой категории
        public int MaxValueCategory { get; set; }
        // означает среднее значение в этой категории
        public int AverageValueCategory { get; set; }
        // означает полный провал в этой категории
        public int MinValueCategory { get; set; }
        // Отвечает за вывод после теста определённых выводов по категории
        // в зависимости от полученных баллов
        public Dictionary<string,string> ConditionsText { get; set; }
        public Category() 
        {
            IdCategory = 0;
            NameCategory = "Категория";
            MaxValueCategory = 0;
            AverageValueCategory = 0;
            MinValueCategory = 0;
            ConditionsText = new Dictionary<string, string>() {
                { "Минимальное число баллов", "Ничего нет"}, { "Между средним и минимальным", "Ничего нет"},
                { "Среднее число баллов", "Ничего нет"},{"Между средним и максимальным", "Ничего нет"},
                { "Максимальное число баллов", "Ничего нет" } };
        }
        public Category(string caregoryname,int max,int average,int min,
           Dictionary<string, string> conditionstext)
        {
            NameCategory = caregoryname;
            MaxValueCategory = max;
            AverageValueCategory = average;
            MinValueCategory = min;
            ConditionsText = conditionstext;
        }
    }
}
