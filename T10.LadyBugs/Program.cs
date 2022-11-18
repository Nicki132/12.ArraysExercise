using System;
using System.Linq;

namespace T10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Field
            //Array of integers
            //0 -> no ladybug
            //1 -> ladybug
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugsIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // initialized the field
            int[] field = new int[fieldSize];
            for (int index = 0; index < fieldSize; index++)
            {
                if (ladyBugsIndexes.Contains(index))
                {
                    // if index is present in ladyBugsIndexes then there is a ladyBug
                    field[index] = 0;
                }
            }
            //string command = Console.ReadLine();
            //while (command != "end")
            //{
            //    command = Console.ReadLine();
            //}
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int initialIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLength = int.Parse(cmdArgs[2]);
                //First always check if the index is valid!
                if (initialIndex < 0 || initialIndex >= field.Length)
                {
                    continue;
                }
                //We have a valid index, then we check if there is a ladybug
                //If there isn`t ladybug
                if (field[initialIndex] == 0)
                {
                    continue;
                }
                //Ladybugs start flying
                //Initial index set to 0, because there is no ladybug anymore
                field[initialIndex] = 0;
                // Calculate where the next index is
                int nextIndex = initialIndex + flyLength;
                while (true)
                {
                    if (direction == "right")
                    {
                        nextIndex += flyLength;
                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLength;
                    }
                    if (nextIndex < 0 || nextIndex >= field.Length)
                    {
                        //Next index is invalid (outside of the field)
                        // The ladybug is gone in to the void
                        break;
                    }
                    if (field[nextIndex] == 0)
                    {
                        //The next index is empty and valid to land
                        //Then we land the ladybug there
                        break;
                    }
                }
                if (nextIndex >= 0 && nextIndex < field.Length)
                {
                    //The next calculated index is valid!
                    //Then we land the ladybug there
                    field[nextIndex] = 1;
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
