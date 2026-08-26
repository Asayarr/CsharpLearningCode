namespace ref和out
{
    internal class Program
    {
        #region ref 参数
        // ref：按引用传递，函数内修改会反映到外部
        // 使用 ref 的变量必须先初始化
        static void AddOne(ref int num)
        {
            num += 1;
        }

        // 多个 ref 参数
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region out 参数
        // out：只出不进，函数必须给 out 参数赋值
        // 使用 out 的变量不需要先初始化
        static bool TryParseInt(string str, out int result)
        {
            result = 0;
            try
            {
                result = int.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // out 多个返回值
        static void GetMinMax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("ref 和 out");

            #region ref 的使用
            int num = 10;
            AddOne(ref num);        // 传引用
            Console.WriteLine(num); // 11（被修改）

            int x = 3, y = 5;
            Swap(ref x, ref y);
            Console.WriteLine(x);   // 5
            Console.WriteLine(y);   // 3
            #endregion

            #region out 的使用
            // out 常用于"尝试解析"模式，返回是否成功 + 结果
            if (TryParseInt("123", out int result))
            {
                Console.WriteLine("解析成功：" + result);
            }
            else
            {
                Console.WriteLine("解析失败");
            }

            // out 不用先声明变量，直接内联（C# 7.0+）
            if (TryParseInt("abc", out int r2))
            {
                Console.WriteLine(r2);
            }
            else
            {
                Console.WriteLine("解析失败");
            }

            int[] arr = { 3, 1, 4, 1, 5, 9, 2, 6 };
            GetMinMax(arr, out int min, out int max);
            Console.WriteLine("最小值：" + min);   // 1
            Console.WriteLine("最大值：" + max);   // 9
            #endregion

            #region ref vs out
            // ref：进可传值出可带值（双向），调用前必须初始化
            // out：只出不进（单向），调用前不用初始化，函数内必须赋值
            // 共同点：都是按引用传递，函数内修改影响外部
            #endregion
        }
    }
}
