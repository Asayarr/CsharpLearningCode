using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    class Food: GameObject
    {
        public Food(Snake snake) 
        {
            RandomPos(snake);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("※");
        }
        // 生成随机位置 和 蛇的位置不重叠 
        public void RandomPos(Snake snake)
        {
            Random r = new Random();
            int x = r.Next(2, Game.w / 2 - 1) * 2;
            int y = r.Next(1, Game.h - 4);
            pos = new Position(x, y);

            if (snake.CheckSamePos(pos))
            {
                RandomPos(snake);
            }
        }
    }
}
