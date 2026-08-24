using System.Collections.Generic;

namespace 常用泛型数据结构类_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List");
            List<int> list = new List<int>();
            List<string> list2 = new List<string>();
            List<bool> list3 = new List<bool>();
            #region 增
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list2.Add("hello");

            List<string> listStr = new List<string>();
            listStr.Add("123");
            list2.AddRange(listStr);

            list.Insert(0, 999);
            Console.WriteLine(list[0]);
            #endregion

            #region 删
            list.Remove(1);

            list.RemoveAt(0);

            list.Clear();
            #endregion

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(2);

            #region 查
            Console.WriteLine(list[0]);

            if (list.Contains(1))
            {
                Console.WriteLine("存在元素1");
            }

            int index = list.IndexOf(2);
            Console.WriteLine(index);
            index = list.IndexOf(5);
            Console.WriteLine(index);

            index = list.LastIndexOf(2);
            Console.WriteLine(index);
            #endregion

            #region 改
            Console.WriteLine(list[0]);
            list[0] = 99;
            Console.WriteLine(list[0]);
            #endregion

            #region 遍历
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            Console.WriteLine("=====================");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine("=====================");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
