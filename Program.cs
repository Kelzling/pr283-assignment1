﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static int maxNum = 4;
        static Sudoku s;

        static void Main(string[] args)
        {
            s = new Sudoku(2, 2, maxNum);

            int[] testValues = {
                2, 3, 1, 4,
                0, 0, 3, 0,
                3, 0, 4, 0,
                0, 1, 2, 3
            };
            int[] testValues2 = {
                1, 0, 0, 0,
                0, 3, 0, 4,
                0, 0, 0, 0,
                4, 0, 2, 0
            };
            s.Set(testValues);

            // TestValidValuesRetriever();
            // TestValidityChecker();
            string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(binDirectory).Parent.Parent.FullName;
            string basePath = Path.Combine(projectDirectory, "Levels");

            var sudoku = Loader.LoadLevel($@"{basePath}\test1.txt");
        }

        static void TestValidValuesRetriever()
        {
            int[] testCells = { 9, 2, 11, 4 };

            foreach (int cell in testCells)
            {
                Console.WriteLine($"Valid values for {cell} are: ");
                int[] validValues = s.GetValidValuesForCell(cell);
                foreach (int value in validValues)
                {
                    Console.Write($" {value} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void TestValidityChecker()
        {
            for (int i = 0; i < maxNum; i++)
            {
                Console.WriteLine($"Col {i}: {s.ColumnValid(i)}");
                Console.WriteLine($"Row {i}: {s.RowValid(i)}");
                Console.WriteLine($"Square {i}: {s.SquareValid(i)} ");
                Console.WriteLine(" ");
            }
            Console.ReadKey();
        }
    }
}
