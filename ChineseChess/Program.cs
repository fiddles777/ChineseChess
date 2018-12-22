using System;

namespace ChineseChess
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string GameOrder = "RED";//先手:RED
            Console.SetWindowSize(2 * Console.WindowWidth, 2 * Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
            Pos pos = new Pos();
            MainBox mainBox = new MainBox();
            ChessBox chessBox = new ChessBox();
            ChessBox chessBoxtest = new ChessBox();
            Position position = new Position(10, 10);
            position.BoxToConsole();
            Console.Write(position.x);

            //添加棋子RED
            chessBox.AddChess("车", "RED", new Position(0, 0));
            chessBox.AddChess("车", "RED", new Position(8, 0));
            chessBox.AddChess("马", "RED", new Position(1, 0));
            chessBox.AddChess("马", "RED", new Position(7, 0));
            chessBox.AddChess("相", "RED", new Position(2, 0));
            chessBox.AddChess("相", "RED", new Position(6, 0));
            chessBox.AddChess("仕", "RED", new Position(3, 0));
            chessBox.AddChess("仕", "RED", new Position(5, 0));
            chessBox.AddChess("帅", "RED", new Position(4, 0));
            chessBox.AddChess("炮", "RED", new Position(1, 2));
            chessBox.AddChess("炮", "RED", new Position(7, 2));
            chessBox.AddChess("兵", "RED", new Position(0, 3));
            chessBox.AddChess("兵", "RED", new Position(2, 3));
            chessBox.AddChess("兵", "RED", new Position(4, 3));
            chessBox.AddChess("兵", "RED", new Position(6, 3));
            chessBox.AddChess("兵", "RED", new Position(8, 3));
            //添加棋子BLACK
            chessBox.AddChess("车", "BLACK", new Position(0, 9));
            chessBox.AddChess("车", "BLACK", new Position(8, 9));
            chessBox.AddChess("马", "BLACK", new Position(1, 9));
            chessBox.AddChess("马", "BLACK", new Position(7, 9));
            chessBox.AddChess("相", "BLACK", new Position(2, 9));
            chessBox.AddChess("相", "BLACK", new Position(6, 9));
            chessBox.AddChess("仕", "BLACK", new Position(3, 9));
            chessBox.AddChess("仕", "BLACK", new Position(5, 9));
            chessBox.AddChess("帅", "BLACK", new Position(4, 9));
            chessBox.AddChess("炮", "BLACK", new Position(1, 7));
            chessBox.AddChess("炮", "BLACK", new Position(7, 7));
            chessBox.AddChess("卒", "BLACK", new Position(0, 6));
            chessBox.AddChess("卒", "BLACK", new Position(2, 6));
            chessBox.AddChess("卒", "BLACK", new Position(4, 6));
            chessBox.AddChess("卒", "BLACK", new Position(6, 6));
            chessBox.AddChess("卒", "BLACK", new Position(8, 6));
            while (GameOrder=="RED"||GameOrder=="BLACK"||GameOrder=="REDCHOSE"||GameOrder=="BLACKCHOSE")
            {
                ConsoleKeyInfo consolekeyinfo = Console.ReadKey(true);
                if ((GameOrder=="RED"||GameOrder=="BLACK")&&consolekeyinfo.Key == ConsoleKey.Enter)
                {
                    if(chessBox.FindChess(pos.currentpos,GameOrder)>=0)
                    {
                        pos.ChosePos();
                        chessBox.GetChosedIndex(chessBox.FindChess(pos.currentpos, GameOrder));
                        GameOrder = GameOrder + "CHOSE";
                    }
                }
                else if((GameOrder == "REDCHOSE" || GameOrder == "BLACKCHOSE") && consolekeyinfo.Key == ConsoleKey.Enter)
                {
                    if(pos.currentpos.x==pos.chosedpos.x && pos.currentpos.y==pos.chosedpos.y)
                    {
                        pos.ischosed = false;
                        if (GameOrder == "BLACKCHOSE")
                            GameOrder = "BLACK";
                        else
                            GameOrder = "RED";
                    }
                    else if(pos.currentpos.IsConsoleValid() == true)//todo
                    {
                        if(chessBox.AbleToMove(pos.currentpos))
                        {
                            if (GameOrder == "REDCHOSE")
                            {
                                if (chessBox.FindChess(pos.currentpos, "BLACK") > -1 || chessBox.FindChess(pos.currentpos, "RED")<0)
                                {
                                    if (chessBox.FindChess(pos.currentpos, "BLACK") > -1)
                                        chessBox.DelChess(chessBox.FindChess(pos.currentpos, "BLACK"));
                                    pos.ischosed = false;
                                    chessBox.ChessMove(chessBox.GetChosedIndex(), pos.currentpos);

                                    if (GameOrder == "REDCHOSE")
                                        GameOrder = "BLACK";
                                    else
                                        GameOrder = "RED";
                                }
                            }
                            else
                            {
                                if (chessBox.FindChess(pos.currentpos, "RED") > -1 || chessBox.FindChess(pos.currentpos, "BLACK")<0)
                                {
                                    if(chessBox.FindChess(pos.currentpos, "RED") > -1)
                                        chessBox.DelChess(chessBox.FindChess(pos.currentpos, "RED"));
                                    pos.ischosed = false;
                                    chessBox.ChessMove(chessBox.GetChosedIndex(), pos.currentpos);

                                    if (GameOrder == "REDCHOSE")
                                        GameOrder = "BLACK";
                                    else
                                        GameOrder = "RED";
                                }
                            }
                        }
                    }
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
                chessBox.ChessPlot();
                pos.PosPlot();
                chessBox.PlotChessWord();
                pos.ChosedPosDoublePlot();

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(62, 20);
                Console.Write("GameCondition:");
                Console.SetCursorPosition(64, 22);
                Console.Write(GameOrder);
            }

            if (GameOrder == "REDWIN" || GameOrder == "BLACKWIN") 
            {
                Console.Clear();
                Console.Write(GameOrder);
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
            x = x * 7;
            y = y * 3;
            return true;
        }
        public bool ConsoleToBox()//控制台坐标转到棋盘坐标
        {
            if ((x ) % 7 != 0 || (y ) % 3 != 0)
                return false;
            x = (x ) / 7;
            y = (y ) / 3;
            return true;
        }
        public bool IsConsoleValid()
        {
            if (x % 7 == 0 && y % 3 == 0)
                return true;
            else
                return false;
        }
    }
}