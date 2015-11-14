namespace _01.BinaryPasswordCount
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            long counter = 1;
            foreach (var item in input)
            {
                if (item == '*')
                {
                    counter *= 2;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
