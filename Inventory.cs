using System;

namespace Rog{

    public class Inventory{
        public void Inv(Player p){
             Console.WriteLine("|          Ивентарь          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|Документы - {0}                  ", p.DocumentsAmmount);
                Console.WriteLine("|Зелье ловкости - {0}", p.AgilityPotionAmmount);
                Console.WriteLine("|Зелье меткости - {0}", p.SharpshootingPotionAmmount);
                if (p.Damage == 20){
                    Console.WriteLine("|Оружие - пистолет");
                }
                else if (p.Damage == 50){
                    Console.WriteLine("|Оружие - автомат");
                }
                else if (p.Damage == 80){
                    Console.WriteLine("|Оружие - электро");
                }
                Console.WriteLine("Аптечка - {0}", p.ChemistryAmmount);
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
        }
    }
}