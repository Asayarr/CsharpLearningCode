namespace 拓展方法
{

    static class Tools 
    {
        public static void SpeakValue(this int value)
        { 
            Console.WriteLine("张三为int拓展的方法"+value);
        }

        public static void SpeakStringInfo(this string str, string str1, string str2) 
        { 
            Console.WriteLine("张三为string拓展的方法");
            Console.WriteLine("调用的方法" + str);
            Console.WriteLine("传的参数" + str1 + str2);
        }
        public static void Fun3 (this Test t) 
        { 
            Console.WriteLine("为test拓展的方法");
        }
    }

    class Test 
    {
        public int i = 10;
        public void Fun1()
        {
            Console.WriteLine("123");
        }

        public void Fun2()
        { 
            Console.WriteLine("456");
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("拓展方法");
            int i = 10;
            i.SpeakValue();

            string str = "000";
            str.SpeakStringInfo("王五","SB");

            Test t = new Test();
            t.Fun3();
        }
    }
}
