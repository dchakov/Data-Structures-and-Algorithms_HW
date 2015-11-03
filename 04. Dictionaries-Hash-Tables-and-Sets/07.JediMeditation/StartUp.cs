namespace _07.JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            string[] arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currentJedy = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                currentJedy = arr[i][0].ToString();
                if (dictionary.ContainsKey(currentJedy))
                {
                    dictionary[currentJedy].Add(arr[i]);
                }
                else
                {
                    dictionary[currentJedy] = new List<string>();
                    dictionary[currentJedy].Add(arr[i]);
                }
            }
            var result = string.Join(" ", dictionary["m"]) + " " + string.Join(" ", dictionary["k"]) + " " + string.Join(" ", dictionary["p"]);
            Console.Write(result);
        }
    }
}
