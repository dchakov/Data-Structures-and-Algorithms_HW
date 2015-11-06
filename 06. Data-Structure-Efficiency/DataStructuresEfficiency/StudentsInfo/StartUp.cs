namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            SortedDictionary<string, SortedSet<Student>> courses =
                new SortedDictionary<string, SortedSet<Student>>();

            ReadStudentsInfoFromFile("../../students.txt", courses);
            foreach (var item in courses)
            {
                Console.WriteLine("{0} -> {1}", item.Key, string.Join(", ", item.Value));
            }
        }

        private static void ReadStudentsInfoFromFile(string filePath, SortedDictionary<string, SortedSet<Student>> courses)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != string.Empty && line != null)
                {
                    string[] data = line.Split('|');
                    string firstName = data[0].Trim();
                    string lastName = data[1].Trim();
                    string courseName = data[2].Trim();

                    if (courses.ContainsKey(courseName))
                    {
                        courses[courseName].Add(new Student(firstName, lastName));
                    }
                    else
                    {
                        courses[courseName] = new SortedSet<Student>();
                        courses[courseName].Add(new Student(firstName, lastName));
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
