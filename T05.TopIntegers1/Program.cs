using System;
using System.Linq;

namespace T05.TopIntegers1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] topIntegers = new int[arr.Length];
            int topIntegersIndex = 0; // Last index that we appended to topIntegers array

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int currentNum = arr[i];
                //By default for me it is TopInteger
                bool isTopInteger = true;
                //Nested loop that loops all indexes right to us to end
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    int nextNum = arr[j];
                    if (nextNum >= currentNum)
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    topIntegers[topIntegersIndex] = currentNum;
                    topIntegersIndex++;
                }
            }
            for (int i = 0; i <= topIntegersIndex; i++)
            {
                int currentTopInteger = topIntegers[i];
                Console.WriteLine($"{currentTopInteger} ");
            }
        }
    }
}
