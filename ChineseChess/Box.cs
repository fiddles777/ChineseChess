using System;
using System.Collections.Generic;
namespace ChineseChess
{
    public class ChessBox//棋子
    {
        public int ChosedIndex;
        static List<Chess> ChessList = new List<Chess>();

        public int AddChess(string _type, string _owner, Position initialpos)//添加棋子
        {
            initialpos.BoxToConsole();
            Console.Write(initialpos.x);
            Console.Write(initialpos.y);
            ChessList.Add(new Chess(_type, _owner, initialpos, ChessList.Count));
            return ChessList.Count;
        }

        public int GetCountChess(Position startpos,Position endpos,string _owner)//不考虑startpos处的棋子，不考虑endpos处的棋子，获得路径上的棋子数量
        {
            int count = 0;
            if(startpos.x == endpos.x)
            {
                for (int i = 0; i <= ChessList.Count;i++)
                {
                    if (ChessList[i].exist == false)
                        continue;
                    if (ChessList[i].owner != _owner)
                        continue;
                    if(ChessList[i].chesspos.x == startpos.x&&
                       (startpos.y<ChessList[i].chesspos.y&&ChessList[i].chesspos.y<endpos.y||endpos.y < ChessList[i].chesspos.y && ChessList[i].chesspos.y < startpos.y))
                    {
                        count += 1;
                    }
                }
            }
            else if (startpos.y == endpos.y)
            {
                for (int i = 0; i <= ChessList.Count; i++)
                {
                    if (ChessList[i].exist == false)
                        continue;
                    if (ChessList[i].owner != _owner)
                        continue;
                    if (ChessList[i].chesspos.y == startpos.y &&
                        ((startpos.x < ChessList[i].chesspos.x && ChessList[i].chesspos.x < endpos.x )|| (endpos.x < ChessList[i].chesspos.x && ChessList[i].chesspos.x < startpos.x)))
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        public void DelChess(int _index)//删除棋子
        {
            //ChessList.RemoveAt(_index);
            ChessList[_index].exist = false;
        }

        public int FindChess(Position _position,string _owner)//查找棋子
        {
            for (int i = 0; i < ChessList.Count;i++)
            {
                if (ChessList[i].exist == false)
                    continue;
                else if (ChessList[i].chesspos.x == _position.x && ChessList[i].chesspos.y == _position.y && ChessList[i].owner == _owner)
                    return i;
            }
            return -1;
        }

        public void ChessMove(int _index,Position position)
        {
            ChessList[_index].ChessMove(position);
        }

        public void ChessPlot()//绘制所有棋子
        {
            for (int i = 0; i < ChessList.Count;i++)
            {
                if (ChessList[i].exist == false)
                    continue;
                if (ChessList[i].owner == "RED")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (ChessList[i].owner == "BLACK")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(ChessList[i].chesspos.x + 0, ChessList[i].chesspos.y + 0);
                Console.Write("┏");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 1, ChessList[i].chesspos.y + 0);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 2, ChessList[i].chesspos.y + 0);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 3, ChessList[i].chesspos.y + 0);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 4, ChessList[i].chesspos.y + 0);
                Console.Write("┓");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 0, ChessList[i].chesspos.y + 1);
                Console.Write("┃");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 4, ChessList[i].chesspos.y + 1);
                Console.Write("┃");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 0, ChessList[i].chesspos.y + 2);
                Console.Write("┗");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 4, ChessList[i].chesspos.y + 2);
                Console.Write("┛");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 1, ChessList[i].chesspos.y + 2);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 2, ChessList[i].chesspos.y + 2);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 3, ChessList[i].chesspos.y + 2);
                Console.Write("━");
                Console.SetCursorPosition(ChessList[i].chesspos.x + 1, ChessList[i].chesspos.y + 1);
                Console.Write(" " + ChessList[i].type);
            }
        }

        public void PlotChessWord()
        {
            for (int i = 0; i < ChessList.Count; i++)
            {
                if (ChessList[i].exist == false)
                    continue;
                if (ChessList[i].owner == "RED")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (ChessList[i].owner == "BLACK")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(ChessList[i].chesspos.x + 1, ChessList[i].chesspos.y + 1);
                Console.Write(" " + ChessList[i].type);
            }
        }
    }

    public class MainBox//棋盘
    {
        public void PrintMainBox()//绘制棋盘
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 2; i < 59;i+=1)
            {
                for (int j = 1; j < 29;j+=3)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("━");
                }
            }

            for (int i = 2; i < 59; i += 7)
            {
                for (int j = 1; j < 29;j++)
                {
                    Console.SetCursorPosition(i, j);

                    if((i+5)%7==0&&(j+2)%3==0)
                    {
                        if(i==2&&j==1)
                        {
                            Console.Write("┏");
                        }
                        else if(i==58&&j==1)
                        {
                            Console.Write("┓");
                        }
                        else if(i==58&&j==28)
                        {
                            Console.Write("┛");
                        }
                        else if(i==2&&j==28)
                        {
                            Console.Write("┗");
                        }
                        else if (j == 16)
                        {
                            if (i == 2)
                                Console.Write("┣");
                            else if (i == 58)
                                Console.Write("┫");
                            else
                                Console.Write("┳");
                        }
                        else if(j==1)
                        {
                            Console.Write("┳");
                        }
                        else if(j==13)
                        {
                            if (i == 2)
                                Console.Write("┣");
                            else if (i == 58)
                                Console.Write("┫");
                            else
                                Console.Write("┻");
                        }
                        else if(j==28)
                        {
                            Console.Write("┻");
                        }
                        else if(i==58)
                        {
                            Console.Write("┫");
                        }
                        else if(i==2)
                        {
                            Console.Write("┣");
                        }
                        else
                            Console.Write("╋");
                    }
                    else if(!(i!=2&&i!=58&&(j==14||j==15)))
                    {
                        Console.Write("┃");
                    }
                }
            }
            Console.SetCursorPosition(20, 14);
            Console.Write("楚              汉");
            Console.SetCursorPosition(22, 15);
            Console.Write("河              界");
        }
    }


    public class Pos //选择框
    {
        public Position currentpos;
        public Position chosedpos;
        public bool ischosed;

        public Pos()//构造
        {
            currentpos.x = 0;
            currentpos.y = 0;
            ischosed = false;
        }

        public int PosMove(int direction)//移动选择框位置
        {
            if (direction < 1 || direction > 4)
                return -1;
            switch (direction)
            {
                case 1:
                    if (currentpos.x> 0)
                        currentpos.x -= 1;
                    break;
                case 2:
                    if (currentpos.x < 60)
                        currentpos.x += 1;
                    break;
                case 3:
                    if (currentpos.y > 0)
                        currentpos.y -= 1;
                    break;
                case 4:
                    if (currentpos.y < 25)
                        currentpos.y += 1;
                    break;
            }
            return direction;
        }

        public void PosPlot()//选中框绘图
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            Console.SetCursorPosition(currentpos.x + 0, currentpos.y + 0);
            Console.Write("┏");
            Console.SetCursorPosition(currentpos.x + 1, currentpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(currentpos.x + 2, currentpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(currentpos.x + 3, currentpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(currentpos.x +4, currentpos.y +0);
            Console.Write("┓");
            Console.SetCursorPosition(currentpos.x +0, currentpos.y +1);
            Console.Write("┃");
            Console.SetCursorPosition(currentpos.x +4, currentpos.y +1);
            Console.Write("┃");
            Console.SetCursorPosition(currentpos.x +0, currentpos.y +2);
            Console.Write("┗");
            Console.SetCursorPosition(currentpos.x +4, currentpos.y +2);
            Console.Write("┛");
            Console.SetCursorPosition(currentpos.x +1, currentpos.y +2);
            Console.Write("━");
            Console.SetCursorPosition(currentpos.x +2, currentpos.y +2);
            Console.Write("━");
            Console.SetCursorPosition(currentpos.x +3, currentpos.y +2);
            Console.Write("━");
        }

        public void ChosedPosPlot()//选中框绘图
        {
            if (ischosed == false)
                return;
            Console.Write("↖");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = false;
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 0);
            Console.Write("┏");
            Console.SetCursorPosition(chosedpos.x + 1, chosedpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosedpos.x + 2, chosedpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosedpos.x + 3, chosedpos.y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 0);
            Console.Write("┓");
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 1);
            Console.Write("┃");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 1);
            Console.Write("┃");
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 2);
            Console.Write("┗");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 2);
            Console.Write("┛");
            Console.SetCursorPosition(chosedpos.x + 1, chosedpos.y + 2);
            Console.Write("━");
            Console.SetCursorPosition(chosedpos.x + 2, chosedpos.y + 2);
            Console.Write("━");
            Console.SetCursorPosition(chosedpos.x + 3, chosedpos.y + 2);
            Console.Write("━");
        }

        public void ChosedPosDoublePlot()//选中框绘图双线
        {
            if (ischosed == false)
                return;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = false;
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 0);
            Console.Write("╔");
            Console.SetCursorPosition(chosedpos.x + 1, chosedpos.y + 0);
            Console.Write("═");
            Console.SetCursorPosition(chosedpos.x + 2, chosedpos.y + 0);
            Console.Write("═");
            Console.SetCursorPosition(chosedpos.x + 3, chosedpos.y + 0);
            Console.Write("═");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 0);
            Console.Write("╗");
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 1);
            Console.Write("║");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 1);
            Console.Write("║");
            Console.SetCursorPosition(chosedpos.x + 0, chosedpos.y + 2);
            Console.Write("╚");
            Console.SetCursorPosition(chosedpos.x + 4, chosedpos.y + 2);
            Console.Write("╝");
            Console.SetCursorPosition(chosedpos.x + 1, chosedpos.y + 2);
            Console.Write("═");
            Console.SetCursorPosition(chosedpos.x + 2, chosedpos.y + 2);
            Console.Write("═");
            Console.SetCursorPosition(chosedpos.x + 3, chosedpos.y + 2);
            Console.Write("═");
        }

        public void ChosePos()//选择框选中
        {
            chosedpos.x = currentpos.x;
            chosedpos.y = currentpos.y;
            if (ischosed == true)
                ischosed = false;
            else
                ischosed = true;
        }
    }
}
