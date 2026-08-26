namespace 函数重载
{
    internal class Program
    {
        #region 函数重载
        // 重载：函数名相同，参数列表不同（个数、类型、顺序不同）
        // 编译器根据实参自动匹配对应版本

        static int Add(int a, int b)
        {
            Console.WriteLine("两个 int");
            return a + b;
        }

        static int Add(int a, int b, int c)
        {
            Console.WriteLine("三个 int");
            return a + b + c;
        }

        static float Add(float a, float b)
        {
            Console.WriteLine("两个 float");
            return a + b;
        }

        static string Add(string a, string b)
        {
            Console.WriteLine("两个 string");
            return a + b;
        }

        // 重载只看参数列表，和返回类型无关
        // 不能只改返回类型来重载（编译错误）
        // static double Add(int a, int b) { }   // 错误：和第一个冲突
        #endregion

        #region 重载 + 可选参数/params
        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        static void Print(string msg, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(msg);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("函数重载");

            #region 重载的调用
            int r1 = Add(1, 2);          // 匹配两个 int
            Console.WriteLine(r1);       // 3

            int r2 = Add(1, 2, 3);       // 匹配三个 int
            Console.WriteLine(r2);       // 6

            float r3 = Add(1.5f, 2.5f);  // 匹配两个 float
            Console.WriteLine(r3);       // 4

            string r4 = Add("hello", "world");   // 匹配两个 string
            Console.WriteLine(r4);       // helloworld
            #endregion

            #region 重载的应用
            Print("一次");
            Print("三次", 3);
            #endregion
        }
    }
}
