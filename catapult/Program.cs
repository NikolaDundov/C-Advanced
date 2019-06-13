using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> walls = new Queue<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int counter = 1;
            int currentWall = walls.Peek();

            while (counter <= n && walls.Count > 0)
            {
                Stack<int> rocks = new Stack<int>(Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (counter % 3 == 0)
                {
                    int wallToAdd = int.Parse(Console.ReadLine());
                    walls.Enqueue(wallToAdd);
                }

                while (true)
                {
                    if (rocks.Peek() > currentWall)
                    {
                        rocks.Push(rocks.Pop() - currentWall);
                        walls.Dequeue();
                        if (walls.Count > 0)
                        {
                            currentWall = walls.Peek();
                        }
                        else
                        {
                            break;
                        }
                    }

                    else if (rocks.Peek() < currentWall)
                    {
                        currentWall -= rocks.Pop();
                        if (rocks.Count == 0)
                        {
                            break;
                        }
                    }

                    else if (currentWall == rocks.Peek())
                    {
                        walls.Dequeue();
                        rocks.Pop();

                        if (walls.Count > 0)
                        {
                            currentWall = walls.Peek();
                        }

                        else
                        {
                            break;
                        }

                        if (rocks.Count == 0)
                        {
                            break;
                        }
                    }
                }

                counter++;
                if (walls.Count == 0)
                {
                    Console.WriteLine("Rocks left: {0}", string.Join(", ", rocks.ToArray()));
                }
            }

            if (walls.Count > 0)
            {
                List<int> fin = walls.ToList();
                fin[0] = currentWall;

                Console.WriteLine($"Walls left: {string.Join(", ", fin)}");
            }

        }
    }
}