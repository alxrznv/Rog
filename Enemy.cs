using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prot_Ant
{
    public class Enemy
    {
        /// <summary>
        /// Гном_пистолет - 1
        /// Гном_автомат - 2
        /// Чихуахуа - 3
        /// </summary>    
        public byte Class_enemy { get; set; }
        /// <summary>
        /// Здоровье врага (гп:60; га:70;ч:20)
        /// </summary>
        public byte Health_enemy { get; set; }
        /// <summary>
        /// Урон врага (гп:30; га:60; ч:90)
        /// </summary>
        public byte Damage_enemy { get; set; }
        /// <summary>
        /// Ловкость врага (гп:40 ; га:50 ; ч:70)
        /// </summary>
        public byte Lovkost_enemy { get; set; }
        /// <summary>
        /// Меткость врага (гп:40 ;га:60 ;ч:10)
        /// </summary>
        public byte Metkost_enemy { get; set; }
        /// <summary>
        /// Шанс спавна врага (гп:40 ;га:20 ; ч:40) 
        /// </summary>
        public byte Meet_chance { get; set; }
        /// <summary>
        /// Кол-во документов (гп:1 ; га:2 ; ч:0)
        /// </summary>
        public byte Doc_drop_count { get; set; }
        /// <summary>
        /// Статус врага (True - жив)
        /// </summary>
        public bool Is_dead { get; set; }
        public Enemy(byte class_enemy, byte helth_enemy, byte damage_enemy, byte lovkost_enemy, byte metkost_enemy, byte meet_chance, byte doc_drop_count, bool is_dead)
        {
            Class_enemy = class_enemy;
            Health_enemy = helth_enemy;
            Damage_enemy = damage_enemy;
            Lovkost_enemy = lovkost_enemy;
            Metkost_enemy = metkost_enemy;
            Meet_chance = meet_chance;
            Doc_drop_count = doc_drop_count;
            Is_dead = is_dead;
        }
    }
}
