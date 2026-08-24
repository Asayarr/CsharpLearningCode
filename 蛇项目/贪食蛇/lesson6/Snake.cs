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
    class Snake : IDraw
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
        
        //移动
        public void Move()
        {
            SnakeBody lastbody = bodys[nowLength - 1];
            Console.SetCursorPosition(lastbody.pos.x, lastbody.pos.y);
            Console.Write("  ");

            //身体移动逻辑
            for (int i = nowLength - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }

            switch (moveDir)
            {
                case E_MoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case E_MoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;
            }

        }

        //改变方向
        public void ChangeDir(E_MoveDir moveDir)
        {
            if (moveDir == this.moveDir ||
                (nowLength > 1 &&
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

        //碰墙撞身体结束逻辑
        public bool CheckEnd(Map map)
        {
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (bodys[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }

            for (int i = 1; i < nowLength; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }
            return false;
        }

        //吃食物相关
        public bool CheckSamePos(Position p)
        {
            for (int i = 0; i < nowLength; i++)
            {
                if (bodys[i].pos == p)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckEatFood(Food food)
        {
            if (bodys[0].pos == food.pos)
            {
                food.RandomPos(this);

                AddBody();
            }
        }

        //长身体
        private void AddBody()
        {
            SnakeBody frontBody = bodys[nowLength - 1];
            bodys[nowLength] = new SnakeBody(E_SnakeBodyType.Body, frontBody.pos.x, frontBody.pos.y);

            ++nowLength;
        }
    }
}
