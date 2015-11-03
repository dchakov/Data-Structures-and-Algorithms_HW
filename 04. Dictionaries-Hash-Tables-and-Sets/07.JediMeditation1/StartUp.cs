namespace _07.JediMeditation1
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var master = new HashSet<string>();
            var knidht = new HashSet<string>();
            var padawan = new HashSet<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                var currentJedy = arr[i][0].ToString();
                if (currentJedy == "m")
                {
                    master.Add(arr[i]);
                }
                else if (currentJedy == "k")
                {
                    knidht.Add(arr[i]);
                }
                else
                {
                    padawan.Add(arr[i]);
                }
            }
            var result = string.Join(" ", master) + " " + string.Join(" ", knidht) + " " + string.Join(" ", padawan);
            Console.Write(result);
        }
    }
}
