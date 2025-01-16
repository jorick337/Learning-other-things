using System.Drawing.Text;

namespace MDS6
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void buttonCreatePerson_Click(object sender, EventArgs e)
        {
            Entity entity = new Entity();
            Button button = new Button();
            entity.Name = textBoxName.Text;
            entity.Health = Convert.ToInt32(textBoxHealth.Text);
            entity.Damage = Convert.ToInt32(textBoxDamage.Text);
            button.Text = entity.Name +
                entity.Health +
                entity.Damage;
            button.Tag = entity;
            void button_ClickChoise(object sender, EventArgs e)
            {
                labelInfoHero.Text = button.Tag.ToString();
                labelInfoHero.Tag = entity;
            }
            button.Click += button_ClickChoise;
            flowLayoutPanelPlayers.Controls.Add(button);
            Map_Values map_Values = new Map_Values();
            map_Values.players_amount.Add(entity);
        }

        private void flowLayoutPanelPlayers_Paint(object sender, PaintEventArgs e)
        {

        }
        List<Entity> map_players = new List<Entity>();
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelInfoPlayersMap.Tag != null && flowLayoutPanelInfoPlayersMap.Tag != map_players)
            {
                flowLayoutPanelInfoPlayersMap.Controls.Clear();
                flowLayoutPanelInfoPlayersMap.Tag = null;
            }
            map_players.Add((Entity)labelInfoHero.Tag);
            Button player = new Button() { Text = labelInfoHero.Tag.ToString(), Size = new Size(100, 50), };
            flowLayoutPanelInfoPlayersMap.Controls.Add(player);
            flowLayoutPanelInfoPlayersMap.Tag = map_players;
        }

        private void btnMapCreate_Click(object sender, EventArgs e)
        {
            Map_Values map_Values = new Map_Values()
            {
                x = int.Parse(textBoxMapX.Text),
                y = int.Parse(textBoxMapY.Text),
                players_amount = map_players,
            };
            Button button = new Button()
            {
                Text = map_Values.ToString(),
                Size = new Size(230, 50),
                Tag = map_Values,
            };
            void button_MouseClick(object sender, EventArgs e)
            {
                if (flowLayoutPanelInfoPlayersMap.Tag == button.Tag)
                {

                }
                else
                {
                    flowLayoutPanelInfoPlayersMap.Controls.Clear();
                    panelMapSee.Controls.Clear();
                    map_Values = (global::MDS6.Map_Values)button.Tag;
                    foreach (var item in map_Values.players_amount)
                    {
                        Button player = new Button() { Text = item.ToString(), Size = new Size(100, 50), };
                        flowLayoutPanelInfoPlayersMap.Controls.Add(player);
                    }
                    textBoxMapX.Text = map_Values.x.ToString();
                    textBoxMapY.Text = map_Values.y.ToString();

                    //Добавление Информации о карте для её принятия и отрисовки
                    labelInfoMap.Text = map_Values.ToString();
                    labelInfoMap.Tag = map_Values;
                    btnAcceptMap.Text = "Выбрать карту";
                    btnAcceptMap.UseVisualStyleBackColor = true;
                    GameManager.CreateMap(map_Values, panelMapSee, 10, 10);

                    flowLayoutPanelInfoPlayersMap.Tag = map_Values.players_amount;
                }
            }
            button.MouseClick += button_MouseClick;
            panelMaps.Controls.Add(button);

            flowLayoutPanelInfoPlayersMap.Controls.Clear();
            map_players = new List<Entity>() { };
        }

        private void btnAcceptMap_Click(object sender, EventArgs e)
        {
            if (btnAcceptMap.UseVisualStyleBackColor == true && labelInfoMap.Tag != null)
            {
                btnAcceptMap.UseVisualStyleBackColor = false;
                btnAcceptMap.Text = "Карта принята";
                btnAcceptMap.BackColor = Color.Green;
            }
            else
            {
                btnAcceptMap.Text = "Выбрать карту";
                btnAcceptMap.UseVisualStyleBackColor = true;

            }
        }

        private void btnAcceptHero_Click(object sender, EventArgs e)
        {
            // выбор героя и введение ему количества монет и пустой инвентарь
            // если пустой лэйбл то ничего не делать
            if (labelInfoHero.Text != null)
            {
                // достаю данные о здоровье,атаке,имени героя из тега
                Entity entity = (Entity)labelInfoHero.Tag;
                Hero hero = new Hero()
                {
                    Name = entity.Name,
                    Health = entity.Health,
                    Damage = entity.Damage,
                };
                // отдаю героя в тег лейбла что над началом и вывожу данный о нём
                labelGameAspect.Tag = hero;
                labelGameAspect.Text = hero.ToString();
            }
        }

        private void btnRunGame_Click(object sender, EventArgs e)
        {
            // если в лейблах есть теги персонажей, карты и карта принята то начать игру и вывести форму Map
            if (labelGameAspect.Tag != null && labelInfoMap.Tag != null && btnAcceptMap.BackColor == Color.Green)
            {
                Map_Values map_Values = (Map_Values)labelInfoMap.Tag;
                Hero hero = (Hero)labelGameAspect.Tag;
                Hide();
                Map map = new Map();
                GameManager.CreateMap(map_Values, map.panelMap, 100, 100);
                map.labelHeroName.Text = hero.Name;
                map.labelHeroDamage.Text = "Урон:"+hero.Damage.ToString();
                map.progressBarHeroHealth.Maximum = hero.Health;
                map.progressBarHeroHealth.Value = hero.Health;
                map.panelMap.Tag = hero;
                map.Show();
            }
        }
        private void panelMapSee_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelMapSee_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void panelMapSee_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}