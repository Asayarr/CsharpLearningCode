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
        Food food;

        int updateIndex = 0;

        public GameScene() 
        { 
            map = new Map();
            snake = new Snake(40, 10);
            food = new Food(snake);
        }
        public void Update()
        {

            if (updateIndex % 4444 == 0) 
            {
                map.Draw();
                food.Draw();

                snake.Move();
                snake.Draw();

                //检测是否撞墙
                if (snake.CheakEnd(map))
                {
                    Game.ChangeScene(E_SceneType.End);
                }

                //吃食物
                snake.CheakEatFood(food);

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
