using System;

namespace Rog{

    public class Player{
        Random rand;
        public String Name {get; set;}
        public int Race {get; set;}
        public int Health{get; set;}
        public int Sharpshooting {get; set;}
        public int Agility {get; set;}
        public int Damage {get; set;}
        public int ChemistryAmmount {get; set;}
        public int AgilityPotionAmmount {get; set;}
        public int SharpshootingPotionAmmount {get; set;}
        public int Item { get; set;}
        public int Documents { get; set; }

        public int UpHealth()
        {
            int upper = (2 * Item + 5)
            int lower = (Item + 2)
            return rand.Next(lower, upper);
        }
        public int UpAgility()
        {
            int upper = (2 * Item + 5)
            int lower = (Item + 2)
            return rand.Next(lower, upper);
        }
        public int UpSharpshooting()
        {
            int upper = (2 * Item + 5)
            int lower = (Item + 2)
            return rand.Next(lower, upper);
        }
 



    }


}