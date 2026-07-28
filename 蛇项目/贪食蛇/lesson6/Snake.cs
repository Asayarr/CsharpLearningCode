using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{   
    /// <summary>
    /// 蛇的移动方向
    /// </summary>
    enum E_MoveDir 
    { 
        /// <summary>
        /// 上
        /// </summary>
        Up,
        /// <summary>
        /// 下
        /// </summary>
        Down,
        /// <summary>
        /// 左
        /// </summary>
        Left,
        /// <summary>
        /// 右
        /// </summary>
        Right,

    }
    class Snake:IDraw
    {
        SnakeBody[] bodys;
        //蛇身体长度
        int nowLength;
        //当前移动方向
        E_MoveDir moveDir;
        public Snake(int x, int y) 
        {
            bodys = new SnakeBody[200];

            bodys[0] = new SnakeBody(E_SnakeBodyType.Head, x, y);
            nowLength = 1;


            moveDir = E_MoveDir.Right;

        }
        public void Draw() 
        {
            for (int i = 0; i < nowLength; i++)
            {
                bodys[i].Draw();
            
            
            }
        }

        public void Move() 
        {
            SnakeBody lastbody = bodys[nowLength - 1];
            Console.SetCursorPosition(lastbody.pos.x, lastbody.pos.y);
            Console.Write("  ");

            switch (moveDir) 
            {
                case E_MoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case E_MoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -=2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;
            }
        
        }

        public void ChangeDir(E_MoveDir moveDir) 
        {
            if (moveDir == this.moveDir ||
                (nowLength >1 &&
                (this.moveDir == E_MoveDir.Left && moveDir == E_MoveDir.Right ||
                this.moveDir == E_MoveDir.Right && moveDir == E_MoveDir.Left ||
                this.moveDir == E_MoveDir.Up && moveDir == E_MoveDir.Down ||
                this.moveDir == E_MoveDir.Down && moveDir == E_MoveDir.Up)
                )
                
               ) 
            {
                return;
            }
            this.moveDir = moveDir;
        }
    }
}
