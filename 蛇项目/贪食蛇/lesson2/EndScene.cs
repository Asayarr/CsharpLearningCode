using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    internal class EndScene : BeginOrEndBaseScene
    {
        public EndScene()
        {
            title = "游戏结束";
            choiceOne = "回到开始界面";
        }

        public override void OnConfirm()
        {
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Start);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
