using System;

namespace Rog
{
    public class Dealer
    {
        public void Deal(Player p, Potion a, Potion s, Potion c, Weapon t, Weapon e)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine(
                "Добро пожаловать в мой магазин, путник!\n "
                    + "Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!"
            );
            Console.WriteLine("|             ЛАВКА          |");
            Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            Console.WriteLine("|      Зелье ловкости(1) - " + a.Cost + "|");
            Console.WriteLine("|         (1) - купить       |");
            Console.WriteLine("|      Зелье меткости(2) - " + s.Cost + "|");
            Console.WriteLine("|         (2) - купить       |");
            Console.WriteLine("|          Аптечка(3)   -  " + c.Cost + "|");
            Console.WriteLine("|         (3) - купить       |");
            Console.WriteLine("|          Автомат(4)   -  " + t.Cost + "|");
            Console.WriteLine("|         (4) - купить       |");
            Console.WriteLine("|          Электро(5)   -  " + e.Cost + "|");
            Console.WriteLine("|         (5) - купить       |");
            Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
            Console.WriteLine("|    Покинуть торговца - (6) |");
            Console.WriteLine("                              ");
            Console.WriteLine("                              ");
            Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");

            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                TryBuy("ловкость", a.Cost, p);
            }
            else if (input == 2)
            {
                TryBuy("меткость", s.Cost, p);
            }
            else if (input == 3)
            {
                TryBuy("аптечка", c.Cost, p);
            }
            else if (input == 4)
            {
                TryBuy("автомат", t.Cost, p);
            }
            else if (input == 5)
            {
                TryBuy("электро", e.Cost, p);
            }
            else if (input == 6)
                ;
        }

        public void TryBuy(string item, int cost, Player p)
        {
            if (p.DocumentsAmmount >= cost)
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
                    p.ChemistryAmmount++;
                }
                else if (item == "автомат")
                {
                    p.Damage = 50;
                }
                else if (item == "электро")
                {
                    p.Damage = 80;
                }
                Console.WriteLine("По-рукам!");
                p.DocumentsAmmount -= cost;
            }
            else
            {
                Console.WriteLine("Денег нет");
                Console.ReadKey();
            }
        }
    }
}
