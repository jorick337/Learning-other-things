
namespace TestForUser
{
    public partial class TestRun : Form
    {
        public TestRun()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateFormSolutionTest(1);
        }
        // ФОРМА ОТВЕТОВ НА ВОПРОСЫ ТЕСТА
        private void CreateFormSolutionTest(int NumberQuestion)
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // ProgressBar с количеством вопросов, Label с номером вопроса, Label вопроса, 
            FormHelper.CreateNewProgressBar("ProgressBarOfNumberQuestion", new Point(10, 10), new Size(550, 30), 16);
            FormHelper.CreateNewLabel("LabelHelpTextForNumberQuestion", new Point(10, 40), new Size(500, 20), 12, null);
            FormHelper.CreateNewLabel("LabelTextQuestion", new Point(10, 70), new Size(550, 50), 16, null);
            // Radiobuttons да, нет, скорее да, скорее нет
            FormHelper.CreateNewRadioButton("RadioButtonYes", new Point(10, 150), new Size(550, 31), 16, "Да");
            FormHelper.CreateNewRadioButton("RadioButtonProbablyYes", new Point(10, 190), new Size(550, 31), 16, "Скорее да");
            FormHelper.CreateNewRadioButton("RadioButtonProbablyNo", new Point(10, 230), new Size(550, 31), 16, "Скорее нет");
            FormHelper.CreateNewRadioButton("RadioButtonNo", new Point(10, 270), new Size(550, 31), 16, "Нет");
            // Button назад, Button далее
            FormHelper.CreateNewButton("BtnBack", new Point(10, 300), new Size(150, 40), 16, "Назад");
            FormHelper.CreateNewButton("BtnNext", new Point(410, 300), new Size(150, 40), 16, "Далее");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // BUTTON НАЗАД, СТАНОВИТЬСЯ НЕВИДИМОЙ ЕСЛИ НОМЕР ВОПРОСА РАВЕН 1
            void NotVisibleForBtnBack()
            {
                Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
                if (NumberQuestion == 1) BtnBack.Visible = false;
            }

            // ОБНОВЛЕНИЕ LABELS СВЯЗАННЫЕ С ВОПРОСОМ, SCROLLBAR С КОЛИЧЕСТВОМ
            void UpdateLabelsQuestion()
            {
                ProgressBar ProgressBarOfNumberQuestion = (ProgressBar)Controls.Find("ProgressBarOfNumberQuestion", false).First();
                Label LabelHelpTextForNumberQuestion = (Label)Controls.Find("LabelHelpTextForNumberQuestion", false).First();
                Label LabelTextQuestion = (Label)Controls.Find("LabelTextQuestion", false).First();
                LabelTextQuestion.Text = $"{NumberQuestion}) {TestsManager.MainTest.Questions![NumberQuestion - 1].TextQuestion}";
                LabelHelpTextForNumberQuestion.Text = $"{NumberQuestion}/{TestsManager.MainTest.Questions!.Count()}";
                ProgressBarOfNumberQuestion.Maximum = TestsManager.MainTest.Questions!.Count();
                ProgressBarOfNumberQuestion.Value = NumberQuestion;
            }
            UpdateLabelsQuestion();

            // ОБНОВИТ ОТВЕТЫ ДЛЯ ТЕСТА
            void UpdateAnswer()
            {
                ProgressBar ProgressBarOfNumberQuestion = (ProgressBar)Controls.Find("ProgressBarOfNumberQuestion", false).First();
                RadioButton RadioButtonYes = (RadioButton)Controls.Find("RadioButtonYes", false).First();
                RadioButton RadioButtonProbablyYes = (RadioButton)Controls.Find("RadioButtonProbablyYes", false).First();
                RadioButton RadioButtonProbablyNo = (RadioButton)Controls.Find("RadioButtonProbablyNo", false).First();
                RadioButton RadioButtonNo = (RadioButton)Controls.Find("RadioButtonNo", false).First();
                if (RadioButtonYes.Enabled == true) AnswersManager.UpdateAnswers(ProgressBarOfNumberQuestion.Value, 1);
                if (RadioButtonProbablyYes.Enabled == true) AnswersManager.UpdateAnswers(ProgressBarOfNumberQuestion.Value, 2);
                if (RadioButtonProbablyNo.Enabled == true) AnswersManager.UpdateAnswers(ProgressBarOfNumberQuestion.Value, 3);
                if (RadioButtonNo.Enabled == true) AnswersManager.UpdateAnswers(ProgressBarOfNumberQuestion.Value, 4);
            }

            // КНОПКА ДАЛЕЕ ЧТО ВЕДЁТ К СЛЕДУЮЩЕМУ ВОПРОСУ ИЛИ ВЫВОДИТ ФОРМУ ВЫВОДА ТЕКСТА
            // ПОСЛЕ ПРОХОЖДЕНИЯ В ЗАВИСИМОСТИ ОТ УСЛОВИЙ
            void BtnNext_Click(object sender, EventArgs e)
            {
                UpdateAnswer();
                FormHelper.DeleteControls(this);
                if (NumberQuestion == TestsManager.MainTest.Questions!.Count())
                {
                    CreateFormEndTest();
                }
                else CreateFormSolutionTest(NumberQuestion + 1);
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        // ФОРМА КОНЕЦ ТЕСТА
        private void CreateFormEndTest()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label помогает понять где мы
            FormHelper.CreateNewLabel("LabelHelpText", new Point(70, 10), new Size(500, 31), 16, "Результаты прохождения теста");
            // ListBox с категориями и результатами, Button перерешать, Button на главную
            List<string> ListBoxWithAllTheResultsDataSource = new List<string>();
            FormHelper.CreateNewTextBox("TextBoxWithAllTheResults", new Point(10, 50), new Size(500, 240), 16, null);
            FormHelper.CreateNewButton("BtnBack", new Point(10, 300), new Size(150, 40), 16, "Заново");
            FormHelper.CreateNewButton("BtnNext", new Point(410, 300), new Size(150, 40), 16, "На главную");
            // Добавление обьектов на форму
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНЫЕ НАСТРОЙКИ

            // LISTBOX С РЕЗУЛЬТАТАМИ ОБНОВЛЕНИЕ ПО ТИПУ: НОМЕРКАТЕГОРИИ) КАТЕГОРИЯ: ТЕКСТУСЛОВИЯ 
            void UpdateListBoxWithAllTheResults()
            {
                TextBox TextBoxWithAllTheResults = (TextBox)Controls.Find("TextBoxWithAllTheResults", false).First();
                foreach (var Category in TestsManager.MainTest.Categories!)
                {
                    string NewResult = $"{Category.IdCategory + 1}) {Category.NameCategory}: {CategoriesManager.ShowResults(Category)}";
                    TextBoxWithAllTheResults.Text = TextBoxWithAllTheResults.Text + NewResult + Environment.NewLine;
                }
                TextBoxWithAllTheResults.Multiline = true;
                TextBoxWithAllTheResults.ReadOnly = true;
                TextBoxWithAllTheResults.BorderStyle = BorderStyle.None;
                TextBoxWithAllTheResults.ScrollBars = ScrollBars.Vertical;
            }
            UpdateListBoxWithAllTheResults();

            // КНОПКА НА ГЛАВНУЮ, ПОКАЗЫВАЕТ ФОРМУ С ТЕСТАМИ И СОХРАНЯЕТ ОТВЕТЫ ДЛЯ ПОЛЬЗОВАТЕЛЯ ЕСЛИ ПРИВЕЛЕГИЯ НЕ ГОСТЬ
            void BtnNext_Click(object sender, EventArgs e)
            {
                if (UsersManager.MainUser.PrivelegeUser != "guest")
                {
                    UsersManager.WriteAnswer();
                }
                FormHelper.DeleteControls(this);
                this.Hide();
                ChoiceTests ChoiceTestsForm = Application.OpenForms.OfType<ChoiceTests>().FirstOrDefault(form => form.Text == "Тесты")!;
                ChoiceTestsForm.Show(ChoiceTestsForm);
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        private void TestRun_FormClosed(object sender, FormClosedEventArgs e)
        {// закрытие всех форм
            Application.Exit();
        }
    }
}