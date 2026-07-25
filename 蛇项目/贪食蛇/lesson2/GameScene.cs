using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    class GameScene :ISceneUpdate
    {
        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("游戏场景");
        }
    }
}
