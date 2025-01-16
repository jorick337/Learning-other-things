using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Средневековая_битва
{
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
            // добавление формы в стек
            Login.forms.Push(this);
        }

        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Для закрытия всех форм при закрытии
            foreach (Form form in Login.forms)
            {
                form.Close();
            }
        }
    }
}
