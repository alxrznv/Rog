using System;

namespace Rog{

    public class Enemy{
        public string Name {get; set;}
        public int Health{get; set;}
        public int Sharpshooting {get; set;}
        public int Agility {get; set;}
        public int Damage {get; set;}
        public int Documents {get; set;}

        public Enemy(string name, int health, int sharpshooting, int agility, int damage, int documents){
            Name = name;
            Health = health;
            Sharpshooting = sharpshooting;
            Agility = agility;
            Damage = damage;
            Documents = documents;
        }
    }
}