using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prot_Ant
{
    internal class Weapon
    {   
        /// <summary>
        /// Вид оружия: пистолет = 1, автомат = 2
        /// </summary>
        public string Weapon_type { get; set; }

        /// <summary>
        /// Урон оружия
        /// </summary>
        public string Weapon_damage { get; set; }
        /// <summary>
        /// Стоимость оружия
        /// </summary>
        public string Weapon_cost { get; set; }
        /// <summary>
        /// Шанс найти оружие у торговца
        /// </summary>
        public string Weapon_chance { get; set; }

     

    }
}
