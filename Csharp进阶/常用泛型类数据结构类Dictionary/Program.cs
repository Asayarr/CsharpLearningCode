namespace 常用泛型类数据结构类Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary");
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            #region 增
            dictionary.Add(1, "123");
            dictionary.Add(2, "222");
            dictionary.Add(3, "222");
            #endregion

            #region 删
            dictionary.Remove(1);
            dictionary.Remove(4); //不会报错

            dictionary.Clear();
            #endregion
            dictionary.Add(1, "123");
            dictionary.Add(2, "222");
            dictionary.Add(3, "222");
            #region 查
            Console.WriteLine(dictionary[2]);
            Console.WriteLine(dictionary[1]);

            if (dictionary.ContainsKey(1))
            {
                Console.WriteLine("存在key1");
            }

            if (dictionary.ContainsValue("222"))
            {
                Console.WriteLine("存在value222");
            }
            #endregion

            #region 改
            dictionary[3] = "555";
            Console.WriteLine(dictionary[3]);
            #endregion

            #region 遍历
            Console.WriteLine(dictionary.Count);

            Console.WriteLine("=========================");
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(dictionary[item]);
            }

            Console.WriteLine("=========================");
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========================");
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine("健" + item.Key + "；值" + item.Value);
            }
            #endregion
        }
    }
}
