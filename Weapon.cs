using System;

namespace Rog{

    public class Weapon{
        public int Damage {get; set;}
        public int Cost {get; set;}
        public Weapon(int damage, int cost){
            Damage = damage;
            Cost = cost;
        }
    }
}