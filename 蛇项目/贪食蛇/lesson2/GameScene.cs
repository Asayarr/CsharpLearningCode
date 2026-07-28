using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace 贪食蛇
{
    class GameScene :ISceneUpdate
    {
        Map map;
        Snake snake;

        int updateIndex = 0;

        public GameScene() 
        { 
            map = new Map();
            snake = new Snake(40, 10);
        }
        public void Update()
        {

            if (updateIndex % 4444 == 0) 
            {
                map.Draw();

                snake.Move();
                snake.Draw();

                updateIndex = 0;

            }
            ++updateIndex;

            //判断键盘输入
            if (Console.KeyAvailable) 
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_MoveDir.Right);
                        break;

                }
            } 

            



        }
    }
}
