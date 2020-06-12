using System;
using System.Collections.Generic;

namespace Software_Academy_Homework_13th_June_2020
{
    class Program
    {
        static int rows = 10;
        static int cols = 10;
        static byte[,] matrix =
            {
            { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 1, 1, 1, 1, 1, 0, 1 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 1, 0, 1, 0, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 1, 1, 1, 1, 0, 1, 0, 1, 0 }
        };

        static List<int> xPoint;
        static List<int> yPoint;

        static bool PathExist(int index)
        {
            if (index >= xPoint.Count)
            {
                return false;
            }
            else
            {
                int row = yPoint[index];
                int col = xPoint[index];
                if (row == rows - 1 && col == cols - 1)
                {
                    return true;
                }
                
                IfCanBePathAdd((row + 1), col); //up
              
                IfCanBePathAdd((row - 1), col); //down
             
                IfCanBePathAdd(row, (col - 1)); //left
                
                IfCanBePathAdd(row, (col + 1)); //right
            }
            return PathExist(index + 1);
        }
        static bool IfCanBePathAdd(int row, int col)
        {
            if (row >= 0 && row < rows &&
                col >= 0 && col < cols &&
                matrix[row, col] == 0)
            {
                matrix[row, col] = 1;
                xPoint.Add(col);
                yPoint.Add(row);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            xPoint = new List<int>();
            xPoint.Add(0);
            yPoint = new List<int>();
            yPoint.Add(0);
            Console.WriteLine(PathExist(0));

            Console.Write("Coordinates of x point: ");
            //Here we list the coordinates on the x point to the exit
            foreach (var item in xPoint)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.Write("Coordinates of y point: ");
            //Here we list the coordinates on the y point to the exit
            foreach (var item in yPoint)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
