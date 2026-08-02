using System.Diagnostics.Tracing;

namespace Problem5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine() ?? "";
            str = str.ToLower();
            string[] parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int words = parts.Length;
            int[] counts = new int[26];
            int letters = 0;
            int maxCount = 0;
            int maxIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    char c = str[i];
                    int index = c - 'a';
                    counts[index]++;
                }
            }
            for (int i = 0;i < counts.Length; i++)
            {
                letters += counts[i];
                if (counts[i] > maxCount)
                {
                    maxCount = counts[i];
                    maxIndex = i;
                }
            }
            char answer = (char)(maxIndex + 'a');
            Console.WriteLine($"字母数:{letters}");
            Console.WriteLine($"单词数: {words}");
            Console.WriteLine($"出现次数最多的字母: {answer}");

        }
    }
}
