using System;

namespace Rog
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Cost { get; set; }

        public Weapon(string name, int damage, int cost)
        {
            Name = name;
            Damage = damage;
            Cost = cost;
        }
    }
}
