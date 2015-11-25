using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 40;
            int[] fibo = new int[100];

            fibo[0] = 1;
            fibo[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }
            Console.WriteLine(fibo[n]);
        }
    }
}
