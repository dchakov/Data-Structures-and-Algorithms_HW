namespace _11.LinkedList
{
    using System;

    //    Implement the data structure linked list.
    //Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
    //Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).

    public class StartUp
    {
        public static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            var item1 = new ListItem<int>(7);
            list.FirstElement = item1;
            item1.NextItem = new ListItem<int>(8);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
