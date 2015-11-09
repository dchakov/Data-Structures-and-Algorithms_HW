namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[,] matrix =
        {
            { "0", "0", "0", "x", "0", "x" },
            { "0", "x", "0", "x", "0", "x" },
            { "0", "*", "x", "0", "x", "0" },
            { "0", "x", "0", "0", "0", "0" },
            { "0", "0", "0", "x", "x", "0" },
            { "0", "0", "0", "x", "0", "x" }
        };
            Cell startCell = new Cell(2, 1, 0);
            TraverseWithBFS(matrix, startCell);
            MarkUnreachableCells(matrix, startCell);
            PrintMatrix(matrix);
        }

        private static void TraverseWithBFS(string[,] matrix, Cell startCell)
        {
            Queue<Cell> visitedCells = new Queue<Cell>();
            visitedCells.Enqueue(startCell);
            while (visitedCells.Count > 0)
            {
                Cell cell = visitedCells.Dequeue();
                int row = cell.Row;
                int col = cell.Col;
                int dist = cell.Distance;
                matrix[row, col] = dist.ToString();
                if (IsInMatrix(matrix, row + 1, col) && matrix[row + 1, col] == "0")
                {
                    visitedCells.Enqueue(new Cell(row + 1, col, dist + 1));
                }
                if (IsInMatrix(matrix, row, col + 1) && matrix[row, col + 1] == "0")
                {
                    visitedCells.Enqueue(new Cell(row, col + 1, dist + 1));
                }
                if (IsInMatrix(matrix, row - 1, col) && matrix[row - 1, col] == "0")
                {
                    visitedCells.Enqueue(new Cell(row - 1, col, dist + 1));
                }
                if (IsInMatrix(matrix, row, col - 1) && matrix[row, col - 1] == "0")
                {
                    visitedCells.Enqueue(new Cell(row, col - 1, dist + 1));
                }
            }
        }

        private static bool IsInMatrix(string[,] matrix, int row, int col)
        {
            bool isInMatrix = ((row < matrix.GetLength(0) && row >= 0) && (col < matrix.GetLength(1) && col >= 0));
            return isInMatrix;
        }

        private static void MarkUnreachableCells(string[,] matrix, Cell startCell)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "0")
                    {
                        matrix[row, col] = "u";
                    }
                }
            }
            matrix[startCell.Row, startCell.Col] = "*";

        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
