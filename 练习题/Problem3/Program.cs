namespace Porblem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("{0}×{1}={2,-2}  ", j, i, i * j);
                }
                Console.WriteLine();
            }
        }
    }
}
