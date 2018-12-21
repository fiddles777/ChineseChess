using System;

namespace ChineseChess
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(2 * Console.WindowWidth, 2 * Console.WindowHeight);
            Console.Clear();
            Pos pos = new Pos();
            MainBox mainBox = new MainBox();
            ChessBox chessBox = new ChessBox();
            Position position = new Position(10, 10);
            position.BoxToConsole();
            Console.Write(position.x);
            while (true)
            {
                //Console.
                ConsoleKeyInfo consolekeyinfo = Console.ReadKey(true);
                if (consolekeyinfo.Key == ConsoleKey.Enter)
                {
                    pos.ChosePos();
                }
                else if (consolekeyinfo.Key == ConsoleKey.LeftArrow)
                {
                    pos.PosMove(1);
                }
                else if (consolekeyinfo.Key == ConsoleKey.RightArrow)
                {
                    pos.PosMove(2);
                }
                else if (consolekeyinfo.Key == ConsoleKey.UpArrow)
                {
                    pos.PosMove(3);
                }
                else if (consolekeyinfo.Key == ConsoleKey.DownArrow)
                {
                    pos.PosMove(4);
                }
                Console.Clear();
                mainBox.PrintMainBox();
                pos.PosPlot();
                pos.ChosedPosDoublePlot();
            }
        }
    }

    public struct Position
    {
        public int x;
        public int y;
        public Position(int _x, int _y)//构造
        {
            x = _x;
            y = _y;
        }
        public bool BoxToConsole()//从棋盘坐标转到控制台坐标
        {
            if (x < 0 || x > 8)
                return false;
            if (y < 0 || y > 9)
                return false;
            x = x * 7 + 5;
            y = y * 3 + 2;
            return true;
        }
        public bool ConsoleToBox()//控制台坐标转到棋盘坐标
        {
            if ((x - 2) % 7 != 0 || (y - 1) % 3 != 0)
                return false;
            x = (x - 2) / 7;
            y = (y - 1) / 3;
            return true;
        }
    }
}