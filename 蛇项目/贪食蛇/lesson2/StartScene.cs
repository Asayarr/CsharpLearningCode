using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    class StartScene : BeginOrEndBaseScene
    {
        public StartScene()
        {
            title = "贪食蛇";
            choiceOne = "开始游戏";
        }
        public override void OnConfirm() 
        {
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
        
          
    }
}
