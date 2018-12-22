using System;
namespace ChineseChess
{
    public class Chess
    {
        public Position chesspos;
        public bool exist;
        public string type;
        public string owner;
        public int index;

        ChessBox chessBox_chess = new ChessBox();

        public Chess(string _type,string _owner,Position initialpos,int _index)//构造
        {
            chesspos.x = initialpos.x;
            chesspos.y = initialpos.y;
            type = _type;
            owner = _owner;
            exist = true;
            index = _index;
        }

        public bool AbleToMove(Position endpos)//beginpos = chesspos
        {
            switch (type)
            {
                case "将":
                    return AbleToMoveShuai(endpos);
                case "帅":
                    return AbleToMoveShuai(endpos); //后面的都没有break
                case "车":
                    return AbleToMoveChe(endpos);//x,y代表想去的地方
                //case "马":
                //    {
                //        return AbleToMoveMa(endpos);
                //    }
                case "仕":
                    return AbleToMoveShi(endpos);
                case "士":
                    return AbleToMoveShi(endpos);
                case "象":
                    return AbleToMoveXiang(endpos);
                case "相":
                    return AbleToMoveXiang(endpos);
                case "卒":
                    return AbleToMoveBing(endpos);
                case "兵":
                    return AbleToMoveBing(endpos);
                //case "炮":
                    //{
                    //    return AbleToMovePao(endpos);
                    //}
            }
            return false;
        }

        public bool AbleToMoveShuai(Position endpos)
        {
            //获得将走的格数
            //(x,y)表示将走到的位置
            int xoff = Math.Abs(endpos.x - chesspos.x); //abs()函数
            int yoff = Math.Abs(endpos.y - chesspos.y);

            if (!((xoff == 7 || yoff == 3) && xoff*yoff == 0))
            {
                return false;
            }
            //判断将是否出了九宫
            //红色的将和黑色的将的x坐标的范围都是3<=x<=5
            if (endpos.x < 21 || endpos.x > 35)
            {
                return false;
            }
            //如果玩家的棋子是红棋
            if (owner == "RED")
            {
                //判断帅是否出了九宫
                if (endpos.y < 0 || endpos.y > 6)
                {
                    return false;
                }
            }
            else//判断黑色的将的范围
            {
                //判断将是否出了九宫
                if (endpos.y > 27 || endpos.y < 21)
                {
                    return false;
                }
            }
            return true;
        }

        public bool AbleToMoveChe(Position endpos)
        {
            if (chesspos.x != endpos.x && chesspos.y != endpos.y)
                return false;
            if (chessBox_chess.GetCountChess(chesspos, endpos, "RED") + chessBox_chess.GetCountChess(chesspos, endpos, "BLACK") == 0)
                return true;
            return false;
        }

        public bool AbleToMoveShi(Position endpos)
        {
            int xoff = Math.Abs(endpos.x - chesspos.x); //abs()函数
            int yoff = Math.Abs(endpos.y - chesspos.y);
           
            if (!(xoff == 7 && yoff == 3))
            {
                return false;
            }
            if (endpos.x < 21 || endpos.x > 35)
            {
                return false;
            }
            //如果玩家的棋子是红棋
            if (owner == "RED")
            {
                if (endpos.y < 0 || endpos.y > 6)
                {
                    return false;
                }
            }
            else
            {
                if (endpos.y > 27 || endpos.y < 21)
                {
                    return false;
                }
            }
            return true;
        }

        public bool AbleToMoveXiang(Position endpos)
        {
            int xoff = Math.Abs(endpos.x - chesspos.x); 
            int yoff = Math.Abs(endpos.y - chesspos.y);
            Position _position = new Position((endpos.x + chesspos.x) / 2, (endpos.y + chesspos.y) / 2);
            if (!(xoff == 14 && yoff == 6))
            {
                return false;
            }

            if (chessBox_chess.FindChess(_position, "RED") + chessBox_chess.FindChess(_position, "RED") > -1)
                return false;
            if (owner == "RED")
            {
                if (endpos.y < 0 || endpos.y > 12)
                {
                    return false;
                }
            }
            else
            {
                if (endpos.y > 27 || endpos.y < 15)
                {
                    return false;
                }
            }
            return true;
        }

        public bool AbleToMoveBing(Position endpos)
        {
            if(owner == "RED")
            {
                if(chesspos.y <= 12)
                {
                    if (!(endpos.x == chesspos.x && endpos.y - chesspos.y == 3))
                        return false;
                }
                else
                {
                    if (endpos.y < chesspos.y)
                        return false;
                    int xoff = Math.Abs(endpos.x - chesspos.x);
                    int yoff = Math.Abs(endpos.y - chesspos.y);
                    if (!((xoff == 7 || xoff == 0) && (yoff == 3 || yoff == 0) && xoff * yoff == 0))
                        return false;
                }
            }
            if(owner == "BLACK")
            {
                if(chesspos.y >= 15)
                {
                    if (!(endpos.x == chesspos.x && endpos.y - chesspos.y == -3))
                        return false;
                }
                else
                {
                    if (endpos.y > chesspos.y)
                        return false;
                    int xoff = Math.Abs(endpos.x - chesspos.x);
                    int yoff = Math.Abs(endpos.y - chesspos.y);
                    if (!((xoff == 7 || xoff == 0) && (yoff == 3 || yoff == 0) && xoff * yoff == 0))
                        return false;
                }
            }
            return true;
        }

        public void ChessMove(Position position)
        {
            chesspos.x = position.x;
            chesspos.y = position.y;
        }
    }
}
