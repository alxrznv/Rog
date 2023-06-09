﻿using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using LockJson;

namespace LockJson
{
   /* public class A
    {
        public int aaaaaa { get; set; }

        public A () { }
        public A (int a1111111) { 
            aaaaaa = a1111111;
        }
    }*/
   public class LockClass
    {
        /// <summary>
        /// Позиция x
        /// </summary>    
        public int Position_x { get; set; }
        /// <summary>
        /// Позиция y
        /// </summary>
        public int Position_y { get; set; }
        public int Counter { get; set; }
        public LockClass() { }
        public LockClass(int _x, int _y, int a) { 
            Position_x = _x;
            Position_y = _y;
            Counter = a;
        }
    }
    public class PositionsRG
    {
        /// <summary>
        /// Позиция x Red
        /// </summary>    
        public int Position_xR { get; set; }
        /// <summary>
        /// Позиция y Red
        /// </summary>
        public int Position_yR { get; set; }
        /// <summary>
        /// Позиция x Green
        /// </summary>    
        public int Position_xG { get; set; }
        /// <summary>
        /// Позиция y Green
        /// </summary>
        public int Position_yG { get; set; }
        public int Counter { get; set; }
        public bool Win { get; set; }
        public PositionsRG() { }
        public PositionsRG(int _xR, int _yR, int _xG, int _yG, int counter, bool win)
        {
            Position_xR = _xR;
            Position_yR = _yR;
            Position_xG = _xG;
            Position_yG = _yG;
            Counter = counter;
            Win = win;
        }
    }

}

class Programm
{
    /* static void Print(object argument)
     {
         A b = argument as A;
         while (b.aaaaaa != 10)
         {
             Console.WriteLine(b.aaaaaa); Thread.Sleep(500);
             Thread.Sleep(100);
         }
     }*/
    static void Draw_Red (object argument)
    {
        int x = 0;
        int y = 0;
        PositionsRG Positions = argument as PositionsRG;
        Random rndXRD = new Random();
        Random rndYRD = new Random();
        while ((Positions.Counter < 5) || ((Positions.Position_xG != Positions.Position_xR) || (Positions.Position_yG != Positions.Position_yR)))
        {
            if (Positions.Counter < 10) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Positions.Position_xR, Positions.Position_yR);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.SetCursorPosition(Positions.Position_xR + j, Positions.Position_yR + i);
                        Console.Write(Positions.Counter);
                        /*if ((i == 0) && (j == 0))
                        {
                            Xr = RedLock.Position_x;
                            Yr = RedLock.Position_y;
                        }*/
                    }
                }
                Thread.Sleep(3000);
                Console.SetCursorPosition(Positions.Position_xR, Positions.Position_yR);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.SetCursorPosition(Positions.Position_xR + j, Positions.Position_yR + i);
                        Console.Write(" ");
                        /*if ((i == 0) && (j == 0))
                        {
                            Xr = RedLock.Position_x;
                            Yr = RedLock.Position_y;
                        }*/
                    }
                }

                Positions.Counter++;
                x = Positions.Position_xR;
                y = Positions.Position_yR;
                Positions.Position_xR = rndXRD.Next(43, 116);
                Positions.Position_yR = rndYRD.Next(13, 32);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.SetCursorPosition(x + j, y + i);
                        Console.Write(Positions.Counter -1);
                        /*if ((i == 0) && (j == 0))
                        {
                            Xr = RedLock.Position_x;
                            Yr = RedLock.Position_y;
                        }*/
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0,35);
                break;
            }


        }
    }

    static void Win1 (object argument)
    {
        PositionsRG PositionsG = argument as PositionsRG;
        while(PositionsG.Win != true)
        {
            if ((PositionsG.Position_xG == PositionsG.Position_xR) && (PositionsG.Position_yG == PositionsG.Position_yR))
            {
                PositionsG.Win = true;
            }
        }

    }
    static void Draw_Pole()
    {
        LockClass Pole = new LockClass()
        {
            Position_x = 43,
            Position_y = 0 + 12
        };
        Console.CursorLeft = Pole.Position_x;
        Console.CursorTop = Pole.Position_y;
        Console.SetWindowSize(160, 60);
        for (int i = 0; i < 75; i++)
        {
            Console.Write("#");
        }
        Pole.Position_x = 42;
        Pole.Position_y = 21 + 12;
        Console.CursorLeft = Pole.Position_x;
        Console.CursorTop = Pole.Position_y;
        for (int i = 0; i < 75; i++)
        {
            Console.Write("#");
        }
        Pole.Position_x = 42;
        Pole.Position_y = 0 + 12;
        Console.CursorLeft = Pole.Position_x;
        Console.CursorTop = Pole.Position_y;
        for (int i = 0; i < 22; i++)
        {
            Console.WriteLine("#");
            Pole.Position_x = 42;
            Console.CursorLeft = Pole.Position_x;
        }
        Pole.Position_x = 117;
        Pole.Position_y = 0 + 12;
        Console.CursorLeft = Pole.Position_x;
        Console.CursorTop = Pole.Position_y;
        for (int i = 0; i < 22; i++)
        {
            Console.WriteLine("#");
            Pole.Position_x = 117;
            Console.CursorLeft = Pole.Position_x;
        }
        //Координаты краев поля
        /* Console.CursorLeft = 42;
         Console.CursorTop = 0 + 12;
         Console.Write("@");
         Console.CursorLeft = 117;
         Console.CursorTop = 0 + 12;
         Console.Write("@");
         Console.CursorLeft = 42;
         Console.CursorTop = 12 + 21;
         Console.Write("@");
         Console.CursorLeft = 117;
         Console.CursorTop = 12 + 21;
         Console.Write("@");*/
    }

    static void Pole()
    {
        Console.SetCursorPosition(42, 12);
        Console.WriteLine("############################################################################\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          ############################################################################");
    }
    static void Main(string[] args)
    {
        Random rndXR = new Random();
        Random rndYR = new Random();
        Random rndXG = new Random();
        Random rndYG = new Random();
        Console.SetWindowSize(160, 60);
        Pole();
        LockClass GreenKey = new LockClass();
        GreenKey.Position_x = 74;
        GreenKey.Position_y = 31;
        LockClass RedLock = new LockClass();
        RedLock.Position_x = rndXR.Next(43, 116);
        RedLock.Position_y = rndYR.Next(13, 32);
        RedLock.Counter = 0;
        PositionsRG GreenKeyANDRedLock = new PositionsRG();
        GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
        GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
        GreenKeyANDRedLock.Position_xR = RedLock.Position_x;
        GreenKeyANDRedLock.Position_yR = RedLock.Position_y;
        GreenKeyANDRedLock.Counter = RedLock.Counter;
        GreenKeyANDRedLock.Win = false;
        ParameterizedThreadStart win = new ParameterizedThreadStart(Win1);
        Thread winThread = new Thread(win);
        winThread.Start((object)GreenKeyANDRedLock);
        ParameterizedThreadStart draw_red = new ParameterizedThreadStart(Draw_Red);
        Thread draw_redThread = new Thread(draw_red);
        draw_redThread.Start((object)GreenKeyANDRedLock);

        while ((GreenKeyANDRedLock.Counter < 10) && (GreenKeyANDRedLock.Win != true))
        {
            if ((GreenKey.Position_x == RedLock.Position_x) && (GreenKey.Position_y == RedLock.Position_y))
    {
                break;
            }
            
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                    Console.Write("K");
                }
            }
            Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
            if ((Console.ReadKey().Key == ConsoleKey.UpArrow) && (GreenKey.Position_y > 14))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y - 2;
                GreenKey.Position_x = GreenKey.Position_x;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
            }
            else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (GreenKey.Position_x > 44))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y;
                GreenKey.Position_x = GreenKey.Position_x - 3;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
            }
            else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (GreenKey.Position_x == 44))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y;
                GreenKey.Position_x = GreenKey.Position_x - 1;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
            }
            else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (GreenKey.Position_x < 113))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y;
                GreenKey.Position_x = GreenKey.Position_x + 3;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
            }
            else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (GreenKey.Position_x == 113))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y;
                GreenKey.Position_x = GreenKey.Position_x + 2;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
            }
            else if ((Console.ReadKey().Key == ConsoleKey.DownArrow) && (GreenKey.Position_y < 31))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write(" ");
                    }
                }
                GreenKey.Position_y = GreenKey.Position_y + 2;
                GreenKey.Position_x = GreenKey.Position_x;
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.CursorLeft = GreenKey.Position_x + j;
                        Console.CursorTop = GreenKey.Position_y + i;
                        Console.Write("K");
                    }
                }
                Console.CursorLeft = GreenKey.Position_x;
                Console.CursorTop = GreenKey.Position_y;

            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 35);
        Console.WriteLine("ОООО");


        /*while ((GreenKeyANDRedLock.Counter < 10)&&((GreenKey.Position_x != RedLock.Position_x) && (GreenKey.Position_y != RedLock.Position_y)))
        {
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                    Console.Write("K");
                }
            }
            Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
            Console.ReadKey();
        }*/



        /*ParameterizedThreadStart draw_green = new ParameterizedThreadStart(Draw_Green);
        Thread draw_greenThread = new Thread(draw_green);
        draw_greenThread.Start((object)GreenKeyANDRedLock);*/


        /*ParameterizedThreadStart print = new ParameterizedThreadStart(Print);
        Thread printThread = new Thread(print);
        printThread.Start((object)a);
        //Thread.Sleep(10000);
        while (a.aaaaaa != 10)
        {
            a.aaaaaa++;
            Thread.Sleep(500);
        }
        Console.WriteLine("12323 " + a.aaaaaa);
*/
    }

}












/*while ((GreenKeyANDRedLock.Counter < 10) && (GreenKeyANDRedLock.Win != true))
{
    *//*if ((GreenKey.Position_x == RedLock.Position_x) && (GreenKey.Position_y == RedLock.Position_y))
    {
        break;
    }*//*
    Thread.Sleep(50);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
            Console.Write("K");
        }
    }
    Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
    if ((Console.ReadKey().Key == ConsoleKey.UpArrow) && (GreenKey.Position_y > 14))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y - 2;
        GreenKey.Position_x = GreenKey.Position_x;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
    }
    else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (GreenKey.Position_x > 44))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y;
        GreenKey.Position_x = GreenKey.Position_x - 3;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
    }
    else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (GreenKey.Position_x == 44))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y;
        GreenKey.Position_x = GreenKey.Position_x - 1;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
    }
    else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (GreenKey.Position_x < 113))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y;
        GreenKey.Position_x = GreenKey.Position_x + 3;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
    }
    else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (GreenKey.Position_x == 113))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y;
        GreenKey.Position_x = GreenKey.Position_x + 2;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
    }
    else if ((Console.ReadKey().Key == ConsoleKey.DownArrow) && (GreenKey.Position_y < 31))
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write(" ");
            }
        }
        GreenKey.Position_y = GreenKey.Position_y + 2;
        GreenKey.Position_x = GreenKey.Position_x;
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.CursorLeft = GreenKey.Position_x + j;
                Console.CursorTop = GreenKey.Position_y + i;
                Console.Write("K");
            }
        }
        Console.CursorLeft = GreenKey.Position_x;
        Console.CursorTop = GreenKey.Position_y;

    }
}*/
