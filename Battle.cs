using System;

namespace Rog{

    public class Battle{
       public  void Batttle(Enemy e,
                            Player p,
                            Potion a, Potion s, Potion c){    
                        Console.WriteLine(
                    "{0}, берегитесь, на вас напал {1}!",
                    p.Name,
                    e.Name
                );


                while (e.Health > 0 && p.Health > 0)
                {
                    Console.WriteLine(
                        "\nВаше здоровье: {0} \nЗдоровье противника: {1}",
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
                        Console.WriteLine(
                            "Активно зелье ловкости, осталось {0} ходов",
                            a.Duration
                        );
                    }

                    if (s.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье меткости, осталось {0} ходов",
                            s.Duration
                        );
                    }
                    choice:
                    Console.WriteLine(
                        "Что будете делать? \n 1. Атака \n 2. Уклонение \n 3. Аптечка \n 4. Зелье Ловкости \n 5. Зелье меткости"
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
                                e.Health =
                                    e.Health
                                    - ((p.Sharpshooting + e.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                e.Health =
                                    e.Health
                                    - ((p.Agility + e.Sharpshooting) / 2);
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
                                    Console.WriteLine(
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
                                Console.WriteLine(
                                    "К сожалению, у вас нет аптечек в данный момент."
                                );
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
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        p.Agility
                                    );
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий ловкости в данный момент"
                                    );
                                    goto choice;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Зелье ловкости уже активно");
                                goto choice;
                            }
                            break;

                        case 5:
                            if (s.Duration == 0)
                            {
                                if (p.Sharpshooting > 0)
                                {
                                    p.Sharpshooting =
                                        p.Sharpshooting + s.Points;
                                    p.SharpshootingPotionAmmount =
                                        p.SharpshootingPotionAmmount - 1;
                                    s.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        p.Sharpshooting
                                    );
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "К сожалению, у вас нет зелий меткости в данный момент"
                                    );
                                    goto choice;
                                }
                            }
                            else
                            {
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
                            p.Sharpshooting =
                                p.Sharpshooting - s.Points;
                            break;
                        case 0:
                            break;
                        default:
                            s.Duration--;
                            break;
                    }
                }
                if (p.Health < 0){
                        Console.WriteLine("Вы погибли. GAME OVER");
                        
                    }
                    else{
                        if (p.Health > 0 && e.Health < 0){
                            Console.WriteLine("Вы победили");
                                p.DocumentsAmmount = p.DocumentsAmmount + e.Documents;
                            Console.WriteLine("Теперь у вас {0} документов", p.DocumentsAmmount);
                            }
                        }
                    }
        }
    }