/*
using System;

namespace Rog{

    public class Dealer{
        public void Deal(){
            Console.Clear();
                Console.WriteLine("Добро пожаловать в мой магазин, путник!\n " +
                "Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!");
                Console.WriteLine("|             ЛАВКА          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|      Зелье ловкости(1) - " + agilityPotionCost +      "|");
                Console.WriteLine("|         (1) - купить       |");
                Console.WriteLine("|      Зелье меткости(2) - " + sharpshootingPotionCost + "|");
                Console.WriteLine("|         (2) - купить       |");
                Console.WriteLine("|          Аптечка(3)   -  " + firstAidCost +           "|");
                Console.WriteLine("|         (3) - купить       |");
                Console.WriteLine("|          Автомат(4)   -  " + automaticGunCost +        "|");
                Console.WriteLine("|         (4) - купить       |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|    Покинуть торговца - (5) |");
                Console.WriteLine("                              ");
                Console.WriteLine("                              ");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|          Ивентарь          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|          Документы -   " + p.Documents +                  "|");
                Console.WriteLine("|       Зелье ловкости - " + p.AgilityPotionAmmount +       "|");
                Console.WriteLine("|       Зелье меткости - " + p.SharpshootingPotionAmmount + "|");
                Console.WriteLine("|           Оружие  -    ");
                Console.WriteLine("|          Аптечка -     " + p.FirstAidAmmount +            "|");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                
                string input = Console.ReadLine().ToLower();
                if (input == "1" || input == "ловкость")
                {
                    TryBuy("ловкость", agilityPotionCost, p);
                }
                else if (input == "2" || input == "меткость")
                {
                    TryBuy("меткость", sharpshootingPotionCost, p);
                }

                else if (input == "3" || input == "аптечка")
                {
                    TryBuy("аптечка", firstAidCost, p);
                }
                else if (input == "4" || input == "автомат")
                {
                    TryBuy("автомат", automaticGunCost, p);
                }
                else if (input == "5" || input == "Покинуть торговца")
                    break;
}
      

            
            


        static void TryBuy(string item, int cost, Player p)
        {
            if (p.Documents >= cost)
            {
                if (item == "ловкость")
                {
                    p.AgilityPotionAmmount++;
                }
                else if (item == "меткость")
                {
                    p.SharpshootingPotionAmmount++;
                }
                else if (item == "аптечка")
                {
                    p.FirstAidAmmount++;
                }
                else if (item == "автомат")
                {
                    p.Damage++;
                }
                Console.WriteLine("По-рукам!");
                p.Documents -= cost;
            }
            else
            {
                Console.WriteLine("Денег нет");
                Console.ReadKey();
                    
            }
    }
}
}
*/