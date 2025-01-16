using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForUser
{
    internal class TestsManager
    {
        // статичная переменная со всеми тестами
        public static List<Test> Tests = new List<Test>();
        // Тест, который решаем
        public static Test MainTest = new Test();
        // Загрузка из Json всех тестов
        public static void Load()
        {
            Tests = FileManager.ReadTests();
        }

        // Запись всех тестов с вопросами
        public static void Write()
        {
            FileManager.WriteTests();
        }

        // добавление нового теста
        public static void Add(Test newtest)
        {
            newtest.IdTest = Tests.Count;
            Tests.Add(newtest);
            Write();
        }
    }
}
