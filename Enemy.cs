using System;

namespace Rog{

    public class Enemy : Program{
        public string Name {get; set;}
        public int Health{get; set;}
        public int Sharpshooting {get; set;}
        public int Agility {get; set;}
        public int Damage {get; set;}

        public Enemy(string name, int health, int sharpshooting, int agility, int damage){
            Name = name;
            Health = health;
            Sharpshooting = sharpshooting;
            Agility = agility;
            Damage = Damage;
        }
    }
}