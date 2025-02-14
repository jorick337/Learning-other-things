using System.Data;

namespace CityLibraryInfoSystem
{
    public partial class MainForm : Form
    {
        public static MainForm thisForm = new();

        public MainForm()
        {
            InitializeComponent();
            panel_Manual.Controls.Add(LabelToDisplayGuide());
        }
        
        public void UpdateForm()
        {
            BasicDatabaseValues.ActiveDatabase?.Open();
            AddTableNames();
            DisplayTable();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void AddTableNames()
        {
            comboBox_TablesName.DataSource = BasicDatabaseValues.ActiveDatabase?.GetTableNames();
            comboBox_TablesName.SelectedIndex = 0;
        }

        private void comboBox_TablesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTable();
        }

        private void DisplayTable()
        {
            dataGridView_Table.DataSource = null;
            dataGridView_Table.DataSource = BasicDatabaseValues.ActiveDatabase?.GetTable(comboBox_TablesName.SelectedItem?.ToString()!);
        }

        private void MainForm_Resize_1(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                comboBox_TablesName.Size = new Size(ClientSize.Width - 208, 39);

                dataGridView_Table.Size = new Size(ClientSize.Width - 208, ClientSize.Height - 50);

                panel_Manual.Size = new Size(ClientSize.Width - 208, ClientSize.Height - 50);
                panel_Manual.Visible = false;
                panel_Manual.Visible = true;

                label_Manual.Font = new Font(label_Manual.Font.FontFamily, panel_Manual.Width * 0.023f + 9);
                label_Manual.Location = new Point(((ClientSize.Width - 202 - label_Manual.Width) / 2) + 202, 0);

                btn_LeaveManual.Location = new Point(-5, ClientSize.Height - 39);
            }
        }

        private void btn_Database_Click(object sender, EventArgs e)
        {
            Hide();
            Form connectionToDataBase = Application.OpenForms[0]!;
            connectionToDataBase.Show();
        }

        private void btn_SendUpdatedData_Click(object sender, EventArgs e)
        {
            BasicDatabaseValues.ActiveDatabase?.SetUpdate(GetDataTable());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            comboBox_TablesName.Visible = false;
            dataGridView_Table.Visible = false;

            label_Manual.Visible = true;
            panel_Manual.Visible = true;
            btn_LeaveManual.Visible = true;
        }

        private Label LabelToDisplayGuide()
        {
            Label label_ManualText = new Label()
            {
                Text = "Данное руководство рекомендуется для прочтения всем пользователям\r\n\r\n" +
                "О ПРИЛОЖЕНИИ.\r\n\r\n" +
                "Приложение \"ConnectToDatabase\" создано с целью управления\nБД MySQL.\r\n\r\n" +
                "ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ.\r\n\r\n" +
                "Для начала работы нужно подключиться к базе данных, используя имя\nсервера, базы данных, пользователя и пароля к нему.\n" +
                "Далее нажать на кнопку \"Загрузить\", попадая при этом\nна основное окно приложения.\r\n\r\n" +
                "РАБОТА С БД.\r\n\r\n" +
                "На основном окне пользователь может при помощи выпадающего\nсписка пользователь может выбрать таблицу из загруженной БД." +
                "\r\nТаблица будет загружена и отображена, что позволит изменять,\nдобавлять и удалять значения.\r\n\r\n" +
                "СОХРАНЕНИЕ БД.\r\n\r\n" +
                "Кнопка \"Отправить\" отправит изменнения в БД.\r\n\r\n" +
                "КНОПКА \"Руководство\".\r\n\r\nОткроет настоящее руководство.\r\n",
                Font = new Font("Times New Roman", panel_Manual.Width * 0.023f),
                AutoSize = true
            };

            panel_Manual.Resize += Panel_Manual_Resize; ;

            void Panel_Manual_Resize(object? sender, EventArgs e)
            {
                label_ManualText.Font = new Font(label_ManualText.Font.FontFamily, panel_Manual.Width * 0.023f);
            }

            return label_ManualText;
        }

        private void btn_LeaveManual_Click(object sender, EventArgs e)
        {
            label_Manual.Visible = false;
            panel_Manual.Visible = false;
            btn_LeaveManual.Visible = false;

            comboBox_TablesName.Visible = true;
            dataGridView_Table.Visible = true;
        }

        private void btn_ImportAndExportXML_Click(object sender, EventArgs e)
        {
            BasicDatabaseValues.ActiveDatabase?.ExportDatabase(GetDataTable());
        }
        
        private void btn_Import_Click(object sender, EventArgs e)
        {
            DataTable dataTable = BasicDatabaseValues.ActiveDatabase?.ImportDatabase()!;

            if (dataTable?.Rows.Count > 0)
            {
                dataGridView_Table.DataSource = dataTable;
            }
        }

        private DataTable GetDataTable()
        {
            DataTable dataTable = (System.Data.DataTable)dataGridView_Table.DataSource;
            dataTable.TableName = comboBox_TablesName.SelectedItem?.ToString();

            return dataTable;
        }

        
    }
}
