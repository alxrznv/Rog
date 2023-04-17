
namespace LockJson
{
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
        public LockClass(int _x, int _y, int a)
        {
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
    class Programm
    {
        static void Draw_Red(object argument)
        {
            int x = 0;
            int y = 0;
            PositionsRG Positions = argument as PositionsRG;
            Random rndXRD = new Random();
            Random rndYRD = new Random();
            while (Positions.Counter < 4)
            {
                if (Positions.Counter < 4)
                {
                    if ((Positions.Position_xG != Positions.Position_xR) && (Positions.Position_yG != Positions.Position_yR))
                    {
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(Positions.Position_xR, Positions.Position_yR);
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(Positions.Position_xR + j, Positions.Position_yR + i);
                                Console.Write(Positions.Counter);
                            }
                        }
                        Console.SetCursorPosition(42, 36);
                        Console.Write(Positions.Position_xR + " " + Positions.Position_yR + " ");
                        Thread.Sleep(8000); /*8000*/
                        Console.SetCursorPosition(Positions.Position_xR, Positions.Position_yR);
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(Positions.Position_xR + j, Positions.Position_yR + i);
                                Console.Write(" ");
                            }
                        }
                        Positions.Counter++;
                        x = Positions.Position_xR;
                        y = Positions.Position_yR;
                        if (Positions.Counter == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(x, y);
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    Console.SetCursorPosition(x + j, y + i);
                                    Console.Write(Positions.Counter - 1);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(42, 37);
                            break;
                        }
                        else
                        {
                            Positions.Position_xR = rndXRD.Next(43, 116);
                            Positions.Position_yR = rndYRD.Next(13, 32);
                        }
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
                                Console.Write(Positions.Counter - 1);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(42, 37);
                        break;
                    }
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
                            Console.Write(Positions.Counter - 1);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(42, 37);
                    break;
                }
            }
        }
        static void Pole()
        {
            Console.SetCursorPosition(42, 12);
            Console.WriteLine("############################################################################\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          #                                                                          #\r\n                                          ############################################################################");
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rndXR = new Random();
            Random rndYR = new Random();
            Random rndXG = new Random();
            Random rndYG = new Random();
            Console.SetWindowSize(160, 60);
            Pole();
            LockClass GreenKey = new LockClass();
            GreenKey.Position_x = 80;
            GreenKey.Position_y = 31;
            LockClass RedLock = new LockClass();
            RedLock.Position_x = rndXR.Next(43, 116);
            RedLock.Position_y = rndYR.Next(13, 32);
            RedLock.Counter = 1;
            if ((RedLock.Position_x == 80) || (RedLock.Position_x == 81))
            {
                RedLock.Position_x = rndXR.Next(43, 79);
            }
            if ((RedLock.Position_y == 31) || (RedLock.Position_y == 30))
            {
                RedLock.Position_y = rndYR.Next(13, 30);
            }
            PositionsRG GreenKeyANDRedLock = new PositionsRG();
            GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
            GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
            GreenKeyANDRedLock.Position_xR = RedLock.Position_x;
            GreenKeyANDRedLock.Position_yR = RedLock.Position_y;
            GreenKeyANDRedLock.Counter = RedLock.Counter;
            ParameterizedThreadStart draw_red = new ParameterizedThreadStart(Draw_Red);
            Thread draw_redThread = new Thread(draw_red);
            draw_redThread.Start((object)GreenKeyANDRedLock);

            while (GreenKeyANDRedLock.Counter < 4)
            {
                if ((GreenKey.Position_x == GreenKeyANDRedLock.Position_xR) && (GreenKey.Position_y == GreenKeyANDRedLock.Position_yR))
                {
                    break;
                }
                else
                {
                    Thread.Sleep(10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                            Console.Write("K");
                            Console.SetCursorPosition(42, 35);
                            Console.Write(GreenKey.Position_x + " " + GreenKey.Position_y);
                        }
                    }
                    Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    if ((Console.ReadKey().Key == ConsoleKey.UpArrow) && (GreenKey.Position_y > 13))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write(" ");
                            }
                        }
                        GreenKey.Position_y = GreenKey.Position_y - 1;
                        GreenKey.Position_x = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write("K");
                                Console.SetCursorPosition(42, 35);
                                Console.Write(GreenKeyANDRedLock.Position_xG + " " + GreenKeyANDRedLock.Position_yG);
                            }
                        }
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    }
                    else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (GreenKey.Position_x > 43))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write(" ");
                            }
                        }
                        GreenKey.Position_y = GreenKey.Position_y;
                        GreenKey.Position_x = GreenKey.Position_x - 1;
                        GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write("K");
                                Console.SetCursorPosition(42, 35);
                                Console.Write(GreenKeyANDRedLock.Position_xG + " " + GreenKeyANDRedLock.Position_yG);
                            }
                        }
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    }
                    else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (GreenKey.Position_x < 115))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write(" ");
                            }
                        }
                        GreenKey.Position_y = GreenKey.Position_y;
                        GreenKey.Position_x = GreenKey.Position_x + 1;
                        GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write("K");
                                Console.SetCursorPosition(42, 35);
                                Console.Write(GreenKeyANDRedLock.Position_xG + " " + GreenKeyANDRedLock.Position_yG);
                            }
                        }
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    }
                    else if ((Console.ReadKey().Key == ConsoleKey.DownArrow) && (GreenKey.Position_y < 31))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.SetCursorPosition(GreenKey.Position_x + j, GreenKey.Position_y + i);
                                Console.Write(" ");
                            }
                        }
                        GreenKey.Position_y = GreenKey.Position_y + 1;
                        GreenKey.Position_x = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_xG = GreenKey.Position_x;
                        GreenKeyANDRedLock.Position_yG = GreenKey.Position_y;
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Console.CursorLeft = GreenKey.Position_x + j;
                                Console.CursorTop = GreenKey.Position_y + i;
                                Console.Write("K");
                                Console.SetCursorPosition(42, 35);
                                Console.Write(GreenKeyANDRedLock.Position_xG + " " + GreenKeyANDRedLock.Position_yG);
                            }
                        }
                        Console.SetCursorPosition(GreenKey.Position_x, GreenKey.Position_y);
                    }
                }
            }
            draw_redThread.Interrupt();
            //draw_redThread.Abort();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(42, 37);
            if (GreenKeyANDRedLock.Counter < 4)
            {
                Console.WriteLine("Ты победил!");
            }
            else
            {
                Console.WriteLine("Ты проиграл!");
            }
            Console.CursorVisible = true;
        }
    }
}