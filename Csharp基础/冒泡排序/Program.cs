namespace 冒泡排序
{
    internal class Program
    {
        // 冒泡排序：相邻元素两两比较，大的往后移（升序）
        // 每一轮把当前未排序部分的最大值"冒泡"到末尾
        static void Main(string[] args)
        {
            Console.WriteLine("冒泡排序");

            int[] arr = new int[] { 8, 7, 1, 5, 6, 2, 4, 3, 9 };

            Console.WriteLine("排序前：");
            PrintArray(arr);

            #region 冒泡排序
            // 外层：共 n-1 轮
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // 内层：相邻比较，把最大的移到末尾
                // 每轮结束，末尾 i+1 个元素已排好序，无需再比较
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // 交换相邻元素
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            #endregion

            Console.WriteLine("排序后：");
            PrintArray(arr);
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
