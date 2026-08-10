using System.Collections;

namespace Arraylist
{
    class Test
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            #region 增
            array.Add(1);
            array.Add("123");
            array.Add(true);
            array.Add(new object());
            array.Add(new Test());
            array.Add(1);
            array.Add(true);

            ArrayList array2 = new ArrayList();
            array2.Add(123);
            //把array2中的元素添加到array中
            array.AddRange(array2);

            array.Insert(1, "插入的元素");
            Console.WriteLine(array[1]);
            #endregion

            #region 删
            //从头部删除
            array.Remove(1);

            array.RemoveAt(2);

            //array.Clear();
            #endregion

            #region 查
            Console.WriteLine(array[0]);

            //判断array中是否包含某个元素
            if (array.Contains("123"))
            {
                Console.WriteLine("包含123");
            }

            //正向查找元素位置
            //找到的返回值是元素的索引位置，找不到返回-1
            int index = array.IndexOf(true);
            Console.WriteLine(index);

            Console.WriteLine(array.IndexOf(false));

            //反向查找元素位置
            int lastIndex = array.LastIndexOf(true);
            Console.WriteLine(lastIndex);
            #endregion

            #region 改
            array[0] = "999";

            #endregion

            #region 遍历
            Console.WriteLine("-------------------");
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }

            //foreach遍历
            Console.WriteLine("-------------------");
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
            #endregion

        }
    }
}
