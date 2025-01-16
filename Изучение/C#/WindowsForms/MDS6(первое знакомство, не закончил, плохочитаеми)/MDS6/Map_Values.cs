using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS6
{
    internal class Map_Values:Entity
    {
        public int x;
        public int y;
        public List<Entity> players_amount = new List<Entity>();
        public Map_Values() {
            x = 10;
            y = 10;
        }
        public void players_amount_ADD(int x)
        {
            for (int i = 0; i < x; i++)
            {
                players_amount.Add(new Entity() { });
            }
        }
        public void Watch_Players(Map_Values map_Values)
        {
            foreach (var item in map_Values.players_amount)
            {
                item.ToString();
            }
        }
        public override string ToString()
        {
            return $"X: {x}\nY: {y}\nИгроки: {players_amount.Count}";
        }
    }
}
