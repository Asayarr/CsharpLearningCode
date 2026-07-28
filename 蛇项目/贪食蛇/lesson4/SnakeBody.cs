using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    enum E_SnakeBodyType
    {
        /// <summary>
        /// 蛇头
        /// </summary>
        Head,
        /// <summary>
        /// 蛇身
        /// </summary>
        Body,
    }
    class SnakeBody: GameObject
    {
        private E_SnakeBodyType type;

        public SnakeBody(E_SnakeBodyType type, int x, int y) 
        { 
            this.type = type;
            this.pos = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_SnakeBodyType.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(type == E_SnakeBodyType.Head ? "●" : "○");
        }
    }
}
