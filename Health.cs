using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prot_Ant
{
    internal class Health
    {
        /// <summary>
        /// Мощность аптечки 
        /// </summary>
        public string Health_power { get; set; }
        /// <summary>
        /// Стоимость аптечки у торговца
        /// </summary>
        public string Health_cost { get; set; }
        /// <summary>
        /// Шанс найти у торговца
        /// </summary>
        public string Health_chance { get; set; }

        public Health(string health_power, string health_cost, string health_chance)
        {
            Health_power = "30";
            Health_cost = "2";
            Health_chance = health_chance;
        }
    }
}
