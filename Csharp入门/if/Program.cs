using System.Security.AccessControl;

namespace if语句;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("请输入你的名字");
        string str = Console.ReadLine();
        if (str != null && str.Equals("张三", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("你好，管理员");

        }
        else
        {
            Console.WriteLine("你好，访客");
        }




    }
}
