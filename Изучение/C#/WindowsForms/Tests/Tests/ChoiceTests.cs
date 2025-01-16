using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForUser
{
    public partial class ChoiceTests : Form
    {
        public ChoiceTests()
        {
            InitializeComponent();
        }

        private void ChoiceTests_FormClosed(object sender, FormClosedEventArgs e)
        {
            // закрытие всех форм
            Application.Exit();
        }

        private void ChoiceTests_Load(object sender, EventArgs e)
        {
            User MainUser = UsersManager.MainUser;
            LabelWithNameUser.Text = $"Имя:\n{MainUser.NameUser}";
            int Lenght = MainUser.Password.Length;
            string EncryptedPassword = "";
            LabelWithPasswordUser.Text = $"Пароль:\n {EncryptedPassword.PadLeft(Lenght, '*')}";
            CreateFormTestsForUser();
        }

        // ФОРМА С ТЕСТАМИ
        private void CreateFormTestsForUser()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16, "Тесты");
            // Label пояснения, DataGridView с тестами, Label что выбрали, Button выбрать
            FormHelper.CreateNewLabel("LabelHelpForTest", new Point(220, 50), new Size(400, 31), 16, "Выберите тест для решения");
            DataTable DataTableTests = new DataTable();
            FormHelper.CreateNewDataGridView("DataGridViewWithAllTheTests", new Point(220, 90), new Size(560, 300), 14, Color.White);
            FormHelper.CreateNewLabel("LabelHelpChoiceTest", new Point(220, 400), new Size(400, 60), 14, "Вы ничего не выбрали");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Выбрать");
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ

            // ОБНОВЛЕНИЕ DATAGRIDIEW С ТЕСТАМИ ПО ТИПУ: ИМЯ-ТЕСТА ОПИСАНИЕ КОЛИЧЕСТВО-ВОПРОСОВ
            DataGridView DataGridViewWithAllTheTests = (DataGridView)Controls.Find("DataGridViewWithAllTheTests", false).First();
            void UpdateDataGridViewAllTheTests()
            {
                DataTableTests.Columns.AddRange(new DataColumn[] {new DataColumn(Name= "Имя", typeof(string)), new DataColumn(Name = "Описание", typeof(string)) ,
                    new DataColumn(Name = "Вопросы", typeof(string)) });
                foreach (var Test in TestsManager.Tests)
                {
                    DataRow NewDataRow = DataTableTests.NewRow();
                    NewDataRow["Имя"] = Test.NameTest;
                    NewDataRow["Описание"] = Test.DescriptionTest;
                    NewDataRow["Вопросы"] = Test.Questions!.Count();
                    DataTableTests.Rows.Add(NewDataRow);
                }
                DataGridViewWithAllTheTests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                DataGridViewWithAllTheTests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DataGridViewWithAllTheTests.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DataGridViewWithAllTheTests.ScrollBars = ScrollBars.Vertical;
                DataGridViewWithAllTheTests.DataSource = DataTableTests;
                DataGridViewWithAllTheTests.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataGridViewWithAllTheTests.ReadOnly = true;
            }
            UpdateDataGridViewAllTheTests();

            // СОБЫТИЕ НАЖАТИЯ НА DATAGRIDVIEW ИЗМЕНИТ LABEL С ТЕСТОМ, КОТОРЫЙ ВЫБРАЛИ
            void UpdateLabelHelpChoiseTest(object? sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= TestsManager.Tests.Count()) return;
                else
                {
                    Label LabelHelpChoiseTest = (Label)this.Controls.Find("LabelHelpChoiceTest", false).First();
                    int IdTest = DataGridViewWithAllTheTests.SelectedCells[0].RowIndex;
                    LabelHelpChoiseTest.Text = $"Вы выбрали тест: {TestsManager.Tests[IdTest].NameTest}";
                }
            }
            DataGridViewWithAllTheTests.CellClick += UpdateLabelHelpChoiseTest!; // ПРИ КЛИКЕ

            // BUTTON ВЫБРАТЬ, ПЕРЕХОДИТ НА ФОРМУ С РЕШЕНИЕМ ТЕСТА
            void BtnNext_Click(object sender, EventArgs e)
            {
                Label LabelHelpChoiceTest = (Label)Controls.Find("LabelHelpChoiceTest", false).First();
                if (LabelHelpChoiceTest.Text.ToString() == "Вы ничего не выбрали") { }
                else
                {
                    // ПО ВЫБРАННОМУ ТЕСТУ ОБНОВИМ ВОПРОСЫ, КАТЕГОРИИ
                    int IdTest = DataGridViewWithAllTheTests.CurrentCell.RowIndex;
                    Test ChoiceTest = TestsManager.Tests.Find(x => x.IdTest == IdTest)!;
                    TestsManager.MainTest = ChoiceTest;
                    AnswersManager.Answers = new Answer()
                    {
                        NumberTest = ChoiceTest.IdTest,
                        NameUser = UsersManager.MainUser.NameUser,
                        NumberQuestionandAnswer = AnswersManager.AddCleanAnswerOnQuestion(ChoiceTest.Questions!.Count()),
                    };
                    FormHelper.DeleteControls(this);
                    TestRun NewTestRun = new TestRun();
                    NewTestRun.Text = ChoiceTest.NameTest;
                    Hide();
                    NewTestRun.Show();
                }
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        public void Show(ChoiceTests choiceTests)
        {
            CreateFormTestsForUser();
            choiceTests.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Login Login = (Login)Application.OpenForms[0]!;
            this.Hide();
            Login.Show();
        }

        private void BtnChangePasswordUser_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteControls(this);
            CreateFormNewPassword();
        }

        // ФОРМА ОБНОВЛЕНИЯ ПАРОЛЯ
        private void CreateFormNewPassword()
        {
            // ГЛАВНЫЕ КОНТРОЛЫ

            // Label сверху говорящий о том что делаем
            FormHelper.CreateNewLabel("LabelHelpText", new Point(270, 10), new Size(500, 31), 16, "Обновление пароля");
            // Label пояснения, TextBox ввод старого пароля, Button подтвердить
            FormHelper.CreateNewLabel("LabelOldPassword", new Point(220, 50), new Size(400, 31), 16, "Введите старый пароль:");
            FormHelper.CreateNewTextBox("TextBoxOldPassword", new Point(220, 90), new Size(400, 31), 16, "Старый пароль");
            FormHelper.CreateNewButton("BtnCheckOldPassword", new Point(630, 90), new Size(150, 40), 16, "Продолжить");
            // Label пояснения, TextBox 1 ввод пароля, Label поянения, TextBox 2 ввод пароля, Button назад, Button Обновить
            FormHelper.CreateNewLabel("LabelNewPassword", new Point(220, 130), new Size(400, 31), 16, "Введите новый пароль:");
            FormHelper.CreateNewTextBox("TextBoxOneNewPassword", new Point(220, 170), new Size(400, 31), 16, "Новый пароль");
            FormHelper.CreateNewLabel("LabelNewPassword", new Point(220, 210), new Size(400, 31), 16, "Введите новый пароль ещё раз:");
            FormHelper.CreateNewTextBox("TextBoxTwoNewPassword", new Point(220, 250), new Size(400, 31), 16, "Новый пароль");
            FormHelper.CreateNewButton("BtnBack", new Point(220, 400), new Size(150, 40), 16, "Назад");
            FormHelper.CreateNewButton("BtnNext", new Point(630, 400), new Size(150, 40), 16, "Обновить");
            FormHelper.AddConrols(this);

            // ПЕРСОНАЛЬНАЯ НАСТРОЙКИ

            // BUTTON ОБНОВИТЬ, ОБНОВЛЯЕТ ПАРОЛЬ ДЛЯ ПОЛЬЗОВАТЕЛЯ, ЕСЛИ ВВЕДЁННЫЕ ПАРОЛИ СОВПАДАЮ, ПЕРЕХАД НА ВКЛАДКУ ВЫБОРА
            void BtnNext_Click(object sender, EventArgs e)
            {
                TextBox TextBoxOneNewPassword = (TextBox)Controls.Find("TextBoxOneNewPassword", false).First();
                TextBox TextBoxTwoNewPassword = (TextBox)Controls.Find("TextBoxTwoNewPassword", false).First();
                if (TextBoxOneNewPassword.Text == TextBoxTwoNewPassword.Text) UsersManager.ChangePassword(TextBoxTwoNewPassword.Text);
                FormHelper.DeleteControls(this);
                CreateFormTestsForUser();
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Visible = false;
            BtnNext.Click += BtnNext_Click!;

            // BUTTON НАЗАД, ИДЁТ НАЗАД НА ВЫБОР ВКЛАДКУ ВЫБОРА ТЕСТА
            void BtnBack_Click(object sender, EventArgs e)
            {
                FormHelper.DeleteControls(this);
                CreateFormTestsForUser();
            }
            Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
            BtnBack.Click += BtnBack_Click!;

            // BUTTON ПРОДОЛЖИТЬ, ПРОВЕРЯЕТ ПРАВИЛЬНОСТЬ СТАРОГО ПАРОЛЯ, ДАЛЕЕ ПОКАЗЫВАЕТ КНОПКУ ОБНОВИТЬ
            void BtnCheckOldPassword_Click(object sender, EventArgs e)
            {
                TextBox TextBoxOldPassword = (TextBox)Controls.Find("TextBoxOldPassword", false).First();
                if (TextBoxOldPassword.Text == UsersManager.MainUser.Password) BtnNext.Visible = true;
            }
            Button BtnCheckOldPassword = (Button)Controls.Find("BtnCheckOldPassword", false).First();
            BtnCheckOldPassword.Click += BtnCheckOldPassword_Click!;
        }
    }
}
