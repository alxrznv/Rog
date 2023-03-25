using System;


namespace Rog
{
    
    public class Dealer
    {
        static int itemChance { get; set; }
        static int agility { get; set; }
        static int sharpshooting { get; set; }
        static int firstAid { get; set; }
        static int documents { get; set; }
        static int race { get; set; }
        static int sharpshootingPotion { get; set; }
        static int chemistryAmmount { get; set; }
        static int AgilityPotionAmmount { get; set; }
        static int SharpshootingPotionAmmount { get; set; }
        public static void LoadDealer(Player p)

        {
            
            
            StartDialogue(p);
        }

        public static void StartDialogue(Player p)
        {
            int chemistryAmmountD
            int agilityPotionAmmountD
            race = p.race;
            int sharpshootingD;
            int firstAidD = p.firstAid;
            documents = p.documents;
            while (true) 
            {
                if (p.race == 1)
                {   
                    Console.Clear()
                    Console.WriteLine("Добро пожаловать в мой магазин, путник! Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!");
                    Console.WriteLine("|        ЛАВКА           |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|    Зелье ловкости(1)   |");
                    Console.WriteLine("|    Зелье меткости(2)   |");
                    Console.WriteLine("|        Аптечка(3)      |");
                    Console.WriteLine("|        Автомат(4)      |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=");

                }

                else
                {
                    Console.WriteLine("Добро пожаловать в мой магазин, путник! Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!");
                    Console.WriteLine("|         ЛАВКА        |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|       Аптечка(1)     |");
                    Console.WriteLine("|       Автомат(2)     |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=");

                }

            }
            
            


        }
    }
}