using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace CityLibraryInfoSystem
{
    internal class ActiveDatabase
    {
        public string Link { get; set; }
        public MySqlConnection ConnectionToDatabase { get; set; }

        public ActiveDatabase()
        {
            Link = "";
            ConnectionToDatabase = new MySqlConnection();
        }

        public ActiveDatabase(string link)
        {
            Link = link;
            ConnectionToDatabase = new MySqlConnection(link);
        }

        public List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();

            var command = "SHOW TABLES";

            MySqlDataReader mySqlDataReader = SendCommandToDatabase(command).ExecuteReader();

            while (mySqlDataReader.Read())
            {
                tableNames.Add(mySqlDataReader[0].ToString()!);
            }
            mySqlDataReader.Close();

            return tableNames;
        }

        public DataTable GetTable(string nameTable)
        {
            DataTable dataTable = new DataTable();

            var command = $"SELECT * FROM {nameTable}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(SendCommandToDatabase(command));
            adapter.Fill(dataTable);

            return dataTable;
        }
        
        public void Open()
        {
            ConnectionToDatabase.Open();
        }

        public void SetUpdate(DataTable dataTable)
        {
            var command = $"SELECT * FROM {dataTable.TableName}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(SendCommandToDatabase(command));

            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(adapter);

            adapter.Update(dataTable);
        }

        public void ExportDatabase(DataTable dataTable)
        {
            XmlDocument xmlDoc = new();

            XmlElement rootElement = xmlDoc.CreateElement("DATA");
            xmlDoc.AppendChild(rootElement);

            foreach (DataRow row in dataTable.Rows)
            {
                XmlElement rowElement = xmlDoc.CreateElement("ROW");
                rootElement.AppendChild(rowElement);

                foreach (DataColumn column in dataTable.Columns)
                {
                    XmlElement columnElement = xmlDoc.CreateElement(column.ColumnName);
                    columnElement.InnerText = row[column].ToString()!;
                    rowElement.AppendChild(columnElement);
                }
            }

            SaveFileDialog saveFileDialog = new() { Filter = "XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv", Title = "Сохранить файл" };
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                xmlDoc.Save(saveFileDialog.FileName);
            }
        }

        public DataTable ImportDatabase()
        {
            DataTable dataTable = new();

            OpenFileDialog openFileDialog = new() { Filter = "XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv", Title = "Открыть файл" };
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                string pathToFile = openFileDialog.FileName;
                if (pathToFile.Split(".csv").Length > 1)
                {

                    StreamReader streamReader = new(pathToFile);

                    string[] headers = streamReader.ReadLine()!.Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header.Trim());
                    }

                    while (!streamReader.EndOfStream)
                    {
                        string[] rows = streamReader.ReadLine()!.Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i].Trim();
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    XmlDocument xmlDoc = new();
                    xmlDoc.Load(pathToFile);

                    XmlNodeReader xmlNodeReader = new(xmlDoc);

                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(xmlNodeReader);

                    dataTable = dataSet.Tables[0];
                }
            }

            return dataTable;
        }

        private MySqlCommand SendCommandToDatabase(string command)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(command, ConnectionToDatabase);

            return mySqlCommand;


        }
    }
}
