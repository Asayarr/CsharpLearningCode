namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int goal = r.Next(1, 101);
            Console.WriteLine("请输入猜测的数(1~100)");
            int guesses = 0;
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    int i = int.Parse(str);
                    guesses++;
                    if (i < 1 || i > 100)
                    {
                        Console.WriteLine("请输入1~100之间的整数");
                    }
                    else if(i< goal)
                    {
                        Console.WriteLine("小了");
                    }
                    else if (i> goal)
                    {
                        Console.WriteLine("大了");
                    }
                    else
                    {
                        Console.WriteLine("猜对了,用了{0}次",guesses);
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("请输入合法数字");
                }
            }



        }
    }
}
