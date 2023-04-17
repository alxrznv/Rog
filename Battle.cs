using System;
using System.Text.Json;
using brownyy;
namespace Rog
{
    public class Battle
    {
        static void DrawKadr(object argument)
        {
            KadrClass Drawen_Kadr = argument as KadrClass;
            String[] str_kadr = Drawen_Kadr.Kadr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(Drawen_Kadr.Position_x, Drawen_Kadr.Position_y);
            for (int i = 0; i < str_kadr.Length; i++)
            {
                Console.Write(str_kadr[i]);
                Console.SetCursorPosition(Drawen_Kadr.Position_x, Drawen_Kadr.Position_y + 1 + i);
            }
        }
        static void DeleteKadr(object argument)
        {
            Char[] simvols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '`', '{', '[', '}', ']', '|', ';', ':', '"', '<', '>', ',', '.', '/', '?' };
            KadrClass Deleted_Kadr = argument as KadrClass;
            String[] str_kadr = Deleted_Kadr.Kadr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str_kadr.Length; i++)
            {
                for (int j = 0; j < simvols.Length; j++)
                {
                    str_kadr[i] = str_kadr[i].Replace(simvols[j], ' ');
                }
            }
            Console.SetCursorPosition(Deleted_Kadr.Position_x, Deleted_Kadr.Position_y);
            for (int i = 0; i < str_kadr.Length; i++)
            {
                Console.Write(str_kadr[i]);
                Console.SetCursorPosition(Deleted_Kadr.Position_x, Deleted_Kadr.Position_y + 1 + i);
            }
        }
        static void Pole()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 238; i++) { Console.Write("#"); }
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 54; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(0, i);
            }
            Console.SetCursorPosition(237, 0);
            for (int i = 0; i < 54; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(237, i);
            }
            Console.SetCursorPosition(0, 52);
            for (int i = 0; i < 238; i++) { Console.Write("#"); }

            /*Console.SetCursorPosition(0, 0); //левая верхняя точка
            Console.WriteLine("%");
            Console.SetCursorPosition(0, 54); //левая нижняя точка
            Console.Write("%");
            Console.SetCursorPosition(237, 0); //правая верхняя точка
            Console.Write("%");
            Console.SetCursorPosition(237, 54); //правая нижняя точка
            Console.Write("%");*/
        }
        public void Batttle(Enemy e, Player p, Potion a, Potion s, Potion c)
        {
            Pole();
            /*Console.SetCursorPosition(0, 53);
            Console.WriteLine("{0}, берегитесь, на вас напал {1}!", p.Name, e.Name);*/
            if ((p.Race == 1) && (p.Damage == 20))
            {
                string data = File.ReadAllText("Pistol_Human_start.json");    //Первый кадр человека с автоматом 
                KadrClass Pistol_Human_start = JsonSerializer.Deserialize<KadrClass>(data);
                string data1 = File.ReadAllText("Pistol_Human_attack_second.json");    //Второй кадр выстрела человека с автоматом 
                KadrClass Pistol_Human_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                string data2 = File.ReadAllText("Pistol_Human_attack_third.json");    //Третий кадр выстрела человека с автоматом 
                KadrClass Pistol_Human_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                string data3 = File.ReadAllText("Pistol_Human_uron_second.json");   //Второй кадр получения урона человека с автоматом 
                KadrClass Pistol_Human_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                string data4 = File.ReadAllText("Pistol_Human_uron_third.json");   //Третий кадр  получения урона человека с автоматом 
                KadrClass Pistol_Human_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                draw_kadr1Thread.Start((object)Pistol_Human_start);
                Thread.Sleep(10);
                while (e.Health > 0 && p.Health > 0)
                {
                    
                    Console.SetCursorPosition(0, 53);
                    //Console.Write(" \n \n \n \n \n \n \n \n");
                    Console.SetCursorPosition(0, 53);
                    Console.WriteLine("Ваше здоровье: {0}, Здоровье противника: {1}                                                  ",
                        p.Health,
                        e.Health
                    );
                    if (a.Duration > 0)
                    {
                        Console.SetCursorPosition(0, 54);
                        Console.WriteLine("Активно зелье ловкости, осталось {0} ходов                                                 ", a.Duration);
                    }
                    if (s.Duration > 0)
                    {
                        Console.SetCursorPosition(0, 55);
                        Console.WriteLine("Активно зелье меткости, осталось {0} ходов"                                                  , s.Duration);
                    }
                choice:
                    Console.SetCursorPosition(0, 56);
                    Console.WriteLine(" 1. Атака (Шанс успеха {0}%) \n 2. Уклонение (Шанс успеха {1}%) \n 3. Аптечка (У вас сейчас {2} шт.)\n 4. Зелье Ловкости (У вас сейчас {3} шт.)\n 5. Зелье меткости (У вас сейчас {4} шт.)",
                        p.Sharpshooting,
                        p.Agility,
                        p.ChemistryAmmount,
                        p.AgilityPotionAmmount,
                        p.SharpshootingPotionAmmount
                    );
                    int hod = Convert.ToInt32(Console.ReadLine());
                    switch (hod)
                    {
                        case 1:
                            Random rnd1 = new Random();
                            int value1 = rnd1.Next(1, 3);
                            if (value1 == 1)
                            {
                                e.Health = e.Health - p.Damage;
                                p.Health = p.Health - e.Damage;
                            }
                            else
                            {
                                e.Health = e.Health - ((p.Sharpshooting + e.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                e.Health = e.Health - ((p.Agility + e.Sharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (p.ChemistryAmmount > 0)
                            {
                                if (p.Health >= 70)
                                {
                                    p.Health = 100;
                                    p.ChemistryAmmount = p.ChemistryAmmount - 1;
                                    /*Console.SetCursorPosition(0, 239);
                                    Console.Write(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        p.Health
                                    );*/
                                }
                                else
                                {
                                    p.Health = p.Health + c.Points;
                                    p.ChemistryAmmount = p.ChemistryAmmount - 1;
                                    /*Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        p.Health
                                    );*/
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("К сожалению, у вас нет аптечек в данный момент.");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("                                               ");
                            }
                            break;
                        case 4:
                            if (a.Duration == 0)
                            {
                                if (p.AgilityPotionAmmount > 0)
                                {
                                    p.Agility = p.Agility + a.Points;
                                    p.AgilityPotionAmmount = p.AgilityPotionAmmount - 1;
                                    a.Duration = 4;
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости, ваш показатель ловкости: {0}",
                                        p.Agility
                                    );
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine("                                                             ");
                                }
                                else
                                {
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий ловкости в данный момент"
                                    );
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine("                                                             ");
                                    goto choice;
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("Зелье ловкости уже активно");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("                                                             ");
                                goto choice;
                            }
                            break;

                        case 5:
                            if (s.Duration == 0)
                            {
                                if (p.Sharpshooting > 0)
                                {
                                    p.Sharpshooting = p.Sharpshooting + s.Points;
                                    p.SharpshootingPotionAmmount = p.SharpshootingPotionAmmount - 1;
                                    s.Duration = 4;
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости, ваш показатель меткости: {0}",
                                        p.Sharpshooting
                                    );
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine("                                                                                                                              ");
                                }
                                                       
                                else
                                {
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий меткости в данный момент"
                                    );
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(50, 56);
                                    Console.WriteLine("                                                                                                                              ");
                                    goto choice;
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("Зелье меткости уже активно");
                                Thread.Sleep(1000);
                                Console.SetCursorPosition(50, 56);
                                Console.WriteLine("                                                                                                                              ");
                                goto choice;
                            }
                            break;
                    }
                    switch (a.Points)
                    {
                        case 1:
                            a.Points--;
                            p.Agility = p.Agility - a.Points;
                            break;
                        case 0:
                            break;
                        default:
                            a.Duration--;
                            break;
                    }
                    switch (s.Duration)
                    {
                        case 1:
                            s.Duration--;
                            p.Sharpshooting = p.Sharpshooting - s.Points;
                            break;
                        case 0:
                            break;
                        default:
                            s.Duration--;
                            break;
                    }
                }
            }
            else
            {
                while (e.Health > 0 && p.Health > 0)
                {
                    Console.SetCursorPosition(0, 53);
                    Console.WriteLine(

                        "Ваше здоровье: {0} \nЗдоровье противника: {1}",
                        p.Health,
                        e.Health
                    );

                    Console.WriteLine(
                        "Ваша ловкость {0}, ваша меткость {1}",
                        p.Agility,
                        p.Sharpshooting
                    );

                    if (a.Duration > 0)
                    {
                        Console.SetCursorPosition(0, 53);
                        Console.WriteLine("Активно зелье ловкости, осталось {0} ходов", a.Duration);
                    }

                    if (s.Duration > 0)
                    {
                        Console.SetCursorPosition(0, 53);
                        Console.WriteLine("Активно зелье меткости, осталось {0} ходов", s.Duration);
                    }
                choice:

                    Console.WriteLine(

                        "Что будете делать? \n 1. Атака (Шанс успеха {0}%) \n 2. Уклонение (Шанс успеха {1}%) \n 3. Аптечка (У вас сейчас {2} шт.)\n 4. Зелье Ловкости (У вас сейчас {3} шт.)\n 5. Зелье меткости (У вас сейчас {4} шт.)",
                        p.Sharpshooting,
                        p.Agility,
                        p.ChemistryAmmount,
                        p.AgilityPotionAmmount,
                        p.SharpshootingPotionAmmount
                    );

                    int hod = Convert.ToInt32(Console.ReadLine());
                    switch (hod)
                    {
                        case 1:
                            Random rnd1 = new Random();
                            int value1 = rnd1.Next(1, 3);
                            if (value1 == 1)
                            {
                                e.Health = e.Health - p.Damage;
                                p.Health = p.Health - e.Damage;
                            }
                            else
                            {
                                e.Health = e.Health - ((p.Sharpshooting + e.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                e.Health = e.Health - ((p.Agility + e.Sharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (p.ChemistryAmmount > 0)
                            {
                                if (p.Health >= 70)
                                {
                                    p.Health = 100;
                                    p.ChemistryAmmount = p.ChemistryAmmount - 1;
                                    Console.SetCursorPosition(0, 239);
                                    Console.Write(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        p.Health
                                    );
                                }
                                else
                                {
                                    p.Health = p.Health + c.Points;
                                    p.ChemistryAmmount = p.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        p.Health
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("К сожалению, у вас нет аптечек в данный момент.");
                            }
                            break;

                        case 4:
                            if (a.Duration == 0)
                            {
                                if (p.AgilityPotionAmmount > 0)
                                {
                                    p.Agility = p.Agility + a.Points;
                                    p.AgilityPotionAmmount = p.AgilityPotionAmmount - 1;
                                    a.Duration = 4;
                                    Console.SetCursorPosition(0, 53);
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        p.Agility
                                    );
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 53);
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий ловкости в данный момент"
                                    );
                                    goto choice;
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 53);
                                Console.WriteLine("Зелье ловкости уже активно");
                                goto choice;
                            }
                            break;

                        case 5:
                            if (s.Duration == 0)
                            {
                                if (p.Sharpshooting > 0)
                                {
                                    p.Sharpshooting = p.Sharpshooting + s.Points;
                                    p.SharpshootingPotionAmmount = p.SharpshootingPotionAmmount - 1;
                                    s.Duration = 4;
                                    Console.SetCursorPosition(0, 53);
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        p.Sharpshooting
                                    );
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 53);
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий меткости в данный момент"
                                    );
                                    goto choice;
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 53);
                                Console.WriteLine("Зелье меткости уже активно");
                                goto choice;
                            }
                            break;
                    }
                    switch (a.Points)
                    {
                        case 1:
                            a.Points--;
                            p.Agility = p.Agility - a.Points;
                            break;
                        case 0:
                            break;
                        default:
                            a.Duration--;
                            break;
                    }
                    switch (s.Duration)
                    {
                        case 1:
                            s.Duration--;
                            p.Sharpshooting = p.Sharpshooting - s.Points;
                            break;
                        case 0:
                            break;
                        default:
                            s.Duration--;
                            break;
                    }
                }
                if (p.Health > 0 && e.Health < 0)
                {
                    Console.SetCursorPosition(0, 53);
                    Console.WriteLine("Вы победили!");
                    p.DocumentsAmmount = p.DocumentsAmmount + e.Documents;
                    Console.WriteLine("Теперь у вас {0} документов", p.DocumentsAmmount);
                }
            }
            
            /*if (p.Health < 0)
            {
                Console.WriteLine("Вы погибли. GAME OVER");
            }
            else
            {
                if (p.Health > 0 && e.Health < 0)
                {
                    Console.WriteLine("Вы победили");
                    p.DocumentsAmmount = p.DocumentsAmmount + e.Documents;
                    Console.WriteLine("Теперь у вас {0} документов", p.DocumentsAmmount);
                }
            }*/
        }
    }
}
