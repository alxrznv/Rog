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
            int firstAidCost;
            int sharpshootingPotionCost;
            int agilityPotionCost;
            int automaticGunCost;
            int pistolCost;



            while (true) 
            {
                firstAidCost = 50;
                sharpshootingPotionCost = 150;
                agilityPotionCost = 120;
                automaticGunCost = 300;
                pistolCost = 200;
           
                
                Console.Clear();
                Console.WriteLine("����� ���������� � ��� �������, ������!\n " +
                "������ �� �����, ��� ��� �� ����� ������ � ,��������������, �������, ��� ��� ������� � ����!");
                Console.WriteLine("|             �����          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|      ����� ��������(1) - " + agilityPotionCost +      "|");
                Console.WriteLine("|         (1) - ������       |");
                Console.WriteLine("|      ����� ��������(2) - " + sharpshootingPotionCost + "|");
                Console.WriteLine("|         (2) - ������       |");
                Console.WriteLine("|          �������(3)   -  " + firstAidCost +           "|");
                Console.WriteLine("|         (3) - ������       |");
                Console.WriteLine("|          �������(4)   -  " + automaticGunCost +        "|");
                Console.WriteLine("|         (4) - ������       |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|    �������� �������� - (5) |");
                Console.WriteLine("                              ");
                Console.WriteLine("                              ");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|          ��������          |");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine("|          ��������� -   " + p.Documents +                  "|");
                Console.WriteLine("|       ����� �������� - " + p.AgilityPotionAmmount +       "|");
                Console.WriteLine("|       ����� �������� - " + p.SharpshootingPotionAmmount + "|");
                Console.WriteLine("|           ������  -    ");
                Console.WriteLine("|          ������� -     " + p.FirstAidAmmount +            "|");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                
                string input = Console.ReadLine().ToLower();
                if (input == "1" || input == "��������")
                {
                    TryBuy("��������", agilityPotionCost, p);
                }
                else if (input == "2" || input == "��������")
                {
                    TryBuy("��������", sharpshootingPotionCost, p);
                }

                else if (input == "3" || input == "�������")
                {
                    TryBuy("�������", firstAidCost, p);
                }
                else if (input == "4" || input == "�������")
                {
                    TryBuy("�������", automaticGunCost, p);
                }
                else if (input == "5" || input == "�������� ��������")
                    break;

            }
            
            


        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.Documents >= cost)
            {
                if (item == "��������")
                {
                    p.AgilityPotionAmmount++;
                }
                else if (item == "��������")
                {
                    p.SharpshootingPotionAmmount++;
                }
                else if (item == "�������")
                {
                    p.FirstAidAmmount++;
                }
                else if (item == "�������")
                {
                    p.Damage++;
                }
                Console.WriteLine("��-�����!");
                p.Documents -= cost;
            }
            else
            {
                Console.WriteLine("����� ���");
                Console.ReadKey();
                    
            }

        }

    }
}