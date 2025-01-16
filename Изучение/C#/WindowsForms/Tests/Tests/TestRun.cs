
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
        // ����� ������� �� ������� �����
        private void CreateFormSolutionTest(int NumberQuestion)
        {
            // ������� ��������

            // ProgressBar � ����������� ��������, Label � ������� �������, Label �������, 
            FormHelper.CreateNewProgressBar("ProgressBarOfNumberQuestion", new Point(10, 10), new Size(550, 30), 16);
            FormHelper.CreateNewLabel("LabelHelpTextForNumberQuestion", new Point(10, 40), new Size(500, 20), 12, null);
            FormHelper.CreateNewLabel("LabelTextQuestion", new Point(10, 70), new Size(550, 50), 16, null);
            // Radiobuttons ��, ���, ������ ��, ������ ���
            FormHelper.CreateNewRadioButton("RadioButtonYes", new Point(10, 150), new Size(550, 31), 16, "��");
            FormHelper.CreateNewRadioButton("RadioButtonProbablyYes", new Point(10, 190), new Size(550, 31), 16, "������ ��");
            FormHelper.CreateNewRadioButton("RadioButtonProbablyNo", new Point(10, 230), new Size(550, 31), 16, "������ ���");
            FormHelper.CreateNewRadioButton("RadioButtonNo", new Point(10, 270), new Size(550, 31), 16, "���");
            // Button �����, Button �����
            FormHelper.CreateNewButton("BtnBack", new Point(10, 300), new Size(150, 40), 16, "�����");
            FormHelper.CreateNewButton("BtnNext", new Point(410, 300), new Size(150, 40), 16, "�����");
            // ���������� �������� �� �����
            FormHelper.AddConrols(this);

            // ������������ ���������

            // BUTTON �����, ����������� ��������� ���� ����� ������� ����� 1
            void NotVisibleForBtnBack()
            {
                Button BtnBack = (Button)Controls.Find("BtnBack", false).First();
                if (NumberQuestion == 1) BtnBack.Visible = false;
            }

            // ���������� LABELS ��������� � ��������, SCROLLBAR � �����������
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

            // ������� ������ ��� �����
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

            // ������ ����� ��� ��Ĩ� � ���������� ������� ��� ������� ����� ������ ������
            // ����� ����������� � ����������� �� �������
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

        // ����� ����� �����
        private void CreateFormEndTest()
        {
            // ������� ��������

            // Label �������� ������ ��� ��
            FormHelper.CreateNewLabel("LabelHelpText", new Point(70, 10), new Size(500, 31), 16, "���������� ����������� �����");
            // ListBox � ����������� � ������������, Button ����������, Button �� �������
            List<string> ListBoxWithAllTheResultsDataSource = new List<string>();
            FormHelper.CreateNewTextBox("TextBoxWithAllTheResults", new Point(10, 50), new Size(500, 240), 16, null);
            FormHelper.CreateNewButton("BtnBack", new Point(10, 300), new Size(150, 40), 16, "������");
            FormHelper.CreateNewButton("BtnNext", new Point(410, 300), new Size(150, 40), 16, "�� �������");
            // ���������� �������� �� �����
            FormHelper.AddConrols(this);

            // ������������ ���������

            // LISTBOX � ������������ ���������� �� ����: ��������������) ���������: ������������ 
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

            // ������ �� �������, ���������� ����� � ������� � ��������� ������ ��� ������������ ���� ���������� �� �����
            void BtnNext_Click(object sender, EventArgs e)
            {
                if (UsersManager.MainUser.PrivelegeUser != "guest")
                {
                    UsersManager.WriteAnswer();
                }
                FormHelper.DeleteControls(this);
                this.Hide();
                ChoiceTests ChoiceTestsForm = Application.OpenForms.OfType<ChoiceTests>().FirstOrDefault(form => form.Text == "�����")!;
                ChoiceTestsForm.Show(ChoiceTestsForm);
            }
            Button BtnNext = (Button)Controls.Find("BtnNext", false).First();
            BtnNext.Click += BtnNext_Click!;
        }

        private void TestRun_FormClosed(object sender, FormClosedEventArgs e)
        {// �������� ���� ����
            Application.Exit();
        }
    }
}