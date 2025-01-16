namespace CityLibraryInfoSystem
{
    public partial class ConnectionToDataBase : Form
    {
        public ConnectionToDataBase()
        {
            InitializeComponent();
        }

        private void MergeData()
        {
            string link = "";

            if (CheckingForValueNull())
            {
                label_HelpText.Text = "Заполните все поля";
            }
            else
            {
                link = "server=" + textBox_ServerName.Text + ";";
                link += "user=" + textBox_NameUser.Text + ";";
                link += "database=" + textBox_NameDatabase.Text + ";";
                link += "password=" + textBox_PasswordUser.Text + ";";
            }

            BasicDatabaseValues.LoadDatabase(link);
        }

        private bool CheckingForValueNull()
        {
            if (textBox_NameDatabase.Text == null || textBox_PasswordUser.Text == null || textBox_NameUser == null || textBox_ServerName == null)
            {
                return true;
            }
            else return false;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            MergeData();
            
            if (BasicDatabaseValues.ActiveDatabase?.ConnectionToDatabase.State == System.Data.ConnectionState.Open)
            {
                MainForm.thisForm?.UpdateForm();
            }
            MainForm.thisForm?.Show();

            Hide();
        }

        private void ConnectionToDataBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox_ShowPasswordUser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowPasswordUser.Checked == true)
            {
                textBox_PasswordUser.PasswordChar = new char();
            }
            else
            {
                textBox_PasswordUser.PasswordChar = '*';
            }
        }
    }
}
