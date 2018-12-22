```c#
using System;
namespace ChineseChess
{
    public class Chess
    {
        public Position chesspos; //棋子所在位置
        public bool exist; //棋子是否存在
        public string type; //棋子的种类
        public string owner; //红黑持有者
        public int index; //每个棋子的索引号
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
            Chess selected = getChess(index);//所选的棋子
            switch(type)
            {
                case "帅":{
                	AbleToMoveShuai(index, killid, x, y); //后面的都没有break   
				}
                case "车":{
                    AbleToMoveChe(index, x, y);//x,y代表想去的地方
                }
                case "马":{
                    AbleToMoveMa(index, x, y);
                }    
                case "士":{
                    AbleToMoveShi(index, x, y);
                }
                case "相":{
                    AbleToMoveXiang(index, x, y);
                }   
                case "兵":{
                    AbleToMoveBing(index, x, y);
                }
                case "炮":{
                    AbleToMovePao(index, x, y);
                }    
            }
            return true;
        }
        public int getChessCount(int curx, int cury, int x, int y){
            int ret = 0;//记录两点之间的棋子的个数
            //(curx,cury)和(x,y)不在同一条直线上
            if(curx != x && cury != y)
            {
                return -1;
            }
            //(curx,cury)和(x,y)在同一点上
            if(curx == x && cury == y)
            {
                return -1;
            }
            //两点在同一条竖线上
            if(curx == x)
            {
                //min为两个点中y坐标最小的点的y坐标
                int min = cury < y ? cury : y;
                //max为两个点中y坐标最大的点的y坐标
                int max = cury> y ? cury : y;
                //查找同一条竖线上两点之间的棋子数
                for(int yy=min+1; yy<max; yy++)
                {
                    //当两点之间有棋子的时候
                    if(haveChess(x,yy) != -1)
                    {
                        ++ret;//棋子数加1
                    }
                }
            }
            else//两点在同一条横线上yo == y
            {
                //min为两个点中x坐标最小的点的x坐标
                int min = curx < x ? curx : x;
                //max为两个点中x坐标最大的点的x坐标
                int max = curx > x ? curx : x;
                //查找同一条竖线上两点之间的棋子数
                for(int xx=min+1; xx<max; xx++)
                {
                    //当两点之间有棋子的时候
                    if(haveChess(xx,y) != -1)
                    {
                        ++ret;//棋子数加1
                    }
                }
            }
            //返回两点之间的棋子数
            return ret;
        }
        //炮的走棋规则
        public bool AbleToMovePao(int index, int killid, int x, int y)
        {
            //通过棋子的ID得到棋子
            Chess selected = getChess(index);
            //获得炮走棋前的位置
            int currentx = selected.chesspos.x;
            int currenty = selected.chesspos.y;
            //当触摸点上有一个棋子
            //而且两点之间只有一个棋子的时候
            //炮吃掉触摸点上的棋子
            if(killid != -1 && this->getChessCount(xo,yo,x,y) == 1)//获取之间的棋子数目可以隔山大牛
            {
                return true;
            }
            if(killid == -1 && this->getChessCount(xo, yo, x, y) == 0)
            {
                return true;
            }
            return false;
        }
        //兵的走棋规则
        public bool AbleToMoveBing(int index, int x, int y)
        {
            //1、一次走一格
            //2、前进一格后不能后退
            //3、过河后才可以左右移动
            Chess selected = getChess(index);
            //获得将当前的位置
            int currentx=selected.chesspos.x;
            int currenty=selected.chesspos.y;
            //获得兵走的格数
            //(x,y)表示将走到的位置
            int xoff = abs(currentx - x);
            int yoff = abs(currenty - y);
            int d = xoff*10 + yoff;
            //走将的时候有两种情况
            //xoff=1, yoff=0：将向左或向右
            //xoff=0, yoff=1：将向前或向后
            if(d != 1 && d != 10)
            {
                return false;
            }
            //如果玩家的棋子是红棋
            if(_redSide == selected.owner)
            {
                //限制红色的兵不能后退
                if(y < currenty)
                {
                    return false;
                }
                //红色的兵没有过河不能左右移动
                if(currenty <= 4 && y == currenty)
                {
                    return false;
                }
            }
            else//判断黑色的兵
            {
                //限制黑色的兵不能后退
                if(y > currenty)
                {
                    return false;
                }
                //黑色的兵没有过河不能左右移动
                if(currenty >= 5 && y == currenty)
                {
                    return false;
                }
            }
            return true;
        }

        //相的走棋规则
        public bool AbleToMoveXiang(int index, int x, int y)
        {
            //每走一次x移动2格,y移动2格
            //不能过河
            //通过棋子的ID得到棋子
            Chess selected = getChess(index);
            //获得相走棋前的位置
            int currentx=selected.chesspos.x;
            int currenty=selected.chesspos.y;
            //获得相走的格数
            //(x,y)表示将走到的位置
            int xoff = abs(currentx - x);
            int yoff = abs(currenty - y);
            int d = xoff*10 + yoff;
            //相每一次x方向走2格子,y方向走2格
            //当走的格数大于2格时
            //返回false
            if(d != 22)
            {
                return false;
            }
            //计算两个坐标的中点坐标
            int xm = (currentx + x) / 2;
            int ym = (currenty + y) / 2;
            //得到(xm,ym)上的棋子
            int id = haveChess(xm, ym);
            //当(xm,ym)上有棋子的时候
            if(id != -1)
            {
                //不能走相
                return false;
            }
            //限制相不能过河
            //如果玩家的棋子是红棋
            if(_redSide == selected.owner)
            {
                //判断相是否过了河
                if(y > 4)
                {
                    return false;
                }
            }
            else//判断黑色的相的范围
            {
                //判断相是否过了河
                if(y < 5)
                {
                    return false;
                }
            }
            return true;
        }
        public bool AbleToMoveShi(int index, int x, int y){
            //士的走棋规则：
            //1、一次走一格
            //2、不能出九宫格
            //3、斜着走
            Chess selected = getChess(index);
            
            //获得走棋前的位置
            int currentx=selected.chesspos.x;
            int currenty=selected.chesspos.y;
            
            //获得走的格数
            //(x,y)表示将走到的位置
            int xoff = abs(currentx - x);
            int yoff = abs(currenty - y);
            int d = xoff*10 + yoff;
            //士每走一步x方向走1格,y方向走1格
            //当走的格数大于1格时
            //返回false
            if(d != 11)
            {
                return false;
            }
            //判断士是否出了九宫
            //红色的士和黑色的士的x坐标的范围都是3<=x<=5
            if(x<3 || x>5)
            {
                return false;
            }
            //如果玩家的棋子是红棋
            if(_redSide == selected.owner)
            {
                //判断士是否出了九宫
                if(y<0 || y>2)
                {
                    return false;
                }
            }
            else//判断黑色的士的范围
            {
                //判断士是否出了九宫
                if(y>9 || y<7)
                {
                    return false;
                }
            }
            return true;
        }
        public bool AbleToMoveMa(int index, int x, int y){
            Chess selected=getChess(index);
            int currentx=selected.chesspos.x;
            int currenty=selected.chesspos.y;
            //获得马走的格数
            //(x,y)表示马走到的位置
            //马有四种情况情况：
            //马先向前或向后走1步，再向左或向右走2步
            //马先向左或向右走1不，再向前或向后走2步
            int xoff = abs(currentx-x);
            int yoff = abs(currenty-y);
            int d = xoff*10 + yoff;
            if(d != 12 && d != 21)
            {
                return false;
            }
            int xm, ym;//记录绊马腿的点的坐标
            if(d == 12)//当马走的是第一种情况
            {
                xm = xo;//绑脚点的x坐标为走棋前马的x坐标
                ym = (yo + y) / 2;//绑脚点的y坐标为走棋前马的y坐标和走棋后马的y坐标的中点坐标
            }
            else//当马走的是第二种情况
            {
                xm = (xo + x) / 2;//绑脚点的x坐标为走棋前马的x坐标和走棋后马的x坐标的中点坐标
                ym = yo;//绑脚点的y坐标为走棋前马的y坐标
            }
            //当绑脚点有棋子时,不能走
            if(haveChess(xm, ym) != -1)
            {
                return false;
            }
            return true;
        }
        public bool AbleToMoveChe(int index,int x,int y){
            Chess selected=getChess(index);
            int currentx=selected.chesspos.x;
            int currenty=selected.chesspos.y;
            if(haveChess(currentx,currenty, x, y)){//如果车的移动轨迹上有棋子那么不能走
            	return false;
            }
            return true;
        }
        public bool AbleToMoveShuai(int index,int killid,int x,int y){
            Chess killed = getChess(killid);//所选的棋子
            //1、一次走一格
            //2、不能出九宫格
            //撞脸杀
            if(killed.type == "帅")
            {
                return AbleToMoveChe(index, x, y);
            }
            //通过棋子的ID得到棋子
            Chess selected = getChess(index);
            //获得将当前的位置
            int currentx = selected.chesspos.x;
            int currenty = selected.chesspos.y;
            //获得将走的格数
            //(x,y)表示将走到的位置
            int xoff = abs(currentx - x); //abs()函数
            int yoff = abs(currenty - y);
            int d = xoff*10 + yoff;
            //有四种情况
            //xoff=1, yoff=0：将向左或向右
            //xoff=0, yoff=1：将向前或向后
            if(d != 1 && d != 10)
            {
                return false;
            }
            //判断将是否出了九宫
            //红色的将和黑色的将的x坐标的范围都是3<=x<=5
            if(x<3 || x>5)
            {
                return false;
            }
            //如果玩家的棋子是红棋
            if(_redSide == selected.owner)
            {
                //判断帅是否出了九宫
                if(y<0 || y>2)
                {
                    return false;
                }
            }
            else//判断黑色的将的范围
            {
                //判断将是否出了九宫
                if(y>9 || y<7)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
```

