namespace 二维数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("二维数组");

            #region 二维数组的声明
            // 二维数组：两个下标的数组，类似表格（行、列）
            // 声明方式1：指定行数和列数
            int[,] arr1 = new int[2, 3];     // 2行3列，元素默认0

            // 声明方式2：声明并初始化
            int[,] arr2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            // 声明方式3：初始化列表推断大小
            int[,] arr3 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };  // 3行2列

            // 声明方式4：最简写法
            int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
            #endregion

            #region 二维数组的访问
            // 通过 [行, 列] 访问
            Console.WriteLine(arr2[0, 0]);   // 1（第0行第0列）
            Console.WriteLine(arr2[1, 2]);   // 6（第1行第2列）

            // 修改元素
            arr2[1, 1] = 99;
            Console.WriteLine(arr2[1, 1]);   // 99

            // 获取维度长度
            Console.WriteLine(arr2.GetLength(0));   // 2（行数）
            Console.WriteLine(arr2.GetLength(1));   // 3（列数）
            #endregion

            #region 二维数组的遍历
            // 方式1：两层 for 循环
            for (int i = 0; i < arr2.GetLength(0); i++)     // 外层：行
            {
                for (int j = 0; j < arr2.GetLength(1); j++) // 内层：列
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }

            // 方式2：foreach（按行优先顺序遍历所有元素）
            foreach (int item in arr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}
