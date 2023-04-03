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
                    Console.WriteLine("����� ���������� � ��� �������, ������!\n " +
                    "������ �� �����, ��� ��� �� ����� ������ � ,��������������, �������, ��� ��� ������� � ����!");
                    Console.WriteLine("|             �����          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|      ����� ��������(1) - " + agilityPotionCoast + "|");
                    Console.WriteLine("|         (1) - ������       |");
                    Console.WriteLine("|      ����� ��������(2) - " + sharpshootingPotionCoast + "|");
                    Console.WriteLine("|         (2) - ������       |");
                    Console.WriteLine("|          �������(3)   - " + firstAidCoast + "|");
                    Console.WriteLine("|         (3) - ������       |");
                    Console.WriteLine("|          �������(4)   - " + automaticGunCoast + "|");
                    Console.WriteLine("|         (4) - ������       |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|    �������� �������� - (5) |");
                    Console.WriteLine("                              ");
                    Console.WriteLine("                              ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|          ��������          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|          ��������� -   " + p.Documents);
                    Console.WriteLine("|       ����� �������� - " + p.AgilityPotionAmmount);
                    Console.WriteLine("|       ����� �������� - " + p.SharpshootingPotionAmmount);
                    Console.WriteLine("|           ������  -         ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice){
                        case 1:
                            if(p.Documents >= agilityPotionCoast)
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - agilityPotionCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!");
                            }

                            break;
                        case 2:
                            if (p.Documents >= sharpshootingPotionCoast) 
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - sharpshootingPotionCoast;
                                p.SharpshootingPotionAmmount++;
                               
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!");
                            }
                            break;
                        case 3:
                            if (p.Documents >= firstAidCoast) 
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - firstAidCoast;
                                p.FirstAidAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!!");
                            }
                            
                            break;
                        case 4:
                            if(p.Documents >= automaticGunCoast)
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - automaticGunCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!");
                            }
                            
                            break;
                        case 5:
                            break;

                    }


                }

                else
                {
                    Console.WriteLine("����� ���������� � ��� �������, ������!\n " +
                    "������ �� �����, ��� ��� �� ����� ������ � ,��������������, �������, ��� ��� ������� � ����!");
                    Console.WriteLine("|              �����           |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|           �������(1) - " + firstAidCoast + "|");
                    Console.WriteLine("|          (1) - ������        |");
                    Console.WriteLine("|           �������(2) - " + automaticGunCoast + "|");
                    Console.WriteLine("|          (2) - ������        |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|      �������� ������� - (3)  |");
                    Console.WriteLine("                                ");
                    Console.WriteLine("                                ");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|            ��������          |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    Console.WriteLine("|            ��������� - " + p.Documents + "|");
                    Console.WriteLine("|             ������� -  " + p.FirstAidAmmount + "|");
                    Console.WriteLine("|         ����� �������� - " + p.SharpshootingPotionAmmount + "|");
                    Console.WriteLine("|             ������  -        |");
                    Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (p.Documents >= firstAidCoast)
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - firstAidCoast;
                                p.FirstAidAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!");
                            }
                            break;
                        case 2:
                            if (p.Documents >= automaticGunCoast)
                            {
                                Console.WriteLine("��-��-��, ��-�����!");
                                p.Documents = p.Documents - automaticGunCoast;
                                p.AgilityPotionAmmount++;
                            }
                            else
                            {
                                Console.WriteLine("�������, ��� ����������� ������ ����������� �����������!");
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