using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS6
{
    internal class Hero:Entity
    {

        public List<string> Inventory { get; set; }
        public int Money { get; set; }

        public Hero()
        {
            Inventory = new List<string>() {"пустой"};
            Money = 1000;
        }
        public override string ToString()
        {
            return $"Имя: {Name}\n" + 
                $"Здоровье: {Health}\n" +
                $"Урон:{Damage}\n" +
                $"Деньги:{Money}\n" +
                $"Инвентарь:{Inventory[0]}";
        }
    }
}
