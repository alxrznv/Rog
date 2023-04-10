using System;

namespace Rog{

    public class Inventory{
        public void Inv(int document, int agilityammount, int sharpshootingammount, int damage, int chemistryammount){
             Console.WriteLine("|          Ивентарь          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|Документы - {0}                  ", document);
                Console.WriteLine("|Зелье ловкости - {0}", agilityammount);
                Console.WriteLine("|Зелье меткости - {0}", sharpshootingammount);
                if (damage == 20){
                    Console.WriteLine("|Оружие - пистолет");
                }
                else if (damage == 50){
                    Console.WriteLine("|Оружие - автомат");
                }
                else if (damage == 80){
                    Console.WriteLine("|Оружие - электро");
                }
                Console.WriteLine("Аптечка - {0}", chemistryammount);
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
        }
    }
}