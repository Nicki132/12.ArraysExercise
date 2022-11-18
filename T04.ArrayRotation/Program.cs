using System;
using System.Linq;

namespace T04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotationsCount = int.Parse(Console.ReadLine());
            for (int rot = 1; rot <= rotationsCount; rot++)
            {
                int firstEl = arr[0];  // not to lose first element
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    // arr[0] = arr[1]
                    // arr[3] = arr[4]
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = firstEl;
            }
            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
