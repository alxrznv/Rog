using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prot_Ant
{
    internal class UpgradePotions
    {
        /// <summary>
        /// Вид зелья: Ловкость = 1, Меткость = 2, Здоровье = 3
        /// </summary>
        public string Potion_type { get; set; }
        /// <summary>
        /// Количество очков, которые восстанавливает залье
        /// </summary>
        public string Potion_points { get; set; }
        /// <summary>
        /// Стоимость зелья у торговца
        /// </summary>
        public string Potion_cost { get; set; }

        public UpgradePotions(string potion_cost,  string potion_point, string potion_type)
        {
            Potion_cost = "10";
            Potion_points = "+20";
            Potion_type = potion_type;
        }
    }
}
