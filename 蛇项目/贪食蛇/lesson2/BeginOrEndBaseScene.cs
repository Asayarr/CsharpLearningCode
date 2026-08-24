using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    abstract class BeginOrEndBaseScene : ISceneUpdate
    {
        protected int nowSelIndex = 0;
        protected string title;
        protected string choiceOne;

        public abstract void OnConfirm();

        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // 绘制标题
            Console.SetCursorPosition(Game.w / 2 - title.Length, 5);
            Console.Write(title);
            // 绘制选项
            Console.SetCursorPosition(Game.w / 2 - choiceOne.Length, 8);
            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(choiceOne);
            Console.SetCursorPosition(Game.w / 2 - 4, 10);
            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("结束游戏");
            // 处理输入
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    --nowSelIndex;
                    if (nowSelIndex < 0)
                    {
                        nowSelIndex = 0;
                    }
                    break;
                case ConsoleKey.DownArrow or ConsoleKey.S: 
                    ++nowSelIndex;
                    if (nowSelIndex > 1)
                    {
                        nowSelIndex = 1;
                    }
                    break;
                case ConsoleKey.Enter or ConsoleKey.J:
                    OnConfirm();
                    break;


            }

                
        }
    }
}
