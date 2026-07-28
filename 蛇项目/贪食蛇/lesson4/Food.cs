using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    class Food: GameObject
    {
        public Food(int x, int y) 
        { 
            pos = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("※");
        }
        // 生成随机位置 和 蛇的位置不重叠 
    }
}
