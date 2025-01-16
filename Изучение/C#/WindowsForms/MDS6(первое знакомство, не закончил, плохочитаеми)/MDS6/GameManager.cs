using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDS6
{
    internal class GameManager
    {
        public static Label[,] labels = new Label[0,0];
        public static int x1;
        public static int y1;
        public static int[] AroundPlayerFocus = new int[2];
        public static Random random = new Random();
        public static void CreateMap(Map_Values map_Values,Panel panel,int width,int height)
        {
            //

            labels = new Label[map_Values.x,map_Values.y];
            for (int i = 0; i < map_Values.x; i++)
            {
                for (int j = 0; j < map_Values.y; j++)
                {
                    Label label = new Label();
                    label.Size = new Size(width, height);
                    label.BackColor = Color.Red;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Location = new Point(width * j, height * i);
                    panel.Controls.Add(label);
                    labels[i, j]=label;
                }
            }
            x1 = labels.GetLength(0) / 2;
            y1 = labels.GetLength(1) / 2;
            labels[x1, y1].BackColor = Color.Green;
            for (int i = 0; i < map_Values.players_amount.Count; i++)
            {
                int x2 = random.Next(0, map_Values.x - 1);
                int y2 = random.Next(0, map_Values.y - 1);

                // если есть тег или зелёный то уменьшить i и выбрать другое место
                if (labels[x2,y2].Tag != null || labels[x2, y2].BackColor == Color.Green){i -= 1; continue; }

                // строю стенки которые не позволяют проходить через эту клетку


                // даю лейблу тег в котором персонаж
                labels[x2, y2].BackColor = Color.Gray;
                labels[x2, y2].Tag = map_Values.players_amount[i];
            }

            // Для фокусирования на персонаже + 4 клетки около него,если есть
            for (int i = 2; i > 0; i--)
            {
                if (i < labels.GetLength(0) - x1)
                {
                    AroundPlayerFocus[0] = i;
                    break;
                }
            }
            for (int i = 4; i > 0; i--)
            { 
                if (i < labels.GetLength(1) - y1)
                {
                    AroundPlayerFocus[1]= i;
                    break;
                }
            }
        }
        public static void Moving(KeyEventArgs key,Map Map)
        {
            switch (key.KeyValue)
            {
                case (char)Keys.W:
                    if (x1 == 0) { break; }
                    labels[x1, y1].BackColor = Color.Red;
                    x1 -= 1;
                    labels[x1, y1].BackColor = Color.Green;

                    // Фокус
                    if (x1 - AroundPlayerFocus[0] <= 0)
                    {
                        labels[0, y1].Focus();
                    }
                    else { labels[x1 - AroundPlayerFocus[0], y1].Focus(); }

                    // Битва
                    if (labels[x1,y1].Tag!=null)
                    {
                        Entity enemy = (Entity)labels[x1, y1].Tag;
                        StartFight(enemy, Map.panelFight);
                        Map.KeyPreview = false;
                    }
                    break;
                case (char)Keys.A:
                    if (y1 == 0 ) { break; }
                    labels[x1, y1].BackColor = Color.Red;
                    y1 -= 1;
                    labels[x1, y1].BackColor = Color.Green;

                    // Фокус
                    if (y1 - AroundPlayerFocus[1] <= 0)
                    {
                        labels[x1, 0].Focus();
                    }
                    else { labels[x1, y1 - AroundPlayerFocus[1]].Focus(); }
                    // Битва
                    if (labels[x1, y1].Tag != null)
                    {
                        Entity enemy = (Entity)labels[x1, y1].Tag;
                        StartFight(enemy,Map.panelFight);
                        Map.KeyPreview = false;
                    }
                    break;
                case (char)Keys.S:
                    if (x1 == labels.GetLength(0)-1) { break; }
                    labels[x1, y1].BackColor = Color.Red;
                    x1 += 1;
                    labels[x1, y1].BackColor = Color.Green;

                    // Фокус
                    if (x1 + AroundPlayerFocus[0] >= labels.GetLength(0))
                    {
                        labels[labels.GetLength(0) - 1,y1].Focus();
                    }
                    else { labels[x1 + AroundPlayerFocus[0],y1 ].Focus(); }

                    // Битва
                    if (labels[x1, y1].Tag != null)
                    {
                        Entity enemy = (Entity)labels[x1, y1].Tag;
                        StartFight(enemy,Map.panelFight);
                        Map.KeyPreview = false;
                    }
                    break;
                case (char)Keys.D:
                    if (y1 == labels.GetLength(1)-1) { break; }
                    labels[x1, y1].BackColor = Color.Red;
                    y1 += 1;
                    labels[x1, y1].BackColor = Color.Green;
                    // Если текущее нахождение + фокус на клетки вперёд больше заданного размара то дать последнее значение для фокуса по 
                    if (y1 + AroundPlayerFocus[1] >= labels.GetLength(1))
                    {
                        labels[x1, labels.GetLength(1)-1].Focus();
                    }
                    else { labels[x1, y1+AroundPlayerFocus[1]].Focus(); }

                    // Битва
                    if (labels[x1, y1].Tag != null)
                    {
                        Entity enemy = (Entity)labels[x1, y1].Tag;
                        StartFight(enemy,Map.panelFight);
                        Map.KeyPreview = false;
                    }
                    break;
                default:
                    break;

            }
        }
        public static void StartFight(Entity enemy,Panel Fight)
        {
            // добавляю лейбл о том какие характеристики у персонажа на панель Fight
            Fight.Controls.Clear();
            Label labelEnemy = new Label(){
                Text = enemy.ToString(),
                Font = new Font("Tahoma",20),
                Size = new Size(300,350),
                Tag = enemy,
            };
            Fight.Controls.Add(labelEnemy);
        }

        public static void EndFightWin(Hero hero,Map Map)
        {
            // После победы очищаю панель, вывожу количество монет и кнопку для того чтобы забрать
            // потом очищаю панель и даю возможность ходить по карте
            Map.panelFight.Controls.Clear();
            int enemymoney = random.Next(50, 100);
            Label labelEnemy = new Label()
            {
                Text = $"Вы победили этого негодяя, забирайте его монеты : {enemymoney}",
                Size = new Size(300,350),
                Font = new Font("Tahoma",20),
            };
            
            void EndFightTakeMoney_Click(object? sender, EventArgs e)
            {
                hero.Money += enemymoney;
                Map.KeyPreview = true;
                Map.panelFight.Controls.Clear();
            }
            Button EndFight = new Button() 
            { 
                Text = "Забрать",
                Size = new Size(164, 50),
                Font = new Font("Tahoma", 20),
                Location = new Point(100,200),
            };
            EndFight.Click += EndFightTakeMoney_Click;
            Map.panelFight.Controls.Add(EndFight);
        }

        

        public static void EndFightLose(Entity enemy,Map map)
        {
            // после поражения заканчиваю игру выводом общей характеристики о том сколько боёв проведено
            // и было заработано достижений
            MessageBox.Show(enemy.ToString());
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }
        }
    }
}
