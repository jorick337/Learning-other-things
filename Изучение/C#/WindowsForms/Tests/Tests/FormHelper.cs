using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForUser
{
    internal class FormHelper
    {
        // класс с созданием разных контролов для удобства и удобочитаемости

        // все созданные контролы
        public static List<Control> Controls = new List<Control>();

        // удаление с формы всех контролов, созданных при помощи класса
        public static void DeleteControls(Form form)
        {
            foreach (Control control in Controls) 
            {
                form.Controls.Remove(control);
            }
            Controls = new List<Control>();
        }

        //добавление на выбранную форму всех созданных контролов
        public static void AddConrols(Form form)
        {
            form.Controls.AddRange(Controls.ToArray());
        }

        // создание textbox для добавления на форму
        public static void CreateNewTextBox(string namecontrol,Point location,Size size,int fontsize,
            string placeholdertext,bool? multiline = null)
        {
            TextBox textBox = new TextBox()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                PlaceholderText = placeholdertext
            };
            if (multiline != null) { textBox.Multiline = (bool)multiline; }
            Controls.Add(textBox);
        }

        // ComboBox
        public static void CreateNewCombobox(string namecontrol, Point location,Size size,
            int fontsize,List<string>? values)
        {
            ComboBox comboBox = new ComboBox()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                DataSource = values
            };
            Controls.Add(comboBox);
        }

        // Label
        public static void CreateNewLabel(string namecontrol, Point location,Size size,
            int fontsize,string? text)
        {
            Label label = new Label()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                Text = text
            };
            Controls.Add(label);
        }

        // Button
        public static void CreateNewButton(string namecontrol, Point location,Size size,int fontsize,
            string text)
        {
            Button button = new Button()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                Text = text
            };
            Controls.Add(button);
        }

        // ListBox
        public static void CreateNewListBox(string namecontrol, Point location, Size size,
            int fontsize, List<string>? value)
        {
            ListBox listbox = new ListBox()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                DataSource = value
            };
            Controls.Add(listbox);
        }

        // DataGridView
        public static void CreateNewDataGridView(string namecontrol, Point location, Size size,
            int fontsize, Color backgroundcolor)
        {
            DataGridView dataGridView = new DataGridView()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                BackgroundColor = backgroundcolor,
            };
            Controls.Add(dataGridView);
        }

        // ProgressBar
        public static void CreateNewProgressBar(string namecontrol, Point location, Size size,
            int fontsize)
        {
            ProgressBar NewProgressBar = new ProgressBar()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
            };
            Controls.Add(NewProgressBar);
        }

        // ProgressBar
        public static void CreateNewRadioButton(string namecontrol, Point location, Size size,
            int fontsize, string text)
        {
            RadioButton NewRadioButton = new RadioButton()
            {
                Name = namecontrol,
                Location = location,
                Size = size,
                Font = new Font("Time New Roman", fontsize),
                Text = text,
            };
            Controls.Add(NewRadioButton);
        }
    }
}
