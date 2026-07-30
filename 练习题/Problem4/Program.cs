namespace Problem4
{
    internal class Program
    {
        static string FilterBadWords(string text, params string[] badWords)
        {
            for (int i = 0; i < badWords.Length; i++)
            {
                text = text.Replace(badWords[i], "**", StringComparison.OrdinalIgnoreCase);
            }
            return text;
        }

        static void Main(string[] args)
        {
            string[] badWords = ["sb", "cnm", "猪"];
            Console.WriteLine("请输入一段文字");
            string text = Console.ReadLine();
            Console.WriteLine(FilterBadWords(text, badWords));
        }
    }
}

