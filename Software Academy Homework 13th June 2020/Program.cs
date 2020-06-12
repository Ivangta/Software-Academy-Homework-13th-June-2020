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

        static List<int> coordinateX;
        static List<int> coordinateY;

        static bool PathExist(int index)
        {
            if (index >= coordinateX.Count)
            {
                return false;
            }
            else
            {
                int row = coordinateY[index];
                int col = coordinateX[index];
                if (row == rows - 1 && col == cols - 1)
                {
                    return true;
                }
                //up
                IfCanBePathAdd((row + 1), col);
                //down
                IfCanBePathAdd((row - 1), col);
                //left
                IfCanBePathAdd(row, (col - 1));
                //right
                IfCanBePathAdd(row, (col + 1));
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
                coordinateX.Add(col);
                coordinateY.Add(row);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            coordinateX = new List<int>();
            coordinateX.Add(0);
            coordinateY = new List<int>();
            coordinateY.Add(0);
            Console.Write(PathExist(0));
        }
    }
}
