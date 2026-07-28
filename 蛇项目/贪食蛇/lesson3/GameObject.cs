using System;
using System.Collections.Generic;
using System.Text;

namespace 贪食蛇
{
    abstract class GameObject: IDraw
    {
        // 位置
        public Position pos;
        public abstract void Draw();
    }
}
