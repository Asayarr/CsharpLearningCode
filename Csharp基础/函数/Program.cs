namespace 函数
{
    internal class Program
    {
        #region 函数定义
        // 函数（方法）是执行特定任务的代码块
        // 语法：访问修饰符 + 返回类型 + 函数名(参数列表) { 函数体 }

        // 无参无返回值
        static void SayHello()
        {
            Console.WriteLine("你好");
        }

        // 有参无返回值
        static void SayHi(string name)
        {
            Console.WriteLine("你好，" + name);
        }

        // 无参有返回值
        static int GetTen()
        {
            return 10;
        }

        // 有参有返回值
        static int Add(int a, int b)
        {
            return a + b;
        }

        // 返回字符串
        static string GetGreeting(string name)
        {
            return "欢迎你，" + name;
        }

        // 多个参数
        static void PrintInfo(string name, int age, string city)
        {
            Console.WriteLine("我叫{0}，今年{1}岁，来自{2}", name, age, city);
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("函数");

            #region 函数的调用
            SayHello();                    // 你好
            SayHi("李四");                  // 你好，李四

            int t = GetTen();
            Console.WriteLine(t);          // 10

            int sum = Add(3, 5);
            Console.WriteLine(sum);        // 8

            string g = GetGreeting("张三");
            Console.WriteLine(g);          // 欢迎你，张三

            PrintInfo("李四", 18, "杭州");
            #endregion

            #region 参数传值（值传递）
            // 值类型参数：传的是值的副本，函数内修改不影响外部
            int num = 10;
            ChangeNum(num);
            Console.WriteLine(num);        // 10（不受影响）

            static void ChangeNum(int x)
            {
                x = 999;
            }
            #endregion

            #region 参数传引用（引用类型参数）
            // 引用类型参数：传的是引用，函数内修改会影响外部
            int[] arr = { 1, 2, 3 };
            ChangeArr(arr);
            Console.WriteLine(arr[0]);     // 99（被修改）

            static void ChangeArr(int[] a)
            {
                a[0] = 99;
            }
            #endregion

            #region return 提前结束
            // return 不仅返回值，还会立即结束函数
            static int Abs(int n)
            {
                if (n < 0)
                {
                    return -n;   // 提前返回
                }
                return n;
            }
            Console.WriteLine(Abs(-5));    // 5
            Console.WriteLine(Abs(8));     // 8
            #endregion
        }
    }
}
