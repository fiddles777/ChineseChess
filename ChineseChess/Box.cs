using System;
namespace ChineseChess
{
    public class ChessBox//棋子
    {
        public static Chess[,] box = new Chess[9, 11];
    }

    public class MainBox//棋盘
    {
        public int[,] box = new int[19, 23];

        public void PrintMainBox()
        {

        }
    }


    public class Pos //选择框
    {
        private int pos_x;
        private int pos_y;

        private int chosed_x;
        private int chosed_y;

        private bool ischosed;
        public Pos()//构造
        {
            pos_x = 20;
            pos_y = 20;
            ischosed = false;
        }

        public int PosMove(int direction)//移动选择框位置
        {
            if (direction < 1 || direction > 4)
                return -1;
            switch (direction)
            {
                case 1:
                    if (pos_x > 0)
                        pos_x -= 1;
                    break;
                case 2:
                    if (pos_x < 60)
                        pos_x += 1;
                    break;
                case 3:
                    if (pos_y > 0)
                        pos_y -= 1;
                    break;
                case 4:
                    if (pos_y < 25)
                        pos_y += 1;
                    break;
            }
            return direction;
        }

        public void PosPlot()//选中框绘图
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Console.SetCursorPosition(pos_x + 0, pos_y + 0);
            Console.Write("┏");
            Console.SetCursorPosition(pos_x + 1, pos_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(pos_x + 2, pos_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(pos_x + 3, pos_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(pos_x +4, pos_y +0);
            Console.Write("┓");
            Console.SetCursorPosition(pos_x +0, pos_y +1);
            Console.Write("┃");
            Console.SetCursorPosition(pos_x +4, pos_y +1);
            Console.Write("┃");
            Console.SetCursorPosition(pos_x +0, pos_y +2);
            Console.Write("┗");
            Console.SetCursorPosition(pos_x +4, pos_y +2);
            Console.Write("┛");
            Console.SetCursorPosition(pos_x +1, pos_y +2);
            Console.Write("━");
            Console.SetCursorPosition(pos_x +2, pos_y +2);
            Console.Write("━");
            Console.SetCursorPosition(pos_x +3, pos_y +2);
            Console.Write("━");
        }

        public void ChosedPosPlot()//选中框绘图
        {
            if (ischosed == false)
                return;
            Console.Write("true");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;
            Console.SetCursorPosition(chosed_x + 0, chosed_y + 0);
            Console.Write("┏");
            Console.SetCursorPosition(chosed_x + 1, chosed_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosed_x + 2, chosed_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosed_x + 3, chosed_y + 0);
            Console.Write("━");
            Console.SetCursorPosition(chosed_x + 4, chosed_y + 0);
            Console.Write("┓");
            Console.SetCursorPosition(chosed_x + 0, chosed_y + 1);
            Console.Write("┃");
            Console.SetCursorPosition(chosed_x + 4, chosed_y + 1);
            Console.Write("┃");
            Console.SetCursorPosition(chosed_x + 0, chosed_y + 2);
            Console.Write("┗");
            Console.SetCursorPosition(chosed_x + 4, chosed_y + 2);
            Console.Write("┛");
            Console.SetCursorPosition(chosed_x + 1, chosed_y + 2);
            Console.Write("━");
            Console.SetCursorPosition(chosed_x + 2, chosed_y + 2);
            Console.Write("━");
            Console.SetCursorPosition(chosed_x + 3, chosed_y + 2);
            Console.Write("━");
        }

        public void PosGet(int[] pos)//获得当前位置
        {
            
        }

        public void ChosePos()
        {
            chosed_x = pos_x;
            chosed_y = pos_y;
            if (ischosed == true)
                ischosed = false;
            else
                ischosed = true;
        }
    }
}
