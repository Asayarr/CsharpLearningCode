using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    /// <summary>
    /// 场景类型枚举
    /// </summary>
    enum E_SceneType
    {
        /// <summary>
        /// 开始场景
        /// </summary>
        Start,
        /// <summary>
        /// 游戏场景
        /// </summary>
        Game,
        /// <summary>
        /// 结束场景
        /// </summary>
        End,
    }
    class Game
    {
        // 游戏窗口宽高
        public const int w = 80;
        public const int h = 20;
        //当前场景
        public static ISceneUpdate nowScene;

        // 构造函数
        public Game() 
        { 
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            
            ChangeScene(E_SceneType.Start);
        }

        // 游戏开始
        public void Start() 
        {
            // 游戏主循环
            while (true) 
            {
                if (nowScene != null) 
                {
                    nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType sceneType) 
        { 
            Console.Clear();

            switch (sceneType)
            {
                case E_SceneType.Start:
                    nowScene = new StartScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;

            }
        }
    }
}
