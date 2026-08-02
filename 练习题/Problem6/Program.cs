namespace Problem6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 4, 1, 5 };
            int[] result = new int[0];

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];
                bool isExist = false;

                for (int j = 0; j < result.Length; j++)
                {
                    if (result[j] == current)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    int[] newResult = new int[result.Length + 1];

                    for (int k = 0; k < result.Length; k++)
                    {
                        newResult[k] = result[k];
                    }

                    newResult[result.Length] = current;

                    result = newResult;
                }
            }

            foreach (int n in result)
                Console.Write(n + " ");
        }
    }
}
