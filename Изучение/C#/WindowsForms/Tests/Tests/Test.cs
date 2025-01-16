using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class Test
    {
        public int IdTest { get; set; }
        public string NameTest { get; set; }
        // КРАТКОЕ ОПИСАНИЕ ТЕСТА 
        public string DescriptionTest { get; set; }
        // у каждого теста свой список вопросов
        public List<Question>? Questions { get; set; }
        // категории со своими значениями
        public List<Category>? Categories { get; set; }
        public Test() 
        {
            IdTest = TestsManager.Tests.Count;
            NameTest = "ТЕСТ";
            DescriptionTest = "ОПИСАНИЕ";
            Questions = new List<Question>();
            Categories = new List<Category>();
        }
        public Test(int idtest, string nametest,string descriptiontest,List<Question> questions,
            List<Category> queshionsCategories)
        {
            IdTest = idtest;
            NameTest = nametest;
            Questions = questions;
            Categories = queshionsCategories;
            DescriptionTest = descriptiontest;
        }
    }
}
