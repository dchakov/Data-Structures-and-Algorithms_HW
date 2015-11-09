namespace _12.QueenPuzzel
{
    using System;

    public class Program
    {
        static bool[] arrA = new bool[8];
        static bool[] arrB = new bool[15];
        static bool[] arrC = new bool[15];
        static int[] arrX = new int[8];
        static bool q = true;

        public static void Main()
        {
            for (int i = 1; i <= 8; i++)
            {
                arrA[i] = true;
            }

            for (int i = 2; i <= 16; i++)
            {
                arrB[i] = true;
            }

            for (int i = -7; i <= 7; i++)
            {
                arrC[i] = true;
            }

            FindQueensSolution(1, q);

        }

        private static void FindQueensSolution(int i, bool q)
        {
            int j = 0;

            do
            {
                j += 1;
                q = false;
                if (arrA[j] && arrB[i + j] && arrC[i - j])
                {
                    arrX[i] = j;
                    arrA[j] = false;
                    arrB[i + j] = false;
                    arrC[i - j] = false;
                    if (i < 8)
                    {
                        FindQueensSolution(i + 1, q);
                        if (!q)
                        {
                            arrA[j] = true;
                            arrB[i + j] = true;
                            arrC[i - j] = true;
                        }
                    }
                    else
                    {
                        q = true;
                        for (int m = 0; m < 8; m++)
                        {
                            Console.Write(arrX[i]);
                        }
                        Console.WriteLine();
                    }
                }
            } while (!q || j != 8);
        }
    }
}
