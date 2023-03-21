using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prot_Ant
{
    public class Player
    {
        /// <summary>
        /// Человек - 1
        /// Эльф - 2
        /// </summary>
        public byte Class_player { get; set; }
        /// <summary>
        /// Пистолет - 1
        /// Автомат - 2
        /// </summary>
        public byte Weapon_type { get; set; }
        /// <summary>
        /// Кол-во зелий Ловкости
        /// </summary>
        public byte Potions_countL { get; set; }
        /// <summary>
        /// Кол-во зелий Меткости
        /// </summary>
        public byte Potions_countM { get; set; }
        /// <summary>
        /// Кол-во Аптечек
        /// </summary>
        public byte Health_count { get; set; }
        /// <summary>
        /// Кол-во документы (валюта)
        /// </summary>
        public byte Doc_count { get; set; }
        /// <summary>
        /// Здоровье игрока (ч:100; э:50)
        /// </summary>
        public byte Health_player { get; set; }
        /// <summary>
        /// Ловкость игрока (ч:33; э:80)
        /// </summary>
        public byte Lovkost_player { get; set; }
        /// <summary>
        /// Меткость игрока (ч:33; э:80)
        /// </summary>
        public byte Metkost_player { get; set; }
        /// <summary>
        /// Статус (True - жив)
        /// </summary>
        public bool Is_dead { get; set; }
        public Player(byte class_player, byte weapon_player, byte potions_countL, byte potions_countM, byte helth_count, byte doc_count, byte helth_player, byte lovkost_player, byte metkost_player, bool is_dead)
        {
            Class_player = class_player;
            Weapon_type = weapon_player;
            Potions_countL = potions_countL;
            Potions_countM = potions_countM;
            Health_count = helth_count;
            Doc_count = doc_count;
            Health_player = 100;
            Lovkost_player = lovkost_player;
            Metkost_player = metkost_player;
            Is_dead = is_dead;
        }
    }
}
