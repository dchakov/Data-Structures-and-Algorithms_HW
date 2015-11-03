namespace _06.PhoneBookInfo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

            ReadPhoneBook("../../phones.txt", phoneBook);
            ReadCommand("../../commands.txt", phoneBook);
        }

        private static void ReadPhoneBook(string fileName, Dictionary<string, List<string>> phoneBook)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (line != String.Empty && line != null)
                {
                    var currentEntry = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = currentEntry[0].Trim();
                    string town = currentEntry[1].Trim();
                    string phoneNumber = currentEntry[2].Trim();
                    if (phoneBook.ContainsKey(name))
                    {
                        phoneBook[name].Add(town + " | " + phoneNumber);
                    }
                    else
                    {
                        phoneBook[name] = new List<string>();
                        phoneBook[name].Add(town + " | " + phoneNumber);
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static void ReadCommand(string fileName, Dictionary<string, List<string>> phoneBook)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (line != String.Empty && line != null)
                {
                    ProcessCommand(line, phoneBook);
                    line = reader.ReadLine();
                }
            }
        }

        private static void ProcessCommand(string commandText, Dictionary<string, List<string>> phoneBook)
        {
            string[] command = commandText.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (command.Length)
            {
                case 2:
                    {
                        Console.WriteLine("Search by Name:");
                        FindByName(command[1], phoneBook);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Search by Name and Town:");
                        FindByTown(command[1], command[2], phoneBook);
                        break;
                    }
                default: break;
            }
        }

        private static void FindByTown(string name, string town, Dictionary<string, List<string>> phoneBook)
        {
            foreach (var pair in phoneBook)
            {
                if (pair.Key.Contains(name))
                {
                    foreach (var item in pair.Value)
                    {
                        if (item.Contains(town))
                        {
                            Console.WriteLine("{0} -> {1}", pair.Key, string.Join(", ", pair.Value));
                        }
                    }
                }
            }
        }

        private static void FindByName(string name, Dictionary<string, List<string>> phoneBook)
        {
            foreach (var pair in phoneBook)
            {
                if (pair.Key.Contains(name))
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, string.Join(", ", pair.Value));
                }
            }
        }


    }
}
