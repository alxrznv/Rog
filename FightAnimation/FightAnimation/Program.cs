// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.Json;
// Все Json файлы находятся рядом с exe в \FightAnimation\FightAnimation\bin\Debug\net6.0\
namespace FightAnimation
{
    public class KadrClass
    {
        /// <summary>
        /// Позиция x
        /// </summary>    
        public int Position_x { get; set; }
        /// <summary>
        /// Позиция y
        /// </summary>
        public int Position_y { get; set; }
        /// <summary>
        /// Номер кадра
        /// </summary>
        public int NumberAnimation { get; set; }
        public string Kadr { get; set; }
        public KadrClass() { }
        public KadrClass(int _x, int _y, int a, string kadr)
        {
            Position_x = _x;
            Position_y = _y;
            NumberAnimation = a;
            Kadr = kadr;
        }
    }
    class Programm
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
            Char[] simvols = {'!','@','#','$','%','^','&','*','(',')','_','-','=','+','`','{','[','}',']','|', ';',':','"','<','>',',','.','/', '?' };
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
        static void Main(string[] args)
        {
            SetConsoleDisplayMode(Console.WindowWidth, Console.WindowHeight);
            Console.SetCursorPosition(0, 0);
            //Console.WriteLine("Это консольное приложение в полноэкранном режиме.");
            Console.CursorVisible = true;
            Console.SetWindowSize(240, 66);

            /*KadrClass Automat_Human_uron_third = new KadrClass();
            Automat_Human_uron_third.Position_x = 0;
            Automat_Human_uron_third.Position_y = 0;
            Automat_Human_uron_third.Kadr = "";

            string Automat_Human_uron_third_Json = JsonSerializer.Serialize(Automat_Human_uron_third, typeof(KadrClass));
            StreamWriter file = File.CreateText("Pistol_Human_attack_second.json");
            file.WriteLine(Automat_Human_uron_third_Json);
            file.Close();*/
            Pole();
            {
                string person = "";
                string weapon = "";
                Console.SetCursorPosition(0, 56);
                Console.WriteLine("Введите рассу: 1.ЧЕЛОВЕК 2.ЭЛЬФ");
                person = Console.ReadLine();
                if (person == "1")
                {
                    Console.SetCursorPosition(1, 57);
                    weapon = Console.ReadLine();

                    if (weapon == "P1")
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
                        while (true)
                        {
                            ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                            draw_kadr1Thread.Start((object)Pistol_Human_start);
                            Console.SetCursorPosition(0, 58);
                            if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Human_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Human_attack_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Human_attack_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Human_attack_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Pistol_Human_attack_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Human_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Human_uron_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Human_uron_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Human_uron_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Pistol_Human_uron_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.D)   //Смерть
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Human_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Human_uron_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Human_uron_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Human_uron_third);
                                Thread.Sleep(sleeping);
                                break;
                            }
                        }
                    }
                    else if (weapon == "A1")
                    {
                        string data = File.ReadAllText("Automat_Human_start.json");    //Первый кадр человека с автоматом 
                        KadrClass Automat_Human_start = JsonSerializer.Deserialize<KadrClass>(data);
                        string data1 = File.ReadAllText("Automat_Human_attack_second.json");    //Второй кадр выстрела человека с автоматом 
                        KadrClass Automat_Human_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                        string data2 = File.ReadAllText("Automat_Human_attack_third.json");    //Третий кадр выстрела человека с автоматом 
                        KadrClass Automat_Human_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                        string data3 = File.ReadAllText("Automat_Human_uron_second.json");   //Второй кадр получения урона человека с автоматом 
                        KadrClass Automat_Human_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                        string data4 = File.ReadAllText("Automat_Human_uron_third.json");   //Третий кадр  получения урона человека с автоматом 
                        KadrClass Automat_Human_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);

                        while (true)
                        {
                            ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                            draw_kadr1Thread.Start((object)Automat_Human_start);
                            Console.SetCursorPosition(0, 58);
                            if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Human_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Human_attack_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Human_attack_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Human_attack_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Automat_Human_attack_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Human_start);

                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Human_uron_second);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Human_uron_second);
                                Thread.Sleep(1);

                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Human_uron_third);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Automat_Human_uron_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.D)   //Смерть
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Human_start);

                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Human_uron_second);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Human_uron_second);
                                Thread.Sleep(1);

                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Human_uron_third);
                                Thread.Sleep(sleeping);
                                break;
                            }
                        }
                    }
                }
                else if (person == "2")
                {
                    Console.SetCursorPosition(1, 57);
                    weapon = Console.ReadLine();
                    if (weapon == "P1")
                    {
                        string data = File.ReadAllText("Pistol_Elf_start.json");    //Первый кадр Эльфа с пистолетом 
                        KadrClass Pistol_Elf_start = JsonSerializer.Deserialize<KadrClass>(data);
                        string data1 = File.ReadAllText("Pistol_Elf_attack_second.json");    //Второй кадр выстрела человека с пистолетом 
                        KadrClass Pistol_Elf_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                        string data2 = File.ReadAllText("Pistol_Elf_attack_third.json");    //Третий кадр выстрела человека с пистолетом 
                        KadrClass Pistol_Elf_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                        string data3 = File.ReadAllText("Pistol_Elf_uron_second.json");   //Второй кадр получения урона человека с пистолетом 
                        KadrClass Pistol_Elf_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                        string data4 = File.ReadAllText("Pistol_Elf_uron_third.json");   //Третий кадр  получения урона человека с пистолетом 
                        KadrClass Pistol_Elf_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                        while (true)
                        {
                            ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                            draw_kadr1Thread.Start((object)Pistol_Elf_start);
                            Console.SetCursorPosition(0, 58);
                            if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Elf_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Elf_attack_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Elf_attack_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Elf_attack_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Pistol_Elf_attack_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Elf_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Elf_uron_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Elf_uron_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Elf_uron_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Pistol_Elf_uron_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.D)   //Смерть
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Pistol_Elf_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Pistol_Elf_uron_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Pistol_Elf_uron_third);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Pistol_Elf_uron_second);
                                Thread.Sleep(sleeping);
                                break;
                            }
                        }
                    }
                    else if (weapon == "A1")
                    {
                        string data = File.ReadAllText("Automat_Elf_start.json");    //Первый кадр Эльфа с автоматом 
                        KadrClass Automat_Elf_start = JsonSerializer.Deserialize<KadrClass>(data);
                        string data1 = File.ReadAllText("Automat_Elf_attack_second.json");    //Второй кадр выстрела человека с автоматом 
                        KadrClass Automat_Elf_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                        string data2 = File.ReadAllText("Automat_Elf_attack_third.json");    //Третий кадр выстрела человека с автоматом 
                        KadrClass Automat_Elf_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                        string data3 = File.ReadAllText("Automat_Elf_uron_second.json");   //Второй кадр получения урона человека с автоматом 
                        KadrClass Automat_Elf_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                        string data4 = File.ReadAllText("Automat_Elf_uron_third.json");   //Третий кадр  получения урона человека с автоматом 
                        KadrClass Automat_Elf_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                        while (true)
                        {
                            ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                            draw_kadr1Thread.Start((object)Automat_Elf_start);
                            Console.SetCursorPosition(0, 58);
                            if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Elf_start);
                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Elf_attack_second);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Elf_attack_second);
                                Thread.Sleep(1);
                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Elf_attack_third);
                                Thread.Sleep(sleeping);
                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Automat_Elf_attack_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Elf_start);

                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Elf_uron_second);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Elf_uron_second);
                                Thread.Sleep(1);

                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Elf_uron_third);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                                delete_kadr3Thread.Start((object)Automat_Elf_uron_third);
                                Thread.Sleep(1);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.D)   //Смерть
                            {
                                int sleeping = 50;
                                ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                                delete_kadr1Thread.Start((object)Automat_Elf_start);

                                ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                                Thread.Sleep(1);
                                Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                                draw_kadr2Thread.Start((object)Automat_Elf_uron_second);
                                Thread.Sleep(sleeping);

                                ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                                Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                                delete_kadr2Thread.Start((object)Automat_Elf_uron_second);
                                Thread.Sleep(1);

                                ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                                Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                                draw_kadr3Thread.Start((object)Automat_Elf_uron_third);
                                Thread.Sleep(sleeping);
                                break;
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
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