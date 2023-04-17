using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
/*using System.Text.Json;*/
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
            Console.SetWindowSize(240, 63);
            KadrClass Automat_Human_uron_third = new KadrClass();
            Automat_Human_uron_third.Position_x = 0;
            Automat_Human_uron_third.Position_y = 0;
            Automat_Human_uron_third.Kadr = "#############################################################\r\n####\r\n####\r\n####\r\n####\r\n####\r\n####\r\n####\r\n####\r\n####\r\n#############################################################";

            string Automat_Human_uron_third_Json = JsonSerializer.Serialize(Automat_Human_uron_third, typeof(KadrClass));
            StreamWriter file = File.CreateText("room.json");
            file.WriteLine(Automat_Human_uron_third_Json);
            file.Close();
            Pole();
            Room();
            Console.SetCursorPosition(5, 10);
            Room();
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