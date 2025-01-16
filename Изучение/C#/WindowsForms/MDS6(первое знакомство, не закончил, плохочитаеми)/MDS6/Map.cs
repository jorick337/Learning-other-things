using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDS6
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        public void Map_KeyDown(object sender, KeyEventArgs e)
        {
            GameManager.Moving(e, this);
        }
        public void panelMap_Paint(object sender, PaintEventArgs e)
        {
        }

        public void Map_Load(object sender, EventArgs e)
        {
            GameManager.labels[GameManager.x1 + GameManager.AroundPlayerFocus[0], GameManager.y1 + GameManager.AroundPlayerFocus[1]].Focus();
        }

        private void panelMap_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panelMap_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }
        }

        private void Map_FormClosed(object sender, FormClosedEventArgs e)
        { }

        private void panelFight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtack_Click(object sender, EventArgs e)
        {
            // если тег панели с битвой не пустой, то забрать переменную о враге и вытащить переменную
            // героя
            if (panelFight.Controls[0].Tag != null)
            {
                // создаю 2 переменые: гуроя и врага
                Entity enemy = (Entity)panelFight.Controls[0].Tag;
                Hero hero = (Hero)panelMap.Tag;
                // если здороье врага больше 0 и больше или равно урону героя
                if (enemy.Health > 0 && enemy.Health > hero.Damage && hero.Health > enemy.Damage)
                {
                    enemy.Health -= hero.Damage;
                    hero.Health -= enemy.Damage;
                    GameManager.StartFight(enemy, panelFight);
                }
                // иначе если здоровье врага равно или больше здоровья героя то вывести поражение
                // иначе победу
                else if (enemy.Health >= hero.Health)
                    {
                        GameManager.EndFightLose(hero, this);
                    }
                else GameManager.EndFightWin(hero, this);
                progressBarHeroHealth.Value = hero.Health;
            }
        }

        private void btnRunFight_Click(object sender, EventArgs e)
        {
        }

        private void btnDefense_Click(object sender, EventArgs e)
        {

        }
    }
}
