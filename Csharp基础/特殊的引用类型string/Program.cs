namespace 特殊的引用类型string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("特殊的引用类型 string");

            #region string 是引用类型
            // string 本质是引用类型（存在堆上），但用起来像值类型
            string str1 = "hello";
            string str2 = str1;       // 复制的是引用
            Console.WriteLine(str1 == str2);   // True（内容相等）

            str2 = "world";           // str2 指向新的字符串对象
            Console.WriteLine(str1);  // hello（str1 不受影响）
            #endregion

            #region string 的不可变性
            // 字符串内容不可变！任何"修改"都是创建新对象
            string s = "abc";
            s = s + "def";            // 实际是创建了新对象"abcdef"，s 指向它
            Console.WriteLine(s);

            string s1 = "hello";
            string s2 = s1;
            // 没有任何方法可以修改 s1 指向的对象内容
            // s1[0] = 'H';  // 编译错误：字符串不能索引赋值
            #endregion

            #region 字符串驻留（常量池）
            // 相同内容的字符串常量指向同一对象（编译期确定）
            string a = "hello";
            string b = "hello";
            Console.WriteLine(ReferenceEquals(a, b));   // True（同一引用）

            // 运行时拼接的不在常量池
            string c = "hel" + "lo";          // 编译期可确定，仍指向常量池
            string d = "hel";
            string e = d + "lo";              // 运行时拼接，新对象
            Console.WriteLine(ReferenceEquals(a, e));   // False
            #endregion

            #region 比较：== 和 Equals
            // 字符串的 == 比较的是内容（编译器特殊处理），不是引用
            string x = "abc";
            string y = "ab" + "c";
            Console.WriteLine(x == y);                 // True（内容相等）
            Console.WriteLine(x.Equals(y));            // True（内容相等）

            // 引用比较才用 ReferenceEquals
            Console.WriteLine(ReferenceEquals(x, y));  // True（常量池同一个）

            // 忽略大小写比较
            string m = "Hello";
            string n = "hello";
            Console.WriteLine(m.Equals(n, StringComparison.OrdinalIgnoreCase));  // True
            #endregion

            #region string 与 char 数组互转
            string str = "hello";
            char[] chars = str.ToCharArray();   // string → char[]
            Console.WriteLine(chars[0]);        // 'h'

            string newStr = new string(chars);  // char[] → string
            Console.WriteLine(newStr);          // hello
            #endregion
        }
    }
}
