using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.Json;
// Все Json файлы находятся рядом с exe в \FightAnimation\FightAnimation\bin\Debug\net6.0\
namespace EnemyAnimation
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
        public KadrClass(int _x, int _y, string kadr)
        {
            Position_x = _x;
            Position_y = _y;
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
        static void Main(string[] args)
        {
            SetConsoleDisplayMode(Console.WindowWidth, Console.WindowHeight);
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.SetWindowSize(240, 63);

            /*{
                KadrClass Automat_Human_uron_third = new KadrClass();
                Automat_Human_uron_third.Position_x = 126;
                Automat_Human_uron_third.Position_y = 39;
                Automat_Human_uron_third.Kadr = "                 \t\t\t\t\t      ---- -----      --.         \r\n                                                          -+#%%%%%@@@@@@@@@@@%%%%*        \r\n                                                       -+@%%%%%%@@@@@@@@@@@@@%%%%%%@@@%**.\r\n                                               ----*@@@%%%@@@@@@@@@@@%%%%@@@#%%@@@@@@*@%%@";

                string Automat_Human_uron_third_Json = JsonSerializer.Serialize(Automat_Human_uron_third, typeof(KadrClass));
                StreamWriter file = File.CreateText("Gnom_automat_death_4.json");
                file.WriteLine(Automat_Human_uron_third_Json);
                file.Close();
            }*/


            Pole();
            {
                string enemy = "";
                Console.SetCursorPosition(0, 56);
                enemy = Console.ReadLine();
                if (enemy == "D")
                {
                    string data = File.ReadAllText("Dog_start.json");    //Первый кадр Dog
                    KadrClass Dog_start = JsonSerializer.Deserialize<KadrClass>(data);
                    string data1 = File.ReadAllText("Dog_attack_second.json");    //Атака 2 кадр Dog
                    KadrClass Dog_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                    string data2 = File.ReadAllText("Dog_attack_third.json");    //Атака 3 кадр Dog
                    KadrClass Dog_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                    string data3 = File.ReadAllText("Dog_uron_second.json");   //Второй кадр получения урона Dog
                    KadrClass Dog_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                    string data4 = File.ReadAllText("Dog_uron_third.json");   //Третий кадр  получения урона Dog 
                    KadrClass Dog_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                    while (true)
                    {
                        ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                        Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                        draw_kadr1Thread.Start((object)Dog_start);
                        if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                        {
                            int sleeping = 50;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Dog_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Dog_attack_second);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Dog_attack_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Dog_attack_third);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Dog_attack_third);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                        {
                            int sleeping = 50;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Dog_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Dog_uron_second);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Dog_uron_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Dog_uron_third);
                            Thread.Sleep(200);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Dog_uron_third);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D)   //Смерть
                        {
                            int sleeping = 50;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Dog_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Dog_uron_second);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Dog_uron_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Dog_uron_third);
                            Thread.Sleep(sleeping);
                            break;
                        }
                    }
                }
                else if (enemy == "A")
                {
                    string data = File.ReadAllText("Gnom_automat_start.json");    //Первый кадр Gnom_automat
                    KadrClass Gnom_automat_start = JsonSerializer.Deserialize<KadrClass>(data);
                    string data1 = File.ReadAllText("Gnom_automat_attack_second.json");    //Атака 2 кадр Gnom_automat
                    KadrClass Gnom_automat_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                    string data2 = File.ReadAllText("Gnom_automat_attack_third.json");    //Атака 3 кадр Gnom_automat
                    KadrClass Gnom_automat_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                    string data3 = File.ReadAllText("Gnom_automat_uron_second.json");   //Второй кадр получения урона Gnom_automat
                    KadrClass Gnom_automat_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                    string data4 = File.ReadAllText("Gnom_automat_uron_third.json");   //Третий кадр  получения урона Gnom_automat 
                    KadrClass Gnom_automat_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                    string data5 = File.ReadAllText("Gnom_automat_death_4.json");   //4 кадр смерти Gnom_automat 
                    KadrClass Gnom_automat_death_4 = JsonSerializer.Deserialize<KadrClass>(data5);
                    string data6 = File.ReadAllText("Gnom_automat_attack_4.json");   //4 кадр  атака Gnom_automat 
                    KadrClass Gnom_automat_attack_4 = JsonSerializer.Deserialize<KadrClass>(data6);
                    string data7 = File.ReadAllText("Gnom_automat_death_1.json");   //1 смерти Gnom_automat 
                    KadrClass Gnom_automat_death_1 = JsonSerializer.Deserialize<KadrClass>(data7);
                    string data8 = File.ReadAllText("Gnom_automat_death_2.json");   //2 смерти Gnom_automat 
                    KadrClass Gnom_automat_death_2 = JsonSerializer.Deserialize<KadrClass>(data8);
                    string data9 = File.ReadAllText("Gnom_automat_death_3.json");   //3 смерти Gnom_automat 
                    KadrClass Gnom_automat_death_3 = JsonSerializer.Deserialize<KadrClass>(data9);
                    while (true)
                    {
                        ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                        Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                        draw_kadr1Thread.Start((object)Gnom_automat_start);
                        if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                        {
                            int sleeping = 50;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_automat_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_automat_attack_second);
                            Thread.Sleep(100);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_automat_attack_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_automat_attack_third);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_automat_attack_third);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr4 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr4Thread = new Thread(draw_kadr4);   //Отрисовка кадра
                            draw_kadr4Thread.Start((object)Gnom_automat_attack_4);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr4 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr4Thread = new Thread(delete_kadr4);   //Удаление кадра
                            delete_kadr4Thread.Start((object)Gnom_automat_attack_4);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                        {
                            int sleeping = 100;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_automat_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_automat_uron_second);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_automat_uron_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_automat_uron_third);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_automat_uron_third);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr4 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr4Thread = new Thread(draw_kadr4);   //Отрисовка кадра
                            draw_kadr4Thread.Start((object)Gnom_automat_uron_second);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr4 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr4Thread = new Thread(delete_kadr4);   //Удаление кадра
                            delete_kadr4Thread.Start((object)Gnom_automat_uron_second);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D) //Смерть
                        {
                            int sleeping = 100;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_automat_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_automat_death_1);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_automat_death_1);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_automat_death_2);
                            Thread.Sleep(150);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_automat_death_2);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr4 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr4Thread = new Thread(draw_kadr4);   //Отрисовка кадра
                            draw_kadr4Thread.Start((object)Gnom_automat_death_3);
                            Thread.Sleep(150);
                            ParameterizedThreadStart delete_kadr4 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr4Thread = new Thread(delete_kadr4);   //Удаление кадра
                            delete_kadr4Thread.Start((object)Gnom_automat_death_3);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr5 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr5Thread = new Thread(draw_kadr5);   //Отрисовка кадра
                            draw_kadr5Thread.Start((object)Gnom_automat_death_4);
                            break;
                        }
                    }
                }
                else if (enemy == "P")
                {
                    string data = File.ReadAllText("Gnom_Kuvalda_start.json");    //Первый кадр Gnom_Kuvalda
                    KadrClass Gnom_Kuvalda_start = JsonSerializer.Deserialize<KadrClass>(data);
                    string data1 = File.ReadAllText("Gnom_Kuvalda_attack_second.json");    //Атака 2 кадр Gnom_Kuvalda
                    KadrClass Gnom_Kuvalda_attack_second = JsonSerializer.Deserialize<KadrClass>(data1);
                    string data2 = File.ReadAllText("Gnom_Kuvalda_attack_third.json");    //Атака 3 кадр Gnom_Kuvalda
                    KadrClass Gnom_Kuvalda_attack_third = JsonSerializer.Deserialize<KadrClass>(data2);
                    string data3 = File.ReadAllText("Gnom_Kuvalda_uron_second.json");   //Второй кадр получения урона Gnom_Kuvalda
                    KadrClass Gnom_Kuvalda_uron_second = JsonSerializer.Deserialize<KadrClass>(data3);
                    string data4 = File.ReadAllText("Gnom_Kuvalda_uron_third.json");   //Третий кадр  получения урона Gnom_Kuvalda 
                    KadrClass Gnom_Kuvalda_uron_third = JsonSerializer.Deserialize<KadrClass>(data4);
                    string data5 = File.ReadAllText("Gnom_Kuvalda_uron_4.json");   //4 кадр  получения урона Gnom_Kuvalda 
                    KadrClass Gnom_Kuvalda_uron_4 = JsonSerializer.Deserialize<KadrClass>(data5);
                    while (true)
                    {
                        ParameterizedThreadStart draw_kadr1 = new ParameterizedThreadStart(DrawKadr);
                        Thread draw_kadr1Thread = new Thread(draw_kadr1);   //Отрисовка кадра
                        draw_kadr1Thread.Start((object)Gnom_Kuvalda_start);
                        if (Console.ReadKey().Key == ConsoleKey.A) // Атака
                        {
                            int sleeping = 50;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_Kuvalda_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_Kuvalda_attack_second);
                            Thread.Sleep(100);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_Kuvalda_attack_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_Kuvalda_attack_third);
                            Thread.Sleep(sleeping);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_Kuvalda_attack_third);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.U) //Урон
                        {
                            int sleeping = 250;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_Kuvalda_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_Kuvalda_uron_second);
                            Thread.Sleep(500);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_Kuvalda_uron_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_Kuvalda_uron_third);
                            Thread.Sleep(50);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_Kuvalda_uron_third);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr4 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr4Thread = new Thread(draw_kadr4);   //Отрисовка кадра
                            draw_kadr4Thread.Start((object)Gnom_Kuvalda_uron_4);
                            Thread.Sleep(300);
                            ParameterizedThreadStart delete_kadr4 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr4Thread = new Thread(delete_kadr4);   //Удаление кадра
                            delete_kadr4Thread.Start((object)Gnom_Kuvalda_uron_4);
                            Thread.Sleep(1);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D) //Смерть
                        {
                            int sleeping = 250;
                            ParameterizedThreadStart delete_kadr1 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr1Thread = new Thread(delete_kadr1);   //Удаление кадра
                            delete_kadr1Thread.Start((object)Gnom_Kuvalda_start);
                            ParameterizedThreadStart draw_kadr2 = new ParameterizedThreadStart(DrawKadr);
                            Thread.Sleep(1);
                            Thread draw_kadr2Thread = new Thread(draw_kadr2);   //Отрисовка кадра
                            draw_kadr2Thread.Start((object)Gnom_Kuvalda_uron_second);
                            Thread.Sleep(500);
                            ParameterizedThreadStart delete_kadr2 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr2Thread = new Thread(delete_kadr2);   //Удаление кадра
                            delete_kadr2Thread.Start((object)Gnom_Kuvalda_uron_second);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr3 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr3Thread = new Thread(draw_kadr3);   //Отрисовка кадра
                            draw_kadr3Thread.Start((object)Gnom_Kuvalda_uron_third);
                            Thread.Sleep(50);
                            ParameterizedThreadStart delete_kadr3 = new ParameterizedThreadStart(DeleteKadr);
                            Thread delete_kadr3Thread = new Thread(delete_kadr3);   //Удаление кадра
                            delete_kadr3Thread.Start((object)Gnom_Kuvalda_uron_third);
                            Thread.Sleep(1);
                            ParameterizedThreadStart draw_kadr4 = new ParameterizedThreadStart(DrawKadr);
                            Thread draw_kadr4Thread = new Thread(draw_kadr4);   //Отрисовка кадра
                            draw_kadr4Thread.Start((object)Gnom_Kuvalda_uron_4);
                            break;
                        }
                    }
                }
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
}