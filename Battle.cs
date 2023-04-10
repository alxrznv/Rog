using System;

namespace Rog{

    public class Battle{
       public  void Batttle(string EnemyName, int EnemyHealth, int EnemyAgility, int EnemySharpshooting, int EnemyDamage, int EnemyDocument,
                      string PlayerName, int PlayerHealth, int PlayerAgility, int PlayerSharpshooting, int PlayerDamage, int PlayerDocument,
                      int AgilityPotionDuration, int SharpshootingPotionDuration,
                        int PlayerChemistryAmmount, int PlayerAgilityPotionAmmount, int PlayerSharpshootingPotionAmmount, 
                       int ChemistryPotionPoints, int AgilityPotionPoints, int SharpshootingPotionPoints){    
                        Console.WriteLine(
                    "{0}, берегитесь, на вас напал {1}!",
                    PlayerName,
                    EnemyName
                );


                while (EnemyHealth > 0 && PlayerHealth > 0)
                {
                    Console.WriteLine(
                        "\nВаше здоровье: {0} \nЗдоровье противника: {1}",
                        PlayerHealth,
                        EnemyHealth
                    );

                    Console.WriteLine(
                        "Ваша ловкость {0}, ваша меткость {1}",
                        PlayerAgility,
                        PlayerSharpshooting
                    );

                    if (AgilityPotionDuration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье ловкости, осталось {0} ходов",
                            AgilityPotionDuration
                        );
                    }

                    if (SharpshootingPotionDuration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье меткости, осталось {0} ходов",
                            SharpshootingPotionDuration
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
                                EnemyHealth = EnemyHealth - PlayerDamage;
                                PlayerHealth = PlayerHealth - EnemyDamage;
                            }
                            else
                            {
                                EnemyHealth =
                                    EnemyHealth
                                    - ((PlayerSharpshooting + EnemyAgility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                EnemyHealth =
                                    EnemyHealth
                                    - ((PlayerAgility + EnemySharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (PlayerChemistryAmmount > 0)
                            {
                                if (PlayerHealth >= 70)
                                {
                                    PlayerHealth = 100;
                                    PlayerChemistryAmmount = PlayerChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        PlayerHealth
                                    );
                                }
                                else
                                {
                                    PlayerHealth = PlayerHealth + ChemistryPotionPoints;
                                    PlayerChemistryAmmount = PlayerChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        PlayerHealth
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
                            if (AgilityPotionDuration == 0)
                            {
                                if (PlayerAgilityPotionAmmount > 0)
                                {
                                    PlayerAgility = PlayerAgility + AgilityPotionPoints;
                                    PlayerAgilityPotionAmmount = PlayerAgilityPotionAmmount - 1;
                                    AgilityPotionDuration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        PlayerAgility
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
                            if (SharpshootingPotionDuration == 0)
                            {
                                if (PlayerSharpshooting > 0)
                                {
                                    PlayerSharpshooting =
                                        PlayerSharpshooting + SharpshootingPotionPoints;
                                    PlayerSharpshootingPotionAmmount =
                                        PlayerSharpshootingPotionAmmount - 1;
                                    SharpshootingPotionDuration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        PlayerSharpshooting
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
                    switch (AgilityPotionPoints)
                    {
                        case 1:
                            AgilityPotionPoints--;
                            PlayerAgility = PlayerAgility - AgilityPotionPoints;
                            break;
                        case 0:
                            break;
                        default:
                            AgilityPotionDuration--;
                            break;
                    }
                    switch (SharpshootingPotionDuration)
                    {
                        case 1:
                            SharpshootingPotionDuration--;
                            PlayerSharpshooting =
                                PlayerSharpshooting - SharpshootingPotionPoints;
                            break;
                        case 0:
                            break;
                        default:
                            SharpshootingPotionDuration--;
                            break;
                    }
                }
                if (PlayerHealth < 0){
                        Console.WriteLine("Вы погибли. GAME OVER");
                        
                    }
                    else{
                        if (PlayerHealth > 0 && EnemyHealth < 0){
                            Console.WriteLine("Вы победили");
                                PlayerDocument = PlayerDocument + EnemyDocument;
                            Console.WriteLine("Теперь у вас {0} документов", PlayerDocument);
                            }
                        }
                    }
        }
    }