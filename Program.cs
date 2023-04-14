using System.Net;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rog
{
    
    public class Program
    {
        static void Draw(object argument)
        {
            RoomClass Room = argument as RoomClass;
            System.String[] str_room = Room.Sprite.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(Room.Position_x, Room.Position_y);
            for (int i = 0; i < str_room.Length; i++)
            {
                Console.Write(str_room[i]);
                Console.SetCursorPosition(Room.Position_x, Room.Position_y + 1 + i);
            }
        }
        static void DrawKadr(object argument)
        {
            RoomClass Drawen_Kadr = argument as RoomClass;
            System.String[] str_kadr = Drawen_Kadr.Sprite.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(Drawen_Kadr.Position_x, Drawen_Kadr.Position_y);
            for (int i = 0; i < str_kadr.Length; i++)
            {
                Console.Write(str_kadr[i]);
                Console.SetCursorPosition(Drawen_Kadr.Position_x, Drawen_Kadr.Position_y + 1 + i);
            }
        }
        static void Delete(object argument)
        {
            Char[] simvols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '`', '{', '[', '}', ']', '|', ';', ':', '"', '<', '>', ',', '.', '/', '?' };
            RoomClass Deleted_Kadr = argument as RoomClass;
            System.String[] str_kadr = Deleted_Kadr.Sprite.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
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
        static void Main()
        {
            SetConsoleDisplayMode(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = true;
            string data1 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\RoomGlobal.json");
            RoomClass Room_1 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_2 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_3 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_4 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_5 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_6 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_7 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_8 = JsonSerializer.Deserialize<RoomClass>(data1);
            RoomClass Room_9 = JsonSerializer.Deserialize<RoomClass>(data1);

            string data10 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Corridor_Vertical.json");
            RoomClass Corridor_47 = JsonSerializer.Deserialize<RoomClass>(data10);
            RoomClass Corridor_14 = JsonSerializer.Deserialize<RoomClass>(data10);
            RoomClass Corridor_58 = JsonSerializer.Deserialize<RoomClass>(data10);
            RoomClass Corridor_25 = JsonSerializer.Deserialize<RoomClass>(data10);
            RoomClass Corridor_69 = JsonSerializer.Deserialize<RoomClass>(data10);
            RoomClass Corridor_36 = JsonSerializer.Deserialize<RoomClass>(data10);

            string data16 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Corridor_Horizontal.json");
            RoomClass Corridor_78 = JsonSerializer.Deserialize<RoomClass>(data16);
            RoomClass Corridor_45 = JsonSerializer.Deserialize<RoomClass>(data16);
            RoomClass Corridor_12 = JsonSerializer.Deserialize<RoomClass>(data16);
            RoomClass Corridor_89 = JsonSerializer.Deserialize<RoomClass>(data16);
            RoomClass Corridor_56 = JsonSerializer.Deserialize<RoomClass>(data16);
            RoomClass Corridor_23 = JsonSerializer.Deserialize<RoomClass>(data16);

            string data22 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Dealer.json");
            RoomClass Dealer = JsonSerializer.Deserialize<RoomClass>(data22);
            string data23 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Hero_Elf.json");
            RoomClass Hero_Elf = JsonSerializer.Deserialize<RoomClass>(data23);
            string data24 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Hero_Hunan.json");
            RoomClass Hero_Human = JsonSerializer.Deserialize<RoomClass>(data24);

            string data25 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Dog1.json");
            RoomClass Dog = JsonSerializer.Deserialize<RoomClass>(data25);
            string data26 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Gnom_automat_minimap.json");
            RoomClass Gnom_automat_minimap = JsonSerializer.Deserialize<RoomClass>(data26);
            string data27 = File.ReadAllText("E:\\Desctop 2\\Rog-Gameplay\\Rog-Gameplay\\bin\\Debug\\net7.0\\Gnom_molot_minimap.json");
            RoomClass Gnom_molot_minimap = JsonSerializer.Deserialize<RoomClass>(data27);


            Room_1.Index = 1;
            Room_1.Position_x = 9;
            Room_1.Position_y = 39;
            Room_2.Index = 2;
            Room_2.Position_x = 89;
            Room_2.Position_y = 39;

            Room_2.Index = 2;
            Room_2.Position_x = 89;
            Room_2.Position_y = 39;
            Room_3.Index = 3;
            Room_3.Position_x = 169;
            Room_3.Position_y = 39;
            Room_4.Index = 4;
            Room_4.Position_x = 9;
            Room_4.Position_y = 21;
            Room_5.Index = 5;
            Room_5.Position_x = 89;
            Room_5.Position_y = 21;
            Room_6.Index = 6;
            Room_6.Position_x = 169;
            Room_6.Position_y = 21;
            Room_7.Index = 7;
            Room_7.Position_x = 9;
            Room_7.Position_y = 3;
            Room_8.Index = 8;
            Room_8.Position_x = 89;
            Room_8.Position_y = 3;
            Room_9.Index = 9;
            Room_9.Position_x = 169;
            Room_9.Position_y = 3;

            Corridor_47.Index = 47;
            Corridor_47.Position_x = 34;
            Corridor_47.Position_y = 13;
            Corridor_14.Index = 14;
            Corridor_14.Position_x = 34;
            Corridor_14.Position_y = 31;
            Corridor_58.Index = 58;
            Corridor_58.Position_x = 114;
            Corridor_58.Position_y = 13;
            Corridor_25.Index = 25;
            Corridor_25.Position_x = 114;
            Corridor_25.Position_y = 31;
            Corridor_69.Index = 69;
            Corridor_69.Position_x = 194;
            Corridor_69.Position_y = 13;
            Corridor_36.Index = 36;
            Corridor_36.Position_x = 194;
            Corridor_36.Position_y = 31;

            Corridor_78.Index = 78;
            Corridor_78.Position_x = 68;
            Corridor_78.Position_y = 5;
            Corridor_45.Index = 45;
            Corridor_45.Position_x = 68;
            Corridor_45.Position_y = 23;
            Corridor_12.Index = 12;
            Corridor_12.Position_x = 68;
            Corridor_12.Position_y = 41;
            Corridor_89.Index = 89;
            Corridor_89.Position_x = 148;
            Corridor_89.Position_y = 5;
            Corridor_56.Index = 56;
            Corridor_56.Position_x = 148;
            Corridor_56.Position_y = 23;
            Corridor_23.Index = 23;
            Corridor_23.Position_x = 148;
            Corridor_23.Position_y = 41;

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



            /*{
                RoomClass Automat_Human_uron_third = new RoomClass();
                Automat_Human_uron_third.Position_x = 0;
                Automat_Human_uron_third.Position_y = 0;
                Automat_Human_uron_third.Sprite = "\t..::   \r\n      +**=   \r\n     .*#*+:. \r\n.==: +***++= \r\n:+*=**####+* \r\n";
                Automat_Human_uron_third.Index = 1;
                string Automat_Human_uron_third_Json = JsonSerializer.Serialize(Automat_Human_uron_third, typeof(RoomClass));
                StreamWriter file = File.CreateText("Gnom_molot_minimap.json");
                file.WriteLine(Automat_Human_uron_third_Json);
                file.Close();
            }*/

            Console.SetWindowSize(240, 63);
            
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
            Console.Clear ();
            Pole();
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_1 = new ParameterizedThreadStart(Draw);
            Thread draw_room_1_thread = new Thread(draw_room_1);
            draw_room_1_thread.Start((object)Room_1);
            Thread.Sleep(1);
            Thread draw_room_2_thread = new Thread(draw_room_1);
            draw_room_2_thread.Start((object)Room_2);
            Thread.Sleep(1);
            Thread draw_room_3_thread = new Thread(draw_room_1);
            draw_room_3_thread.Start((object)Room_3);
            Thread.Sleep(1);
            Thread draw_room_4_thread = new Thread(draw_room_1);
            draw_room_4_thread.Start((object)Room_4);
            Thread.Sleep(1);
            Thread draw_room_5_thread = new Thread(draw_room_1);
            draw_room_5_thread.Start((object)Room_5);
            Thread.Sleep(1);
            Thread draw_room_6_thread = new Thread(draw_room_1);
            draw_room_6_thread.Start((object)Room_6);
            Thread.Sleep(1);
            Thread draw_room_7_thread = new Thread(draw_room_1);
            draw_room_7_thread.Start((object)Room_7);
            Thread.Sleep(1);
            Thread draw_room_8_thread = new Thread(draw_room_1);
            draw_room_8_thread.Start((object)Room_8);
            Thread.Sleep(1);
            Thread draw_room_9_thread = new Thread(draw_room_1);
            draw_room_9_thread.Start((object)Room_9);
            Thread.Sleep(1);

            ParameterizedThreadStart draw_corridor_47 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_47_thread = new Thread(draw_corridor_47);
            draw_corridor_47_thread.Start((object)Corridor_47);
            Thread.Sleep(1);
            Thread draw_corridor_14_thread = new Thread(draw_corridor_47);
            draw_corridor_14_thread.Start((object)Corridor_14);
            Thread.Sleep(1);
            Thread draw_corridor_58_thread = new Thread(draw_corridor_47);
            draw_corridor_58_thread.Start((object)Corridor_58);
            Thread.Sleep(1);
            Thread draw_corridor_25_thread = new Thread(draw_corridor_47);
            draw_corridor_25_thread.Start((object)Corridor_25);
            Thread.Sleep(1);
            Thread draw_corridor_69_thread = new Thread(draw_corridor_47);
            draw_corridor_69_thread.Start((object)Corridor_69);
            Thread.Sleep(1);
            Thread draw_corridor_36_thread = new Thread(draw_corridor_47);
            draw_corridor_36_thread.Start((object)Corridor_36);
            Thread.Sleep(1);

            ParameterizedThreadStart draw_corridor_78 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_78_thread = new Thread(draw_corridor_78);
            draw_corridor_78_thread.Start((object)Corridor_78);
            Thread.Sleep(1);
            Thread draw_corridor_45_thread = new Thread(draw_corridor_78);
            draw_corridor_45_thread.Start((object)Corridor_45);
            Thread.Sleep(1);
            Thread draw_corridor_89_thread = new Thread(draw_corridor_78);
            draw_corridor_89_thread.Start((object)Corridor_89);
            Thread.Sleep(1);
            Thread draw_corridor_56_thread = new Thread(draw_corridor_78);
            draw_corridor_56_thread.Start((object)Corridor_56);
            Thread.Sleep(1);
            Thread draw_corridor_12_thread = new Thread(draw_corridor_78);
            draw_corridor_12_thread.Start((object)Corridor_12);
            Thread.Sleep(1);
            Thread draw_corridor_23_thread = new Thread(draw_corridor_78);
            draw_corridor_23_thread.Start((object)Corridor_23);
            Thread.Sleep(1);
            if (player.Race == 1 )
            {
                player.Position = 2;
                while (player.Health > 0)
              {
                    ParameterizedThreadStart delete_hero_human = new ParameterizedThreadStart(Delete);
                    Thread delete_hero_human_thread = new Thread(delete_hero_human);
                    ParameterizedThreadStart draw_hero_human = new ParameterizedThreadStart(Draw);
                    Thread draw_hero_human_thread = new Thread(draw_hero_human);
                    //Console.WriteLine("Положение:\n");
                    switch (player.Position)
                  {
                      case 1:
                            Hero_Human.Position_x = 18;
                            Hero_Human.Position_y = 44;
                            Hero_Human.Index = 1;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    @@@\n    #@@\n");
                            break;
                      case 2:
                            Hero_Human.Position_x = 99;
                            Hero_Human.Position_y = 44;
                            Hero_Human.Index = 2;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    @@@\n    @#@\n");
                            break;
                      case 3:
                            Hero_Human.Position_x = 180;
                            Hero_Human.Position_y = 44;
                            Hero_Human.Index = 3;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    @@@\n    @@#\n");
                            break;
                      case 4:
                            Hero_Human.Position_x = 18;
                            Hero_Human.Position_y = 26;
                            Hero_Human.Index = 4;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    #@@\n    @@@\n");
                          break;
                      case 5:
                            Hero_Human.Position_x = 99;
                            Hero_Human.Position_y = 26;
                            Hero_Human.Index = 5;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    @#@\n    @@@\n");
                            break;
                      case 6:
                            Hero_Human.Position_x = 180;
                            Hero_Human.Position_y = 26;
                            Hero_Human.Index = 6;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@@\n    @@#\n    @@@\n");
                            break;
                      case 7:
                            Hero_Human.Position_x = 18;
                            Hero_Human.Position_y = 8;
                            Hero_Human.Index = 7;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    #@@\n    @@@\n    @@@\n");
                            break;
                      case 8:
                            Hero_Human.Position_x = 99;
                            Hero_Human.Position_y = 8;
                            Hero_Human.Index = 7;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @#@\n    @@@\n    @@@\n");
                          break;
                      case 9:
                            Hero_Human.Position_x = 180;
                            Hero_Human.Position_y = 8;
                            Hero_Human.Index = 7;
                            Thread.Sleep(1);
                            draw_hero_human_thread.Start((object)Hero_Human);
                            Thread.Sleep(1);
                            //Console.WriteLine("    @@#\n    @@@\n    @@@\n");
                            break;
                  }
                  //Console.WriteLine("Выберите направление перемещения:");

                 /* switch (player.Position)
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
                  }*/

                  choiceDirection: ConsoleKeyInfo Direction = Console.ReadKey();
                  switch (player.Position)
                  {
                      case 1:
                          switch (Direction.Key)
                          {
                              case ConsoleKey.RightArrow:
                                  player.Position++;
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.RightArrow:
                                  player.Position++;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 44;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.RightArrow:
                                  player.Position++;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                  player.Position += 3;
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 26;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 18;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.RightArrow:
                                  player.Position++;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.UpArrow:
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    goto exit;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 99;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
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
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              case ConsoleKey.DownArrow:
                                  player.Position -= 3;
                                    Hero_Human.Position_x = 180;
                                    Hero_Human.Position_y = 8;
                                    Thread.Sleep(1);
                                    delete_hero_human_thread.Start((object)Hero_Human);
                                    Thread.Sleep(1);
                                    break;
                              default:
                                  goto choiceDirection;
                          }
                          break;
                  }
                 //Console.Clear();
              }
              exit: Console.SetCursorPosition(0, 58);
                Console.WriteLine("\nДо связи....\n"); ;
             }
            else
            {
                player.Position = 2;
                while (player.Health > 0)
                {
                    ParameterizedThreadStart delete_hero_elf = new ParameterizedThreadStart(Delete);
                    Thread delete_hero_elf_thread = new Thread(delete_hero_elf);
                    ParameterizedThreadStart draw_hero_elf = new ParameterizedThreadStart(Draw);
                    Thread draw_hero_elf_thread = new Thread(draw_hero_elf);
                    switch (player.Position)
                    {
                        case 1:
                            Hero_Elf.Position_x = 15;
                            Hero_Elf.Position_y = 41;
                            Hero_Elf.Index = 1;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 2:
                            Hero_Elf.Position_x = 96;
                            Hero_Elf.Position_y = 41;
                            Hero_Elf.Index = 2;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 3:
                            Hero_Elf.Position_x = 177;
                            Hero_Elf.Position_y = 41;
                            Hero_Elf.Index = 3;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 4:
                            Hero_Elf.Position_x = 15;
                            Hero_Elf.Position_y = 23;
                            Hero_Elf.Index = 4;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 5:
                            Hero_Elf.Position_x = 96;
                            Hero_Elf.Position_y = 23;
                            Hero_Elf.Index = 5;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 6:
                            Hero_Elf.Position_x = 177;
                            Hero_Elf.Position_y = 23;
                            Hero_Elf.Index = 6;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 7:
                            Hero_Elf.Position_x = 15;
                            Hero_Elf.Position_y = 5;
                            Hero_Elf.Index = 7;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 8:
                            Hero_Elf.Position_x = 96;
                            Hero_Elf.Position_y = 5;
                            Hero_Elf.Index = 8;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
                            break;
                        case 9:
                            Hero_Elf.Position_x = 177;
                            Hero_Elf.Position_y = 5;
                            Hero_Elf.Index = 9;
                            Thread.Sleep(1);
                            draw_hero_elf_thread.Start((object)Hero_Elf);
                            Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);

                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    player.Position++;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);

                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 41;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    player.Position++;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    player.Position += 3;
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 23;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 15;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    player.Position++;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    goto exit;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 96;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
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
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    player.Position -= 3;
                                    Hero_Elf.Position_x = 177;
                                    Hero_Elf.Position_y = 5;
                                    Thread.Sleep(1);
                                    delete_hero_elf_thread.Start((object)Hero_Elf);
                                    Thread.Sleep(1);
                                    break;
                                default:
                                    goto choiceDirection;
                            }
                            break;
                    }
                    //Console.Clear();
                }
            exit: Console.SetCursorPosition(0, 58);
                Console.WriteLine("\nДо связи....\n"); ;
            }
            Console.ReadKey ();
            }
            static void SetConsoleDisplayMode(int width, int height)
        {
            const int SW_MAXIMIZE = 3;
            IntPtr hConsole = GetConsoleWindow();
            ShowWindow(hConsole, SW_MAXIMIZE);
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
