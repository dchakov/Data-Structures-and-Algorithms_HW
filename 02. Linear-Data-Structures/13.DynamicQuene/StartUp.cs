namespace _13.DynamicQuene
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            DynamicQuene<int> quene = new DynamicQuene<int>();

            quene.Enquene(5);
            quene.Enquene(2);
            quene.Enquene(6);
            quene.Enquene(7);

            Console.WriteLine(string.Join(", ",quene));
            Console.WriteLine(quene.Dequene());
            Console.WriteLine(quene.Peek());
        }
    }
}
