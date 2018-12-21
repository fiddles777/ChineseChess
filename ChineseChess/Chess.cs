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
            //switch(type)
            //{
            //case "兵"||"卒":
            //{

            //}

            //}
            return true;
        }
        public void ChessMove(Position position)
        {
            chesspos.x = position.x;
            chesspos.y = position.y;
        }
    }
}
