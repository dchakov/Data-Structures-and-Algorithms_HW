namespace _12.DynamicStack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CustomStack<int> numbers = new CustomStack<int>();

            numbers.Push(5);
            numbers.Push(6);
            numbers.Push(2);
            numbers.Push(7);
            numbers.Push(8);

            Console.WriteLine(string.Join(", ",numbers));
            Console.WriteLine(numbers.Pop());
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
