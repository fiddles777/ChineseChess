using System;

namespace ChineseChess
{
    class MainClass:Chess
    {
        
        public static void Main(string[] args)
        {
            Pos pos = new Pos();
            pos.PosPlot();
            while(true)
            {
                ConsoleKeyInfo consolekeyinfo = Console.ReadKey(true);
                Console.Write(consolekeyinfo.Key);
                if(consolekeyinfo.Key == ConsoleKey.Enter)
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
                else if(consolekeyinfo.Key == ConsoleKey.DownArrow)
                {
                    pos.PosMove(4);
                }
                Console.Clear();
                pos.ChosedPosPlot();
                pos.PosPlot();
            }
        }
    }
}
