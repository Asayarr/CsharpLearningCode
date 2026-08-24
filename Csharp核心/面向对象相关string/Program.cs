namespace 面向对象相关string
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("string");

            #region 知识点一 字符串指定位置的获取
            string str = "Hello, World!";
            Console.WriteLine(str[0]); //与python的索引类似，获取指定位置的字符
            //转为char数组
            char[] chars = str.ToCharArray();
            Console.WriteLine(chars[1]);

            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }
            #endregion

            #region 知识点二 字符串拼接
            str = string.Format("{0}{1}",1,3333); //类似python的f-string
            Console.WriteLine(str); //13333
            #endregion

            #region 知识点三 正向查找字符的位置
            str = "Hello, World!";
            int index = str.IndexOf('o'); // 查找字符 'o' 的位置
            Console.WriteLine(index); // 输出 4
            index = str.IndexOf("S"); // 查找子字符串 "S" 的位置
            Console.WriteLine(index); // 输出 -1 (未找到)
            #endregion

            #region 知识点四 反向查找字符串位置
            str = "我是一个字符串，我是一个字符串";
            index = str.LastIndexOf("字符串"); // 查找最后一个子字符串 "字符串" 的位置
            Console.WriteLine(index); // 输出 12
            #endregion

            #region 知识点五 移除指定位置后的字符
            str = "我是张三张三";
            str = str.Remove(4); // 移除索引 4 及之后的所有字符
            Console.WriteLine(str); // 输出 "我是张三"

            str = str.Remove(2, 2); // 从索引 2 开始移除 2 个字符
            Console.WriteLine(str); // 输出 "我是"
            #endregion

            #region 知识点六 替换字符串
            str = "我是张三张三";
            str = str.Replace("张三", "李四"); // 将 "张三" 替换为 "李四"
            Console.WriteLine(str); // 输出 "我是李四李四"
            #endregion

            #region 知识点七 大小写转换
            str = "slkafjlkjflsajlf";
            str = str.ToUpper();
            Console.WriteLine(str);

            str = str.ToLower();
            Console.WriteLine(str);
            #endregion

            #region 知识点八 字符串截取
            str = "Hello, World!";
            str = str.Substring(7); // 从索引 7 开始截取到字符串末尾
            Console.WriteLine(str); // 输出 "World!"

            str = "Hello, World!";
            str = str.Substring(1, 5); // 从索引 1 开始截取 5 个字符
            Console.WriteLine(str); // 输出 "ello,"
                                    //不能out of range
            #endregion

            #region 知识点九 字符串切割
            str = "1,2,3,4,5,6,7,8,9";
            string[] strs = str.Split(','); // 以逗号为分隔符切割字符串
            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
            #endregion
        }
    }
}
