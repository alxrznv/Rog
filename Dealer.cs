using System;
using System.Net;

namespace Rog
{
    
    public class Dealer
    {

        public static void LoadDealer(Player p)

        {
            Console.Clear();
            StartDialogue(p);
        }

        public static void StartDialogue(Player p)
        {
            int firstAidCoast;
            int sharpshootingPotionCoast;
            int agilityPotionCoast;
            int automaticGunCoast;
            int pistolCoast;



            while (true) 
            {
                firstAidCoast = 50;
                sharpshootingPotionCoast = 150;
                agilityPotionCoast = 120;
                automaticGunCoast = 300;
                pistolCoast = 200;
                if (p.Race == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Добро пожаловать в мой магазин, путник!\n " +
                    "Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!");
                    Console.WriteLine("|             ЛАВКА          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|      Зелье ловкости(1) - " + agilityPotionCoast + "|");
                    Console.WriteLine("|         (1) - купить       |");
                    Console.WriteLine("|      Зелье меткости(2) - " + sharpshootingPotionCoast + "|");
                    Console.WriteLine("|         (2) - купить       |");
                    Console.WriteLine("|          Аптечка(3)   - " + firstAidCoast + "|");
                    Console.WriteLine("|         (3) - купить       |");
                    Console.WriteLine("|          Автомат(4)   - " + automaticGunCoast + "|");
                    Console.WriteLine("|         (4) - купить       |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|    Покинуть торговца - (5) |");
                    Console.WriteLine("                              ");
                    Console.WriteLine("                              ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|          Ивентарь          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|          Документы -   " + p.Documents);
                    Console.WriteLine("|       Зелье ловкости - " + p.AgilityPotionAmmount);
                    Console.WriteLine("|       Зелье меткости - " + p.SharpshootingPotionAmmount);
                    Console.WriteLine("|           Оружие  -         ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice){
                        case 1:
                            if(p.Documents >= agilityPotionCoast)
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - agilityPotionCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!");
                            }

                            break;
                        case 2:
                            if (p.Documents >= sharpshootingPotionCoast) 
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - sharpshootingPotionCoast;
                                p.SharpshootingPotionAmmount++;
                               
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!");
                            }
                            break;
                        case 3:
                            if (p.Documents >= firstAidCoast) 
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - firstAidCoast;
                                p.FirstAidAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!!");
                            }
                            
                            break;
                        case 4:
                            if(p.Documents >= automaticGunCoast)
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - automaticGunCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!");
                            }
                            
                            break;
                        case 5:
                            break;

                    }


                }

                else
                {
                    Console.WriteLine("Добро пожаловать в мой магазин, путник!\n " +
                    "Товара не много, так как он очень редкий и ,соответственно, дорогой, так что выбирай с умом!");
                    Console.WriteLine("|              ЛАВКА           |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|           Аптечка(1) - " + firstAidCoast + "|");
                    Console.WriteLine("|          (1) - купить        |");
                    Console.WriteLine("|           Автомат(2) - " + automaticGunCoast + "|");
                    Console.WriteLine("|          (2) - купить        |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|      Покинуть магазин - (3)  |");
                    Console.WriteLine("                                ");
                    Console.WriteLine("                                ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|            Ивентарь          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|            Документы - " + p.Documents + "|");
                    Console.WriteLine("|             Аптечка -  " + p.FirstAidAmmount + "|");
                    Console.WriteLine("|         Зелье меткости - " + p.SharpshootingPotionAmmount + "|");
                    Console.WriteLine("|             Оружие  -        |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (p.Documents >= firstAidCoast)
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - firstAidCoast;
                                p.FirstAidAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!");
                            }
                            break;
                        case 2:
                            if (p.Documents >= automaticGunCoast)
                            {
                                Console.WriteLine("Ха-ха-ха, по-рукам!");
                                p.Documents = p.Documents - automaticGunCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("Приходи, как раздобудешь нужное колличестов разведанных!");
                            }
                            break;
                        case 3:
                            break;
                           


                    }

                }

            }
            
            


        }
    }
}