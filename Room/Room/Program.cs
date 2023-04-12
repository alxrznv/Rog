using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
// Все Json файлы находятся рядом с exe в \FightAnimation\FightAnimation\bin\Debug\net6.0\
namespace EnemyAnimation
{

    public class RoomClass
    {
        public int Position_x { get; set; }
        public int Position_y { get; set; }
        public int Index { get; set; }
        public string Sprite { get; set; }
    }

   /* public class KadrClass
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
    }*/
    /*############################################################
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    #                                                          #
    ############################################################*/
    class Programm
    {
        static void Draw(object argument)
        {
            RoomClass Room = argument as RoomClass;
            String[] str_room = Room.Sprite.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(Room.Position_x, Room.Position_y);
            for (int i = 0; i < str_room.Length; i++)
            {
                Console.Write(str_room[i]);
                Console.SetCursorPosition(Room.Position_x, Room.Position_y + 1 + i);
            }
        }
       /* static void DrawKadr(object argument)
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
        }*/
        static void Room()
        {
            Console.SetCursorPosition(5, 36);
            for (int i = 0; i < 60; i++) { Console.Write("#"); }
            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < 11; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(5, 36 + i);
            }
            Console.SetCursorPosition(5, 0);
            for (int i = 0; i < 11; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(64, 36 + i);
            }
            Console.SetCursorPosition(5, 46);
            for (int i = 0; i < 60; i++) { Console.Write("#"); }
            /*Console.SetCursorPosition(0, 0); //левая верхняя точка
            Console.WriteLine("%");
            Console.SetCursorPosition(0, 54); //левая нижняя точка
            Console.Write("%");
            Console.SetCursorPosition(237, 0); //правая верхняя точка
            Console.Write("%");
            Console.SetCursorPosition(237, 54); //правая нижняя точка
            Console.Write("%");*/
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
            Console.CursorVisible = true;
            string data1 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_1 = JsonSerializer.Deserialize<RoomClass>(data1);
            string data2 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_2 = JsonSerializer.Deserialize<RoomClass>(data2);
            string data3 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_3 = JsonSerializer.Deserialize<RoomClass>(data3);
            string data4 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_4 = JsonSerializer.Deserialize<RoomClass>(data4);
            string data5 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_5 = JsonSerializer.Deserialize<RoomClass>(data5);
            string data6 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_6 = JsonSerializer.Deserialize<RoomClass>(data6);
            string data7 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_7 = JsonSerializer.Deserialize<RoomClass>(data7);
            string data8 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_8 = JsonSerializer.Deserialize<RoomClass>(data8);
            string data9 = File.ReadAllText("RoomGlobal.json");
            RoomClass Room_9 = JsonSerializer.Deserialize<RoomClass>(data9);

            string data10 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_47 = JsonSerializer.Deserialize<RoomClass>(data10);
            string data11 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_14 = JsonSerializer.Deserialize<RoomClass>(data11);
            string data12 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_58 = JsonSerializer.Deserialize<RoomClass>(data12);
            string data13 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_25 = JsonSerializer.Deserialize<RoomClass>(data13);
            string data14 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_69 = JsonSerializer.Deserialize<RoomClass>(data14);
            string data15 = File.ReadAllText("Corridor_Vertical.json");
            RoomClass Corridor_36 = JsonSerializer.Deserialize<RoomClass>(data15);

            string data16 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_78 = JsonSerializer.Deserialize<RoomClass>(data16);
            string data17 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_45 = JsonSerializer.Deserialize<RoomClass>(data17);
            string data18 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_12 = JsonSerializer.Deserialize<RoomClass>(data18);
            string data19 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_89 = JsonSerializer.Deserialize<RoomClass>(data19);
            string data20 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_56 = JsonSerializer.Deserialize<RoomClass>(data20);
            string data21 = File.ReadAllText("Corridor_Horizontal.json");
            RoomClass Corridor_23 = JsonSerializer.Deserialize<RoomClass>(data21);

                Room_1.Index = 1;
                Room_1.Position_x = 9;
                Room_1.Position_y = 39;
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

            Console.SetWindowSize(240, 63);
            /*{
                RoomClass Automat_Human_uron_third = new RoomClass();
                Automat_Human_uron_third.Position_x = 63;
                Automat_Human_uron_third.Position_y = 0;
                Automat_Human_uron_third.Sprite = "########################\r\n                        \r\n                        \r\n                        \r\n                        \r\n########################";
                Automat_Human_uron_third.Index = 1;
                string Automat_Human_uron_third_Json = JsonSerializer.Serialize(Automat_Human_uron_third, typeof(RoomClass));
                StreamWriter file = File.CreateText("Corridor_Horizontal.json");
                file.WriteLine(Automat_Human_uron_third_Json);
                file.Close();
            }*/
            Pole();
           
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_1 = new ParameterizedThreadStart(Draw);
            Thread draw_room_1_thread = new Thread(draw_room_1);
            draw_room_1_thread.Start((object)Room_1);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_2 = new ParameterizedThreadStart(Draw);
            Thread draw_room_2_thread = new Thread(draw_room_2);
            draw_room_2_thread.Start((object)Room_2);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_3 = new ParameterizedThreadStart(Draw);
            Thread draw_room_3_thread = new Thread(draw_room_3);
            draw_room_3_thread.Start((object)Room_3);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_4 = new ParameterizedThreadStart(Draw);
            Thread draw_room_4_thread = new Thread(draw_room_4);
            draw_room_4_thread.Start((object)Room_4);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_5 = new ParameterizedThreadStart(Draw);
            Thread draw_room_5_thread = new Thread(draw_room_5);
            draw_room_5_thread.Start((object)Room_5);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_6 = new ParameterizedThreadStart(Draw);
            Thread draw_room_6_thread = new Thread(draw_room_6);
            draw_room_6_thread.Start((object)Room_6);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_7 = new ParameterizedThreadStart(Draw);
            Thread draw_room_7_thread = new Thread(draw_room_7);
            draw_room_7_thread.Start((object)Room_7);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_8 = new ParameterizedThreadStart(Draw);
            Thread draw_room_8_thread = new Thread(draw_room_8);
            draw_room_8_thread.Start((object)Room_8);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_room_9 = new ParameterizedThreadStart(Draw);
            Thread draw_room_9_thread = new Thread(draw_room_9);
            draw_room_9_thread.Start((object)Room_9);
            Thread.Sleep(1);
            
            ParameterizedThreadStart draw_corridor_47 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_47_thread = new Thread(draw_corridor_47);
            draw_corridor_47_thread.Start((object)Corridor_47);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_14 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_14_thread = new Thread(draw_corridor_14);
            draw_corridor_14_thread.Start((object)Corridor_14);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_58 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_58_thread = new Thread(draw_corridor_58);
            draw_corridor_58_thread.Start((object)Corridor_58);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_25 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_25_thread = new Thread(draw_corridor_25);
            draw_corridor_25_thread.Start((object)Corridor_25);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_69 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_69_thread = new Thread(draw_corridor_69);
            draw_corridor_69_thread.Start((object)Corridor_69);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_36 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_36_thread = new Thread(draw_corridor_36);
            draw_corridor_36_thread.Start((object)Corridor_36);
            Thread.Sleep(1);

            ParameterizedThreadStart draw_corridor_78 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_78_thread = new Thread(draw_corridor_78);
            draw_corridor_78_thread.Start((object)Corridor_78);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_45 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_45_thread = new Thread(draw_corridor_45);
            draw_corridor_45_thread.Start((object)Corridor_45);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_89 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_89_thread = new Thread(draw_corridor_89);
            draw_corridor_89_thread.Start((object)Corridor_89);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_56 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_56_thread = new Thread(draw_corridor_56);
            draw_corridor_56_thread.Start((object)Corridor_56);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_12 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_12_thread = new Thread(draw_corridor_12);
            draw_corridor_12_thread.Start((object)Corridor_12);
            Thread.Sleep(1);
            ParameterizedThreadStart draw_corridor_23 = new ParameterizedThreadStart(Draw);
            Thread draw_corridor_23_thread = new Thread(draw_corridor_23);
            draw_corridor_23_thread.Start((object)Corridor_23);

            Console.SetCursorPosition(0, 61);
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