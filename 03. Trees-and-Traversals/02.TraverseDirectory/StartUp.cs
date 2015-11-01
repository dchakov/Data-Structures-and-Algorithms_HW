namespace _02.TraverseDirectory
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            string directoryPath = "C:\\WINDOWS";
            TraverseDir(new DirectoryInfo(directoryPath));
        }

        private static void TraverseDir(DirectoryInfo dir)
        {
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    if (file.FullName.EndsWith(".exe"))
                    {
                        Console.WriteLine(file.FullName);
                    }
                }

                DirectoryInfo[] children = dir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    TraverseDir(child);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
