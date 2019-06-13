using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new string[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string[] command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string action = command[0];
            string header = command[1];
            if (action == "hide")
            {
                int del = -1;

                for (int i = 0; i < matrix[0].Length; i++)
                {
                    if (matrix[0][i] == header)
                    {
                        del = i;
                        break;
                    }
                }

                for (int row = 0; row < n; row++)
                {
                    List<string> mid = new List<string>();

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (col != del)
                        {
                            mid.Add(matrix[row][col]);
                        }
                    }

                    matrix[row] = mid.ToArray();
                }

                for (int row = 0; row < n; row++)
                {
                    Console.WriteLine(string.Join(" | ", matrix[row]));
                }

            }
            else if (action == "sort")
            {
                int sort = -1;

                List<string> mid = new List<string>();

                for (int i = 0; i < matrix[0].Length; i++)
                {
                    if (matrix[0][i] == header)
                    {
                        sort = i;
                        break;
                    }
                }

                for (int row = 1; row < n; row++)
                {
                    mid.Add(matrix[row][sort]);
                }

                mid = mid.OrderBy(x => x).ToList();

                Console.WriteLine(string.Join(" | ", matrix[0]));

                for (int i = 0; i < mid.Count; i++)
                {
                    for (int row = 1; row < n; row++)
                    {
                        if (matrix[row][sort] == mid[i])
                        {
                            Console.WriteLine(string.Join(" | ", matrix[row]));
                            break;
                        }
                    }
                }
            }
            else if (action == "filter")
            {
                Console.WriteLine(string.Join(" | ", matrix[0]));

                int filter = -1;

                for (int i = 0; i < matrix[0].Length; i++)
                {
                    if (matrix[0][i] == command[1])
                    {
                        filter = i;
                        break;
                    }
                }

                for (int row = 1; row < n; row++)
                {
                    if (matrix[row][filter] == command[2])
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }
        }
    }
}