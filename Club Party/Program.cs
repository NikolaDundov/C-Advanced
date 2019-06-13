using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();


            var hallsNames = new Queue<string>();
            var enteredGuests = new List<int>();

            for (int i = 0; i < line.Length; i++)
            {
                string currentInput = line[i];

                if (currentInput.Length == 1 && char.IsLetter(char.Parse(currentInput)))
                {
                    hallsNames.Enqueue(currentInput);
                }

                else
                {
                    int currentGroup = int.Parse(currentInput);

                    if (hallsNames.Count > 0 && (enteredGuests.Sum() + currentGroup) <= maxCapacity)
                    {
                        enteredGuests.Add(int.Parse(currentInput));
                    }

                    else if (hallsNames.Count > 0)
                    {
                        Console.WriteLine($"{hallsNames.Dequeue()} -> {string.Join(", ", enteredGuests)}");
                        enteredGuests.Clear();

                        if (hallsNames.Count > 0)
                        {
                            enteredGuests.Add(currentGroup);
                        }
                    }
                }
            }
        }
    }
}