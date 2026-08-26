namespace 交错数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("交错数组");

            #region 交错数组的声明
            // 交错数组（锯齿数组）：数组的元素还是数组
            // 每个"行"的长度可以不同
            // 注意：声明时先指定行数，[] 里不写列数

            // 声明方式1：先声明行数，再逐个 new 行
            int[][] arr1 = new int[3][];
            arr1[0] = new int[2];          // 第0行：2个元素
            arr1[1] = new int[4];          // 第1行：4个元素
            arr1[2] = new int[3];          // 第2行：3个元素

            // 声明方式2：声明并初始化
            int[][] arr2 = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8, 9 }
            };

            // 声明方式3：最简写法
            int[][] arr3 =
            {
                new int[] { 1, 2 },
                new int[] { 3, 4, 5 }
            };
            #endregion

            #region 交错数组的访问
            // 通过 [行][列] 访问
            Console.WriteLine(arr2[0][0]);   // 1（第0行的第0个）
            Console.WriteLine(arr2[1][2]);   // 5（第1行的第2个）

            // 修改元素
            arr2[2][1] = 99;
            Console.WriteLine(arr2[2][1]);   // 99

            // 获取长度：Length 是行数，每行有自己的 Length
            Console.WriteLine(arr2.Length);        // 3（行数）
            Console.WriteLine(arr2[0].Length);     // 2（第0行元素个数）
            Console.WriteLine(arr2[1].Length);     // 3（第1行元素个数）
            #endregion

            #region 交错数组的遍历
            // 两层循环：外层遍历行，内层遍历当前行的元素
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write(arr2[i][j] + " ");
                }
                Console.WriteLine();
            }

            // foreach
            foreach (int[] row in arr2)
            {
                foreach (int item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
