using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TestForUser
{
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
        }

        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            // закрытие всех форм
            Application.Exit();
        }

        // BUTTON ЭКЗЕМПЛЯРЫ , ВЫВОДИТ ФОРМУ С ЭКЗЕМПЛЯРАММ
        private void btnChanges_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteControls(this);
            CreateFormViewUserAndTest();
        }

        // ФОРМА С ЭКЗЕМПЛЯРАМИ, ВЫВОДИТ СПИСКИ СО ВСЕМИ ТЕСТАМИ И ПОЛЬЗОВАТЕЛЯМИ, МОЖНО ИХ ПРОСМАТРИВАТЬ
        private void CreateFormViewUserAndTest()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label обьясняет где находимся
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Все существующие экземпляры");
            // Label Тесты, ComBoBox с названиями тестов, Button смотреть
            FormHelper.CreateNewLabel("LabelHelpTextForTests", new Point(220, 50), new Size(400, 31), 16, "Тесты");
            List<string> ComboBoxWithNamesTestsDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithNamesTests", new Point(220, 90), new Size(400, 31), 16, null);
            FormHelper.CreateNewButton("BtnNextToInformationChoiceTest", new Point(630, 90), new Size(150, 40), 16, "Смотреть");
            // Label Тесты, ComBoBox с названиями тестов
            FormHelper.CreateNewLabel("LabelHelpTextForUsers", new Point(220, 130), new Size(400, 31), 16, "Пользователи");
            List<string> ComboBoxWithNamesUsersDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithNamesUsers", new Point(220, 170), new Size(400, 31), 16, null);
            FormHelper.CreateNewButton("BtnNextToInformationChoiceUser", new Point(630, 170), new Size(150, 40), 16, "Смотреть");
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКА

            // ОБНОВЛЕНИЕ COMBOBOX С ИМЕНАМИ ТЕСТОВ
            void UpdateComboBoxWithNamesTests()
            {
                ComboBox ComboBoxWithNamesTests = (ComboBox)Controls.Find("ComboBoxWithNamesTests", false).First();
                foreach (var Test in TestsManager.Tests)
                {
                    ComboBoxWithNamesTestsDataSource.Add($"{Test.IdTest + 1}) {Test.NameTest}");
                }
                ComboBoxWithNamesTests.DataSource = ComboBoxWithNamesTestsDataSource;
            }
            UpdateComboBoxWithNamesTests();

            // ОБНОВЛЕНИЕ COMBOBOX С ИМЕНАМИ ТЕСТОВ
            void UpdateComboBoxWithNamesUsers()
            {
                ComboBox ComboBoxWithNamesUsers = (ComboBox)Controls.Find("ComboBoxWithNamesUsers", false).First();
                foreach (var User in UsersManager.Users)
                {
                    ComboBoxWithNamesUsersDataSource.Add($"{User.IdUser + 1}) {User.NameUser}");
                }
                ComboBoxWithNamesUsers.DataSource = ComboBoxWithNamesUsersDataSource;
            }
            UpdateComboBoxWithNamesUsers();

            // BUTTON СМОТРЕТЬ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ТЕСТЕ
            void BtnNextToInformationChoiceTest_Click(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithNamesTests = (ComboBox)Controls.Find("ComboBoxWithNamesTests", false).First();
                Test ChoiceTest = TestsManager.Tests.Find(x => x.IdTest == ComboBoxWithNamesTests.SelectedIndex)!;
                FormHelper.DeleteControls(this);
                CreateFormInfoTestOrToSave(ChoiceTest, true);
            }
            Button BtnNextToInformationChoiceTest = (Button)Controls.Find("BtnNextToInformationChoiceTest", false).First();
            BtnNextToInformationChoiceTest.Click += BtnNextToInformationChoiceTest_Click!;

            // BUTTON СМОТРЕТЬ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ПОЛЬЗОВАТЕЛЕ
            void BtnNextToInformationChoiceUser_Click(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithNamesUsers = (ComboBox)Controls.Find("ComboBoxWithNamesUsers", false).First();
                User ChoiceUser = UsersManager.Users.Find(x => x.IdUser == ComboBoxWithNamesUsers.SelectedIndex)!;
                FormHelper.DeleteControls(this);
                CreateFormUser(ChoiceUser, true);
            }
            Button BtnNextToInformationChoiceUser = (Button)Controls.Find("BtnNextToInformationChoiceUser", false).First();
            BtnNextToInformationChoiceUser.Click += BtnNextToInformationChoiceUser_Click!;
        }

        // КНОПКА КОНСТРУКТОРА
        private void btnCreater_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteControls(this);
            CreaterNew();
        }

        // ФОРМА ВЫБОРА СОЗДАНИЯ
        private void CreaterNew()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label обьясняет где находимся
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Меню выбора желаемого конструктора");
            // Label говорит какой выбор делаем
            FormHelper.CreateNewLabel("LabelHelpTextForComboBox", new Point(220, 50),
                new Size(400, 31), 16, "Что желаете создать?");
            // Создаем на форме Combobox с выбором, выбираем что создать
            FormHelper.CreateNewCombobox("ComboBoxOfChoice", new Point(220, 90), new Size(400, 31), 16,
                new List<string>() { "Пользователя", "Тест" });
            // Создаём кнопку для создания экземпляра
            FormHelper.CreateNewButton("BtnCreateCopy", new Point(630, 400), new Size(150, 40), 16, "Начать");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКА

            // КНОПКА ВЫБОРА ЗАГРУЗКИ ФОРМЫ В ЗАВИСИМОСТИ ОТ ВЫБОРА В COMBOBOX 
            void Create_Click(object sender, EventArgs e)
            {
                ComboBox choice = (ComboBox)Controls.Find("ComboBoxOfChoice", false).First();
                FormHelper.DeleteControls(this);
                if (choice.Text == "Пользователя")
                {
                    User NewUser = new User();
                    CreateFormUser(NewUser);
                }
                else
                {
                    Test NewTest = new Test();
                    CreateFormTest(NewTest);
                }
            }
            Button create = (Button)this.Controls.Find("BtnCreateCopy", false).First();
            create.Click += Create_Click!;
        }

        // ФОРМА СОЗДАНИЯ ТЕСТА, TRUE - ТОГДА ДОБАВИТЬСЯ ТЕКСТ NEWTEST(ДЛЯ КНОПКИ НАЗАД)
        private void CreateFormTest(Test NewTest, bool? Back = null)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Конструктор создания теста");
            // Label Id, говорит какой Id присваивается тесту, Name ввод,Description ввод
            FormHelper.CreateNewLabel("LabelIdTest", new Point(220, 50), new Size(70, 31), 16,
                $"Id: {NewTest.IdTest}");
            FormHelper.CreateNewTextBox("TextBoxNameTest", new Point(290, 50), new Size(330, 31),
                16, "Имя теста");
            FormHelper.CreateNewTextBox("TextBoxDescriptionTest", new Point(220, 90), new Size(400, 100),
                16, "Описание теста", true);
            // Label Id, Question ввод, DataGridView с вопросами, Button добавить, Button удалить, Button изменить
            FormHelper.CreateNewLabel("LabelIdQuestion", new Point(220, 200), new Size(70, 70), 16,
                $"   Id: {NewTest.Questions!.Count}");
            FormHelper.CreateNewTextBox("TextBoxQuestion", new Point(290, 200), new Size(490, 70), 16,
                "Добавте сюда свой вопрос", true);
            BindingList<Question> Questions = new BindingList<Question>();
            FormHelper.CreateNewDataGridView("DataGridViewWithAllTheQuestions", new Point(220, 280),
                new Size(560, 110), 14, Color.White);
            FormHelper.CreateNewButton("BtnAddQuestion", new Point(630, 50), new Size(150, 40),
                16, "Добавить");
            FormHelper.CreateNewButton("BtnDeleteQuestion", new Point(630, 100), new Size(150, 40), 16,
                "Удалить");
            FormHelper.CreateNewButton("BtnChangeQuestion", new Point(630, 150), new Size(150, 40), 16,
                "Изменить");
            // Button далее, Button информации о тесте, Button назад
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            FormHelper.CreateNewButton("BtnInfo", new Point(425, 400), new Size(150, 40), 16, "Ваш Тест");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Далее>>>");
            // добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКА

            // ЕСЛИ ВЕРНУЛСЯ НАЗАД ОБНОВЛЯЕМ КОНТРОЛЫ
            if (Back == true)
            {
                TextBox TextBoxNameTest = (TextBox)this.Controls.Find("TextBoxNameTest", false).First();
                TextBox TextBoxDescriptionTest =
                    (TextBox)this.Controls.Find("TextBoxDescriptionTest", false).First();
                TextBoxNameTest.Text = NewTest.NameTest;
                TextBoxDescriptionTest.Text = NewTest.DescriptionTest;
            }

            DataGridView DataGridViewWithAllTheQuestions =
                (DataGridView)Controls.Find("DataGridViewWithAllTheQuestions", false).First();
            // ОБНОВЛЕНИЕ DATAGRIDVIEW С ВОПРОСАМИ ПО ТИПУ : НОМЕР) ВОПРОС
            // TRUE - ОБНОВИТЬ ВСЁ, NULL - ДОБАВИТЬ ПОСЛЕДНЕЕ ЗНАЧЕНИЕ В NEWTEST.QUESTIONS
            void UpdateDataGridViewWithAllTheQuestions(bool? AllQuestions = null)
            {
                DataGridViewWithAllTheQuestions.AutoGenerateColumns = false; // Колонны создадим вручную
                foreach (var Question in NewTest.Questions!) { Questions.Add(Question); };
                DataGridViewWithAllTheQuestions.DataSource = Questions;
                DataGridViewWithAllTheQuestions.ColumnHeadersHeight = 31;
                DataGridViewWithAllTheQuestions.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;  // Размер колонок по тексту
                DataGridViewWithAllTheQuestions.Columns.Add("IdQuestion", "Id");                                  // Id
                DataGridViewWithAllTheQuestions.Columns[0].DataPropertyName = "IdQuestion";
                DataGridViewWithAllTheQuestions.Columns[0].ReadOnly = true;
                DataGridViewWithAllTheQuestions.Columns.Add("TextQuestion", "Вопрос");                            // Вопрос
                DataGridViewWithAllTheQuestions.Columns[1].DataPropertyName = "TextQuestion";
                DataGridViewWithAllTheQuestions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            UpdateDataGridViewWithAllTheQuestions();

            // ФУНКЦИЯ ОБНОВЛЯЕТ ЗНАЧЕНИЯ ДЛЯ TEXTBOXS
            void UpdateTextBox(object? sender, DataGridViewCellEventArgs e)
            {
                Label LabelIdQuestion = (Label)Controls.Find("LabelIdQuestion", false).First();
                TextBox TextBoxQuestion =
                    (TextBox)Controls.Find("TextBoxQuestion", false).First();
                var IdQuestion = DataGridViewWithAllTheQuestions.CurrentCell.RowIndex;
                if (IdQuestion == -1 || IdQuestion >= NewTest.Questions!.Count) return;
                TextBoxQuestion.Text = NewTest.Questions[IdQuestion].TextQuestion;
                LabelIdQuestion.Text = $"   Id:\n {NewTest.Questions[IdQuestion].IdQuestion}";
            }
            DataGridViewWithAllTheQuestions.CellClick += UpdateTextBox!; // ПРИ КЛИКЕ
            DataGridViewWithAllTheQuestions.CellValueChanged += UpdateTextBox!; // ПРИ ИЗМЕНЕНИИ ЯЧЕЕК

            Question ReadTextBoxForQuestion()
            {
                Label LabelIdQuestion = (Label)Controls.Find("LabelIdQuestion", false).First();
                TextBox TextBoxQuestion =
                    (TextBox)Controls.Find("TextBoxQuestion", false).First();
                Question ChoiceQuestion = new Question();
                // Обновляем если что-то вписали в TextBoxs
                if (TextBoxQuestion.Text.ToString() != "")
                {
                    ChoiceQuestion.TextQuestion = TextBoxQuestion.Text;
                    ChoiceQuestion.IdQuestion = int.Parse(LabelIdQuestion.Text.Split(" ")[4]);
                };
                return ChoiceQuestion;
            }

            // BUTTON ДОБАВИТЬ, ДОБАВЛЯЕТ ВОПРОС В NEWTEST, DATAGRIDVIEW
            void BtnAddQuestion_Click(object sender, EventArgs e)
            {
                Label LabelIdQuestion = (Label)Controls.Find("LabelIdQuestion", false).First();
                Question NewQuestion = ReadTextBoxForQuestion();
                NewQuestion.IdQuestion = NewTest.Questions.Count;
                NewTest.Questions.Add(NewQuestion);
                Questions.Add(NewQuestion);
                LabelIdQuestion.Text = $"   Id:\n {NewTest.Questions.Count}";
            }
            Button BtnAddQuestion = (Button)Controls.Find("BtnAddQuestion", false).First();
            BtnAddQuestion.Click += BtnAddQuestion_Click!;

            // BUTTON УДАЛИТЬ, УДАЛЯЕТ ВЫДЕЛЕННЫЙ ВОПРОС В DATAGRIDVIEW И ОБНОВЛЯЕТ ID ДЛЯ ДРУГИХ ВОПРОСОВ
            void BtnDeleteQuestion_Click(object sender, EventArgs e)
            {

                Question ChoiceQuestion = ReadTextBoxForQuestion();
                if (ChoiceQuestion.IdQuestion == NewTest.Questions.Count) return;
                NewTest.Questions.RemoveAt(ChoiceQuestion.IdQuestion);
                Questions.RemoveAt(ChoiceQuestion.IdQuestion);
                for (int i = ChoiceQuestion.IdQuestion; i < NewTest.Questions!.Count; i++)
                {
                    NewTest.Questions![i].IdQuestion = i;
                }
            }
            Button BtnDeleteQuestion = (Button)Controls.Find("BtnDeleteQuestion", false).First();
            BtnDeleteQuestion.Click += BtnDeleteQuestion_Click!;

            // BUTTON ИЗМЕНИТЬ, ИЗМЕНЯЕТ ВЫДЕЛЕННУЮ КАТЕГОРИЮ В DATAGRIDVIEW 
            void BtnChangeQuestion_Click(object sender, EventArgs e)
            {
                Question ChoiceQuestion = ReadTextBoxForQuestion();
                NewTest.Questions![ChoiceQuestion.IdQuestion] = ChoiceQuestion;
                Questions[ChoiceQuestion.IdQuestion] = ChoiceQuestion;
            }
            Button BtnChangeQuestion = (Button)Controls.Find("BtnChangeQuestion", false).First();
            BtnChangeQuestion.Click += BtnChangeQuestion_Click!;


            // BUTTON НАЗАД, ВЫВОДИТ ФОРМУ ВЫБОРА КОНСТРУКТОРА
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreaterNew();
            }
            Button BtnBack = (Button)this.Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ВАШ ТЕСТ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ТЕСТЕ
            void BtnInfo_Click(object sender, EventArgs e)
            {
                TextBox TextBoxNameTest = (TextBox)this.Controls.Find("TextBoxNameTest", false).First();
                TextBox TextBoxDescriptionTest =
                    (TextBox)this.Controls.Find("TextBoxDescriptionTest", false).First();
                // Обновляем NewTest
                if (TextBoxNameTest.Text != "") NewTest.NameTest = TextBoxNameTest.Text;
                if (TextBoxDescriptionTest.Text != "") NewTest.DescriptionTest = TextBoxDescriptionTest.Text;
                FormHelper.DeleteControls(this);
                CreateFormInfoTestOrToSave(NewTest);
            }
            Button BtnInfo = (Button)this.Controls.Find("BtnInfo", false).First();
            BtnInfo.Click += BtnInfo_Click!;

            // BUTTON ДАЛЕЕ, ИДЁТ К ФОРМЕ СОЗДАНИЯ КАТЕГОРИЙ
            void btnNext_Click(object sender, EventArgs e)
            {
                TextBox TextBoxNameTest = (TextBox)this.Controls.Find("TextBoxNameTest", false).First();
                TextBox TextBoxDescriptionTest =
                    (TextBox)this.Controls.Find("TextBoxDescriptionTest", false).First();
                // Обновляем NewTest
                if (TextBoxNameTest.Text != "") NewTest.NameTest = TextBoxNameTest.Text;
                if (TextBoxDescriptionTest.Text != "") NewTest.DescriptionTest = TextBoxDescriptionTest.Text;
                FormHelper.DeleteControls(this);
                CreateFormNewCategories(NewTest);
            }
            Button BtnNext = (Button)this.Controls.Find("BtnNext", false).First();
            BtnNext.Click += btnNext_Click!;
        }

        // ФОРМА СОЗДАНИЯ КАТЕГОРИЙ ДЛЯ ТЕСТА
        private void CreateFormNewCategories(Test NewTest)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Создание категорий для теста");
            // Label показывает Id, TextBox ввод NameCategory
            FormHelper.CreateNewLabel("LabelIdCategory", new Point(220, 50), new Size(100, 31), 16,
                $"Id: {NewTest.Categories!.Count}");
            FormHelper.CreateNewTextBox("TextBoxNameCategory", new Point(320, 50), new Size(300, 31), 16,
                "Добавте сюда свою категорию", true);
            // TextBoxs: ввод MinValueCategory, ввод AverageValueCategory, ввод MaxValueCategory
            // Button добавить, Button удалить, Button изменить, ListBox с категориями
            FormHelper.CreateNewTextBox("TextBoxMinValueCategory", new Point(220, 90), new Size(400, 31),
                16, "Полный провал категории", true);
            FormHelper.CreateNewTextBox("TextBoxAverageValueCategory", new Point(220, 130), new Size(400, 31),
                16, "Среднее значение категории", true);
            FormHelper.CreateNewTextBox("TextBoxMaxValueCategory", new Point(220, 170), new Size(400, 31),
                16, "Значение полного успеха категории", true);
            FormHelper.CreateNewButton("BtnAddCategory", new Point(630, 50), new Size(150, 40), 16,
                "Добавить");
            FormHelper.CreateNewButton("BtnDeleteCategory", new Point(630, 105), new Size(150, 40), 16,
                "Удалить");
            FormHelper.CreateNewButton("BtnChangeCategory", new Point(630, 161), new Size(150, 40), 16,
                "Изменить");
            BindingList<Category> Categories = new BindingList<Category>();
            FormHelper.CreateNewDataGridView("DataGridViewWithAllTheCategories", new Point(220, 210),
                new Size(560, 180), 14, Color.White);
            // Button далее, Button информации о тесте, Button назад
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            FormHelper.CreateNewButton("BtnInfo", new Point(425, 400), new Size(150, 40), 16, "Ваш Тест");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Далее>>>");
            // добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // DATAGRIDVIEW С ЗНАЧЕНИЯМИ КАТЕГОРИИ, ДОБАВЛЯЕМ СТОЛБЦЫ ПО ТИПУ:
            // НОМЕР КАТЕГОРИЯ МИН. СРЕДН. МАКС. , ДОБАВЛЯЕМ ИСТОЧНИК ДАННЫХ, НАСТРАИВАЕМ
            DataGridView DataGridViewWithAllTheCategories =
                    (DataGridView)Controls.Find("DataGridViewWithAllTheCategories", false).First();
            void UpdateDataGridViewWithAllTheCategories()
            {
                DataGridViewWithAllTheCategories.AutoGenerateColumns = false; // Колонны создадим вручную
                foreach (var Category in NewTest.Categories) { Categories.Add(Category); };
                DataGridViewWithAllTheCategories.DataSource = Categories;
                DataGridViewWithAllTheCategories.ColumnHeadersHeight = 31;
                DataGridViewWithAllTheCategories.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;  // Размер колонок по тексту
                DataGridViewWithAllTheCategories.Columns.Add("IdCategory", "Id");                                  // Id
                DataGridViewWithAllTheCategories.Columns[0].DataPropertyName = "IdCategory";
                DataGridViewWithAllTheCategories.Columns[0].ReadOnly = true;
                DataGridViewWithAllTheCategories.Columns.Add("NameCategory", "Имя");                               // Категория
                DataGridViewWithAllTheCategories.Columns[1].DataPropertyName = "NameCategory";
                DataGridViewWithAllTheCategories.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridViewWithAllTheCategories.Columns.Add("MinValueCategory", "Мин.");                          // Мин
                DataGridViewWithAllTheCategories.Columns[2].DataPropertyName = "MinValueCategory";
                DataGridViewWithAllTheCategories.Columns.Add("AverageValueCategory", "Средн.");                    // Средн
                DataGridViewWithAllTheCategories.Columns[3].DataPropertyName = "AverageValueCategory";
                DataGridViewWithAllTheCategories.Columns.Add("MaxValueCategory", "Макс.");                         // Макс
                DataGridViewWithAllTheCategories.Columns[4].DataPropertyName = "MaxValueCategory";
            }
            UpdateDataGridViewWithAllTheCategories();

            // ФУНКЦИЯ ОБНОВЛЯЕТ ЗНАЧЕНИЯ ДЛЯ TEXTBOXS
            void UpdateTextBoxs(object? sender, DataGridViewCellEventArgs e)
            {
                Label LabelIdCategory = (Label)Controls.Find("LabelIdCategory", false).First();
                TextBox TextBoxNameCategory =
                    (TextBox)Controls.Find("TextBoxNameCategory", false).First();
                TextBox TextBoxMinValueCategory =
                    (TextBox)Controls.Find("TextBoxMinValueCategory", false).First();
                TextBox TextBoxAverageValueCategory =
                    (TextBox)Controls.Find("TextBoxAverageValueCategory", false).First();
                TextBox TextBoxMaxValueCategory =
                    (TextBox)Controls.Find("TextBoxMaxValueCategory", false).First();
                var IdCategory = DataGridViewWithAllTheCategories.CurrentCell.RowIndex;
                if (IdCategory == -1 || IdCategory >= NewTest.Categories.Count) return;
                TextBoxNameCategory.Text = NewTest.Categories![IdCategory].NameCategory;
                TextBoxMinValueCategory.Text = NewTest.Categories![IdCategory].MinValueCategory.ToString();
                TextBoxAverageValueCategory.Text = NewTest.Categories![IdCategory].AverageValueCategory.ToString();
                TextBoxMaxValueCategory.Text = NewTest.Categories![IdCategory].MaxValueCategory.ToString();
                LabelIdCategory.Text = $"Id: {NewTest.Categories![IdCategory].IdCategory}";
            }
            DataGridViewWithAllTheCategories.CellClick += UpdateTextBoxs!; // ПРИ КЛИКЕ
            DataGridViewWithAllTheCategories.CellValueChanged += UpdateTextBoxs!; // ПРИ ИЗМЕНЕНИИ ЯЧЕЕК

            Category ReadTextBoxForCategory()
            {
                Label LabelIdCategory = (Label)Controls.Find("LabelIdCategory", false).First();
                TextBox TextBoxNameCategory =
                    (TextBox)Controls.Find("TextBoxNameCategory", false).First();
                TextBox TextBoxMinValueCategory =
                    (TextBox)Controls.Find("TextBoxMinValueCategory", false).First();
                TextBox TextBoxAverageValueCategory =
                    (TextBox)Controls.Find("TextBoxAverageValueCategory", false).First();
                TextBox TextBoxMaxValueCategory =
                    (TextBox)Controls.Find("TextBoxMaxValueCategory", false).First();
                Category NewCategory = new Category();
                AnswersToQuestionsByCategory AnswersForQuestions = new AnswersToQuestionsByCategory();
                // Обновляем если что-то вписали в TextBoxs
                if (TextBoxNameCategory.Text.ToString() != "")
                {
                    NewCategory.IdCategory = int.Parse(LabelIdCategory.Text.Split(" ").Last());
                    NewCategory.NameCategory = TextBoxNameCategory.Text;
                    AnswersForQuestions.NameCategory = TextBoxNameCategory.Text;
                    AnswersForQuestions.TextToAnswerAndAnswer =
                        new AnswersToQuestionsByCategory().TextToAnswerAndAnswer;
                };
                if (TextBoxMinValueCategory.Text.ToString() != "") NewCategory.MinValueCategory =
                        int.Parse(TextBoxMinValueCategory.Text);
                if (TextBoxAverageValueCategory.Text.ToString() != "") NewCategory.AverageValueCategory =
                        int.Parse(TextBoxAverageValueCategory.Text);
                if (TextBoxMaxValueCategory.Text.ToString() != "") NewCategory.MaxValueCategory =
                        int.Parse(TextBoxMaxValueCategory.Text);
                return NewCategory;
            }

            // BUTTON ДОБАВИТЬ, ДОБАВЛЯЕТ НОВУЮ КАТЕГОРИЮ В NEWTEST И DATAGRIDVIEW
            // ОБНОВЛЯЕТ БАЛЬНУЮ СИСТУМУ ПО КАТЕГОРИИ
            void BtnAddCategory_Click(object sender, EventArgs e)
            {
                Label LabelIdCategory = (Label)Controls.Find("LabelIdCategory", false).First();
                // Обновление DataGridView с категориями и NewTest
                Category NewCategory = ReadTextBoxForCategory();
                NewCategory.IdCategory = NewTest.Categories.Count;
                AnswersToQuestionsByCategory AnswersForQuestions = new AnswersToQuestionsByCategory()
                {
                    NameCategory = NewCategory.NameCategory,
                    TextToAnswerAndAnswer = new AnswersToQuestionsByCategory().TextToAnswerAndAnswer
                };
                NewTest.Categories.Add(NewCategory);
                Categories.Add(NewCategory);
                foreach (var Question in NewTest.Questions!) // Добавляем категории к вопросам
                {
                    Question.AnswersToQuestionsByCategories.Add(AnswersForQuestions);
                }
                // Обновляем Label с Id категории
                LabelIdCategory.Text = $"Id: {NewTest.Categories.Count}";
            }
            Button BtnAddCategory = (Button)Controls.Find("BtnAddCategory", false).First();
            BtnAddCategory.Click += BtnAddCategory_Click!;

            // BUTTON УДАЛИТЬ, УДАЛЯЕТ ВЫДЕЛЕННУЮ КАТЕГОРИЮ В DATAGRIDVIEW И ОБНОВЛЯЕТ ID ДЛЯ ДРУГИХ КАТЕГОРИЙ
            void BtnDeleteCategory_Click(object sender, EventArgs e)
            {
                Category ChoiceCategory = ReadTextBoxForCategory();
                NewTest.Categories.RemoveAt(ChoiceCategory.IdCategory);
                Categories.RemoveAt(ChoiceCategory.IdCategory);
                for (int i = ChoiceCategory.IdCategory; i < NewTest.Categories.Count; i++)
                {
                    NewTest.Categories[i].IdCategory = i;
                }
            }
            Button BtnDeleteCategory = (Button)Controls.Find("BtnDeleteCategory", false).First();
            BtnDeleteCategory.Click += BtnDeleteCategory_Click!;

            // BUTTON ИЗМЕНИТЬ, ИЗМЕНЯЕТ ВЫДЕЛЕННУЮ КАТЕГОРИЮ В DATAGRIDVIEW 
            void BtnChangeCategory_Click(object sender, EventArgs e)
            {
                Category ChoiceCategory = ReadTextBoxForCategory();
                NewTest.Categories![ChoiceCategory.IdCategory] = ChoiceCategory;
                Categories[ChoiceCategory.IdCategory] = ChoiceCategory;
            }
            Button BtnChangeCategory = (Button)Controls.Find("BtnChangeCategory", false).First();
            BtnChangeCategory.Click += BtnChangeCategory_Click!;

            // BUTTON НАЗАД, ВЫВОДИТ ФОРМУ СОЗДАНИЯ ТЕСТА
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormTest(NewTest, true);
            }
            Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ВАШ ТЕСТ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ТЕСТЕ
            void BtnInfo_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormInfoTestOrToSave(NewTest);
            }
            Button BtnInfo = (Button)Controls.Find("BtnInfo", false).First();
            BtnInfo.Click += BtnInfo_Click!;

            // BUTTON ДАЛЕЕ, ИДЁТ К ФОРМЕ СОЗДАНИЯ КАТЕГОРИЙ
            // ЕСЛИ НЕТ ВОПРОСОВ ИЛИ КАТЕГОРИЙ, ТО СОЗДАЁМ, ПОСКОЛЬКУ ДАЛЬШЕ БЕЗ НИХ НИКАК
            void btnNext_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormNewValuesForQuestion(NewTest, 1);
            }
            Button BtnNext = (Button)this.Controls.Find("BtnNext", false).First();
            BtnNext.Click += btnNext_Click!;
        }

        // ФОРМА ПРИСВОЕНИЯ ВОПРОСАМ БАЛОВ ПО КАТЕГОРИИ И ОТВЕТУ
        private void CreateFormNewValuesForQuestion(Test NewTest, int NumberQuestion)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Создание бальной системы");
            // Label вопроса по типу : Номер) Вопрос?
            FormHelper.CreateNewLabel("LabelQuestion", new Point(220, 50), new Size(400, 31), 16, null);
            // ComboBox с категориями, TextBox ввод значений ответов на вопросы, Button добавить, Button удалить, Button изменить,
            List<string> ComboBoxWithAllTheCategoriesDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithAllTheCategories", new Point(220, 90),
                new Size(400, 31), 16, null);
            FormHelper.CreateNewTextBox("TextBoxYesValueAnswerForCategory", new Point(220, 130),
                new Size(50, 31), 16, "Да");
            FormHelper.CreateNewTextBox("TextBoxNoValueAnswerForCategory", new Point(280, 130),
                new Size(50, 31), 16, "Нет");
            FormHelper.CreateNewTextBox("TextBoxProbablyYesValueAnswerForCategory", new Point(340, 130),
                new Size(135, 31), 16, "Скорее да");
            FormHelper.CreateNewTextBox("TextBoxProbablyNoValueAnswerForCategory", new Point(485, 130),
                new Size(135, 31), 16, "Скорее нет");
            FormHelper.CreateNewButton("BtnChangeValuesQuestion", new Point(630, 90), new Size(150, 40), 16,
                "Изменить");
            DataTable DataTableValuesQuestion = new DataTable();
            FormHelper.CreateNewDataGridView("DataGridViewWithAllTheValuesQuestions", new Point(220, 170),
                new Size(560, 220), 14, Color.White);
            // Button далее, Button информации о тесте, Button назад
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            FormHelper.CreateNewButton("BtnInfo", new Point(425, 400), new Size(150, 40), 16, "Ваш Тест");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Далее>>>");
            // добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // ФУНКЦИЯ ПРОВЕРКИ И ВЫВОДА ВОПРОСА ПО ТИПУ: НОМЕР) ВОПРОС
            void UpdateLabelQuestion()
            {
                if (NewTest.Categories!.Count == 0)
                {
                    NewTest.Categories.Add(new Category());
                    foreach (var Question in NewTest.Questions!)
                    {
                        Question.AnswersToQuestionsByCategories.Add(new AnswersToQuestionsByCategory()
                        { NameCategory = NewTest.Categories[0].NameCategory, TextToAnswerAndAnswer = new AnswersToQuestionsByCategory().TextToAnswerAndAnswer });
                    }
                }
                if (NewTest.Questions!.Count == 0)
                {
                    NewTest.Questions.Add(new Question());
                    foreach (var Category in NewTest.Categories)
                    {
                        NewTest.Questions[0].AnswersToQuestionsByCategories.Add(new AnswersToQuestionsByCategory()
                        { NameCategory = Category.NameCategory, TextToAnswerAndAnswer = new AnswersToQuestionsByCategory().TextToAnswerAndAnswer });
                    }
                }
                Label LabelQuestion = (Label)Controls.Find("LabelQuestion", false).First();
                LabelQuestion.Text = $"{NumberQuestion}) {NewTest.Questions![NumberQuestion - 1].TextQuestion}";
            }
            UpdateLabelQuestion();

            // ФУНКЦИЯ ОБНОВЛЕНИЯ COMBOBOX С КАТЕГОРИЯМИ
            void UpdateComboBox()
            {
                ComboBoxWithAllTheCategoriesDataSource.Clear();
                foreach (var Category in NewTest.Categories!)
                {
                    ComboBoxWithAllTheCategoriesDataSource.Add(Category.NameCategory);
                }
                // Обновим ComboBox
                ComboBox ComboBoxWithAllTheCategories =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                ComboBoxWithAllTheCategories.DataSource = ComboBoxWithAllTheCategoriesDataSource;
            }
            UpdateComboBox();

            // DATAGRIDVIEW С ЗНАЧЕНИЯМИ КАТЕГОРИИ, ДОБАВЛЯЕМ СТОЛБЦЫ ПО ТИПУ:
            // КАТЕГОРИЯ ДА НЕТ СКОРЕЕ ДА СКОРЕЕ НЕТ, ДОБАВЛЯЕМ ИСТОЧНИК ДАННЫХ, НАСТРАИВАЕМ
            DataGridView DataGridViewWithAllTheValuesQuestions =
                    (DataGridView)Controls.Find("DataGridViewWithAllTheValuesQuestions", false).First();
            void UpdateDataGridViewWithAllTheCategories()
            {
                // Создадим и заполним колонны
                DataTableValuesQuestion.Columns.Add("Категория", typeof(string));
                foreach (var key in NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[0].TextToAnswerAndAnswer.Keys)
                {
                    DataTableValuesQuestion.Columns.Add($"{key}", typeof(string));
                }
                foreach (var AnswerQuestion in NewTest.Questions[NumberQuestion - 1].AnswersToQuestionsByCategories)
                {
                    DataRow dataRow = DataTableValuesQuestion.NewRow();
                    dataRow["Категория"] = AnswerQuestion.NameCategory;
                    foreach (KeyValuePair<string, int> keyValuePair in AnswerQuestion.TextToAnswerAndAnswer)
                    {
                        dataRow[$"{keyValuePair.Key}"] = keyValuePair.Value;
                    }
                    DataTableValuesQuestion.Rows.Add(dataRow);
                }
                DataGridViewWithAllTheValuesQuestions.DataSource = DataTableValuesQuestion;
                DataGridViewWithAllTheValuesQuestions.ColumnHeadersHeight = 31;
                DataGridViewWithAllTheValuesQuestions.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DataGridViewWithAllTheValuesQuestions.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridViewWithAllTheValuesQuestions.Columns[0].ReadOnly = true;
            }
            UpdateDataGridViewWithAllTheCategories();

            // ФУНКЦИЯ ОБНОВЛЯЕТ ЗНАЧЕНИЯ ДЛЯ TEXTBOXS
            void UpdateTextBoxs(object? sender, DataGridViewCellEventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories = (ComboBox)Controls.Find("ComboBoxWithAllTheCategories", false).First();
                TextBox TextBoxYesValueAnswerForCategory =
                    (TextBox)Controls.Find("TextBoxYesValueAnswerForCategory", false).First();
                TextBox TextBoxNoValueAnswerForCategory =
                    (TextBox)Controls.Find("TextBoxNoValueAnswerForCategory", false).First();
                TextBox TextBoxProbablyYesValueAnswerForCategory =
                    (TextBox)Controls.Find("TextBoxProbablyYesValueAnswerForCategory", false).First();
                TextBox TextBoxProbablyNoValueAnswerForCategory =
                    (TextBox)Controls.Find("TextBoxProbablyNoValueAnswerForCategory", false).First();
                var IdCategory = DataGridViewWithAllTheValuesQuestions.CurrentCell.RowIndex;
                if (IdCategory == -1 || IdCategory >= NewTest.Categories!.Count) return;
                TextBoxYesValueAnswerForCategory.Text =
                    NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[IdCategory].TextToAnswerAndAnswer.ElementAt(0).Value.ToString();
                TextBoxNoValueAnswerForCategory.Text =
                    NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[IdCategory].TextToAnswerAndAnswer.ElementAt(1).Value.ToString();
                TextBoxProbablyYesValueAnswerForCategory.Text =
                    NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[IdCategory].TextToAnswerAndAnswer.ElementAt(2).Value.ToString();
                TextBoxProbablyNoValueAnswerForCategory.Text =
                    NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[IdCategory].TextToAnswerAndAnswer.ElementAt(3).Value.ToString();
                ComboBoxWithAllTheCategories.SelectedIndex = IdCategory;
            }
            DataGridViewWithAllTheValuesQuestions.CellClick += UpdateTextBoxs!; // ПРИ КЛИКЕ
            DataGridViewWithAllTheValuesQuestions.CellValueChanged += UpdateTextBoxs!; // ПРИ ИЗМЕНЕНИИ ЯЧЕЕК

            AnswersToQuestionsByCategory ReadTextBoxForValuesAnswers()
            {
                ComboBox ComboBoxWithAllTheCategories = (ComboBox)Controls.Find("ComboBoxWithAllTheCategories", false).First();
                TextBox TextBoxYesValueAnswerForCategory = (TextBox)Controls.Find("TextBoxYesValueAnswerForCategory", false).First();
                TextBox TextBoxNoValueAnswerForCategory = (TextBox)Controls.Find("TextBoxNoValueAnswerForCategory", false).First();
                TextBox TextBoxProbablyYesValueAnswerForCategory = (TextBox)Controls.Find("TextBoxProbablyYesValueAnswerForCategory", false).First();
                TextBox TextBoxProbablyNoValueAnswerForCategory = (TextBox)Controls.Find("TextBoxProbablyNoValueAnswerForCategory", false).First();
                AnswersToQuestionsByCategory ValuesAnswer = new AnswersToQuestionsByCategory();
                // Обновляем если что-то вписали в TextBoxs
                ValuesAnswer.NameCategory = ComboBoxWithAllTheCategories.Text;
                if (TextBoxYesValueAnswerForCategory.Text.ToString() != "") ValuesAnswer.TextToAnswerAndAnswer["Да"] =
                        int.Parse(TextBoxYesValueAnswerForCategory.Text);
                if (TextBoxNoValueAnswerForCategory.Text.ToString() != "") ValuesAnswer.TextToAnswerAndAnswer["Нет"] =
                        int.Parse(TextBoxNoValueAnswerForCategory.Text);
                if (TextBoxProbablyYesValueAnswerForCategory.Text.ToString() != "") ValuesAnswer.TextToAnswerAndAnswer["Скорее да"] =
                        int.Parse(TextBoxProbablyYesValueAnswerForCategory.Text);
                if (TextBoxProbablyNoValueAnswerForCategory.Text.ToString() != "") ValuesAnswer.TextToAnswerAndAnswer["Скорее нет"] =
                        int.Parse(TextBoxProbablyNoValueAnswerForCategory.Text);
                return ValuesAnswer;
            }

            // BUTTON ИЗМЕНИТЬ, ИЗМЕНЯЕТ ЗНАЧЕНИЯ ОТВЕТОВ NEWTEST И DATAGRIDVIEW
            void BtnAddCategory_Click(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories = (ComboBox)Controls.Find("ComboBoxWithAllTheCategories", false).First();
                // Обновление DataGridView с ответами по категории и NewTest
                AnswersToQuestionsByCategory ValuesAnswer = ReadTextBoxForValuesAnswers();
                int IdCategory = ComboBoxWithAllTheCategories.SelectedIndex;
                NewTest.Questions![NumberQuestion - 1].AnswersToQuestionsByCategories[IdCategory] = ValuesAnswer;
                DataTableValuesQuestion.Rows[IdCategory]["Да"] = ValuesAnswer.TextToAnswerAndAnswer["Да"];
                DataTableValuesQuestion.Rows[IdCategory]["Нет"] = ValuesAnswer.TextToAnswerAndAnswer["Нет"];
                DataTableValuesQuestion.Rows[IdCategory]["Скорее да"] = ValuesAnswer.TextToAnswerAndAnswer["Скорее да"];
                DataTableValuesQuestion.Rows[IdCategory]["Скорее нет"] = ValuesAnswer.TextToAnswerAndAnswer["Скорее нет"];
                // Обновляем ComboBox на следующую категорию
                if (IdCategory + 1 == ComboBoxWithAllTheCategories.Items.Count) ComboBoxWithAllTheCategories.SelectedIndex = 0;
                else ComboBoxWithAllTheCategories.SelectedIndex = IdCategory + 1;
            }
            Button BtnAddCategory = (Button)Controls.Find("BtnChangeValuesQuestion", false).First();
            BtnAddCategory.Click += BtnAddCategory_Click!;

            // BUTTON НАЗАД, ВЫВОДИТ ФОРМУ СОЗДАНИЯ КАТЕГОРИЙ ДЛЯ ТЕСТА
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormNewCategories(NewTest);
            }
            Button BtnBack = (Button)this.Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ВАШ ТЕСТ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ТЕСТЕ
            void BtnInfo_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormInfoTestOrToSave(NewTest);
            }
            Button BtnInfo = (Button)this.Controls.Find("BtnInfo", false).First();
            BtnInfo.Click += BtnInfo_Click!;

            // КНОПКА ДАЛЕЕ ЧТО ВЕДЁТ К СЛЕДУЮЩЕМУ ВОПРОСУ ИЛИ ВЫВОДИТ ФОРМУ С УСЛОВИЯМИ ВЫВОДА ТЕКСТА
            // ПОСЛЕ ПРОХОЖДЕНИЯ В ЗАВИСИМОСТИ ОТ УСЛОВИЙ
            void BtnNext_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                // Если вопросы закончились, вывести форму добавления текста для условий
                if (NumberQuestion == NewTest.Questions!.Count)
                {
                    CreateFormNewConditionsForCategories(NewTest, 1);
                }
                else CreateFormNewValuesForQuestion(NewTest, NumberQuestion + 1);
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        // ФОРМА СОЗДАНИЯ УСЛОВИЙ, ВЛИЯЮЩИХ НА КОНЕЧНЫЙ РЕЗУЛЬТАТ ТЕСТА
        private void CreateFormNewConditionsForCategories(Test NewTest, int NumberCategory)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Создание текста для условий");
            // Label номер и категория, 
            FormHelper.CreateNewLabel("LabelCategoryName", new Point(220, 50), new Size(400, 31), 16, null);
            // Combobox выбор условия, Button добавить, TextBox ввод текста условия, 
            // ListBox с условием и количетсвом строк
            List<string> ComboBoxWithAllTheConditionsDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithAllTheConditions", new Point(220, 90),
                new Size(400, 31), 16, null);
            FormHelper.CreateNewButton("BtnChangeConditions", new Point(630, 90),
               new Size(150, 40), 16, "Изменить");
            FormHelper.CreateNewTextBox("TextBoxCondition", new Point(220, 130), new Size(560, 125),
                16, "Текст что выведиться по окончании теста, если условие верно", true);
            DataTable DataTableConditions = new DataTable();
            FormHelper.CreateNewDataGridView("DataGridViewWithAllTheConditions", new Point(220, 265),
                new Size(560, 125), 14, Color.White);
            // Button далее, Button информации о тесте, Button назад
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            FormHelper.CreateNewButton("BtnInfo", new Point(425, 400), new Size(150, 40), 16, "Ваш Тест");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Далее>>>");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // ФУНКЦИЯ ПРОВЕРКИ И ВЫВОДА КАТЕГОРИИ ПО ТИПУ: НОМЕР) КАТЕГОРИЯ
            void UpdateLabelQuestion()
            {
                if (NewTest.Categories!.Count == 0) NewTest.Categories.Add(new Category());
                Label LabelCategoryName = (Label)Controls.Find("LabelCategoryName", false).First();
                LabelCategoryName.Text = $"{NumberCategory}) {NewTest.Categories![NumberCategory - 1].NameCategory}";
            }
            UpdateLabelQuestion();

            // COMBOBOX С УСЛОВИЯМИ, ОБНОВЛЕНИЕ ПО ТИПУ: НОМЕР) УСЛОВИЕ
            foreach (var Condition in NewTest.Categories![NumberCategory - 1].ConditionsText)
            {
                int IdCondition = ComboBoxWithAllTheConditionsDataSource.Count;
                ComboBoxWithAllTheConditionsDataSource.Add(
                    $"{IdCondition + 1}) {Condition.Key}");
            }
            ComboBox ComboBoxWithAllTheConditions =
                (ComboBox)this.Controls.Find("ComboBoxWithAllTheConditions", false).First();
            ComboBoxWithAllTheConditions.DataSource = ComboBoxWithAllTheConditionsDataSource;

            // DATAGRIDVIEW С ЗНАЧЕНИЯМИ УСЛОВИЙ, ДОБАВЛЯЕМ УСЛОВИЯ ПО ТИПУ:
            // УСЛОВИЕ ТЕКСТУСЛОВИЯ, ДОБАВЛЯЕМ ИСТОЧНИК ДАННЫХ, НАСТРАИВАЕМ
            DataGridView DataGridViewWithAllTheConditions =
                    (DataGridView)Controls.Find("DataGridViewWithAllTheConditions", false).First();
            void UpdateDataGridViewWithAllTheCategories()
            {
                // Создадим и заполним колонны
                DataTableConditions.Columns.Add("Условие", typeof(string));
                DataTableConditions.Columns.Add("Текст условия", typeof(string));
                foreach (var key in NewTest.Categories[NumberCategory - 1].ConditionsText)
                {
                    DataRow dataRow = DataTableConditions.NewRow();
                    dataRow["Условие"] = key.Key;
                    dataRow["Текст условия"] = key.Value;
                    DataTableConditions.Rows.Add(dataRow);
                }
                DataGridViewWithAllTheConditions.DataSource = DataTableConditions;
                DataGridViewWithAllTheConditions.ColumnHeadersHeight = 31;
                DataGridViewWithAllTheConditions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DataGridViewWithAllTheConditions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridViewWithAllTheConditions.Columns[0].ReadOnly = true;
            }
            UpdateDataGridViewWithAllTheCategories();

            // ФУНКЦИЯ ОБНОВЛЯЕТ ЗНАЧЕНИЯ ДЛЯ TEXTBOXS
            void UpdateTextBoxs(object? sender, DataGridViewCellEventArgs e)
            {
                TextBox TextBoxCondition = (TextBox)Controls.Find("TextBoxCondition", false).First();
                var IdCategory = DataGridViewWithAllTheConditions.CurrentCell.RowIndex;
                if (IdCategory == -1 || IdCategory >= NewTest.Categories!.Count) return;
                TextBoxCondition.Text =
                    NewTest.Categories[NumberCategory - 1].ConditionsText.ElementAt(ComboBoxWithAllTheConditions.SelectedIndex).Value;
            }
            DataGridViewWithAllTheConditions.CellClick += UpdateTextBoxs!; // ПРИ КЛИКЕ
            DataGridViewWithAllTheConditions.CellValueChanged += UpdateTextBoxs!; // ПРИ ИЗМЕНЕНИИ ЯЧЕЕК

            // ЧИТАЕТ ВЫБРАННОЕ УСЛОВИЕ, ЗАПИСЫВАЕТ ЕГО ТЕКСТ
            Dictionary<string, string> ReadTextBoxForCondition()
            {
                TextBox TextBoxCondition = (TextBox)Controls.Find("TextBoxCondition", false).First();
                Dictionary<string, string> ChoiceConditionText = new Category().ConditionsText;
                // Обновляем если что-то вписали в TextBox
                if (TextBoxCondition.Text.ToString() != "")
                {
                    ChoiceConditionText[ChoiceConditionText.ElementAt(ComboBoxWithAllTheConditions.SelectedIndex).Key] =
                        TextBoxCondition.Text.ToString();
                }
                return ChoiceConditionText;
            }

            // BUTTON ИЗМЕНИТЬ, ЧТО МЕНЯЕТ ЗНАЧЕНИЕ NEWTEST И DATAGRIDVIEW У ВЫБРАННОГО УСЛОВИЯ
            void BtnChangeConditions_Click(object sender, EventArgs e)
            {
                int IdCondition = ComboBoxWithAllTheConditions.SelectedIndex;
                Dictionary<string, string> ChoiceCondition = ReadTextBoxForCondition();
                // Обновим значения
                NewTest.Categories[NumberCategory - 1].ConditionsText[ChoiceCondition.ElementAt(IdCondition).Key] =
                    ChoiceCondition.ElementAt(IdCondition).Value;
                DataTableConditions.Rows[IdCondition]["Условие"] = ChoiceCondition.ElementAt(IdCondition).Key;
                DataTableConditions.Rows[IdCondition]["Текст условия"] = ChoiceCondition.ElementAt(IdCondition).Value;
                // Обновим ListBox и переключим ComboBox на следующее условие для удобства,если есть
                if (ComboBoxWithAllTheConditions.SelectedIndex + 1 !=
                    ComboBoxWithAllTheConditions.Items.Count)
                { ComboBoxWithAllTheConditions.SelectedIndex += 1; }
                else ComboBoxWithAllTheConditions.SelectedIndex = 0;
            }
            Button BtnChangeConditions =
                (Button)this.Controls.Find("BtnChangeConditions", false).First();
            BtnChangeConditions.Click += BtnChangeConditions_Click!;

            // BUTTON НАЗАД, ВЫВОДИТ ФОРМУ ПРИСВОЕНИЯ ВОПРОСАМ БАЛЛОВ ПО КАТЕГОРИЯМ
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormNewValuesForQuestion(NewTest, 1);
            }
            Button BtnBack = (Button)this.Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ВАШ ТЕСТ, ВЫВОДИТ ФОРМУ ИНФОРМАЦИИ О ТЕСТЕ
            void BtnInfo_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormInfoTestOrToSave(NewTest);
            }
            Button BtnInfo = (Button)this.Controls.Find("BtnInfo", false).First();
            BtnInfo.Click += BtnInfo_Click!;

            // КНОПКА ДАЛЕЕ ЧТО ВЫВОДИТ СЛЕДУЮЩУЮ КАТЕГОРИЮ ИЛИ ЖЕ ЗАКАНЧИВАЕТ СОЗДАНИЕ ТЕСТА
            // ВЫВОДОМ ИНФОРМАЦИИ О НЕЙ И ПРЕДЛАГАЕТ ИЗМЕНИТЬ ТЕСТ ИЛИ ЖЕ СОХРАНИТЬ ЕГО
            void BtnNext_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                if (NumberCategory == NewTest.Categories.Count)
                {
                    CreateFormInfoTestOrToSave(NewTest);
                }
                else CreateFormNewConditionsForCategories(NewTest, NumberCategory + 1);
            }
            Button BtnNext = (Button)this.Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        // ФОРМА ИНФОРМАЦИИ О ТЕСТЕ, МОЖНО ИЗМЕНИТЬ ИЛИ СОХРАНИТЬ
        // КНОПКА СОХРАНЕНИЯ ПО УМОЛЧАНИЮ НЕ ДОСТУПНА
        private void CreateFormInfoTestOrToSave(Test NewTest, bool? NeedBtnBack = null)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Создание нового теста");
            // Label Id теста, Label Название теста, TextBox описания, ComboBox с вопросами, Button изменить
            FormHelper.CreateNewLabel("LabelIdTest", new Point(220, 50), new Size(100, 31), 16,
                $"Id: {NewTest.IdTest}");
            FormHelper.CreateNewLabel("LabelNameTest", new Point(320, 50), new Size(240, 31), 16,
                $"Название: {NewTest.NameTest}");
            FormHelper.CreateNewTextBox("TextBoxDescriptionTest", new Point(220, 90), new Size(400, 50), 14, null, true);
            List<string> ComboBoxWithAllTheQuestionsDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithAllTheQuestions", new Point(220, 150),
                new Size(400, 31), 16, null);
            FormHelper.CreateNewButton("BtnChangeNameTestAndQuestions", new Point(630, 50), new Size(150, 40),
                16, "Изменить");
            // Label ответов на вопросы по категории, Button изменить
            FormHelper.CreateNewLabel("LabelWithValuesAnswersForQuestionOnCategory", new Point(220, 190),
                new Size(400, 31), 14, null);
            FormHelper.CreateNewButton("BtnChangeValuesAnswersForQuestionOnCAtegory", new Point(630, 185),
                new Size(150, 40), 16, "Изменить");
            // ComboBox с категориями, Label значений категорий,Button изменить
            List<string> ComboBoxWithAllTheCategoriesDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithAllTheCategories", new Point(220, 230),
                new Size(400, 31), 16, null);
            FormHelper.CreateNewLabel("LabelWithValuesCategory", new Point(220, 270), new Size(400, 31),
                14, null);
            FormHelper.CreateNewButton("BtnChangeNamesAndValuesCategories", new Point(630, 230),
                new Size(150, 40), 16, "Изменить");
            // ComboBox с условиями,Label с текстом условия по категории и вопросу, Button изменить
            List<string> ComboBoxWithAllTheConditionsDataSource = new List<string>();
            FormHelper.CreateNewCombobox("ComboBoxWithAllTheConditions", new Point(220, 301),
                new Size(400, 31), 16, null);
            FormHelper.CreateNewTextBox("TextBoxWithTextOfCondition", new Point(220, 341), new Size(400, 50),
                14, null, true);
            FormHelper.CreateNewButton("BtnChangeTextOfCondition", new Point(630, 301), new Size(150, 40),
                16, "Изменить");
            // Button назад, Button назад, Button сохранить
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            FormHelper.CreateNewButton("BtnClear", new Point(425, 400), new Size(150, 40), 16, "Очистить");
            FormHelper.CreateNewButton("BtnSaveNewTest", new Point(630, 400), new Size(150, 40), 16, "Сохранить");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // TEXTBOX С ОПИСАНИЕМ ТЕСТА, МЕНЯЕМ НА READONLY И ДОБАВЛЯЕМ СКРОЛЛ, УБИРАЕМ РАМКУ
            TextBox TextBoxDescriptionTest = (TextBox)this.Controls.Find("TextBoxDescriptionTest", false).First();
            TextBoxDescriptionTest.ReadOnly = true;
            TextBoxDescriptionTest.ScrollBars = ScrollBars.Vertical;
            TextBoxDescriptionTest.Text = NewTest.DescriptionTest;

            // TEXTBOX С ТЕКСТОМ УСЛОВИЯ, МЕНЯЕМ НА READONLY И ДОБАВЛЯЕМ СКРОЛЛ, УБИРАЕМ РАМКУ
            TextBox TextBoxWithTextOfCondition =
                (TextBox)this.Controls.Find("TextBoxWithTextOfCondition", false).First();
            TextBoxWithTextOfCondition.ReadOnly = true;
            TextBoxWithTextOfCondition.ScrollBars = ScrollBars.Vertical;

            // ИЕРАРХИЯ ОБНОВЛЕНИЯ ДАННЫХ: 
            // 1 - COMBOBOXWITHALLTHECATEGORIES - COMBOBOX КАТЕГОРИИ
            // 2 - LABELWITHVALUESCATEGORY - МИН СРЕДН МАКС КАТЕГОРИИ
            // 3 - COMBOBOXWITHALLTHECONDITIONS - COMBOBOX УСЛОВИЯ
            // 4 - LABELWITHTEXTCONDITION - ТЕКСТ УСЛОВИЯ
            // 5 - COMBOBOXWITHALLTHEQUESTIONS - COMBOBOX ВОПРОСЫ
            // 6 - LABELWITHVALUESQUESTIONFORCATEGORY - ДА НЕТ СКОРЕЕ ДА СКОРЕЕ НЕТ

            // ОБНОВЛЕНИЕ COMBOBOX С ВОПРОСАМИ ПО ТИПУ : НОМЕР) ВОПРОС 
            void UpdateComboBoxWithAllTheQuestions()
            {
                ComboBox ComboBoxWithAllTheQuestions =
                    (ComboBox)Controls.Find("ComboBoxWithAllTheQuestions", false).First();
                ComboBoxWithAllTheQuestionsDataSource.Clear();
                ComboBox ComboBoxWithAllTheCategories =
                         (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                ComboBoxWithAllTheCategories.SelectedIndexChanged += UpdateLabelWithValuesAnswersForCategory!;
                ComboBoxWithAllTheQuestions.SelectedIndexChanged += UpdateLabelWithValuesAnswersForCategory!;
                if (NewTest.Categories!.Count == 0 || NewTest.Questions!.Count == 0)
                {
                    Label LabelWithValuesAnswersForQuestionOnCategory =
                        (Label)this.Controls.Find("LabelWithValuesAnswersForQuestionOnCategory", false).First();
                    LabelWithValuesAnswersForQuestionOnCategory.Text = "Ответы не найдены";
                    ComboBoxWithAllTheCategories.SelectedIndexChanged -= UpdateLabelWithValuesAnswersForCategory!;
                    ComboBoxWithAllTheQuestions.SelectedIndexChanged -= UpdateLabelWithValuesAnswersForCategory!;
                }
                if (NewTest.Questions!.Count == 0) ComboBoxWithAllTheQuestions.DataSource = new string[1] { "Вопросов нет" };
                else
                {
                    foreach (var Question in NewTest.Questions!)
                    {
                        ComboBoxWithAllTheQuestionsDataSource.Add(
                        $"{Question.IdQuestion + 1}) " + Question.TextQuestion);
                    }
                    ComboBoxWithAllTheQuestions.DataSource = ComboBoxWithAllTheQuestionsDataSource;
                }
            }

            // ОБНОВЛЕНИЕ COMBOBOX С КАТЕГОРИЯМИ ПО ТИПУ : НОМЕР) КАТЕГОРИЯ;
            // ТУТ ЖЕ ДОБАВЛЯЕМ СОБЫТИЕ ОБНОВЛЕНИЯ ПРИ СМЕНЕ ВЫДЕЛЕННОГО ОБЪЕКТА
            // ЕСЛИ НЕТ КАТЕГОРИЙ В NEWTEST, ТО МЕНЯЕМ ТЕКСТ ДЛЯ СВЯЗАННЫХ КОНТРОЛОВ
            void UpdateComboBoxWithAllTheCategories()
            {
                ComboBox ComboBoxWithAllTheCategories =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                Label LabelWithValuesCategory =
                    (Label)Controls.Find("LabelWithValuesCategory", false).First();
                ComboBox ComboBoxWithAllTheConditions =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheConditions", false).First();
                TextBox TextBoxWithTextOfCondition =
                    (TextBox)Controls.Find("TextBoxWithTextOfCondition", false).First();
                ComboBoxWithAllTheCategoriesDataSource.Clear();
                if (NewTest.Categories!.Count == 0)
                {
                    ComboBoxWithAllTheCategories.DataSource = new string[1] { "Отсутствуют категории" };
                    LabelWithValuesCategory.Text = "Значений для категорий не найдено";
                    ComboBoxWithAllTheConditions.DataSource = new string[1] { "Условия не доступны" };
                    TextBoxWithTextOfCondition.Text = "Текст к условию отсутствует";
                }
                else
                {
                    ComboBoxWithAllTheCategories.SelectedIndexChanged += UpdateLabelWithValuesCategory!;
                    ComboBoxWithAllTheCategories.SelectedIndexChanged += UpdateComboBoxWithAllTheConditions!;
                    ComboBoxWithAllTheCategories.SelectedIndexChanged += UpdateLabelWithTextOfCondition!;
                    foreach (var Category in NewTest.Categories!)
                    {
                        ComboBoxWithAllTheCategoriesDataSource.Add(
                        $"{Category.IdCategory + 1}) " + Category.NameCategory);
                    }
                    ComboBoxWithAllTheCategories.DataSource = ComboBoxWithAllTheCategoriesDataSource;
                }
            }
            UpdateComboBoxWithAllTheCategories();
            UpdateComboBoxWithAllTheQuestions();

            // ОБНОВЛЕНИЕ COMBOBOX С УСЛОВИЯМИ ПО ТИПУ : НОМЕР) УСЛОВИЕ
            void UpdateComboBoxWithAllTheConditions(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheConditions =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheConditions", false).First();
                ComboBoxWithAllTheConditionsDataSource.Clear();
                var ConditionText = new Category().ConditionsText;
                for (int i = 0; i < ConditionText.Count(); i++)
                {
                    ComboBoxWithAllTheConditionsDataSource.Add($"{i + 1}) {ConditionText.ElementAt(i).Key}");
                }
                ComboBoxWithAllTheConditions.DataSource = ComboBoxWithAllTheConditionsDataSource;
            }

            // ОБНОВЛЕНИЕ LABEL ПО ТИПУ: ЗНАЧЕНИЯ БАЛЛОВ ДЛЯ КАТЕГОРИИ: МИН.: СРЕДН.: МАКС.:
            void UpdateLabelWithValuesCategory(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                Label LabelWithValuesCategory =
                    (Label)this.Controls.Find("LabelWithValuesCategory", false).First();
                int IdCategory = ComboBoxWithAllTheCategories.SelectedIndex;
                LabelWithValuesCategory.Text =
                    $"Мин.: {NewTest.Categories![IdCategory].MinValueCategory} " +
                    $"Средн.: {NewTest.Categories[IdCategory].AverageValueCategory} " +
                    $"Макс.: {NewTest.Categories[IdCategory].MaxValueCategory} ";
            }

            // ОБНОВЛЕНИЕ LABEL С ОТВЕТАМИ НА ВОПРОСЫ ПО КАТЕГОРИИ ПО ТИПУ:
            // ОТВЕТЫ НА ВОПРОСЫ ПО КАТЕГОРИИ: ДА: НЕТ: СКОРЕЕ ДА: СКОРЕЕ НЕТ:
            void UpdateLabelWithValuesAnswersForCategory(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                ComboBox ComboBoxWithAllTheQuestions =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheQuestions", false).First();
                Label LabelWithValuesAnswersForQuestionOnCategory =
                    (Label)this.Controls.Find("LabelWithValuesAnswersForQuestionOnCategory", false).First();
                int IdCategory = ComboBoxWithAllTheCategories.SelectedIndex;
                int IdQuestion = ComboBoxWithAllTheQuestions.SelectedIndex;
                Dictionary<string, int> TextToAnswerAndAnswer =
                    NewTest.Questions![IdQuestion].AnswersToQuestionsByCategories[IdCategory].TextToAnswerAndAnswer;
                var CaAV = NewTest.Questions[IdQuestion].AnswersToQuestionsByCategories;
                LabelWithValuesAnswersForQuestionOnCategory.Text =
                    $"Да: {TextToAnswerAndAnswer.ElementAt(0).Value} " +
                    $"Нет: {TextToAnswerAndAnswer.ElementAt(1).Value} " +
                    $"Скорее да: {TextToAnswerAndAnswer.ElementAt(2).Value} " +
                    $"Скорее нет: {TextToAnswerAndAnswer.ElementAt(3).Value}";
            }

            // ОБНОВЛЕНИЕ LABEL С ТЕКСТОМ ДЛЯ УСЛОВИЯ ПО ТИПУ: УСЛОВИЕ
            void UpdateLabelWithTextOfCondition(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                ComboBox ComboBoxWithAllTheConditions =
                    (ComboBox)this.Controls.Find("ComboBoxWithAllTheConditions", false).First();
                TextBox LabelWithTextOfCondition =
                    (TextBox)this.Controls.Find("TextBoxWithTextOfCondition", false).First();
                int IdCategory = ComboBoxWithAllTheCategories.SelectedIndex;
                int IdCondition = ComboBoxWithAllTheConditions.SelectedIndex;
                string TextCondition =
                    NewTest.Categories![IdCategory].ConditionsText.ElementAt(IdCondition).Value;
                LabelWithTextOfCondition.Text = TextCondition;
            }

            // BUTTON ИЗМЕНИТЬ (1 СВЕРХУ), ПЕРЕХОДИТ К ФОРМЕ ДЛЯ РЕДАКТИРОВНИЯ ИМЕНИ,ОПИСАНИЯ, ВОПРОСОВ
            void BtnChangeNameTestAndQuestions_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormTest(NewTest);
            }
            Button BtnChangeNameTestAndQuestions = (Button)Controls.Find("BtnChangeNameTestAndQuestions", false).First();
            BtnChangeNameTestAndQuestions.Click += BtnChangeNameTestAndQuestions_Click!;

            // BUTTON ИЗМЕНИТЬ (2 СВЕРХУ), ПЕРЕХОДИТ К ФОРМЕ ДЛЯ РЕДАКТИРОВНИЯ ОТВЕТОВ НА ВОПРОСЫ ПО КАТЕГОРИИ
            void BtnChangeValuesAnswersForQuestionOnCAtegory_Click(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheQuestions = (ComboBox)Controls.Find("ComboBoxWithAllTheQuestions", false).First();
                FormHelper.DeleteControls(this);
                CreateFormNewValuesForQuestion(NewTest, ComboBoxWithAllTheQuestions.SelectedIndex + 1);
            }
            Button BtnChangeValuesAnswersForQuestionOnCAtegory = (Button)Controls.Find("BtnChangeValuesAnswersForQuestionOnCAtegory", false).First();
            BtnChangeValuesAnswersForQuestionOnCAtegory.Click += BtnChangeValuesAnswersForQuestionOnCAtegory_Click!;

            // BUTTON ИЗМЕНИТЬ (3 СВЕРХУ), ПЕРЕХОДИТ К ФОРМЕ ДЛЯ РЕДАКТИРОВНИЯ ОТВЕТОВ НА ВОПРОСЫ ПО КАТЕГОРИИ
            void BtnChangeNamesAndValuesCategories_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormNewCategories(NewTest);
            }
            Button BtnChangeNamesAndValuesCategories = (Button)Controls.Find("BtnChangeNamesAndValuesCategories", false).First();
            BtnChangeNamesAndValuesCategories.Click += BtnChangeNamesAndValuesCategories_Click!;

            // BUTTON ИЗМЕНИТЬ (4 СВЕРХУ), ПЕРЕХОДИТ К ФОРМЕ ДЛЯ РЕДАКТИРОВНИЯ КАТЕГОРИЙ
            void BtnChangeTextOfCondition_Click(object sender, EventArgs e)
            {
                ComboBox ComboBoxWithAllTheCategories = (ComboBox)this.Controls.Find("ComboBoxWithAllTheCategories", false).First();
                FormHelper.DeleteControls(this);
                CreateFormNewConditionsForCategories(NewTest, ComboBoxWithAllTheCategories.SelectedIndex + 1);
            }
            Button BtnChangeTextOfCondition = (Button)Controls.Find("BtnChangeTextOfCondition", false).First();
            BtnChangeTextOfCondition.Click += BtnChangeTextOfCondition_Click!;

            // BUTTON НАЗАД, ВЫВОДИТ ФОРМУ ПРИСВОЕНИЯ ТЕКСТОВ К УСЛОВИЯМ ПО КАТЕГОРИИ ИЛИ ФОРМУ С ЭКЗЕМПЛЯРАМИ
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                if (NeedBtnBack == true)
                {
                    CreateFormViewUserAndTest();
                }
                else CreateFormNewConditionsForCategories(NewTest, 1);
            }
            Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ОЧИСТИТЬ, УДАЛЯЕТ ЭТОТ ТЕСТ И ВЫВОДИТ НОВЫЙ АБСОЛЮТНО ЧИСТЫЙ НА ЭТОЙ ЖЕ ФОРМЕ
            void BtnClear_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                NewTest = new Test();
                CreateFormInfoTestOrToSave(NewTest);
            }
            Button BtnClear = (Button)Controls.Find("BtnClear", false).First();
            BtnClear.Click += BtnClear_Click!;

            // КНОПКА СОХРАНИТЬ, СОХРАНЯЕТ ТЕСТ С ТЕКУЩИМИ НАСТРОЙКАМИ
            // ВЫВОДИТ ФОРМУ ПОДТВЕРЖДЕНИЯ ТОГО,ЧТО ТЕСТ УСПЕШНО ЗАПИСАН И ПРЕДЛАГАЕТ ВЫЙТИ НА ГЛАВНУЮ
            void BtnSaveNewTest_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                if (TestsManager.Tests.Find(t => t.IdTest == NewTest.IdTest) == null)
                {
                    TestsManager.Add(NewTest);
                }
                else 
                { 
                    TestsManager.Tests[NewTest.IdTest] = NewTest;
                    TestsManager.Write();
                }
                CreateFormConfirmationNewTest(NewTest);
            }
            Button BtnSaveNewTest = (Button)this.Controls.Find("BtnSaveNewTest", false).First();
            BtnSaveNewTest.Click += BtnSaveNewTest_Click!;
        }

        // ФОРМА ПОДТВЕРЖДЕНИЯ СОЗДАНИЯ ТЕСТА И ВЫХОДОМ НА ГЛАВНЫЙ ЭКРАН
        private void CreateFormConfirmationNewTest(Test NewTest)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Тест создан");
            // Label подтверждения, Button на главную
            FormHelper.CreateNewLabel("LabelNewTest", new Point(220, 50), new Size(400, 31), 16,
                $"Тест с именем {NewTest.NameTest} успешно сохранён.");
            FormHelper.CreateNewButton("BtnGoToMainForm", new Point(630, 400), new Size(150, 40), 16, "На главную");
            FormHelper.AddConrols(this);
            
            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ

            // BUTTON НА ГЛАВНУЮ, ВЫВОДИТ ГЛАВНУЮ ФОРМУ
            void BtnGoToMainForm_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateMainForm();
            }
            Button BtnGoToMainForm = (Button)Controls.Find("BtnGoToMainForm", false).First();
            BtnGoToMainForm.Click += BtnGoToMainForm_Click!;
        }

        // СОЗДАНИЕ ГЛАВНОЙ ФОРМЫ
        private void CreateMainForm()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16, "Главная");
            // Label id, Label имя, Label привелегия
            FormHelper.CreateNewLabel("LabelUserId", new Point(220, 50), new Size(70, 31), 16, $"Id: {UsersManager.MainUser.IdUser}");
            FormHelper.CreateNewLabel("LabelUserName", new Point(300, 50), new Size(320, 31), 16, $"Имя: {UsersManager.MainUser.NameUser}");
            FormHelper.CreateNewLabel("LabelUserPrivelege", new Point(220, 90), new Size(400, 31), 16, $"Привелегия: {UsersManager.MainUser.PrivelegeUser}");
            //  Label количество тестов, Label количество пользователей,
            FormHelper.CreateNewLabel("LabelNumberOfTests", new Point(220, 130), new Size(400, 31), 16, $"Общее количество тестов: {TestsManager.Tests.Count}");
            FormHelper.CreateNewLabel("LabelNumberOfUsers", new Point(220, 170), new Size(400, 31), 16,
                $"Общее количество пользователей: {UsersManager.Users.Count}");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ
        }

        // Создание нового пользователя
        private void CreateFormUser(User NewUser, bool? NeedBtnBack = null)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16, "Конструктор создания пользователя");
            // TextBox , TextBox Пароль, TextBox уровень доступа пользователя, Button создания пользователя
            FormHelper.CreateNewLabel("TextBoxIdUser", new Point(220, 50), new Size(70, 31), 16, $"Id: {UsersManager.Users.Count}");
            FormHelper.CreateNewTextBox("TextBoxNameUser", new Point(300, 50), new Size(320, 31), 16, "Имя пользователя");
            FormHelper.CreateNewTextBox("TextBoxPasswordUser", new Point(220, 90), new Size(400, 31), 16, "Пароль");
            FormHelper.CreateNewLabel("TextBoxIdUser", new Point(220, 130), new Size(400, 31), 16, "Привелегия:");
            FormHelper.CreateNewCombobox("ComboboxWithPrivelegeUser", new Point(220, 170), new Size(400, 31), 16, User.Priveleges);
            FormHelper.CreateNewButton("BtnCreateUser", new Point(630, 400), new Size(150, 40), 16, "Сохранить");
            // Button назад
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "<<<Назад");
            // Добавление контролов
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ

            // СОЗДАЁТ BUTTON НАЗАД НА ФОРМУ С ЭКЗЕМПЛЯРАМИ ИЛИ К ФОРМЕ ВЫБОРА КОНСТРУКТОРА
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                if (NeedBtnBack == true) CreateFormViewUserAndTest();
                else CreaterNew();
            }
            Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // УРОВЕНЬ ДОСТУПА В COMBOBOX ПО УМОЛЧАНИЮ
            ComboBox ComboBoxWithPrivelegeUser = (ComboBox)Controls.Find("ComboBoxWithPrivelegeUser", false).First();
            ComboBoxWithPrivelegeUser.SelectedItem = User.Priveleges[2];

            // ЕСЛИ ПРИШЁЛ ИЗ ЭКЗЕМПЛЯРОВ, ТО ОБНОВИМ КОНТРОЛЫ
            void UpdateControlsOnChoiceUser()
            {
                Label LabelIdUser = (Label)Controls.Find("TextBoxIdUser", false).First();
                TextBox TextBoxNameUser = (TextBox)Controls.Find("TextBoxNameUser", false).First();
                TextBox TextBoxPasswordUser = (TextBox)Controls.Find("TextBoxPasswordUser", false).First();
                LabelIdUser.Text = $"Id: {NewUser.IdUser}";
                TextBoxNameUser.Text = $"{NewUser.NameUser}";
                TextBoxPasswordUser.Text = $"{NewUser.Password}";
                ComboBoxWithPrivelegeUser.SelectedIndex = User.Priveleges.IndexOf(NewUser.PrivelegeUser);
            }
            if (NeedBtnBack == true) UpdateControlsOnChoiceUser(); else return;

            // BUTTON ЗАПИСЫВАЕТ НОВОГО ПОЛЬЗОВАТЕЛЯ, ВЫВОДИТ ФОРМУ ПОДТВЕРЖДЕНИЯ
            void CreateUser_Click(object sender, EventArgs e)
            {
                TextBox TextBoxNameUser = (TextBox)Controls.Find("TextBoxNameUser", false).First();
                TextBox TextBoxPasswordUser = (TextBox)Controls.Find("TextBoxPasswordUser", false).First();
                var NewUser = new User();
                if (TextBoxNameUser.Text.ToString() != "") NewUser.NameUser = TextBoxNameUser.Text;
                if (TextBoxNameUser.Text.ToString() != "") NewUser.NameUser = TextBoxNameUser.Text;
                if (ComboBoxWithPrivelegeUser.SelectedIndex != 3) NewUser.PrivelegeUser = User.Priveleges[ComboBoxWithPrivelegeUser.SelectedIndex];
                UsersManager.UserAdd(NewUser);
                FormHelper.DeleteControls(this);
                CreateFormConfirmationNewUser(NewUser);
            }
            Button BtnCreateUser = (Button)this.Controls.Find("BtnCreateUser", false).First();
            BtnCreateUser.Click += CreateUser_Click!;
        }

        // ФОРМА ПОДТВЕРЖДЕНИЯ СОЗДАНИЯ ТЕСТА И ВЫХОДОМ НА ГЛАВНЫЙ ЭКРАН
        private void CreateFormConfirmationNewUser(User NewUser)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16,
                "Пользователь создан");
            // Label подтверждения, Button на главную
            FormHelper.CreateNewLabel("LabelNewUser", new Point(220, 50), new Size(400, 31), 16,
                $"Пользователь с именем {NewUser.NameUser} успешно сохранён.");
            FormHelper.CreateNewButton("BtnGoToMainForm", new Point(630, 400), new Size(150, 40), 16, "На главную");

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ

            // BUTTON НА ГЛАВНУЮ, ВЫВОДИТ ГЛАВНУЮ ФОРМУ
            void BtnGoToMainForm_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateMainForm();
            }
            Button BtnGoToMainForm = (Button)Controls.Find("BtnGoToMainForm", false).First();
            BtnGoToMainForm.Click += BtnGoToMainForm_Click!;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteControls(this);
            CreateMainForm();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            CreateMainForm();
        }

        // BUTTON К ТЕСТАМ, ВЫВОДИТ ФОРМУ 
        private void BtnToTests_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteControls(this);
            ChoiceTests NewChoiceTest = new ChoiceTests();
            this.Hide();
            NewChoiceTest.Show();
        }
    }
}
