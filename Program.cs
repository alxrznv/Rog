using System;
using System.Net;

namespace Rog
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            Enemy pistoldwarf = new Enemy("Гном с пистолетом", 60, 40, 40, 30);
            Enemy tommygundwarf = new Enemy("Гном с автоматом", 70, 60, 50, 60);
            Enemy chihuahua = new Enemy("Чихуахуа", 20, 10, 70, 90);
            Potion agilitypotion = new Potion();
            Potion sharpshootingpotion = new Potion();
            Weapon pistol = new Weapon(20, 666);        //цены будут позже
            Weapon tommygun = new Weapon(50, 666);
            Weapon electro = new Weapon(80, 666);

            Console.WriteLine(
                " Когда-то давно 4 расы жили в мире. Но гномы объединились с темными силами и создали государство Пол Рейха. \n Нацисты объявили войну людям, оркам и эльфам. Никто не мог остановить армию гномов. Орки были уничтожены в первые 5 лет. \n Нужно остановить ужасную войну! Вы шпион Союза, вас внедрили в штаб гномов для добычи сведений о новом оружии Рейха. \n На вас наложена мощная магия маскировки. По завершению операции, уходите на точку эвакуации, вас встретит подполье. \n Товарищ, не подведите нас!"
            );
            Console.WriteLine("Как вас зовут?");
            player.Name = Console.ReadLine();
            Console.WriteLine("Добро пожаловать в игру, {0}", player.Name);
            Console.WriteLine(
                "Выберите расу за которую хотите играть: \n 1. Человек. Описание \n 2. Эльф. Описание"
            );
            player.Race = Convert.ToInt32(Console.ReadLine());
            switch (player.Race)
            {
                case 1:
                    Console.WriteLine("Вы выбрали играть за человека.");
                    player.Health = 100;
                    player.Sharpshooting = 33;
                    player.Agility = 33;
                    player.Damage = pistol.Damage;
                    Console.WriteLine("Нажмите любую клавишу чтобы начать");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Вы выбрали играть за эльфа.");
                    player.Health = 50;
                    player.Sharpshooting = 80;
                    player.Agility = 80;
                    player.Damage = pistol.Damage;
                    Console.WriteLine("Нажмите любую клавишу чтобы начать");
                    Console.ReadKey();
                    break;
            }

            player.AgilityPotionAmmount = 1;
            player.SharpshootingPotionAmmount = 1;
            Random rnd = new Random();
            int value = rnd.Next(1, 101);
            if (value >= 1 && value <= 40){
                Console.WriteLine(
                    "{0}, берегитесь, на вас напал {1}!",
                    player.Name,
                    pistoldwarf.Name
                );


                while (pistoldwarf.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine(
                        "\nВаше здоровье: {0} \nЗдоровье противника: {1}",
                        player.Health,
                        pistoldwarf.Health
                    );

                    Console.WriteLine(
                        "Ваша ловкость {0}, ваша меткость {1}",
                        player.Agility,
                        player.Sharpshooting
                    );

                    if (agilitypotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье ловкости, осталось {0} ходов",
                            agilitypotion.Duration
                        );
                    }

                    if (sharpshootingpotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье меткости, осталось {0} ходов",
                            sharpshootingpotion.Duration
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
                                pistoldwarf.Health = pistoldwarf.Health - player.Damage;
                                player.Health = player.Health - pistoldwarf.Damage;
                            }
                            else
                            {
                                pistoldwarf.Health =
                                    pistoldwarf.Health
                                    - ((player.Sharpshooting + pistoldwarf.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                pistoldwarf.Health =
                                    pistoldwarf.Health
                                    - ((player.Agility + pistoldwarf.Sharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (player.ChemistryAmmount > 0)
                            {
                                if (player.Health >= 70)
                                {
                                    player.Health = 100;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
                                    );
                                }
                                else
                                {
                                    player.Health = player.Health + 30;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
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
                            if (agilitypotion.Duration == 0)
                            {
                                if (player.AgilityPotionAmmount > 0)
                                {
                                    player.Agility = player.Agility + agilitypotion.Points;
                                    player.AgilityPotionAmmount = player.AgilityPotionAmmount - 1;
                                    agilitypotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        player.Agility
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
                            if (sharpshootingpotion.Duration == 0)
                            {
                                if (player.SharpshootingPotionAmmount > 0)
                                {
                                    player.Sharpshooting =
                                        player.Sharpshooting + sharpshootingpotion.Points;
                                    player.SharpshootingPotionAmmount =
                                        player.SharpshootingPotionAmmount - 1;
                                    sharpshootingpotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        player.Sharpshooting
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
                    switch (agilitypotion.Duration)
                    {
                        case 1:
                            agilitypotion.Duration--;
                            player.Agility = player.Agility - agilitypotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            agilitypotion.Duration--;
                            break;
                    }
                    switch (sharpshootingpotion.Duration)
                    {
                        case 1:
                            sharpshootingpotion.Duration--;
                            player.Sharpshooting =
                                player.Sharpshooting - sharpshootingpotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            sharpshootingpotion.Duration--;
                            break;
                    }
                }
                if (player.Health < 0){
                        Console.WriteLine("Вы погибли. GAME OVER");
                    }
                    else{
                        if (player.Health > 0 && pistoldwarf.Health < 0){
                            Console.WriteLine("Вы победили");
                        }
                    }
                }
            
        















               else if (value > 40 && value <= 80){
                   Console.WriteLine("{0}, берегитесь, на вас напал враг {1}!", player.Name, chihuahua.Name);

                   while (chihuahua.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine(
                        "\nВаше здоровье: {0} \nЗдоровье противника: {1}",
                        player.Health,
                        chihuahua.Health
                    );

                    Console.WriteLine(
                        "Ваша ловкость {0}, ваша меткость {1}",
                        player.Agility,
                        player.Sharpshooting
                    );

                    if (agilitypotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье ловкости, осталось {0} ходов",
                            agilitypotion.Duration
                        );
                    }

                    if (sharpshootingpotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье меткости, осталось {0} ходов",
                            sharpshootingpotion.Duration
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
                                chihuahua.Health = chihuahua.Health - player.Damage;
                                player.Health = player.Health - chihuahua.Damage;
                            }
                            else
                            {
                                chihuahua.Health =
                                    chihuahua.Health
                                    - ((player.Sharpshooting + chihuahua.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                chihuahua.Health =
                                    chihuahua.Health
                                    - ((player.Agility + chihuahua.Sharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (player.ChemistryAmmount > 0)
                            {
                                if (player.Health >= 70)
                                {
                                    player.Health = 100;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
                                    );
                                }
                                else
                                {
                                    player.Health = player.Health + 30;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
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
                            if (agilitypotion.Duration == 0)
                            {
                                if (player.AgilityPotionAmmount > 0)
                                {
                                    player.Agility = player.Agility + agilitypotion.Points;
                                    player.AgilityPotionAmmount = player.AgilityPotionAmmount - 1;
                                    agilitypotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        player.Agility
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
                            if (sharpshootingpotion.Duration == 0)
                            {
                                if (player.SharpshootingPotionAmmount > 0)
                                {
                                    player.Sharpshooting =
                                        player.Sharpshooting + sharpshootingpotion.Points;
                                    player.SharpshootingPotionAmmount =
                                        player.SharpshootingPotionAmmount - 1;
                                    sharpshootingpotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        player.Sharpshooting
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
                    switch (agilitypotion.Duration)
                    {
                        case 1:
                            agilitypotion.Duration--;
                            player.Agility = player.Agility - agilitypotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            agilitypotion.Duration--;
                            break;
                    }
                    switch (sharpshootingpotion.Duration)
                    {
                        case 1:
                            sharpshootingpotion.Duration--;
                            player.Sharpshooting =
                                player.Sharpshooting - sharpshootingpotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            sharpshootingpotion.Duration--;
                            break;
                    }
                }
                if (player.Health < 0){
                        Console.WriteLine("Вы погибли. GAME OVER");
                    }
                    else{
                        if (player.Health > 0 && chihuahua.Health < 0){
                            Console.WriteLine("Вы победили");
                        }
                    }



























               }else if (value > 80 && value <= 101){
                   Console.WriteLine("{0}, берегитесь, на вас напал враг {1}!", player.Name, tommygundwarf.Name);



                   while (tommygundwarf.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine(
                        "\nВаше здоровье: {0} \nЗдоровье противника: {1}",
                        player.Health,
                        tommygundwarf.Health
                    );

                    Console.WriteLine(
                        "Ваша ловкость {0}, ваша меткость {1}",
                        player.Agility,
                        player.Sharpshooting
                    );

                    if (agilitypotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье ловкости, осталось {0} ходов",
                            agilitypotion.Duration
                        );
                    }

                    if (sharpshootingpotion.Duration > 0)
                    {
                        Console.WriteLine(
                            "Активно зелье меткости, осталось {0} ходов",
                            sharpshootingpotion.Duration
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
                                tommygundwarf.Health = tommygundwarf.Health - player.Damage;
                                player.Health = player.Health - tommygundwarf.Damage;
                            }
                            else
                            {
                                tommygundwarf.Health =
                                    tommygundwarf.Health
                                    - ((player.Sharpshooting + tommygundwarf.Agility) / 2);
                            }
                            break;

                        case 2:
                            Random rnd2 = new Random();
                            int value2 = rnd2.Next(1, 3);
                            if (value2 == 1)
                            {
                                tommygundwarf.Health =
                                    tommygundwarf.Health
                                    - ((player.Agility + tommygundwarf.Sharpshooting) / 2);
                            }
                            else { }
                            break;

                        case 3:
                            if (player.ChemistryAmmount > 0)
                            {
                                if (player.Health >= 70)
                                {
                                    player.Health = 100;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
                                    );
                                }
                                else
                                {
                                    player.Health = player.Health + 30;
                                    player.ChemistryAmmount = player.ChemistryAmmount - 1;
                                    Console.WriteLine(
                                        "Вы использовали аптечку \n Ваше здоровье {0}",
                                        player.Health
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
                            if (agilitypotion.Duration == 0)
                            {
                                if (player.AgilityPotionAmmount > 0)
                                {
                                    player.Agility = player.Agility + agilitypotion.Points;
                                    player.AgilityPotionAmmount = player.AgilityPotionAmmount - 1;
                                    agilitypotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье ловкости \n Ваш показатель ловкости: {0}",
                                        player.Agility
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
                            if (sharpshootingpotion.Duration == 0)
                            {
                                if (player.SharpshootingPotionAmmount > 0)
                                {
                                    player.Sharpshooting =
                                        player.Sharpshooting + sharpshootingpotion.Points;
                                    player.SharpshootingPotionAmmount =
                                        player.SharpshootingPotionAmmount - 1;
                                    sharpshootingpotion.Duration = 4;
                                    Console.WriteLine(
                                        "Вы использовали зелье меткости \n Ваш показатель меткости: {0}",
                                        player.Sharpshooting
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
                    switch (agilitypotion.Duration)
                    {
                        case 1:
                            agilitypotion.Duration--;
                            player.Agility = player.Agility - agilitypotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            agilitypotion.Duration--;
                            break;
                    }
                    switch (sharpshootingpotion.Duration)
                    {
                        case 1:
                            sharpshootingpotion.Duration--;
                            player.Sharpshooting =
                                player.Sharpshooting - sharpshootingpotion.Points;
                            break;
                        case 0:
                            break;
                        default:
                            sharpshootingpotion.Duration--;
                            break;
                    }
                }
                if (player.Health < 0){
                        Console.WriteLine("Вы погибли. GAME OVER");
                    }
                    else{
                        if (player.Health > 0 && tommygundwarf.Health < 0){
                            Console.WriteLine("Вы победили");
                        }
                    }
               }
        }
    }
}
