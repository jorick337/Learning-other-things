using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS6
{
    internal class Entity
    {
        public string Name;
        public int Health;
        public int Damage;
        public Entity()
        {
            Name = "Default";
            Damage = 0;
            Health = 0;
        }
        public override string ToString()
        {
            return $"Имя: {Name}\n" +$"Здоровье: {Health}\nУрон:{Damage}";
        }
        
    }
}
