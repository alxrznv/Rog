using System;
using System.Net;

namespace Rog
{
    public class Program
    {
        static void Main()
        {
            Player player = new Player();
            Enemy pistoldwarf = new Enemy("Гном с пистолетом", 60, 40, 40, 30, 10);
            Enemy tommygundwarf = new Enemy("Гном с автоматом", 70, 60, 50, 60, 15);
            Enemy chihuahua = new Enemy("Чихуахуа", 20, 10, 70, 90, 5);
            Potion agilitypotion = new Potion();
            Potion sharpshootingpotion = new Potion();
            Potion chemistrypotion = new Potion();
            Weapon pistol = new Weapon("Пистолет", 20, 666); //цены будут позже
            Weapon tommygun = new Weapon("Автомат", 50, 666);
            Weapon electro = new Weapon("Электро", 80, 666);
            Battle Batttle = new Battle();
            Inventory inventory = new Inventory();
            Dealer dealer = new Dealer();

            Console.WriteLine(
                " Когда-то давно 4 расы жили в мире. Но гномы объединились с темными силами и создали государство Пол Рейха. \n Нацисты объявили войну людям, оркам и эльфам. Никто не мог остановить армию гномов. Орки были уничтожены в первые 5 лет. \n Нужно остановить ужасную войну! Вы шпион Союза, вас внедрили в штаб гномов для добычи сведений о новом оружии Рейха. \n На вас наложена мощная магия маскировки. По завершению операции, уходите на точку эвакуации, вас встретит подполье. \n Товарищ, не подведите нас!\n"
            );
            Console.WriteLine("Нажмите любую клавишу чтобы начать");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Как вас зовут?");
            player.Name = Console.ReadLine();
            Console.WriteLine("Добро пожаловать в игру, {0}", player.Name);
            Console.WriteLine(
                "Выберите расу за которую хотите играть: \n 1. Человек. Описание \n 2. Эльф. Описание\n"
            );
            ConsoleKeyInfo _race = Console.ReadKey();
            player.Race = int.Parse(_race.KeyChar.ToString());
            switch (player.Race)
            {
                case 1:
                    Console.WriteLine(". Вы выбрали играть за человека.");
                    player.Health = 100;
                    player.Sharpshooting = 33;
                    player.Agility = 33;
                    player.Damage = pistol.Damage;
                    Console.WriteLine("Нажмите любую клавишу чтобы начать");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine(". Вы выбрали играть за эльфа.");
                    player.Health = 50;
                    player.Sharpshooting = 80;
                    player.Agility = 80;
                    player.Damage = pistol.Damage;
                    Console.WriteLine("Нажмите любую клавишу чтобы начать");
                    Console.ReadKey();
                    break;
            }

            player.Position = 2;
            Console.Clear();
            while (player.Health > 0)
            {
                Console.WriteLine("Положение:\n");
                switch (player.Position)
                {
                    case 1:
                        Console.WriteLine("    @@@\n    @@@\n    #@@\n");
                        break;
                    case 2:
                        Console.WriteLine("    @@@\n    @@@\n    @#@\n");
                        break;
                    case 3:
                        Console.WriteLine("    @@@\n    @@@\n    @@#\n");
                        break;
                    case 4:
                        Console.WriteLine("    @@@\n    #@@\n    @@@\n");
                        break;
                    case 5:
                        Console.WriteLine("    @@@\n    @#@\n    @@@\n");
                        break;
                    case 6:
                        Console.WriteLine("    @@@\n    @@#\n    @@@\n");
                        break;
                    case 7:
                        Console.WriteLine("    #@@\n    @@@\n    @@@\n");
                        break;
                    case 8:
                        Console.WriteLine("    @#@\n    @@@\n    @@@\n");
                        break;
                    case 9:
                        Console.WriteLine("    @@#\n    @@@\n    @@@\n");
                        break;
                }
                Console.WriteLine("Выберите направление перемещения:");

                switch (player.Position)
                {
                    case 1: case 4: case 7:
                        break;
                    default:
                        Console.WriteLine("    < Влево");
                        break;
                }
                switch (player.Position)
                {
                    case 3: case 6: case 9:
                        break;
                    default:
                        Console.WriteLine("    > Вправо");
                        break;
                }
                switch (player.Position)
                {
                    case 1: case 2: case 3:
                        break;
                    default:
                        Console.WriteLine("    v Вниз");
                        break;
                }
                switch (player.Position)
                {
                    case 7: case 8: case 9:
                        break;
                    default:
                        Console.WriteLine("    ^ Вверх");
                        break;
                }

                choiceDirection: ConsoleKeyInfo Direction = Console.ReadKey();
                switch (player.Position)
                {
                    case 1:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 2:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 3:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 4:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 5:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 6:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.UpArrow:
                                player.Position += 3;
                                break;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 7:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 8:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.RightArrow:
                                player.Position++;
                                break;
                            case ConsoleKey.UpArrow:
                                goto exit;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;

                    case 9:
                        switch (Direction.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                player.Position--;
                                break;
                            case ConsoleKey.DownArrow:
                                player.Position -= 3;
                                break;
                            default:
                                goto choiceDirection;
                        }
                        break;
                }
                Console.Clear();
            }
            exit: Console.WriteLine("\nДо связи....\n"); ;

            /*
                        player.AgilityPotionAmmount = 1;
                        player.SharpshootingPotionAmmount = 1;
                        Random rnd = new Random();
                        int value = rnd.Next(1, 101);
                        if (value >= 1 && value <= 40)
                        {
                            Batttle.Batttle(
                                pistoldwarf,
                                player,
                                agilitypotion,
                                sharpshootingpotion,
                                chemistrypotion
                            );
                        }
                        else if (value > 40 && value <= 80)
                        {
                            Batttle.Batttle(
                                chihuahua,
                                player,
                                agilitypotion,
                                sharpshootingpotion,
                                chemistrypotion
                            );
                        }
                        else if (value > 80 && value <= 101)
                        {
                            Batttle.Batttle(
                                tommygundwarf,
                                player,
                                agilitypotion,
                                sharpshootingpotion,
                                chemistrypotion
                            );
                        }
                        Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                        Console.ReadKey();
                        inventory.Inv(player);
                        dealer.Deal(
                            player,
                            agilitypotion,
                            sharpshootingpotion,
                            chemistrypotion,
                            tommygun,
                            electro
                        ); */
        }
    }
}
